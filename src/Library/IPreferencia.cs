using System;

namespace Library
{
    public interface IPreferencia
    {
        bool MeGusta {get; }

        int ValorarItem (IItem item);

    }
}
