using System;
using Autofac;
using chatapp_server.CommandBus;
using chatapp_server.CommandHandlers;

namespace chatapp_server.Container.ContainerModules
{
    public class CommandModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterAssemblyTypes(ThisAssembly)
                .Where(x => x.IsAssignableTo<IHandleCommand>())
                .AsImplementedInterfaces();

            builder.Register<Func<Type, IHandleCommand>>(c =>
            {
                var ctx = c.Resolve<IComponentContext>();

                return t =>
                {
                    var handlerType = typeof(IHandleCommandG<>)
                        .MakeGenericType(t);
                    return (IHandleCommand) ctx.Resolve(handlerType);
                };
            });

            builder.RegisterType<CommandBus.CommandBus>()
                .AsImplementedInterfaces();
        }

    }
}
