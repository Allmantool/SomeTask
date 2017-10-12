using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Test.Abstract;

namespace Test.Implement.Commands {
    public class SimpleCmd : ICmd {
        public string Mask { get; private set; }
        public bool IsRecursive { get; private set; }
        public string Location { get; private set; }

        /// <summary>
        /// it represents structure in hierachy style
        /// </summary>
        /// <param name="mask"></param>
        /// <param name="isRecursive"></param>
        /// <param name="location"></param>
        public SimpleCmd(string mask = "*", bool isRecursive = false, string location = "") {
            Location = location;
            Mask = mask;
            IsRecursive = isRecursive;
        }

        public string Run() {
            var root = new DirectoryInfo(Location);
            var files = root.GetFiles(Mask, IsRecursive ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly);

            var output = $"Root: {root.Name} ({root.FullName}){Environment.NewLine}";

            for (int i = 0; i < files.Count(); i++) {
                output = output + ParensFolders(files[i]);
            }

            return output;
        }

        /// <summary>
        /// with schema 
        /// </summary>
        /// <param name="searchFile"></param>
        /// <returns></returns>
        private string ParensFolders(FileInfo searchFile) {
            var dirs = new Queue<string>();
            var rootDir = searchFile.Directory;
            var depth = 0;

            rootDir.Refresh();
            //issue: some time rootDir is null, ever when file (folder) exists => something with time to access to I/O
            if (rootDir.Exists || rootDir != null) {

                //folders
                while (!Location.StartsWith(rootDir.FullName, StringComparison.OrdinalIgnoreCase)) {
                    rootDir.Refresh();

                    depth++;
                    dirs.Enqueue($"Depth: {depth}: { new String('-', depth)}>{ rootDir.Name }");

                    rootDir = rootDir.Parent;
                }
            }

            //file
            dirs.Enqueue($"Depth: {depth++}: { new String('-', depth)}>{searchFile.Name}{Environment.NewLine}");

            return dirs.Count > 0 ? string.Join(Environment.NewLine, dirs.Select(x => x)) : @"";
        }
    }
}