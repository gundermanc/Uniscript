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
    public class UniToken : IUniToken
    {
        /// <summary>
        /// Stores the type readonly.
        /// </summary>
        private readonly UniTokenType type;

        /// <summary>
        /// Stores the value readonly.
        /// </summary>
        private readonly object value;

        /// <summary>
        /// Initializes a new instance of the <see cref="UniToken{TValue}"/>
        /// </summary>
        /// <param name="type">The type of the token.</param>
        /// <param name="value">The value stored within the token.</param>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", 
            "SA1642:ConstructorSummaryDocumentationMustBeginWithStandardText",
            Justification = "StyleCop is incorrectly reading the text here.")]
        public UniToken(UniTokenType type, object value)
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
        /// Gets the value of this token.
        /// </summary>
        /// <typeparam name="TValue">
        /// The desired return type.
        /// </typeparam>
        /// <exception cref="InvalidOperationException">
        /// Value is of a different type.
        /// </exception>
        /// <returns>The value in the desired return type.</returns>
        public TValue GetValue<TValue>()
        {
            // Check value is the type expected by the caller.
            if (this.value.GetType() != typeof(TValue))
            {
                throw new UniInvalidTokenTypeException();
            }

            return (TValue)this.value;
        }
    }
}
