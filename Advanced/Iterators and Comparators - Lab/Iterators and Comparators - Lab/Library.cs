using System.Collections;
using System.Collections.Generic;

namespace IteratorsAndComparators
{
    public class Library : IEnumerable<Book>
    {
        private List<Book> books;
        public Library(params Book[] books)
        {
            this.books = new List<Book>(books);
            this.books.Sort(new BookComparator());
        }

        public IEnumerator<Book> GetEnumerator()
        {
            return new LibraryIterator(books);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private class LibraryIterator : IEnumerator<Book>
        {
            private int index = -1;
            private List<Book> books;

            public LibraryIterator(List<Book> books)
            {
                this.Reset();
                this.books = new List<Book>(books);
            }
            public Book Current => books[index];

            object IEnumerator.Current => this.Current;

            public void Dispose()
            {
            }

            public bool MoveNext()
            {
                index++;
                if (index >= this.books.Count)
                {
                    return false;
                }

                return true;
            }

            public void Reset()
            {
                index = -1;
            }
        }
    }
}
