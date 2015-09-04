//----------------------------------------------------------------------- 
// <copyright file="UniKeyExistsException.cs" company="Gundersoft"> 
//     Copyright (c) Christian Gunderman. All rights reserved. 
// </copyright> 
// <author>Christian Gunderman</author> 
//-----------------------------------------------------------------------

namespace Uniscript
{
    /// <summary>
    /// The given key already exists in symbol table exception.
    /// </summary>
    public sealed class UniKeyExistsException : UniException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UniKeyExistsException"/>
        /// class.
        /// </summary>
        /// <param name="key">The key that already exists.</param>
        public UniKeyExistsException(string key)
            : base(string.Format("\"{0}\" key already exists in current scope in SymbolTable."))
        {
        }
    }
}
