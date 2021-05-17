using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Atividade.Controllers
{
    public class ViewHelper : Controller
    {
        public string NameView(string viewName = null)
        {
            var controllerName = ControllerContext.ActionDescriptor.ControllerName;
            viewName ??= ControllerContext.ActionDescriptor.ActionName;

            return "~/Views/User/" + controllerName + "/" + viewName + ".cshtml";
        }
    }
}
