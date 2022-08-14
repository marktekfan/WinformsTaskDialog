﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

/*=============================================================================
**
**
**
** Purpose: Exception class for null arguments to a method.
**
**
=============================================================================*/

using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace WinformsTaskDialog.BackportStubs
{
    // The ArgumentException is thrown when an argument
    // is null when it shouldn't be.
    [Serializable]
    [System.Runtime.CompilerServices.TypeForwardedFrom("mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")]
    public class ArgumentNullException : ArgumentException
    {
        private const int HResults_E_POINTER = unchecked((int)0x80004003);
        // Creates a new ArgumentNullException with its message
        // string set to a default message explaining an argument was null.
        public ArgumentNullException()
             : base("Value cannot be null.")
        {
            // Use E_POINTER - COM used that for null pointers.  Description is "invalid pointer"
            HResult = HResults_E_POINTER;
        }

        public ArgumentNullException(string? paramName)
            : base("Value cannot be null.", paramName)
        {
            HResult = HResults_E_POINTER;
        }

        public ArgumentNullException(string? message, Exception? innerException)
            : base(message, innerException)
        {
            HResult = HResults_E_POINTER;
        }

        public ArgumentNullException(string? paramName, string? message)
            : base(message, paramName)
        {
            HResult = HResults_E_POINTER;
        }

        protected ArgumentNullException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        /// <summary>Throws an <see cref="ArgumentNullException"/> if <paramref name="argument"/> is null.</summary>
        /// <param name="argument">The reference type argument to validate as non-null.</param>
        /// <param name="paramName">The name of the parameter with which <paramref name="argument"/> corresponds.</param>
        public static void ThrowIfNull([NotNull] object? argument, [CallerArgumentExpression("argument")] string? paramName = null)
        {
            if (argument is null)
            {
                throw new ArgumentNullException(paramName);
            }
        }

        /// <summary>Throws an <see cref="ArgumentNullException"/> if <paramref name="argument"/> is null.</summary>
        /// <param name="argument">The pointer argument to validate as non-null.</param>
        /// <param name="paramName">The name of the parameter with which <paramref name="argument"/> corresponds.</param>
        //BP [CLSCompliant(false)]
        public static unsafe void ThrowIfNull([NotNull] void* argument, [CallerArgumentExpression("argument")] string? paramName = null)
        {
            if (argument is null)
            {
                throw new ArgumentNullException(paramName);
            }
        }

        /// <summary>Throws an <see cref="ArgumentNullException"/> if <paramref name="argument"/> is null.</summary>
        /// <param name="argument">The pointer argument to validate as non-null.</param>
        /// <param name="paramName">The name of the parameter with which <paramref name="argument"/> corresponds.</param>
        internal static unsafe void ThrowIfNull(IntPtr argument, [CallerArgumentExpression("argument")] string? paramName = null)
        {
            if (argument == IntPtr.Zero)
            {
                throw new ArgumentNullException(paramName);
            }
        }
    }
}