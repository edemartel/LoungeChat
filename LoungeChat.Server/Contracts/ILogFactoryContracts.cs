using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoungeChat.Server.Contracts {
    using System.Diagnostics.Contracts;

    using Services;

    // ReSharper disable once InconsistentNaming
    [ContractClassFor(typeof(ILogFactory))]
    class ILogFactoryContracts : ILogFactory {
        #region Implementation of ILogFactory

        public ILog Create(Type type) {
            Contract.Requires<ArgumentNullException>(type != null, "Type argument cannot be null.");
            Contract.Requires<ArgumentNullException>(!type.IsInterface, "Type given must be a class.");
            
            return null;
        }

        public ILog Create(string name) {
            Contract.Requires<ArgumentNullException>(!string.IsNullOrEmpty(name), "Logger name cannot be null or empty.");

            return null;
        }

        #endregion
    }
}
