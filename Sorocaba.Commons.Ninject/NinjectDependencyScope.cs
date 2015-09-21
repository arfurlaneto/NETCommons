﻿using Ninject;
using Ninject.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Dependencies;

namespace Sorocaba.Commons.Ninject {
    public class NinjectDependencyScope : IDependencyScope {

        private IResolutionRoot resolver;

        public NinjectDependencyScope(IResolutionRoot resolver) {
            this.resolver = resolver;
        }

        public object GetService(Type serviceType) {
            if (resolver == null) {
                throw new ObjectDisposedException("this", "This scope has been disposed.");
            }
            return resolver.TryGet(serviceType);
        }

        public object GetNamedService(Type serviceType, string name) {
            if (resolver == null) {
                throw new ObjectDisposedException("this", "This scope has been disposed.");
            }
            return resolver.TryGet(serviceType, name);
        }

        public IEnumerable<object> GetServices(Type serviceType) {
            if (resolver == null) {
                throw new ObjectDisposedException("this", "This scope has been disposed.");
            }
            return resolver.GetAll(serviceType);
        }

        public void Dispose() {
            IDisposable disposable = resolver as IDisposable;
            if (disposable != null) {
                disposable.Dispose();
            }
            resolver = null;
        }
    }
}
