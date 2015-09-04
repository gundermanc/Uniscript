//----------------------------------------------------------------------- 
// <copyright file="UniSymbolTable.cs" company="Gundersoft"> 
//     Copyright (c) Christian Gunderman. All rights reserved. 
// </copyright> 
// <author>Christian Gunderman</author> 
//-----------------------------------------------------------------------

namespace Uniscript
{
    using System;

    /// <summary>
    /// The default symbol table implementation.
    /// </summary>
    /// <typeparam name="TValue">The type for the symbol table values.</typeparam>
    internal class UniSymbolTable<TValue> : IUniSymbolTable<TValue>
    {
        /// <summary>
        /// Gets the current depth of the symbol table.
        /// </summary>
        public int Depth
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Gets or sets a value in the symbol table. By default, adds the item to the
        /// top of the stack of tables and gets the values from the first table in the
        /// stack that has the item.
        /// </summary>
        /// <exception cref="UniKeyNotFoundException">
        /// Thrown if the specified key cannot be found in the symbol table.
        /// </exception>
        /// <exception cref="UniKeyExistsException">
        /// Thrown if the specified key already exists in the symbol table.
        /// </exception>
        /// <param name="key">The key to lookup in the symbol table.</param>
        /// <param name="fromTopOnly">If true, checks only the top table.</param>
        /// <returns>The value from the first scope that defines the key.</returns>
        public TValue this[string key, bool fromTopOnly = false]
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Pushes a new level on to the symbol table.
        /// </summary>
        public void Push()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Pops the top level from the symbol table.
        /// </summary>
        /// <exception cref="InvalidOperationException">
        /// Thrown if there is only one table remaining.
        /// </exception>
        public void Pop()
        {
            throw new NotImplementedException();
        }
    }
}
