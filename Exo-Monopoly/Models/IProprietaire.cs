using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exo_Monopoly.Models
{
    public interface IProprietaire
    {
        bool EstHypotequee { get; }
        void Hypothequer();
        void Deshypothequer();
    }
}
