using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kassan.Menus
{
    internal interface IMenuOption
    {
        public string Category { get; }
        public string[] Options { get;}

        
    }

}
