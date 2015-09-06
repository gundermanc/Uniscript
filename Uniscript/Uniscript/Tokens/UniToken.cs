using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uniscript.Tokens
{
    public class UniToken<TValue> : IUniToken<TValue>
    {
        public UniToken(UniTokenType type, TValue value)
        {

        }

        public UniTokenType Type
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public TValue Value
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}
