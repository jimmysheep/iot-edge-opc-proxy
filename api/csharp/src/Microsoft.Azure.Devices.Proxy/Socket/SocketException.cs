// ------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All rights reserved.
//  Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

namespace Microsoft.Azure.Devices.Proxy {
    using System;

    public class SocketException : System.Net.Sockets.SocketException {

        public SocketError Error { get; private set; }

        internal string _message;
        public override string Message => _message; 

        internal Exception _innerException;
        public new Exception InnerException => _innerException; 

        public SocketException(string message, Exception e,
            SocketError errorCode)
            : base() {
            Error = errorCode;
            _message = message;
            _innerException = e;
        }

        public SocketException(string message, Exception e) 
            : this(message, e, SocketError.Fatal) {
        }

        public SocketException(string message, SocketError errorCode = SocketError.Fatal)
            : this(message, null, errorCode) {
        }

        public SocketException(SocketError errorCode)
            : this(errorCode.ToString(), errorCode) {
        }

        public SocketException(Exception e)
            : this(e.ToString(), e) {
        }

        public SocketException(AggregateException e)
            : this(e.GetCombinedExceptionMessage(), e) {
        }

        public SocketException(string message, AggregateException e, SocketError errorCode = SocketError.Fatal)
            : this(message, (Exception)e?.Flatten(), errorCode) {
        }
    }
}
