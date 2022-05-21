using System;

namespace SimpleJSON.Util
{
    [Serializable]
    public class Wrapper<T>
    {
        public T[] Items;

        public Wrapper(T[] items)
        {
            Items = items;
        }
    }
}