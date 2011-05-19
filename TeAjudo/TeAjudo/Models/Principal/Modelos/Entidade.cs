using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeAjudo.Models.Principal.Modelos
{
    public abstract class Entidade
    {
        public virtual Guid Id { get; set; }

        public virtual bool IsPersistent
        {
            get { return !IsTransient(); }
        }

        public override bool Equals(object obj)
        {
            if (!IsTransient())
            {
                var persistentObject = obj as Entidade;
                return (persistentObject != null) && (Id == persistentObject.Id);
            }

            return base.Equals(obj);
        }

        public static bool operator ==(Entidade left, Entidade right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Entidade left, Entidade right)
        {
            return !Equals(left, right);
        }

        public override int GetHashCode()
        {
            // When this instance is transient, we use the base GetHashCode()
            // and remember it, so an instance can NEVER change its hash code.
            if (IsTransient())
            {
                return base.GetHashCode();
            }

            return Id.GetHashCode();
        }

        private bool IsTransient()
        {
            return Equals(Id, Guid.Empty);
        }
    }
}