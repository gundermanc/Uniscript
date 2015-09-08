//----------------------------------------------------------------------- 
// <copyright file="IUniError.cs" company="Gundersoft"> 
//     Copyright (c) Christian Gunderman. All rights reserved. 
// </copyright> 
// <author>Christian Gunderman</author> 
//-----------------------------------------------------------------------

namespace Uniscript.Errors
{
    /// <summary>
    /// Error object interface.
    /// </summary>
    public interface IUniError
    {
        /// <summary>
        /// Gets the line number where this error occurred.
        /// </summary>
        int Line { get; }

        /// <summary>
        /// Gets the message for the error.
        /// </summary>
        string Message { get; }

        /// <summary>
        /// Gets the unique error code.
        /// </summary>
        int Code { get; }
    }
}
