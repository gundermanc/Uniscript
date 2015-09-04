using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uniscript.Tokens
{
    abstract class UniTokenBase<T>
    {
        public UniType Type { get; }

        public T Value { get; }

        public UniTokenBase(UniType type, T value)
        {
            this.Type = type;
            this.Value = value;
        }
    }
}
