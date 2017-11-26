using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace XMLTest {
    [TestClass]
    public class Composite {
        [TestMethod]
        public void Main() {
            Component fileSystem = new Directory("Файловая система");
            // Determine new disk.
            Component diskC = new Directory("Диск С");
            // New files.
            Component pngFile = new File("12345.png");
            Component docxFile = new File("Document.docx");

            // Add files to Disk C.
            diskC.Add(pngFile);
            diskC.Add(docxFile);
            // Add Disk C to file system.
            fileSystem.Add(diskC);

            // Print all data.
            fileSystem.Print();
            Console.WriteLine();
            // удаляем с диска С файл
            diskC.Remove(pngFile);
            // создаем новую папку
            Component docsFolder = new Directory("Мои Документы");
            // добавляем в нее файлы
            Component txtFile = new File("readme.txt");
            Component csFile = new File("Program.cs");
            docsFolder.Add(txtFile);
            docsFolder.Add(csFile);
            diskC.Add(docsFolder);
            fileSystem.Print();

            Console.Read();
        }
    }

    abstract class Component {
        protected readonly string name;

        protected Component(string name) {
            this.name = name;
        }

        public virtual void Add(Component component) { }

        public virtual void Remove(Component component) { }

        public virtual void Print() {
            Console.WriteLine(name);
        }
    }

    class Directory : Component {
        private readonly List<Component> _components = new List<Component>();

        public Directory(string name)
            : base(name) {
        }

        public override void Add(Component component) {
            _components.Add(component);
        }

        public override void Remove(Component component) {
            _components.Remove(component);
        }

        public override void Print() {
            Console.WriteLine("Узел " + name);
            Console.WriteLine("Подузлы:");
            foreach (Component t in _components) {
                t.Print();
            }
        }
    }

    class File : Component {
        public File(string name)
            : base(name) { }
    }
}
