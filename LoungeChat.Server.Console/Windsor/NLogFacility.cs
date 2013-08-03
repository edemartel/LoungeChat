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

namespace LoungeChat.Server.Console.Windsor {
    using Castle.Facilities.Logging;
    using Castle.MicroKernel.Facilities;

    using NLog;
    using NLog.Config;
    using NLog.Targets;

    public class NLogFacility : AbstractFacility {
        protected override void Init() {
            Configure();
            Kernel.AddFacility<LoggingFacility>(
                f => f.LogUsing(LoggerImplementation.ExtendedNLog)
                      .ConfiguredExternally());
        }

        private void Configure() {
            var config = new LoggingConfiguration();
            var consoleTarget = new ColoredConsoleTarget {
                Layout = @"${date:format=HH\:mm\:ss} ${logger} ${message}"
            };

            config.AddTarget("console", consoleTarget);
            config.LoggingRules.Add(new LoggingRule("*", LogLevel.Debug, consoleTarget));

            // UGH GLOBALS
            LogManager.Configuration = config;
        }
    }
}
