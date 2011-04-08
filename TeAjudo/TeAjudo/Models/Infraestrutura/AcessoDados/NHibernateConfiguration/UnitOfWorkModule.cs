using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeAjudo.Models.Infraestrutura.AcessoDados.NHibernateConfiguration
{
    public class UnitOfWorkModule : IHttpModule
    {
        public void Init(HttpApplication context)
        {
            context.BeginRequest += context_BeginRequest;
            context.EndRequest += context_EndRequest;
        }

        private void context_BeginRequest(object sender, EventArgs e)
        {
            var instance = IoC.StructureMapBootstrapper.Resolve<IUnitOfWork>();
            instance.Begin();
        }

        public void Dispose()
        {
            //throw new NotImplementedException();
        }

        private void context_EndRequest(object sender, EventArgs e)
        {
            var instance = IoC.StructureMapBootstrapper.Resolve<IUnitOfWork>();
            try { instance.Commit(); }
            catch
            {
                instance.RollBack();
                throw;
            }
            finally { instance.Dispose(); }
        }
    }
}