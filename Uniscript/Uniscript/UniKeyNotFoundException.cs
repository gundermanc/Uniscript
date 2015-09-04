//----------------------------------------------------------------------- 
// <copyright file="UniKeyNotFoundException.cs" company="Gundersoft"> 
//     Copyright (c) Christian Gunderman. All rights reserved. 
// </copyright> 
// <author>Christian Gunderman</author> 
//-----------------------------------------------------------------------

namespace Uniscript
{
    /// <summary>
    /// The given key was not found in 
    /// </summary>
    public sealed class UniKeyNotFoundException : UniException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UniKeyNotFoundException"/>
        /// class.
        /// </summary>
        /// <param name="key">The key that could not be found.</param>
        public UniKeyNotFoundException(string key)
            : base(string.Format("\"{0}\" key cannot be found in SymbolTable."))
        {
        }
    }
}
