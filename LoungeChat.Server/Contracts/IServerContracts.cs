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

    [ContractClassFor(typeof(IServer))]
    // ReSharper disable once InconsistentNaming
    public abstract class IServerContracts : IServer {
        #region Implementation of IServer

        public void BindTo(string ip, int port) {
            Contract.Requires<ArgumentNullException>(!string.IsNullOrEmpty(ip), "IP must not be empty.");
            Contract.Requires<ArgumentOutOfRangeException>(port > 0 && port < 65536, "Port must be in range (0; 65536).");
        }

        public void Start() {
        }

        #endregion
    }
}
