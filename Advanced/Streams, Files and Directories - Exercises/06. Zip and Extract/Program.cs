using System;
using System.IO.Compression;

namespace _06._Zip_and_Extract
{
    class Program
    {
        static void Main(string[] args)
        {
            ZipFile.CreateFromDirectory("../../../", @"C:\demo\zippedFile.zip");
            ZipFile.ExtractToDirectory(@"C:\demo\zippedFile.zip", @"C:\demo1");
        }
    }
}
