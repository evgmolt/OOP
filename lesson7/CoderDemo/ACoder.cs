using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoderDemo
{
    internal class ACoder : ICoder
    {
        public string Decode(string context)
        {
            return new string(context.Select(c => --c).ToArray());
        }

        public string Encode(string context)
        {
            return new string (context.Select(c => ++c).ToArray());
        }
    }
}
