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

namespace LoungeChat.Server.Components {
    using System;

    using Services;

    public class Server : IServer {
        private readonly ILog _logger;

        public Server(ILog logger) {
            _logger = logger;
        }

        private void Test() {
            throw new Exception("Abababa");
        }

        private void Test2() {
            try {
                Test();
            } catch (Exception e) {
                throw new Exception("blblblb", e);
            }
        }

        #region Implementation of IServer

        public void BindTo(string ip, int port) {
            _logger.Info("BindTo({0}, {1})", ip, port);
        }

        public void Start() {
            _logger.Debug("Debug");
            _logger.Info("Start()");
            _logger.Warning("Warning");
            _logger.Error("Error");
            _logger.Fatal("Fatal");
            try {
                Test();
            } catch (Exception e) {
                _logger.Error(e, "Exception1");
            }
            try {
                Test2();
            } catch (Exception e) {
                _logger.Error(e, "Exception2");
            }

        }

        #endregion
    }
}
