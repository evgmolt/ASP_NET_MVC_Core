using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SafeListDemo
{
    public class SafeList<T> : IDisposable, IEnumerable
    {
        private ReaderWriterLockSlim _listLock = new ReaderWriterLockSlim();
        private List<T> _innerList = new List<T>();

        public int Count
        { get { return _innerList.Count; } }

        public T[] GetArray()
        {
            _listLock.EnterReadLock();
            var result = _innerList.ToArray();
            _listLock.ExitReadLock();
            return result;
        }

        public T Read(int index)
        {
            _listLock.EnterReadLock();
            try
            {
                return _innerList[index];
            }
            finally
            {
                _listLock.ExitReadLock();
            }
        }
        public void Add(T element)
        {
            _listLock.EnterWriteLock();
            try
            {
                _innerList.Add(element);
            }
            finally
            {
                _listLock.ExitWriteLock();
            }
        }
        public void Remove(T element)
        {
            _listLock.EnterWriteLock();
            try
            {
                _innerList.Remove(element);
            }
            finally
            {
                _listLock.ExitWriteLock();
            }
        }
        public void RemoveAt(int index)
        {
            _listLock.EnterWriteLock();
            try
            {
                _innerList.RemoveAt(index);
            }
            finally
            {
                _listLock.ExitWriteLock();
            }
        }

        public void Dispose()
        {
            if (_listLock != null)
            {
                _listLock.Dispose();
            }
        }

        public IEnumerator GetEnumerator()
        {
            return _innerList.GetEnumerator();
        }
    }
}
