﻿using Microsoft.Extensions.FileProviders;
using System.IO;

namespace Microsoft.AspNetCore.Builder
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseNodeModules(this IApplicationBuilder app, string root)
        {
            string path = Path.Combine(root, "node_modules");
            var fileProvider = new PhysicalFileProvider(path);
                
            StaticFileOptions options = new StaticFileOptions
            {
                RequestPath = "/node_modules",
                FileProvider = fileProvider
            };

            app.UseStaticFiles(options);

            return app;
        }
    }
}
