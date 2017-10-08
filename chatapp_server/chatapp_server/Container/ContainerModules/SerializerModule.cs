using Autofac;
using chatapp_server.Serializer;

namespace chatapp_server.Container.ContainerModules
{
    public class SerializerModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<NewtonSerializer>()
                .AsImplementedInterfaces()
                .SingleInstance();
        }
    }
}
