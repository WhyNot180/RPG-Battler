using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Battler
{
    public interface ISelectable<T>
    {
        void select();
        string Name { get; }
        string Description { get; }
    }
}
