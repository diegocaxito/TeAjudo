using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;

namespace TeAjudo.Apresentacao.Atributos
{
    public class AutoMapAttribute : ActionFilterAttribute
    {
        private readonly Type _destType;
		private readonly Type _sourceType;

        public AutoMapAttribute(Type sourceType, Type destType)
		{
			_sourceType = sourceType;
			_destType = destType;
		}

		public override void OnActionExecuted(ActionExecutedContext filterContext)
		{
			object model = filterContext.Controller.ViewData.Model;

			object viewModel = Mapper.Map(model, _sourceType, _destType);

			filterContext.Controller.ViewData.Model = viewModel;
		}
    }
}