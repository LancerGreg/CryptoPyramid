using CryptoPyramid.Incoder;
using CryptoPyramid.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoPyramid
{
    class Program
    {
        static void Main(string[] args)
        {
            string myBirthday = "1100010111010001";
            string DumpOfSession = "1100001000011101001100110110000001101100010111111100111100010111";

            IncodTranslation translation = new IncodTranslation(myBirthday);
            GroupPyramid pyramid = new GroupPyramid();

            Console.WriteLine(translation._pyramid);
            pyramid.ShowPyramid(translation._pyramid);
            translation.ShowFinalyDump(translation.GroupingUpperPyramid(translation.GroupingPyramid(translation.SplitPyramid())));

            Console.Read();
        }
    }
}
