using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09_Inferfaces_Intorduction
{
    public interface IFruit
    {
        string Name { get; }
        bool IsPeeled { get; }
        string Peel();
    }
}
