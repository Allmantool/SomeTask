using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace XMLTest {
    [TestClass]
    public class Proxy {
        /// <summary>
        /// Proxy Design Pattern.
        /// </summary>
        [TestMethod]
        public void Main() {
            using (IBook book = new BookStoreProxy()) {
                // Read first page.
                Page page1 = book.GetPage(1);
                Console.WriteLine(page1.Text);

                // Read second page.
                Page page2 = book.GetPage(2);
                Console.WriteLine(page2.Text);

                // Return first page.
                page1 = book.GetPage(1);
                Console.WriteLine(page1.Text);
            }

        }
    }

    class Page {
        public int Id { get; set; }
        public int Number { get; set; }
        public string Text { get; set; }
    }

    class PageContext : DbContext {
        public DbSet<Page> Pages { get; set; }
    }

    interface IBook : IDisposable {
        Page GetPage(int number);
    }

    class BookStore : IBook {
        private PageContext db;

        public BookStore() {
            db = new PageContext();

        }

        public Page GetPage(int number) {
            return db.Pages.FirstOrDefault(p => p.Number == number);
        }

        public void Dispose() {
            db.Dispose();
        }
    }

    class BookStoreProxy : IBook {
        private readonly List<Page> _pages;
        private BookStore _bookStore;

        public BookStoreProxy() {
            _pages = new List<Page>();
        }

        public Page GetPage(int number) {
            Page page = _pages.FirstOrDefault(p => p.Number == number);

            if (page == null) {
                if (_bookStore == null) {
                    _bookStore = new BookStore();
                }

                page = _bookStore.GetPage(number);
                _pages.Add(page);

            }

            return page;
        }

        public void Dispose() {
            _bookStore?.Dispose();
        }
    }
}
