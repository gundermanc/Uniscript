using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uniscript.Tokens
{
    interface IToken
    {
        UniType Type { get; }
        T Value { get; }
    }
}
