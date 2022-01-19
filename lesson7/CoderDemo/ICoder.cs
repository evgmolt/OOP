using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoderDemo
{
    internal interface ICoder
    {
        string Encode(string context);
        string Decode(string context);
    }
}
