//----------------------------------------------------------------------- 
// <copyright file="UniSymbolTable.cs" company="Gundersoft"> 
//     Copyright (c) Christian Gunderman. All rights reserved. 
// </copyright> 
// <author>Christian Gunderman</author> 
//-----------------------------------------------------------------------

namespace Uniscript
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// The default symbol table implementation. Symbol table is constructed of sub-scopes.
    /// Each sub-scope encompasses the current scope as well as all of the scopes above it.
    /// </summary>
    /// <typeparam name="TValue">The type for the symbol table values.</typeparam>
    internal class UniSymbolTable<TValue> : IUniSymbolTable<TValue>
    {
        /// <summary>
        /// Stack of dictionaries in the symbol table. Each dictionary represents a new level
        /// of scope. Each scope encompasses the scope above it as well.
        /// </summary>
        private readonly Stack<Dictionary<string, TValue>> tableStack
            = new Stack<Dictionary<string, TValue>>();

        /// <summary>
        /// Initializes new instance of the <see cref="UniSymbolTable{TValue}"/>.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules",
            "SA1642:ConstructorSummaryDocumentationMustBeginWithStandardText",
            Justification = "StyleCop is incorrectly reading the text here.")]
        public UniSymbolTable()
        {
            // Push default table. Symbol table ALWAYS has at least one.
            this.Push();
        }

        /// <summary>
        /// Gets the current depth of the symbol table.
        /// </summary>
        public int Depth
        {
            get
            {
                return this.tableStack.Count;
            }
        }

        /// <summary>
        /// Gets or sets a value in the symbol table. By default, adds the item to the
        /// top of the stack of tables and gets the values from the first table in the
        /// stack that has the item.
        /// </summary>
        /// <exception cref="UniKeyNotFoundException">
        /// Thrown during get if the specified key cannot be found in the symbol table.
        /// </exception>
        /// <exception cref="UniKeyExistsException">
        /// Thrown during set if the specified key already exists in the symbol table.
        /// </exception>
        /// <param name="key">The key to lookup in the symbol table.</param>
        /// <param name="fromTopOnly">If true, checks only the top table.</param>
        /// <returns>The value from the first scope that defines the key.</returns>
        public TValue this[string key, bool fromTopOnly = false]
        {
            get
            {
                key.AssertNotNullOrEmptyOrWhitespace(nameof(key));

                // Iterate through each of the scopes.
                foreach (var table in this.tableStack)
                {
                    TValue value;

                    if (table.TryGetValue(key, out value))
                    {
                        return value;
                    }

                    // If only checking top scope, break to the exception.
                    if (fromTopOnly)
                    {
                        break;
                    }
                }

                // Key doesn't exist in any of the scopes.
                throw new UniKeyNotFoundException(key);
            }

            set
            {
                key.AssertNotNullOrEmptyOrWhitespace(nameof(key));
                value.AssertNotNull(nameof(value));

                var table = this.tableStack.Peek();

                // Key already exists and we do not allow replacing keys.
                if (table.ContainsKey(key))
                {
                    throw new UniKeyExistsException(key);
                }

                table.Add(key, value);
            }
        }

        /// <summary>
        /// Pushes a new level on to the symbol table.
        /// </summary>
        public void Push()
        {
            this.tableStack.Push(new Dictionary<string, TValue>());
        }

        /// <summary>
        /// Pops the top level from the symbol table.
        /// </summary>
        /// <exception cref="InvalidOperationException">
        /// Thrown if the default context is the only remaining context in the stack.
        /// In other words, there is only one table remaining.
        /// </exception>
        public void Pop()
        {
            // Disallow popping default context.
            if (this.Depth == 1)
            {
                throw new UniNoMoreContextsException();
            }

            this.tableStack.Pop();
        }
    }
}
