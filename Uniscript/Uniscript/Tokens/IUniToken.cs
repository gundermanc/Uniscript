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
    public interface IUniToken
    {
        /// <summary>
        /// Gets a value indicating the token type.
        /// </summary>
        UniTokenType Type { get; }

        /// <summary>
        /// Gets the value of this token.
        /// </summary>
        /// <typeparam name="TValue">
        /// The desired return type.
        /// </typeparam>
        /// <exception cref="InvalidOperationException">
        /// Value is of a different type.
        /// </exception>
        /// <returns>The value in the desired return type.</returns>
        TValue GetValue<TValue>();
    }
}
