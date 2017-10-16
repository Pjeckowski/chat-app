using Autofac;
using chatapp_server.Servers;

namespace chatapp_server.Container.ContainerModules
{
    public class ServerModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<Server>()
                .SingleInstance();
        }
    }
}
