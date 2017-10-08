using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;

namespace chatapp_server.Container
{
    public interface IMyContainerBuilder
    {
        IContainer BuildContainer(List<Module> modules);
    }
}
