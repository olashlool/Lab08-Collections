using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phil_s_Lending_Library
{
    class Backpack<T> : IBag<T>
    {
        private List<T> bookList = new List<T>();

        public IEnumerator<T> GetEnumerator()
        {
            foreach (T items in bookList)
            {
                yield return items;
            }
        }

        public void Pack(T item)
        {
            bookList.Add(item);
        }

        public T Unpack(int index)
        {
            T item = bookList[index];
            bookList.RemoveAt(index);
            return item;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
