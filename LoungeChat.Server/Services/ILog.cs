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

namespace LoungeChat.Server.Services {
    using System;
    using System.Diagnostics.Contracts;

    using Annotations;

    using Contracts;

    [ContractClass(typeof(ILogContracts))]
    public interface ILog {
        [StringFormatMethod("format")]
        void Debug(string format, params object[] args);

        [StringFormatMethod("format")]
        void Debug(Exception exception, string format, params object[] args);

        [StringFormatMethod("format")]
        void Info(string format, params object[] args);

        [StringFormatMethod("format")]
        void Info(Exception exception, string format, params object[] args);

        [StringFormatMethod("format")]
        void Warning(string format, params object[] args);

        [StringFormatMethod("format")]
        void Warning(Exception exception, string format, params object[] args);

        [StringFormatMethod("format")]
        void Error(string format, params object[] args);

        [StringFormatMethod("format")]
        void Error(Exception exception, string format, params object[] args);

        [StringFormatMethod("format")]
        void Fatal(string format, params object[] args);

        [StringFormatMethod("format")]
        void Fatal(Exception exception, string format, params object[] args);
    }
}
