using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kassan.FileManagement
{
    /// <summary>
    /// Writes Products, Receipt, Campaign to a textfile
    /// </summary>
    internal interface IFileWriter
    {
        void Write(); 
    }
}
