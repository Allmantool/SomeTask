using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace XMLTest {
    [TestClass]
    public class UnitTetsBugs {
        /// <summary>
        /// Get group of bug classification
        /// </summary>
        [TestMethod]
        public void TestBugClassification() {
            string _contentRootPath = @"C:\Users\Pavel_Chyzhykau\Desktop\qa-interviewer-master-3bc47169d3c8c9c7699759a26b385d2edd1bf9ac\QAInterviewTestApp\";
            //Directory.GetCurrentDirectory();
            const string pathToBugStorage = @"Storage\BugStorage.xml";

            var fullPathToBugStorage = Path.Combine(_contentRootPath, pathToBugStorage);// @"j:\GitHub\SomeTask\XMLTest\XMLBugs.xml";


            //Is that exist?
            Assert.IsTrue(System.IO.File.Exists(fullPathToBugStorage));

            var xRoot = XElement.Load(fullPathToBugStorage);

            //render info to output window
            Action<IList<BugDto>, string> renderToConsole = (data, filedName) =>
                Debug.WriteLine(
                    $"Group by element: <{filedName}>"
                    + Environment.NewLine
                    + string.Join(Environment.NewLine, data)
                    + Environment.NewLine
                );


            //anomymous function for the sake of brevity
            // 1) parse Xml nodes to dto objects
            // 2) group and order result in appropriate way
            Func<string, bool, IList<BugDto>> linqGroupFunc = (field, renderMode) => {
                var result = xRoot.Elements().Select(x => new {
                    Type = x.Elements().FirstOrDefault(el => el.Name.LocalName == field)?.Value,
                    Description = x.Elements().FirstOrDefault(el => el.Name.LocalName == "bugName")?.Value,
                    Location = x.Elements().FirstOrDefault(el => el.Name.LocalName == "page")?.Value,
                    Complexity = x.Elements().FirstOrDefault(el => el.Name.LocalName == "difficultyLevel")?.Value
                }).GroupBy(item => item.Type).Select((gr, indx) => new BugDto() {
                    Index = indx,
                    Type = gr.Key,
                    Count = gr.Count(),
                    Descriptions = gr.Select(y => y.Description).OrderBy(y => y).ToList()
                })
                .OrderBy(r => r.Count)
                .ToList();

                //render to output or not
                if (renderMode) {
                    renderToConsole.Invoke(result, field);
                }

                return result;
            };


            //expected count type of error
            Assert.AreEqual(linqGroupFunc.Invoke("classification", true).Count, 5);

            //the expected number of difficulty leves
            Assert.AreEqual(linqGroupFunc.Invoke("difficultyLevel", false).Count, 3);

            //the expected number of destination pages
            Assert.AreEqual(linqGroupFunc.Invoke("page", false).Count, 2);

            //the expected number of destination set
            Assert.AreEqual(linqGroupFunc.Invoke("set", false).Count, 1);

            //the expected number of destination set
            Assert.AreEqual(linqGroupFunc.Invoke("bugName", false).Count, 34);
        }
    }

    /// <summary>
    /// intermediate class (xml => csharp)
    /// </summary>
    internal class BugDto {
        public int Index { private get; set; }
        public string Type { private get; set; }
        public string Location { get; set; }
        public string Complexity { get; set; }
        public IEnumerable<string> Descriptions { private get; set; }
        public int Count { get; set; }

        public override string ToString() {
            var str = $"{Index,2}" +
                      $"{Type,60}" +
                      $"{Count,7}";

            var description = string.Join(Environment.NewLine, Descriptions.Select((x, indx) => $"- {x}"));

            return str + Environment.NewLine + description;
        }
    }
}