using System;
using System.Web.Mvc;
using System.Web.Routing;
using Ninject;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Domain.Abstract;
using Domain.Entities;
using Domain.Concrete; 

namespace WebUI.Infrastructure
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        private IKernel ninjectKernel;

        public NinjectControllerFactory() {
            ninjectKernel = new StandardKernel();
            AddBindings();

        }

        private void AddBindings()
        {
            ninjectKernel.Bind<IExhibitRepository>().To<EFExhibitRepository>();
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)  {
            return controllerType == null ? null: (IController)ninjectKernel.Get(controllerType);
        }

    }

   
}