//----------------------------------------------------------------------- 
// <copyright file="UniNoMoreContextsException.cs" company="Gundersoft"> 
//     Copyright (c) Christian Gunderman. All rights reserved. 
// </copyright> 
// <author>Christian Gunderman</author> 
//-----------------------------------------------------------------------

namespace Uniscript
{
    /// <summary>
    /// Cannot pop another context from the symbol table because the current context
    /// is the default context.
    /// </summary>
    public sealed class UniNoMoreContextsException : UniException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UniNoMoreContextsException"/>
        /// class.
        /// </summary>
        public UniNoMoreContextsException() : base("Cannot pop default symbol table context.")
        {
        }
    }
}
