using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using chatapp_server.Repositories.ChatRoomRepositories;
using chatapp_server.Repositories.UserRepositories;

namespace chatapp_server.Container.ContainerModules
{
    public class RepositoryModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<LocalUserRepository>()
                .AsImplementedInterfaces()
                .SingleInstance();

            builder.RegisterType<LocalChatRoomRepository>()
                .AsImplementedInterfaces()
                .SingleInstance();
        }
    }
}
