using System;
using System.Web.Mvc;
using System.Web.Routing;

namespace TeAjudo.Models.Infraestrutura.IoC
{
    public class StructureMapControllerFactory : DefaultControllerFactory
    {
        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            if (controllerType == null)
                return null;

            var controller = StructureMapBootstrapper.Resolve(controllerType);

            return controller as IController;
        }
    }
}