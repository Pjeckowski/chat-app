using System.Collections.Generic;
using System.Windows;
using Autofac;
using chatapp_server.Container;
using chatapp_server.Container.ContainerModules;
using chatapp_server.Servers;


namespace chatapp_server
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Server Server;
        private IContainer container;
        private IMyContainerBuilder MyContainerBuilder;
        private List<Module> Modules;
        public MainWindow()
        {
            InitializeComponent();

            MyContainerBuilder = new MyContainerBuilder();

            Modules = new List<Module>();
            Modules.Add(new CommandModule());
            Modules.Add(new RepositoryModule());
            Modules.Add(new SerializerModule());
            Modules.Add(new ServerModule());

            container = MyContainerBuilder.BuildContainer(Modules);

            Server = container.Resolve<Server>();
            if (Server.ServerStart())
            {
                TestLabel.Content = "Dziala";
            }
            
        }
    }
}
