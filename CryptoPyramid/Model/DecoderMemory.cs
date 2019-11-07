using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoPyramid.Model
{
    public class DecoderMemory
    {
        public DecoderMemory(List<int> @volatile)
        {
            _volatile = @volatile;
        }

        public List<int> _volatile  { get; set; }
    }
}
