using System;

namespace Library
{
    public interface IItem
    {
        string Nombre {get; }
        bool Equals(object obj);
        int GetHashCode();
        string ToString();
    }
}
