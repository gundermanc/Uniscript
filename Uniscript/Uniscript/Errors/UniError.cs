//----------------------------------------------------------------------- 
// <copyright file="UniError.cs" company="Gundersoft"> 
//     Copyright (c) Christian Gunderman. All rights reserved. 
// </copyright> 
// <author>Christian Gunderman</author> 
//-----------------------------------------------------------------------

namespace Uniscript.Errors
{
    using System;

    /// <summary>
    /// Defines the structure of errors.
    /// </summary>
    public struct UniError : IUniError
    {
        /// <summary>
        /// Stores the error message.
        /// </summary>
        private readonly string message;

        /// <summary>
        /// Stores the unique error code.
        /// </summary>
        private readonly int code;

        /// <summary>
        /// Stores the line on which the error occurred.
        /// </summary>
        private readonly int line;

        /// <summary>
        /// Initializes a new instance of the <see cref="UniError"/> struct.
        /// </summary>
        /// <param name="line">The line on which the error occurred.</param>
        /// <param name="code">The unique error code.</param>
        /// <param name="message">The message for this error.</param>
        private UniError(int line, int code, string message)
        {
            message.AssertNotNullOrEmptyOrWhitespace(nameof(message));

            if (line <= 0 || code <= 0)
            {
                throw new InvalidOperationException("Line and code must be greater than 0.");
            }

            this.line = line;
            this.code = code;
            this.message = message;
        }

        /// <summary>
        /// Gets the line number where this error occurred.
        /// </summary>
        public int Line
        {
            get
            {
                return this.line;
            }
        }

        /// <summary>
        /// Gets the message for the error.
        /// </summary>
        public string Message
        {
            get
            {
                return this.message;
            }
        }

        /// <summary>
        /// Gets the unique error code.
        /// </summary>
        public int Code
        {
            get
            {
                return this.code;
            }
        }
    }
}
