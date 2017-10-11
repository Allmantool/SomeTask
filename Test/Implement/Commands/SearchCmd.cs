using System;
using System.IO;
using System.Linq;
using System.Text;
using Test.Abstract;

namespace Test.Implement.Commands {
    public class SearchCmd : ICmd {
        public string Mask { get; private set; }
        public string Location { get; private set; }
        public bool IsRecursive { get; private set; }
        public bool IsSearchMode { get; set; }

        public SearchCmd(string location = "", string mask = "*", bool isRecursive = false, bool isSearchMode = false) {
            Mask = mask;
            Location = location;
            IsRecursive = isRecursive;
            IsSearchMode = isSearchMode;
        }

        public string Run() {
            return showFilesInSpecFolder(Location, Mask, IsRecursive, 0 , IsSearchMode);
        }

        private string showFilesInSpecFolder(string dirPath = "", string mask = "*", bool recursive = false, int depth = 0, bool searchMode = false) {
            var output = String.Empty;
            //increment with each recursive loop
            depth++;
            //var regex = new Regex(mask);

            //if path is null then take current folder
            var dir = new DirectoryInfo(dirPath);

            //when recursive seach not change location
            if (!recursive) Location = dir.FullName;

            //root folder name
            if (depth == 1) { output = output + $"Root: {dir.Name} ({dir.FullName}){Environment.NewLine}"; }

            //Getting fises name in current folder (Notice: There is used mask by name for filtreation pupposes)
            var itemNames = dir.GetFiles(mask, SearchOption.TopDirectoryOnly).Select(file => $" file: {file.Name}")
                    //.Concat(dir.GetDirectories().Select((folder, indx) => $"folder: {folder.Name}"))
                    .ToList();

            //recusive mode
            if (!recursive) {
                // if not recursive that simple add subfolders name from current folder
                var folders = dir.GetDirectories().Select((folder, indx) => $"folder: {folder.Name}").ToList();

                // merge folders and files name into one array
                itemNames = !searchMode ? itemNames.Concat(folders).ToList() : itemNames;
            } else {
                // loop through directory tree => iterate each folder
                var folders = dir.GetDirectories().Select(
                    (folder, indx) => $"{showFilesInSpecFolder(folder.FullName, mask: mask, depth: depth, recursive: recursive, searchMode: true)}").ToList();

                // merge folders and files name into one array in same depth (level tree)
                // search mode response for rendering only files match appropriate mask without folder names
                itemNames = itemNames.Where(x => x.Contains("folder") || x.Contains("file")).Concat(folders.Where(y => y.Length > 0)).ToList();
            }

            // build  result representation string
            var str = new StringBuilder(@"").Append(
                string.Join(
                    Environment.NewLine,
                    itemNames.Select(x => (!x.Contains(">") ? $"Depth: {depth} {new String('-', depth)}> {x}" : x)))
                );

            return $"{output}{str}";
        }
    }
}