using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoPyramid.TranslationRule
{
    public static class Rule
    {
        public static (string dump, int _volatile) IncoderRule(string dump)
        {
            int _volatile = -1;
            switch (dump)
            {
                case "0000":
                    dump = "0000";
                    break;
                case "0001":
                    dump = "0010";
                    _volatile = 0;
                    break;
                case "0010":
                    dump = "0000"; 
                    _volatile = 0;
                    break;
                case "0011":
                    dump = "1111";
                    _volatile = 0;
                    break;
                case "0100":
                    dump = "0010";
                    _volatile = 1;
                    break;
                case "0101":
                    dump = "0011";
                    _volatile = 1;
                    break;
                case "0110":
                    dump = "1111";
                    _volatile = 1;
                    break;
                case "0111":
                    dump = "0000";
                    _volatile = 1;
                    break;
                case "1000":
                    dump = "0011";
                    _volatile = 0;
                    break;
                case "1001":
                    dump = "0111";
                    _volatile = 1;
                    break;
                case "1010":
                    dump = "0110";
                    _volatile = 0;
                    break;
                case "1011":
                    dump = "0110";
                    _volatile = 1;
                    break;
                case "1100":
                    dump = "0000";
                    break;
                case "1101":
                    dump = "1111";
                    break;
                case "1110":
                    dump = "0111";
                    _volatile = 0;
                    break;
                case "1111":
                    dump = "1111";
                    break;
            }

            return (dump, _volatile);
        }

        public static string DecoderRule(string dump, int _volatile)
        {
            if (_volatile == -1)
                return dump;
            switch (dump)
            {
                case "0000":
                    if (_volatile == 0)
                        dump = "0010";
                    else if (_volatile == 1)
                        dump = "0111";
                    else
                        dump = "1100";
                    break;
                case "0001":
                    break;
                case "0010":
                    if (_volatile == 0)
                        dump = "0001";
                    else
                        dump = "0100";
                    break;
                case "0011":
                    if (_volatile == 0)
                        dump = "1000";
                    else
                        dump = "0101";
                    break;
                case "0100":
                    break;
                case "0101":
                    break;
                case "0110":
                    if (_volatile == 0)
                        dump = "1010";
                    else
                        dump = "1011";
                    break;
                case "0111":
                    if (_volatile == 0)
                        dump = "1110";
                    else
                        dump = "1001";
                    break;
                case "1000":
                    break;
                case "1001":
                    break;
                case "1010":
                    break;
                case "1011":
                    break;
                case "1100":
                    break;
                case "1101":
                    break;
                case "1110":
                    break;
                case "1111":
                    if (_volatile == 0)
                        dump = "0011";
                    else if (_volatile == 1)
                        dump = "0110";
                    else
                        dump = "1101";
                    break;
            }

            return dump;
        }
    }
}
