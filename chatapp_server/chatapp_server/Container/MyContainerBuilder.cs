using System.Collections.Generic;
using Autofac;

namespace chatapp_server.Container
{
    public class MyContainerBuilder : IMyContainerBuilder
    {
        private ContainerBuilder builder;

        public MyContainerBuilder()
        {
            if (null == builder)
            {
                builder = new ContainerBuilder();
            }
        }
        public IContainer BuildContainer(List<Module> modules)
        {
            foreach (Module module in modules)
            {
                builder.RegisterModule(module);
            }
            return builder.Build();
        }
    }
}
