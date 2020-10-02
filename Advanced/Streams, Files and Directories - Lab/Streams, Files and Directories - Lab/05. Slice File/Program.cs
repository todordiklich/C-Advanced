using System;
using System.Collections.Generic;
using System.IO;

namespace _05._Slice_File
{
    class Program
    {
        static void Main(string[] args)
        {
            int parts = 4;

            using (var reader = new FileStream("../../../sliceMe.txt", FileMode.Open))
            {
                long pieceSize = (long)Math.Ceiling((double)reader.Length / parts);

                for (int i = 0; i < parts; i++)
                {
                    long currPieceSize = 0;

                    using (var createFile = new FileStream($"../../../Part-{i+1}.txt", FileMode.Create))
                    {
                        byte[] buffer = new byte[4096];

                        while (reader.Read(buffer, 0, buffer.Length) == buffer.Length)
                        {
                            currPieceSize += buffer.Length;
                            createFile.Write(buffer, 0, buffer.Length);

                            if (currPieceSize >= pieceSize) 
                            { 
                                break; 
                            }
                        }
                    }
                }
            }
        }
    }
}
