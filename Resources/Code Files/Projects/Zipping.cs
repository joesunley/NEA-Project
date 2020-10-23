using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Compression;

namespace Zipping
{
    class Program
    {
        static void Main(string[] args)
        {
            string startPath = @".\start";
            string zipPath = @".\result.zip";
            string extractPath = @".\extract";

            ZipFile.CreateFromDirectory(startPath, zipPath);

            ZipFile.ExtractToDirectory(zipPath, extractPath);

        }
    }
}