﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace MicroNetCore.Probes.Core
{
    public sealed class HttpProbesMiddleware<TProbe>
        where TProbe : IProbe
    {
        private readonly RequestDelegate _next;
        private readonly string _path;
        private readonly IEnumerable<TProbe> _probes;

        public HttpProbesMiddleware(RequestDelegate next, IServiceProvider serviceProvider, string path)
        {
            _next = next;
            _probes = serviceProvider.GetServices<TProbe>();
            _path = path;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (IsProbeRequest(context, _path))
            {
                try
                {
                    var tasks = _probes.Select(async p => await p.ProbeAsync());
                    var results = await Task.WhenAll(tasks);

                    context.Response.StatusCode = results.All(r => r)
                        ? (int) HttpStatusCode.OK
                        : (int) HttpStatusCode.ServiceUnavailable;
                }
                catch
                {
                    context.Response.StatusCode = (int) HttpStatusCode.ServiceUnavailable;
                }
            }
            else
            {
                await _next(context);
            }
        }

        private static bool IsProbeRequest(HttpContext context, string path)
        {
            return string.Equals(path, context.Request.Path, StringComparison.OrdinalIgnoreCase);
        }
    }
}