//----------------------------------------------------------------------- 
// <copyright file="IUniToken.cs" company="Gundersoft"> 
//     Copyright (c) Christian Gunderman. All rights reserved. 
// </copyright> 
// <author>Christian Gunderman</author> 
//-----------------------------------------------------------------------

namespace Uniscript.Tokens
{
    /// <summary>
    /// The interface for all tokens.
    /// </summary>
    /// <typeparam name="TValue">The type of the value stored within this token.</typeparam>
    public interface IUniToken<TValue>
    {
        /// <summary>
        /// Gets a value indicating the token type.
        /// </summary>
        UniTokenType Type { get; }

        /// <summary>
        /// Gets the value of the token.
        /// </summary>
        TValue Value { get; }
    }
}
