//----------------------------------------------------------------------- 
// <copyright file="UniInvalidTokenTypeException.cs" company="Gundersoft"> 
//     Copyright (c) Christian Gunderman. All rights reserved. 
// </copyright> 
// <author>Christian Gunderman</author> 
//-----------------------------------------------------------------------

namespace Uniscript
{
    /// <summary>
    /// Value in token is not of the requested type.
    /// </summary>
    public sealed class UniInvalidTokenTypeException : UniException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UniInvalidTokenTypeException"/>
        /// class.
        /// </summary>
        public UniInvalidTokenTypeException() : base("Token is not expected type.")
        {
        }
    }
}
