using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using StructureMap;
using StructureMap.Configuration;
using StructureMap.Configuration.DSL;

namespace TeAjudo.Models.Infraestrutura.IoC
{
    public class StructureMapBootstrapper
    {
        private static bool dependenciesRegistered;
        private static readonly object sync = new object();

        public static void Initialize() {
            ObjectFactory.Initialize(x => { 
                x.AddRegistry(new NHibernateRegistry());
                x.AddRegistry(new RepositoriosRegistry());
                x.AddRegistry(new ServicosRegistry());
            });
        }

        public static TInstance With<TWith, TInstance>(TWith o)
        {
            return ObjectFactory.With(o).GetInstance<TInstance>();
        }

        public static T Resolve<T>()
        {
            return ObjectFactory.GetInstance<T>();
        }

        public static T Resolve<T>(string name)
        {
            return ObjectFactory.GetNamedInstance<T>(name);
        }

        public static object Resolve(Type modelType)
        {
            return ObjectFactory.GetInstance(modelType);
        }

        public static bool Registered<T>()
        {
            EnsureDependenciesRegistered();
            return ObjectFactory.GetInstance<T>() != null;
        }

        public static bool Registered(Type type)
        {
            EnsureDependenciesRegistered();
            return ObjectFactory.GetInstance(type) != null;
        }

        public static void EnsureDependenciesRegistered()
        {
            if (!dependenciesRegistered)
            {
                lock (sync)
                {
                    if (!dependenciesRegistered)
                    {
                        Initialize();
                        dependenciesRegistered = true;
                    }
                }
            }
        }
    }
}