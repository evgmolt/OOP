using System;
using System.Collections;

namespace MyListDemo
{
    internal class MyList<T> : IList<T>, IReadOnlyList<T>, IList
    {
        private T[] _internalArray;
        private int _internalArrayLength;//Размер массива
        private int _size;//Размер коллекции (сколько элементов добавлено)
        private const int _defaultSize = 10;
        public MyList()
        {
            _internalArray = new T[_defaultSize];
            _internalArrayLength = _defaultSize;
        }
        public MyList(int arraySize)
        {
            _internalArray = new T[arraySize];
            _internalArrayLength = arraySize;
        }
        public int InternalArrayLength { 
            get 
            { 
                return _internalArray.Length; 
            } 
            private set 
            { 
                if (value < _internalArrayLength || value <= 0)
                {
                    throw new ArgumentException();
                }
                if (value != _internalArrayLength)
                {
                    T[] newInternalArray = new T[value];
                    Array.Copy(_internalArray, 0, newInternalArray, 0, _internalArrayLength);
                    _internalArray = newInternalArray;
                    _internalArrayLength = value;
                }
            }
        }
        public T this[int index] 
        { 
            get
            {
                return _internalArray[index];
            }
            set
            {
                _internalArray[index] = value;  
            }
        }
        object? IList.this[int index]
        {
            get
            {
                return _internalArray[index];
            }
            set
            {
                T val = default(T);
                try
                {
                    val = (T)value;
                }
                catch (InvalidCastException)
                {
                }
                _internalArray[index] = val;
            }
        }
        public int Count
        { 
            get { return _size; } 
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public bool IsFixedSize
        {
            get { return false; }
        }
        public bool IsSynchronized
        {
            get { return false; }
        }

        public object SyncRoot => throw new NotImplementedException();

        public void Add(T item)
        {
            if (_size == _internalArray.Length)
            {
                InternalArrayLength = _size * 2;//Если нужно увеличить размер, увеличиваем в 2 раза
            }
            _internalArray[_size++] = item;
        }

        public int Add(object? value)
        {
            try
            {
                Add((T)value);
            }
            catch (InvalidCastException)
            {
            }

            return Count - 1;
        }

        public void Clear()
        {
            if (_size > 0)
            {
                Array.Clear(_internalArray, 0, _size); 
                _size = 0;
            }
        }

        public bool Contains(T item)
        {
            return Array.IndexOf(_internalArray, item) >= 0;
        }

        public bool Contains(object? value)
        {
            try
            {
                return Contains((T)value);
            }
            catch (InvalidCastException)
            {
                return false;
            }
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            Array.Copy(_internalArray, array, arrayIndex);
        }

        public void CopyTo(Array array, int index)
        {
            Array.Copy(_internalArray, array, index);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new Enumerator(this); 
        }

        public int IndexOf(T item)
        {            
            return Array.IndexOf(_internalArray, item);
        }

        public int IndexOf(object? value)
        {
            T itemT = default(T);
            try
            {
                itemT = (T)value;
            }
            catch (InvalidCastException)
            {
            }
            return Array.IndexOf(_internalArray, itemT);
        }

        public void Insert(int index, T item)
        {
            if ((uint)index > (uint)_size)
            {
                throw new ArgumentOutOfRangeException();
            }
            if (_size == _internalArray.Length)
            {
                InternalArrayLength = _size * 2;
            }
            if (index < _size)
            {
                Array.Copy(_internalArray, index, _internalArray, index + 1, _size - index);
            }
            _internalArray[index] = item;
            _size++;
        }

        public void Insert(int index, object? value)
        {
            T itemT = default(T);
            try
            {
                itemT = (T)value;
            }
            catch (InvalidCastException)
            {
            }
            Insert(index, itemT);
        }

        public bool Remove(T item)
        {
            int index = IndexOf(item);
            if (index >= 0)
            {
                RemoveAt(index);
                return true;
            }
            return false;
        }

        public void Remove(object? value)
        {
            T itemT = default(T);
            try
            {
                itemT = (T)value;
            }
            catch (InvalidCastException)
            {
            }
            Remove(itemT);
        }

        public void RemoveAt(int index)
        {
            if ((uint)index >= (uint)_size)
            {
                throw new ArgumentOutOfRangeException();
            }
            _size--;
            if (index < _size)
            {
                Array.Copy(_internalArray, index + 1, _internalArray, index, _size - index);
            }
            _internalArray[_size] = default(T);
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return new Enumerator(this);
        }

        public struct Enumerator : IEnumerator<T>, System.Collections.IEnumerator
        {
            private MyList<T> list;
            private int index;
            private T current;

            internal Enumerator(MyList<T> list)
            {
                this.list = list;
                index = 0;
                current = default(T);
            }

            public void Dispose()
            {
            }

            public bool MoveNext()
            {

                MyList<T> localList = list;

                if ((uint)index < (uint)localList._size)
                {
                    current = localList._internalArray[index];
                    index++;
                    return true;
                }
                return MoveNextRare();
            }

            private bool MoveNextRare()
            {
                index = list._size + 1;
                current = default(T);
                return false;
            }

            public T Current
            {
                get
                {
                    return current;
                }
            }

            Object System.Collections.IEnumerator.Current
            {get
                {
                    if (index == 0 || index == list._size + 1)
                    {
                        throw new InvalidOperationException();
                    }
                    return Current;
                }
            }

            void System.Collections.IEnumerator.Reset()
            {
                index = 0;
                current = default(T);
            }
        }
    }
}
