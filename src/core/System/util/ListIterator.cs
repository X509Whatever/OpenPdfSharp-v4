using System;
using System.Collections;
using System.Collections.Generic;

namespace System.util {
    /// <summary>
    /// Summary description for ListIterator.
    /// </summary>
    public class ListIterator<T> {
        IList<T> col;
        int cursor = 0;
        int lastRet = -1;

        public ListIterator(IList<T> col) {
            this.col = col;
        }

        public bool HasNext() {
            return cursor != col.Count;
        }

        public T Next() {
            var next = col[cursor];
            lastRet = cursor++;
            return next;
        }

        public T Previous() {
            int i = cursor - 1;
            var previous = col[i];
            lastRet = cursor = i;
            return previous;
        }

        public void Remove() {
            if (lastRet == -1)
                throw new InvalidOperationException();
            col.RemoveAt(lastRet);
            if (lastRet < cursor)
                cursor--;
            lastRet = -1;
        }
    }

    public class ListIterator {
        IList col;
        int cursor = 0;
        int lastRet = -1;

        public ListIterator(IList col) {
            this.col = col;
        }

        public bool HasNext() {
            return cursor != col.Count;
        }

        public object Next() {
            var next = col[cursor];
            lastRet = cursor++;
            return next;
        }

        public object Previous() {
            int i = cursor - 1;
            var previous = col[i];
            lastRet = cursor = i;
            return previous;
        }

        public void Remove() {
            if (lastRet == -1)
                throw new InvalidOperationException();
            col.RemoveAt(lastRet);
            if (lastRet < cursor)
                cursor--;
            lastRet = -1;
        }
    }
}
