using Kassan.FileManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kassan.Shopping
{
    internal class Reciept : IFileWriter, IFileReader
    {

        public string Date { get; set; }

        public double Total { get; set; }

        public static int recieptCount = 0;

        public void Write()
        {
            // Write to file
        }

        public void Read()
        {
            // Read from file
        }

       
    }
}

/// <summary>
/// Writes Products, Reciept, Campaign to a textfile
/// </summary>

/// <summary>
/// Reads Products, Reciept, Campaign from a textfile
/// </summary>