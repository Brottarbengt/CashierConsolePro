using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kassan.FileManagement
{
    /// <summary>
    /// Reads Products, Reciept, Campaign from a textfile
    /// </summary>
    internal interface IFileReader
    {
        void Read();
    }
}
