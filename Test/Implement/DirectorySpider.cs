using System;
using System.Collections.Generic;
using System.IO;
using Test.Abstract;

namespace Test {
    /// <summary>
    /// Class that have responsobilite move through directory system
    /// </summary>
    public class DirectorySpider {
        public DirectoryInfo CurrLocation { get; private set; }
        public Stack<ICmd> Commands { get; set; }

        public DirectorySpider() {
            CurrLocation = new DirectoryInfo(Directory.GetCurrentDirectory());
            Commands = new Stack<ICmd>();
        }

        /// <summary>
        /// Execude commands
        /// </summary>
        /// <returns></returns>
        public string ExucCmd() {
            var strResult = String.Empty;

            do {
                strResult = strResult + Commands.Pop().Run();
            } while (Commands.Count > 0);

            return strResult;
        }

        public string Up() {
            CurrLocation = CurrLocation.Parent;

            return CurrLocation.FullName;
        }

        public bool CnageLocation(string newLocation) {
            try {
                CurrLocation = new DirectoryInfo(newLocation);
            } catch (Exception) {

                return false;
            }

            return true;
        }
    }
}