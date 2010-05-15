using System;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using StructureMap;
using StructureMap.Configuration;
using StructureMap.Pipeline;
using System.Web.Routing;

namespace WebUI
{
    public class StructureMapControllerFactory
        : DefaultControllerFactory
    {
        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            try
            {
                return ObjectFactory.GetInstance(controllerType) as Controller;
            }
            catch (StructureMapException)
            {
                System.Diagnostics.Debug.WriteLine(ObjectFactory.WhatDoIHave());
                throw;
            }
        }
    }
}
