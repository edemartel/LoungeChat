#region Apache License 2.0

// Copyright 2013 Lounge<Chat> Team
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//   http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License. 

#endregion

namespace LoungeChat.Server.Contracts {
    using System;
    using System.Diagnostics.Contracts;

    using Services;

    // ReSharper disable once InconsistentNaming
    [ContractClassFor(typeof(ILog))]
    public abstract class ILogContracts : ILog {
        #region Implementation of ILog

        public void Debug(string format, params object[] args) {
            Contract.Requires<ArgumentNullException>(!string.IsNullOrEmpty(format), "Format string cannot be null or empty.");
        }

        public void Debug(Exception exception, string format, params object[] args) {
            Contract.Requires<ArgumentNullException>(!string.IsNullOrEmpty(format), "Format string cannot be null or empty.");
            Contract.Requires<ArgumentNullException>(exception != null, "Exception object cannot be null or empty.");
        }

        public void Info(string format, params object[] args) {
            Contract.Requires<ArgumentNullException>(!string.IsNullOrEmpty(format), "Format string cannot be null or empty.");
        }

        public void Info(Exception exception, string format, params object[] args) {
            Contract.Requires<ArgumentNullException>(!string.IsNullOrEmpty(format), "Format string cannot be null or empty.");
            Contract.Requires<ArgumentNullException>(exception != null, "Exception object cannot be null or empty.");
        }

        public void Warning(string format, params object[] args) {
            Contract.Requires<ArgumentNullException>(!string.IsNullOrEmpty(format), "Format string cannot be null or empty.");
        }

        public void Warning(Exception exception, string format, params object[] args) {
            Contract.Requires<ArgumentNullException>(!string.IsNullOrEmpty(format), "Format string cannot be null or empty.");
            Contract.Requires<ArgumentNullException>(exception != null, "Exception object cannot be null or empty.");
        }

        public void Error(string format, params object[] args) {
            Contract.Requires<ArgumentNullException>(!string.IsNullOrEmpty(format), "Format string cannot be null or empty.");
        }

        public void Error(Exception exception, string format, params object[] args) {
            Contract.Requires<ArgumentNullException>(!string.IsNullOrEmpty(format), "Format string cannot be null or empty.");
            Contract.Requires<ArgumentNullException>(exception != null, "Exception object cannot be null or empty.");
        }

        public void Fatal(string format, params object[] args) {
            Contract.Requires<ArgumentNullException>(!string.IsNullOrEmpty(format), "Format string cannot be null or empty.");
        }

        public void Fatal(Exception exception, string format, params object[] args) {
            Contract.Requires<ArgumentNullException>(!string.IsNullOrEmpty(format), "Format string cannot be null or empty.");
            Contract.Requires<ArgumentNullException>(exception != null, "Exception object cannot be null or empty.");
        }

        #endregion
    }
}
