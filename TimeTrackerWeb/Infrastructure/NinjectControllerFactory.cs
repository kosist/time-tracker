using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using AutoMapper;
using BaseLayer.IRepositories;
using DbLayer.DbRepositories;
using Ninject;
using TimeTrackerWeb.Mapping;
using TimeTrackerWeb.Models;

namespace TimeTrackerWeb.Infrastructure
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        private IKernel ninjectKernel;
        private IMapper _mapper;

        public NinjectControllerFactory()
        {
            ninjectKernel = new StandardKernel();
            _mapper = AutoMapperWebConfiguration.WebMapper;
            AddBindings();
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return controllerType == null
                ? null
                : (IController) ninjectKernel.Get(controllerType);
        }

        private void AddBindings()
        {
            ninjectKernel.Bind<IUnitOfWork>().To<UnitOfWork>()
                .WithConstructorArgument("context", new ApplicationDbContext());
            
            ninjectKernel.Bind<IMapper>().ToConstant(_mapper).InSingletonScope();
        }
    }
}