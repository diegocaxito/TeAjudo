using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using TeAjudo.Models.Infraestrutura.IoC;

namespace TeAjudo
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }

        protected void Application_Start()
        {
            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
            AreaRegistration.RegisterAllAreas();

            ControllerBuilder.Current.SetControllerFactory(new StructureMapControllerFactory());
            StructureMapBootstrapper.Initialize();
            Models.Infraestrutura.Mapeamento.ConfiguracaoAutoMapper.Configurar();
        }

        protected void Application_AuthenticateRequest()
        {
            var authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            if (authCookie != null)
            {
                var authTicket = FormsAuthentication.Decrypt(authCookie.Value);

                var genericIdentity = new GenericIdentity(authTicket.Name, "Custom");
                var roles = new[] { authTicket.UserData };
                var genericPrincipal = new GenericPrincipal(genericIdentity, roles);

                Context.User = genericPrincipal;
            }
        }
    }
}