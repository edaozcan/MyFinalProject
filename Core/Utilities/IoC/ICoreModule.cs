using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.IoC
{
    interface ICoreModule
    {
        void Load(IServiceCollection serviceCollection);
    }
}
