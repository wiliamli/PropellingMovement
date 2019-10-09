
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;

namespace Jwell.PropellingMovement.DependencyContainer
{
    public class NInjectDependencyResolver : NInjectScope, IDependencyResolver
    { 

        private readonly IKernel _kernel;

        /// <summary>
        /// Get Kernel value 
        /// </summary>
        public IKernel Container
        {
            get { return _kernel; }
        }


        /// <summary>
        /// NInject dependency resolver class
        /// </summary>
        /// <param name="container">IKernel value</param>
        public NInjectDependencyResolver(IKernel container)
            : base(container)
        {
            _kernel = container;
        }

        /// <summary>
        /// Begin dependency scope
        /// </summary>
        /// <returns>IDependencyScope object</returns>
        public new IDependencyScope BeginScope()
        {
            return new NInjectScope(_kernel);
        }

    }
}