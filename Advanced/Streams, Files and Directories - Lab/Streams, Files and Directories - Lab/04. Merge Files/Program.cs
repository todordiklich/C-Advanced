using System;
using System.IO;

namespace _04._Merge_Files
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var firstReader = new StreamReader("../../../FileOne.txt"))
            {
                using (var secondReader = new StreamReader("../../../FileTwo.txt"))
                {
                    using (var writer = new StreamWriter("../../../Otput.txt"))
                    {
                        string firstLine = firstReader.ReadLine();
                        string secondLine = secondReader.ReadLine();

                        while (firstLine != null || secondLine != null)
                        {
                            if (firstLine != null)
                            {
                                writer.WriteLine(firstLine);
                            }
                            if (secondLine != null)
                            {
                                writer.WriteLine(secondLine);
                            }

                            firstLine = firstReader.ReadLine();
                            secondLine = secondReader.ReadLine();
                        }
                    }
                }

            }
        }
    }
}
