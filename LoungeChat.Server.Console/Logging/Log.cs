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

namespace LoungeChat.Server.Console.Logging {
    using System;

    using NLog;

    using Services;

    public sealed class Log : ILog {
        private readonly Logger _logger;

        public Log(string name) {
            _logger = LogManager.GetLogger(name);
        }

        public Log() {
            _logger = LogManager.GetLogger("");
        }

        private void DoLogging(LogLevel level, Exception exception, string format, params object[] args) {
            if (!_logger.IsEnabled(level)) {
                return;
            }

            var message = string.Format(format, args);

            if (exception == null) {
                _logger.Log(level, message);
            } else {
                _logger.LogException(level, message, exception);
            }
        }

        #region Implementation of ILog

        public void Debug(string format, params object[] args) {
            Debug(null, format, args);
        }

        public void Debug(Exception exception, string format, params object[] args) {
            DoLogging(LogLevel.Debug, exception, format, args);
        }

        public void Info(string format, params object[] args) {
            Info(null, format, args);
        }

        public void Info(Exception exception, string format, params object[] args) {
            DoLogging(LogLevel.Info, exception, format, args);
        }

        public void Warning(string format, params object[] args) {
            Warning(null, format, args);
        }

        public void Warning(Exception exception, string format, params object[] args) {
            DoLogging(LogLevel.Warn, exception, format, args);
        }

        public void Error(string format, params object[] args) {
            Error(null, format, args);
        }

        public void Error(Exception exception, string format, params object[] args) {
            DoLogging(LogLevel.Error, exception, format, args);
        }

        public void Fatal(string format, params object[] args) {
            Fatal(null, format, args);
        }

        public void Fatal(Exception exception, string format, params object[] args) {
            DoLogging(LogLevel.Fatal, exception, format, args);
        }

        #endregion
    }
}
