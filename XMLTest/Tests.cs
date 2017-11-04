using System;
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
            const string _pathToBugStorage = "Storage\\BugStorage.xml";

            var fullPathToBugStorage = Path.Combine(_contentRootPath, _pathToBugStorage);

            //Is that exist?
            Assert.IsTrue(File.Exists(fullPathToBugStorage));


            var _xElement = XElement.Load(fullPathToBugStorage);

            //render info to debug window
            Action<IList<GroupDTO>, string> renderToConsole = (data, filedName) =>
                Debug.WriteLine(
                    $"Group by element: <{filedName}>"
                    + Environment.NewLine
                    + string.Join(Environment.NewLine, data)
                    + Environment.NewLine
                );


            //anomymous function for the sake of brevity
            Func<string, bool, IList<GroupDTO>> linqGroupFunc = (field, isDescribe) => {
                var result = _xElement.Elements()
                 .Select(el => el.Elements()
                        .Where(i => i.Name.LocalName == field || (isDescribe == true && i.Name.LocalName == "bugName")) // return 34 objecs(list) with two item
                        .Select(x => new { GrName = x.Name.LocalName, Value = x.Value }));
                //.FirstOrDefault().Value)
                //.GroupBy(item => new { item.GrName }));
                // .OrderBy(gr => gr.Count())
                // .Select((gr, i) => new GroupDTO {
                //     Index = i,
                //     GroupName = gr.Key,
                //     ElementCount = gr.Count()
                // })
                // .ToList();

                //renderToConsole.Invoke(result, field);

                return new List<GroupDTO>();// result;
            };


            //expected count type of error
            Assert.AreEqual(linqGroupFunc.Invoke("classification", true).Count(), 5);

            //the expected number of difficulty leves
            Assert.AreEqual(linqGroupFunc.Invoke("difficultyLevel", false).Count(), 3);

            //the expected number of destination pages
            Assert.AreEqual(linqGroupFunc.Invoke("page", false).Count(), 2);

            //the expected number of destination set
            Assert.AreEqual(linqGroupFunc.Invoke("set", false).Count(), 1);

            //the expected number of destination set
            Assert.AreEqual(linqGroupFunc.Invoke("bugName", false).Count(), 34);
        }

        [TestMethod]
        public void TestArrToLinear() {
            var twoDimArr = new string[5, 2] {
                {"","" },
                {"","" },
                {"","" },
                {"","" },
                {"","" }
            };

            string[,] Tablero = new string[3, 3] {
                {"a","b","c"},
                {"d","e","f"},
                {"g","h","i"}
            };
        }
    }

    internal class GroupDTO {
        public int Index { get; set; }
        public string GroupName { get; set; }
        public IList<string> BugsNames { get; set; }
        public int ElementCount { get; set; }

        public override string ToString() {
            var str = $"{Index,2}" +
                      $"{GroupName,50}" +
                      $"{ElementCount,7}";

            return str;
        }
    }
}


