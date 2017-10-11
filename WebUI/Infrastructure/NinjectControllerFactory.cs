using System;
using System.Web.Mvc;
using System.Web.Routing;
using Ninject;
using Moq;
using Domain.Abstract;
using Domain.Entities;
using System.Collections.Generic;
using System.Linq;

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
            Mock<IExhibitRepository> mock = new Mock<IExhibitRepository>();
            mock.Setup(m => m.Exhibits).Returns(new List<Exhibit>{
                new Exhibit {Name="T-34-85", Category ="Средние танки" },
                 new Exhibit {Name="ИС", Category ="Тяжелые танки" }
            }.AsQueryable());
            ninjectKernel.Bind<IExhibitRepository>().ToConstant(mock.Object);
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)  {
            return controllerType == null ? null: (IController)ninjectKernel.Get(controllerType);
        }

    }

   
}