using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Autofac;

namespace chatapp_client
{
    class Client
    {
        public delegate void EventDelegate(string Message);
        public event EventDelegate MessageReceived;
        public TcpClient ClientSocket { get; private set; }
        BinaryWriter Writer;
        BinaryReader Reader;
        Thread ReadingThread;

        public bool ClientStatus;
        string Message;
        byte[] RecByte = new byte[1];


        public Client()
        {
            ClientSocket = new TcpClient();
        }

        private void ReadThread()
        {
            while (ClientStatus)
            {
                
                try
                {
                    RecByte[0] = Reader.ReadByte();
                    Message += Encoding.ASCII.GetString(RecByte);
                    if (Message.Contains("##"))
                    {
                        MessageReceived(Message);
                        Message = string.Empty;
                    }

                }
                catch (EndOfStreamException)
                {
                    Thread.Sleep(10);
                }

            }
        }

        public string Connect(string IP, int Port)
        {
            if (!ClientSocket.Connected)
            {
                try
                {
                    ClientSocket.Connect(IP, Port);
                    Writer = new BinaryWriter(ClientSocket.GetStream());
                    Reader = new BinaryReader(ClientSocket.GetStream());
                    ReadingThread = new Thread(new ThreadStart(ReadThread));
                    ReadingThread.Start();
                    return "Connected!";
                }
                catch (Exception ex)
                {
                    return ex.ToString();
                }
            }
            else
                return "Connected!";
        }

        public string Send(string Message)
        {
            if (ClientSocket.Connected)
            {
                byte[] SendBuff = new byte[Message.Length];

                try
                {
                    SendBuff = Encoding.ASCII.GetBytes(Message);
                    Writer.Write(SendBuff, 0, SendBuff.Length);
                    return string.Empty;
                }
                catch (Exception ex)
                {
                    return ex.ToString();
                }
            }
            else
                return "Client not connected.";
        }

    }
}