//<? xml version="1.0" encoding="utf-8" ?>
//<bugs xmlns = "main.bugs.storage" >
//  < !--Login Page bugs -->
//  <bug>
//    <!--Bug 2.1-->
//    <bugName>PasswordLableWidth</bugName>
//    <page>login</page>
//    <classification>css</classification>
//    <refersElementId>password-lable-bug</refersElementId>
//    <cssRule>width</cssRule>
//    <cssValue>103px</cssValue>
//    <difficultyLevel>medium</difficultyLevel>
//    <set>global</set>
//  </bug>
//  <bug>
//    <!--Bug 2.2-->
//    <bugName>LablesBottomAligned</bugName>
//    <page>login</page>
//    <classification>css</classification>
//    <refersElementId>lables-container-bug</refersElementId>
//    <cssRule>vertical-align</cssRule>
//    <cssValue>bottom</cssValue>
//    <difficultyLevel>low</difficultyLevel>
//    <set>global</set>
//  </bug>
//  <bug>
//    <!--Bug 2.3-->
//    <bugName>LoginNotRequired</bugName>
//    <page>login</page>
//    <classification>validation</classification>
//    <refersElementId>login-input-bug</refersElementId>
//    <difficultyLevel>low</difficultyLevel>
//    <set>global</set>
//  </bug>
//  <bug>
//    <!--Bug 2.4-->
//    <bugName>LoginAcceptsSpecialSymbols</bugName>
//    <page>login</page>
//    <classification>validation</classification>
//    <refersElementId>login-field-bug</refersElementId>
//    <difficultyLevel>low</difficultyLevel>
//    <set>global</set>
//  </bug>
//  <bug>
//    <!--Bug 2.5-->
//    <bugName>ButtonsNotAlligned</bugName>
//    <page>login</page>
//    <classification>css</classification>
//    <refersElementId>buttons-container-bug</refersElementId>
//    <cssRule>margin</cssRule>
//    <cssValue>100px</cssValue>
//    <difficultyLevel>medium</difficultyLevel>
//    <set>global</set>
//  </bug>
//  <bug>
//    <!--Bug 2.6-->
//    <bugName>CancelButtotTextIsSentenceCase</bugName>
//    <page>login</page>
//    <classification>content</classification>
//    <refersElementId>cancel-button-bug</refersElementId>
//    <contentValue>Cancel</contentValue>
//    <difficultyLevel>medium</difficultyLevel>
//    <set>global</set>
//  </bug>
//  <bug>
//    <!--Bug 2.7-->
//    <bugName>PasswordFieldIsNotCleared</bugName>
//    <page>login</page>
//    <classification>logic</classification>
//    <refersElementId>password-field-bug</refersElementId>
//    <difficultyLevel>low</difficultyLevel>
//    <set>global</set>
//  </bug>
//  <bug>
//    <!--Bug 2.8-->
//    <bugName>NoRedFrame</bugName>
//    <page>login</page>
//    <classification>css</classification>
//    <refersElementId>login-field-bug | password-field-bug</refersElementId>
//    <cssRule>border-style</cssRule>
//    <cssValue>none</cssValue>
//    <difficultyLevel>low</difficultyLevel>
//    <set>global</set>
//  </bug>
//  <bug>
//    <!--Bug 2.9-->
//    <bugName>ErrorMessageInTheBottomPage</bugName>
//    <page>login</page>
//    <classification>css</classification>
//    <refersElementId>error-messages-container-bug</refersElementId>
//    <cssRule>margin</cssRule>
//    <cssValue>100px</cssValue>
//    <difficultyLevel>medium</difficultyLevel>
//    <set>global</set>
//  </bug>
//  <bug>
//    <!--Bug 2.10-->
//    <bugName>ErrorMessageIncorrectContent</bugName>
//    <page>login</page>
//    <classification>content</classification>
//    <refersElementId>error-messages-container-bug</refersElementId>
//    <contentValue>Login or Password is incorect.</contentValue>
//    <difficultyLevel>medium</difficultyLevel>
//    <set>global</set>
//  </bug>

