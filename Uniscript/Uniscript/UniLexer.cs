//----------------------------------------------------------------------- 
// <copyright file="UniLexer.cs" company="Gundersoft"> 
//     Copyright (c) Christian Gunderman. All rights reserved. 
// </copyright> 
// <author>Christian Gunderman</author> 
//-----------------------------------------------------------------------

namespace Uniscript
{
    using System;
    using System.Collections.Generic;
    using Errors;
    using Tokens;

    /// <summary>
    /// Lexer implementation for tokenization of script code.
    /// </summary>
    internal sealed class UniLexer : IUniLexer
    {
        /// <summary>
        /// Explodes a string of code into a sequence of tokens.
        /// </summary>
        /// <param name="code">A piece of code.</param>
        /// <returns>A tuple containing the resulting tokens and an enumerable of errors.</returns>
        public Tuple<IEnumerable<IUniToken>, IEnumerable<IUniError>> Tokenize(string code)
        {
            throw new NotImplementedException();
        }
    }
}
