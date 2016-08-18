using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.Extensions.Primitives;

namespace CustomRouteAttributes.Routing
{
    using Prevent;

    public class CustomHttpHeaderActionConstraint : IActionConstraint
    {
        private readonly string headerName;
        private readonly string headerValue;

        public CustomHttpHeaderActionConstraint(string headerName, string headerValue)
        {
            Prevent.NullOrWhiteSpaceString(headerName, nameof(headerName));
            Prevent.NullObject(headerValue, nameof(headerValue));

            this.headerName = headerName;
            this.headerValue = headerValue;
        }

        public bool Accept(ActionConstraintContext context)
        {
            var values = GetCustomHeaderValues(context.RouteContext.HttpContext.Request, this.headerName);
            return values.Any(value => string.Equals(value, this.headerValue, StringComparison.OrdinalIgnoreCase));
        }

        public int Order { get; set; }

        private static List<string> GetCustomHeaderValues(HttpRequest request, string headerName)
        {
            StringValues headerValues;
            request.Headers.TryGetValue(headerName, out headerValues);
            return headerValues.ToString().Split(',').Select(x => x.Trim()).ToList();
        }
    }
}