//  <!-- Home Page bugs -->
//  <bug>
//    <!--Bug 3.1-->
//    <bugName>SignInContentBug</bugName>
//    <page>home</page>
//    <classification>content</classification>
//    <refersElementId>signIn-button-bug</refersElementId>
//    <contentValue>Sign Out</contentValue>
//    <difficultyLevel>high</difficultyLevel>
//    <set>global</set>
//  </bug>
//  <bug>
//    <!--Bug 3.2-->
//    <bugName>DateInIncorrectFormat</bugName>
//    <page>home</page>
//    <classification>visualization</classification>
//    <refersElementId>date-time-container-bug</refersElementId>
//    <difficultyLevel>low</difficultyLevel>
//    <set>global</set>
//  </bug>
//  <bug>
//    <!--Bug 3.3-->
//    <bugName>TimeInIncorrectFormat</bugName>
//    <page>home</page>
//    <classification>visualization</classification>
//    <refersElementId>date-time-container-bug</refersElementId>
//    <difficultyLevel>medium</difficultyLevel>
//    <set>global</set>
//    <description>The time should correspond to EST time-zone.</description>
//  </bug>
//  <bug>
//    <!--Bug 3.4-->
//    <bugName>LinkIsNotChangeColor</bugName>
//    <page>home</page>
//    <classification>css</classification>
//    <refersElementId>navigation-bar-container-bug</refersElementId>
//    <cssRule>???</cssRule>
//    <cssValue>???</cssValue>
//    <difficultyLevel>medium</difficultyLevel>
//    <set>global</set>
//  </bug>
//  <bug>
//    <!--Bug 3.5-->
//    <bugName>NewsWidgetCursorIsNotChangePointer</bugName>
//    <page>home</page>
//    <classification>css</classification>
//    <cssRule>???</cssRule>
//    <cssValue>???</cssValue>
//    <refersElementId>N/A</refersElementId>
//    <difficultyLevel>medium</difficultyLevel>
//    <set>global</set>
//  </bug>
//  <bug>
//    <!--Bug 3.6-->
//    <bugName>NewsWidgetDateIncorrectFormat</bugName>
//    <page>home</page>
//    <classification>visualization</classification>
//    <refersElementId>date-time-news-container-bug</refersElementId>
//    <difficultyLevel>low</difficultyLevel>
//    <set>global</set>
//  </bug>
//  <bug>
//    <!--Bug 3.7-->
//    <bugName>NewsWidgetHeadlineLimited</bugName>
//    <page>home</page>
//    <classification>content</classification>
//    <refersElementId>headline-news-container-bug</refersElementId>
//    <contentValue>60</contentValue>
//    <difficultyLevel>low</difficultyLevel>
//    <set>global</set>
//  </bug>
//  <bug>
//    <!--Bug 3.8-->
//    <bugName>EndTruncatedHeadlineNoEllipsis</bugName>
//    <page>home</page>
//    <classification>visualization</classification>
//    <refersElementId>truncated-headline-noEllipsis-bug</refersElementId>
//    <difficultyLevel>medium</difficultyLevel>
//    <set>global</set>
//  </bug>
//  <bug>
//    <!--Bug 3.9-->
//    <bugName>MarketWidgetCursorIsNotChangePointer</bugName>
//    <page>home</page>
//    <classification>css</classification>
//    <cssRule>???</cssRule>
//    <cssValue>???</cssValue>
//    <refersElementId>N/A</refersElementId>
//    <difficultyLevel>medium</difficultyLevel>
//    <set>global</set>
//  </bug>
//  <bug>
//    <!--Bug 3.10-->
//    <bugName>PeriodLableCloserToPrice</bugName>
//    <page>home</page>
//    <classification>css</classification>
//    <cssRule>???</cssRule>
//    <cssValue>???</cssValue>
//    <refersElementId>N/A</refersElementId>
//    <difficultyLevel>medium</difficultyLevel>
//    <set>global</set>
//  </bug>
//  <bug>
//    <!--Bug 3.11-->
//    <bugName>TheBoxWidthNotChanged</bugName>
//    <page>home</page>
//    <classification>visualization</classification>
//    <refersElementId>N/A</refersElementId>
//    <difficultyLevel>medium</difficultyLevel>
//    <set>global</set>
//  </bug>
//  <bug>
//    <!--Bug 3.12-->
//    <bugName>PeriodLablesContent</bugName>
//    <page>home</page>
//    <classification>content</classification>
//    <contentValue>3 month | 6 month</contentValue>
//    <refersElementId>N/A</refersElementId>
//    <difficultyLevel>medium</difficultyLevel>
//    <set>global</set>
//  </bug>
//  <bug>
//    <!--Bug 3.13-->
//    <bugName>IndexMissingOption</bugName>
//    <page>home</page>
//    <classification>visualization</classification>
//    <contentValue>Nikkei 225</contentValue>
//    <refersElementId>N/A</refersElementId>
//    <difficultyLevel>low</difficultyLevel>
//    <set>global</set>
//  </bug>
//  <bug>
//    <!--Bug 3.14-->
//    <bugName>AxisXNotEqual</bugName>
//    <page>home</page>
//    <classification>visualization</classification>
//    <refersElementId>N/A</refersElementId>
//    <difficultyLevel>medium</difficultyLevel>
//    <set>global</set>
//  </bug>
//  <bug>
//    <!--Bug 3.15-->
//    <bugName>ChartShouldBeStable</bugName>
//    <page>home</page>
//    <classification>logic</classification>
//    <refersElementId>N/A</refersElementId>
//    <difficultyLevel>high</difficultyLevel>
//    <set>global</set>
//  </bug>
//  <bug>
//    <!--Bug 3.16-->
//    <bugName>PortfolioSectionNoInnerBorder</bugName>
//    <page>home</page>
//    <classification>css</classification>
//    <refersElementId>???</refersElementId>
//    <cssRule>???</cssRule>
//    <cssValue>????</cssValue>
//    <difficultyLevel>medium</difficultyLevel>
//    <set>global</set>
//  </bug>
//  <bug>
//    <!--Bug 3.17-->
//    <bugName>PortfolioWidgetCursorIsNotChangePointer</bugName>
//    <page>home</page>
//    <classification>css</classification>
//    <cssRule>???</cssRule>
//    <cssValue>???</cssValue>
//    <refersElementId>???</refersElementId>
//    <difficultyLevel>medium</difficultyLevel>
//    <set>global</set>
//  </bug>
//  <bug>
//    <!--Bug 3.18-->
//    <bugName>LinkShouldLeadTo404Page</bugName>
//    <page>home</page>
//    <classification>logic</classification>
//    <refersElementId>???</refersElementId>
//    <difficultyLevel>low</difficultyLevel>
//    <set>global</set>
//  </bug>
//  <bug>
//    <!--Bug 3.19-->
//    <bugName>SecuritiesColumnSelectedByDefault</bugName>
//    <page>home</page>
//    <classification>logic</classification>
//    <refersElementId>???</refersElementId>
//    <difficultyLevel>low</difficultyLevel>
//    <set>global</set>
//  </bug>
//  <bug>
//    <!--Bug 3.20-->
//    <bugName>IndicesColumnHigerThanSecurities</bugName>
//    <page>home</page>
//    <classification>css</classification>
//    <refersElementId>???</refersElementId>
//    <cssRule>???</cssRule>
//    <cssValue>???</cssValue>
//    <difficultyLevel>medium</difficultyLevel>
//    <set>global</set>
//  </bug>
//  <bug>
//    <!--Bug 3.21-->
//    <bugName>ItemNameDefaultsToTheDefaultItem</bugName>
//    <page>home</page>
//    <classification>logic</classification>
//    <refersElementId>N/A</refersElementId>
//    <difficultyLevel>low</difficultyLevel>
//    <set>global</set>
//  </bug>
//  <bug>
//    <!--Bug 3.22-->
//    <bugName>PriceFilterNotContainsAnyValues</bugName>
//    <page>home</page>
//    <classification>visualization</classification>
//    <refersElementId>N/A</refersElementId>
//    <difficultyLevel>low</difficultyLevel>
//    <set>global</set>
//  </bug>
//  <bug>
//    <!--Bug 3.23-->
//    <bugName>AxisYNotContains2013Year</bugName>
//    <page>home</page>
//    <classification>visualization</classification>
//    <refersElementId>N/A</refersElementId>
//    <difficultyLevel>medium</difficultyLevel>
//    <set>global</set>
//  </bug>
//  <bug>
//    <!--Bug 3.24-->
//    <bugName>TheChartReflectsOnlyForTonIndexAndTopSecurity</bugName>
//    <page>home</page>
//    <classification>logic</classification>
//    <refersElementId>N/A</refersElementId>
//    <difficultyLevel>medium</difficultyLevel>
//    <set>global</set>
//  </bug>
//</bugs>