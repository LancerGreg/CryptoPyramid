using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoPyramid.Model
{
    public class GroupPyramid
    {
        public int _place { get; set; }
        public string _dump { get; set; } 
        public List<GroupPyramid> _groupPyramids { get; set; }

        public GroupPyramid() { }
        public GroupPyramid(int place, string dump, List<GroupPyramid> groupPyramids = null)
        {
            _place = place;
            _dump = dump;
            _groupPyramids = groupPyramids;
        }

        public void ShowPyramid(string pyramid)
        {
            Console.WriteLine();
            var steps = Math.Sqrt(pyramid.Length);
            string space = "";
            for (int i = 0; i < steps; i++)
                space += " ";
            for(int i = 0; i < pyramid.Length; i++)
            {
                if (Math.Pow((int)Math.Sqrt(i), 2) == i)
                {
                    Console.WriteLine();
                    space = space.Substring(0, space.Length - 1);
                    Console.Write($"{space}");
                }
                Console.Write($"{pyramid[i]}");
            }
            Console.WriteLine("\n");
        }
    }
}
