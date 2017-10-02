using System;
using System.Diagnostics;
using System.Reflection;
using System.Windows;
using Autofac;
using chatapp_client.Commands;
using chatapp_client.Handlers;
using Newtonsoft.Json;

namespace chatapp_client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
        Client Client;
        private IContainer AutContainer;

        public MainWindow()
        {
            InitializeComponent();

            Client = new Client();
            Client.MessageReceived += Client_MessageReceived;
            LetsPLayWithThisShiet();
            //DoSomething();

        }

        void Client_MessageReceived(string Message)
        {
            throw new NotImplementedException();
        }

        private void Connect_Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(Client.Connect("127.0.0.1", 36000));
        }

        private void DoSomething()
        {
            ICommand lel = new Register()
            {
                Name = "LOL",
                Password = "Kol"
            };

            var JsonSettings = new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.All
            };

            string json = JsonConvert.SerializeObject(lel, JsonSettings);
            Debug.WriteLine(json);

            //ICommand lelDS = JsonConvert.DeserializeObject<ICommand>(json, JsonSettings);
            //Debug.WriteLine(lelDS.ToString());


        }
        //{"$type":"chatapp_client.Register, chatapp_client","Name":"LOL","Password":"Kol"}

        private async void LetsPLayWithThisShiet()
        {
            var builder = new ContainerBuilder();

             //Register individual components

            builder.RegisterAssemblyTypes(typeof(ICommandHandler<>).GetTypeInfo().Assembly)
                .AssignableTo(typeof(ICommandHandler<>))
                .InstancePerLifetimeScope();

            //builder.RegisterType<RegisterHandler>().As<ICommandHandler<Register>>()
            //    .InstancePerLifetimeScope();

            builder.RegisterType<CommandDispatcher>()
                .As<ICommandDispatcher>()
                .InstancePerLifetimeScope();

            var container = builder.Build();

            var JsonSettings = new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.All
            };

            string jsonData =
                "{\"$type\":\"chatapp_client.Register, chatapp_client\",\"Name\":\"LOL\",\"Password\":\"Kol\"}";
            ICommand lelDS = JsonConvert.DeserializeObject<ICommand>(jsonData, JsonSettings);

            ICommandDispatcher dispatcher = container.Resolve<ICommandDispatcher>();
            await dispatcher.DispatchAsync(lelDS);
        }

    }
}