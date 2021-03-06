﻿#region Apache License 2.0

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
    using System.Diagnostics.Contracts;

    using Castle.Core;
    using Castle.MicroKernel;
    using Castle.MicroKernel.Context;

    using Services;

    public sealed class LogResolver : ISubDependencyResolver {
        private readonly ILogFactory _factory;

        #region Implementation of ISubDependencyResolver

        public LogResolver(ILogFactory factory) {
            _factory = factory;
        }

        private bool CanResolve(DependencyModel dependency) {
            return dependency.TargetType == typeof(ILog);
        }

        private object Resolve(ComponentModel model, DependencyModel dependency) {
            Contract.Requires(CanResolve(dependency), "Resolve() called on an unresolvable type.");
            return _factory.Create(model.Implementation);
        }

        public bool CanResolve(
            CreationContext context,
            ISubDependencyResolver resolver,
            ComponentModel model,
            DependencyModel dependency) {
            return CanResolve(dependency);
        }

        public object Resolve(
            CreationContext context,
            ISubDependencyResolver resolver,
            ComponentModel model,
            DependencyModel dependency) {
            return Resolve(model, dependency);
        }

        #endregion
    }
}
