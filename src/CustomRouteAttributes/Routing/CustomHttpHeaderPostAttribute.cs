using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.AspNetCore.Mvc.Routing;

namespace CustomRouteAttributes.Routing
{
    public class CustomHttpHeaderPostAttribute : RouteAttribute, IActionConstraintFactory, IActionHttpMethodProvider
    {
        private readonly CustomHttpHeaderActionConstraint constraint;

        public CustomHttpHeaderPostAttribute(string template, string headerName, string headerValue) 
            : base(template)
        {
            this.constraint = new CustomHttpHeaderActionConstraint(headerName, headerValue);
        }

        public CustomHttpHeaderPostAttribute(string headerName, string headerValue)
            : this(string.Empty, headerName, headerValue)
        {
            // Nothing to do...
        }

        public IActionConstraint CreateInstance(IServiceProvider services)
        {
            return this.constraint;
        }

        public bool IsReusable { get; } = false;

        public IEnumerable<string> HttpMethods { get; } = new[] {"POST"};
    }
}
