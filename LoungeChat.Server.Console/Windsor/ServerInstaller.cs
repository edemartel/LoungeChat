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
    using System;

    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Windsor;

    using Services;

    public sealed class ServerInstaller : IWindsorInstaller {
        private const string ComponentNamespace = "LoungeChat.Server.Components";

        private bool IsServerComponent(Type type) {
            return type.Namespace != null && type.Namespace.StartsWith(ComponentNamespace);
        }

        #region Implementation of IWindsorInstaller

        public void Install(IWindsorContainer container, IConfigurationStore store) {
            container.Register(
                Classes.FromAssemblyContaining<IServer>()
                       .Where(IsServerComponent)
                       .WithService.DefaultInterfaces());
        }

        #endregion
    }
}
