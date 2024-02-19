using ImageResizeFunction.Services;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImageResizeFunction
{
    [assembly: FunctionsStartup(typeof(ImageResizeFunction.Startup))]
    public class Startup : FunctionsStartup 
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddSingleton<IImageResizer, ImageResizer>();
        }
    }
}
