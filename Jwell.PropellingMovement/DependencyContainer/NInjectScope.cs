﻿using Ninject.Activation;
using Ninject.Parameters;
using Ninject.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;

namespace Jwell.PropellingMovement.DependencyContainer
{
    public class NInjectScope: IDependencyResolver
    {
        private bool isDisposed = false;

        protected IResolutionRoot resolutionRoot;


        /// <summary>
        /// NInject scope class. Facilitator for resolver
        /// </summary>
        /// <param name="kernel">IResolutionRoot value</param>
        public NInjectScope(IResolutionRoot kernel)
        {
            resolutionRoot = kernel;
        }



        /// <summary>
        /// Get request based on a type
        /// </summary>
        /// <param name="serviceType">ServiceType value</param>
        /// <returns>IRequest object</returns>
        private IRequest GetRequest(Type serviceType)
        {
            return resolutionRoot.CreateRequest(serviceType, null, new Parameter[0], true, true);
        }

        /// <summary>
        /// Dispose object
        /// </summary>
        private void Dispose(bool disposing)
        {
            // Do clean up here
            if (!isDisposed)
            {
                if (disposing)
                {
                    if (resolutionRoot != null)
                    {
                        resolutionRoot = null;
                    }
                }
                isDisposed = true;
            }
        }

        /// <summary>
        /// Get services based on a type
        /// </summary>
        /// <param name="serviceType">ServiceType value</param>
        /// <returns>IRequest object</returns>
        public IEnumerable<object> GetServices(Type serviceType)
        {
            IRequest request = GetRequest(serviceType);
            return resolutionRoot.Resolve(request).ToList();
        }

        /// <summary>
        /// Get service based on a type
        /// </summary>
        /// <param name="serviceType">ServiceType value</param>
        /// <returns>Object value</returns>
        public object GetService(Type serviceType)
        {
            return GetServices(serviceType).SingleOrDefault();
        }

        /// <summary>
        /// Dispose object
        /// </summary>
        public void Dispose()
        {
            // Do clean up here
            Dispose(true);
        }

        /// <summary>
        /// Begin dependency scope
        /// </summary>
        /// <returns>IDependencyScope object</returns>
        public IDependencyScope BeginScope()
        {
            // Do begin scoping here 
            throw new NotImplementedException();
        }
    }
}