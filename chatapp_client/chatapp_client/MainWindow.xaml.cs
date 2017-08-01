using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace chatapp_client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
        Client Client;
        public MainWindow()
        {
            InitializeComponent();

            Client = new Client();
            Client.MessageReceived += Client_MessageReceived;
        }

        void Client_MessageReceived(string Message)
        {
            throw new NotImplementedException();
        }

        private void Connect_Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(Client.Connect("127.0.0.1", 36000));
        }
    }
}
