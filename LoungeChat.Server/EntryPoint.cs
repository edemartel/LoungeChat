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

namespace LoungeChat.Server {
    using Castle.Core.Logging;
    using Castle.Windsor;
    using Castle.Windsor.Installer;

    public class EntryPoint {
        private readonly IExtendedLogger _logger;

        public EntryPoint(IExtendedLogger logger) {
            _logger = logger;
        }

        public void Run(string[] args) {
            _logger.Info("Hello");
        }

        #region Bootstrapping

        private static IWindsorContainer Bootstrap() {
            var ioc = new WindsorContainer();
            ioc.Install(FromAssembly.This());
            return ioc;
        }

        public static void Main(string[] args) {
            using (var ioc = Bootstrap()) {
                var self = ioc.Resolve<EntryPoint>();
                self.Run(args);
            }
        }

        #endregion
    }
}
