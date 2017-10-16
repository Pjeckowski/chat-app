using System;
using System.Diagnostics;
using System.Windows;
using Autofac;
using chatapp_client.Commands;
using chatapp_client.Handlers;
using chatapp_client.Serializer;
using Chat_Protocol.Commands;
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
        private ISerializer Serializer = new NewtonSerializer();

        public MainWindow()
        {
            InitializeComponent();

            Client = new Client();
            Client.MessageReceived += Client_MessageReceived;
            //LetsPLayWithThisShiet();
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

        private void Send_Button_Click(object sender, RoutedEventArgs e)
        {
           MessageCommand Mcommand = new MessageCommand("I am message");
            string message = Serializer.Serialize(Mcommand);
            Client.Send(message);
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
            var assemblies = typeof(ICommand).Assembly;

            builder.RegisterAssemblyTypes(assemblies)
                .AsClosedTypesOf(typeof(ICommandHandler<>))
                .InstancePerLifetimeScope();

            builder.RegisterType<CommandDispatcher>()
                .As<ICommandDispatcher>()
                .InstancePerLifetimeScope();

            var container = builder.Build();

            var jsonSettings = new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.All
            };

            string jsonData =
                "{\"$type\":\"chatapp_client.Register, chatapp_client\",\"Name\":\"LOL\",\"Password\":\"Kol\"}";
            ICommand lelDS = JsonConvert.DeserializeObject<ICommand>(jsonData, jsonSettings);

            ICommandDispatcher dispatcher = container.Resolve<ICommandDispatcher>();
            await dispatcher.DispatchAsync(lelDS);
        }



    }
}