using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StructureMap;
using StructureMap.Configuration;
using StructureMap.Configuration.DSL;

namespace TeAjudo.Models.Infraestrutura.IoC
{
    public class StructureMapBootstrapper
    {
        public static void Initialize() {
            ObjectFactory.Initialize(
                x => {
                    x.AddRegistry(new NHibernateStructureMap());
                    x.AddRegistry(new RepositoriosStructureMap());
                });
        }
    }
}