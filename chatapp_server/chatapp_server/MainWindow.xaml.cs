using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using chatapp_server.Repositories.ChatRoomRepositories;
using chatapp_server.Serializer;


namespace chatapp_server
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            List<TestClass> TS = new List<TestClass>();

            TS.Add(new TestClass(1,"1"));
            TS.Add(new TestClass(2,"2"));

            var MyTs = new TestClass(1,"1");

            var kk = TS.Find(oTS => oTS.Text == "1" && oTS.Number == 1);
            kk.Number = 4;
            kk.Text = "4";

            if (TS[0].Number == 4)
            {
                TestLabel.Content = "Działa";
            }

        }
    }
}
