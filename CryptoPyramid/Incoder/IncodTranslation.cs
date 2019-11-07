using CryptoPyramid.Model;
using CryptoPyramid.TranslationRule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoPyramid.Incoder
{
    class IncodTranslation
    {
        public string _pyramid { get; set; }
        public List<DecoderMemory> decoderMemory = new List<DecoderMemory>();

        public IncodTranslation(string pyramid)
        {
            _pyramid = pyramid;
        }

        /// <summary>
        /// Operation 'Math.Pow(x, (int)Math.Log(pyramid.Length, x)) != pyramid.Length' checks word length for compatibility with x to any degree
        /// In this program x = 4 because we are dealing with a pyramid in which each section will be folded from 4 parts
        /// </summary>
        /// <param name="pyramid">string of bytes</param>
        /// <returns></returns>
        public List<GroupPyramid> SplitPyramid()
        {
            if (Math.Pow(4, (int)Math.Log(_pyramid.Length, 4)) != _pyramid.Length)
            {
                Console.WriteLine($"This string {_pyramid} need has length equals integer from the logarithm 4");
                return null;
            }
            if (!CheckBite(_pyramid))
            {
                Console.WriteLine($"This string {_pyramid} mast has only chars 0 or 1");
                return null;
            }
            List<GroupPyramid> groupPyramids = new List<GroupPyramid>();
            for (int i = 0; i < _pyramid.Length; i++)
            {
                groupPyramids.Add(new GroupPyramid(i, _pyramid[i].ToString()));
            }

            return groupPyramids;
        }

        private bool CheckBite(string pyramid)
        {
            if (!pyramid.All(c => c == '1' || c == '0'))
                return false;
            else
                return true;
        }

        public List<GroupPyramid> GroupingPyramid(List<GroupPyramid> groupsPyramid)
        {
            if (groupsPyramid == null)
                return null;
            if (groupsPyramid.Count == 1)
                return null;

            List<GroupPyramid> groupsPyramidUpperRang = new List<GroupPyramid>();
            int nextPosition = 0;
            int lastStep = -1;
            for (int i = 0; i < groupsPyramid.Count; i += 4)
            {
                List<GroupPyramid> groupsPyramidLowRang = new List<GroupPyramid>();
                int position = (int)Math.Sqrt(i);
                if (position % 2 == 0)
                {
                    position = position * 2 + 2;
                }
                else
                    position = -(position * 2);
                nextPosition += 2;
                if (lastStep != (int)Math.Sqrt(i))
                {
                    nextPosition = (position > 0) ? (i / 4) : (int)(Math.Pow(((int)Math.Sqrt(i) - 1), 2) / 4 + 1);
                    lastStep = (int)Math.Sqrt(i);
                }
                groupsPyramidLowRang.Add(groupsPyramid[i]);
                groupsPyramidLowRang.Add(groupsPyramid[i + (position - 1)]);
                groupsPyramidLowRang.Add(groupsPyramid[i + (position)]);
                groupsPyramidLowRang.Add(groupsPyramid[i + (position + 1)]);
                groupsPyramidUpperRang.Add(new GroupPyramid(nextPosition, null, groupsPyramidLowRang));
            }

            List<GroupPyramid> sortGroupsPyramidUpperRang = new List<GroupPyramid>();
            for (int i = 0; i < groupsPyramidUpperRang.Count; i++)
            {
                sortGroupsPyramidUpperRang.Add(groupsPyramidUpperRang.Find(a => a._place == i));
            }

            return sortGroupsPyramidUpperRang;
        }
        

        public List<GroupPyramid> GroupingUpperPyramid(List<GroupPyramid> groupsPyramid)
        {
            if (groupsPyramid == null)
                return null;
            for (int i = 0; i < groupsPyramid.Count; i++)
            {
                string dump = groupsPyramid[i]._groupPyramids[0]._dump
                    + groupsPyramid[i]._groupPyramids[1]._dump
                    + groupsPyramid[i]._groupPyramids[2]._dump
                    + groupsPyramid[i]._groupPyramids[3]._dump;

                decoderMemory.Add(new DecoderMemory(new List<int>()));

                while (dump != "0000" && dump != "1111")
                {
                    decoderMemory.Last()._volatile.Add(Rule.IncoderRule(dump)._volatile);
                    dump = Rule.IncoderRule(dump).dump;
                    groupsPyramid[i]._groupPyramids[0]._dump = dump[0].ToString();
                    groupsPyramid[i]._groupPyramids[1]._dump = dump[1].ToString();
                    groupsPyramid[i]._groupPyramids[2]._dump = dump[2].ToString();
                    groupsPyramid[i]._groupPyramids[3]._dump = dump[3].ToString();
                    ShowDump(groupsPyramid);
                    Console.WriteLine();
                }
                groupsPyramid[i]._dump = dump[0].ToString();
            }

            for (int i = 0; i < groupsPyramid.Count; i++)
            {
                Console.Write(groupsPyramid[i]._dump);
            }

            Console.WriteLine();

            if (groupsPyramid.Count == 1)
                return groupsPyramid;
            else
                return GroupingUpperPyramid(GroupingPyramid(groupsPyramid));
        }

        public void ShowFinalyDump(List<GroupPyramid> groupsPyramid)
        {
            if (groupsPyramid == null)
                return;
            Console.WriteLine();
        }

        private void ShowDump(List<GroupPyramid> groupsPyramid)
        {
            for (int i = 0; i < groupsPyramid.Count; i++)
            {
                if (groupsPyramid[i]._groupPyramids != null)
                {
                    for (int j = 0; j < groupsPyramid[i]._groupPyramids.Count; j++)
                    {
                        Console.Write(groupsPyramid[i]._groupPyramids[j]._dump);
                    }
                }
            }
        }
    }
}
