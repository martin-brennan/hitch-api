﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace hitch
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            config.Formatters.Remove(config.Formatters.XmlFormatter);
            // Web API routes
            config.MapHttpAttributeRoutes();
        }
    }
}