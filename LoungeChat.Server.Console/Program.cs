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

namespace LoungeChat.Server.Console {
    using System;

    using Castle.Windsor;
    using Castle.Windsor.Installer;

    using Services;

    internal static class Program {
        private static IWindsorContainer Bootstrap() {
            var ioc = new WindsorContainer();
            ioc.Install(FromAssembly.This());
            return ioc;
        }

        private static void Run(IWindsorContainer ioc, string[] args) {
            var server = ioc.Resolve<IServer>();
            var ip = "127.0.0.1";
            var port = 5222;

            if (args.Length >= 1) {
                ip = args[0];
            }

            if (args.Length >= 2) {
                port = Convert.ToInt32(args[1]);
            }

            server.BindTo(ip, port);
            server.Start();
        }

        private static void Main(string[] args) {
            using (var ioc = Bootstrap()) {
                Run(ioc, args);
            }
        }
    }
}
