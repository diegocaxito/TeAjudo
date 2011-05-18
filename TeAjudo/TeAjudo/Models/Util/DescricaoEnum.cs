using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Reflection;
using System.ComponentModel;

namespace TeAjudo.Models.Util
{
    public static class DescricaoEnum
    {
        public static string PegarDescricao(this Enum enumerador)
        {
            string description = String.Empty;
            DescriptionAttribute da;

            FieldInfo fi = enumerador.GetType().
                        GetField(enumerador.ToString());
            da = (DescriptionAttribute)Attribute.GetCustomAttribute(fi,
                        typeof(DescriptionAttribute));
            if (da != null)
                description = da.Description;
            else
                description = enumerador.ToString();

            return description; 
        }
    }
}