//----------------------------------------------------------------------- 
// <copyright file="UniToken.cs" company="Gundersoft"> 
//     Copyright (c) Christian Gunderman. All rights reserved. 
// </copyright> 
// <author>Christian Gunderman</author> 
//-----------------------------------------------------------------------

namespace Uniscript.Tokens
{
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Basic token class implementation.
    /// </summary>
    /// <typeparam name="TValue">The type of the value stored within.</typeparam>
    public class UniToken<TValue> : IUniToken<TValue>
    {
        /// <summary>
        /// Stores the type readonly.
        /// </summary>
        private readonly UniTokenType type;

        /// <summary>
        /// Stores the value readonly.
        /// </summary>
        private readonly TValue value;

        /// <summary>
        /// Initializes a new instance of the <see cref="UniToken{TValue}"/>
        /// </summary>
        /// <param name="type">The type of the token.</param>
        /// <param name="value">The value stored within the token.</param>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", 
            "SA1642:ConstructorSummaryDocumentationMustBeginWithStandardText",
            Justification = "StyleCop is incorrectly reading the text here.")]
        public UniToken(UniTokenType type, TValue value)
        {
            this.type = type;
            this.value = value;
        }

        /// <summary>
        /// Gets the token's type.
        /// </summary>
        public UniTokenType Type
        {
            get
            {
                return this.type;
            }
        }

        /// <summary>
        /// Gets the token's value.
        /// </summary>
        public TValue Value
        {
            get
            {
                return this.value;
            }
        }
    }
}
