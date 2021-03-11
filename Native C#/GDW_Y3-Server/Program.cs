﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDW_Y3_Server
{
    class Program
    {
        // main server test
        static void ServerTest(bool twoWay)
        {
            NetworkLibrary.UdpServer server = new NetworkLibrary.UdpServer();


            // NOTE: the server sending data only does not work
            // I don't know if I'll bother to fix it though.
            // Also, setting up delays or non-blocking sockets before the server is running causes it to crash.

            // two way mode
            if (twoWay)
                server.SetCommunicationMode(NetworkLibrary.UdpServer.mode.both);
            else
                server.SetCommunicationMode(NetworkLibrary.UdpServer.mode.receive); // receive by default


            server.SetBlockingSockets(false);

            // runs the server
            server.RunServer();

            // Console.WriteLine(server.GetIPAddress());

            // while loop for updates
            while (server.IsRunning())
            {
                // if doing two way 
                if (twoWay)
                {
                    Console.WriteLine("Enter Message: ");
                    string str = Console.ReadLine();
                    byte[] sendData = Encoding.ASCII.GetBytes(str);
                    server.SetSendBufferData(sendData);
                }


                server.Update();

                byte[] data = server.GetReceiveBufferData();

                if (data.Length > 0)
                    Console.WriteLine(Encoding.ASCII.GetString(data, 0, data.Length));
            }

            server.ShutdownServer();
        }

        // 1 to 4 Server Test
        static void Server4Test()
        {
            NetworkLibrary.UdpServer4 server4 = new NetworkLibrary.UdpServer4();

            // runs the serve
            server4.RunServer();

            // Console.WriteLine(server.GetIPAddress());

            // while loop for updates
            while (server4.IsRunning())
            {
                Console.WriteLine("Enter Message: ");
                string str = Console.ReadLine();
                byte[] sendData = Encoding.ASCII.GetBytes(str);
                server4.SetSendBufferData(sendData);

                server4.SetBlockingSockets(false);
                server4.Update();
                
                
                // server4.SetReceiveTimeout(1);
                // server4.SetSendTimeout(1);

                byte[] data; 
                
                // buffer 1
                data = server4.GetReceiveBuffer1Data();

                if (data != null && data.Length > 0)
                    Console.WriteLine("Buffer 1: " + Encoding.ASCII.GetString(data, 0, data.Length));

                // buffer 2
                data = server4.GetReceiveBuffer2Data();

                if (data != null && data.Length > 0)
                    Console.WriteLine("Buffer 2: " + Encoding.ASCII.GetString(data, 0, data.Length));

                // buffer 3
                data = server4.GetReceiveBuffer3Data();

                if (data != null && data.Length > 0)
                    Console.WriteLine("Buffer 3: " + Encoding.ASCII.GetString(data, 0, data.Length));

                // buffer 4
                data = server4.GetReceiveBuffer4Data();

                if (data != null && data.Length > 0)
                    Console.WriteLine("Buffer 4: " + Encoding.ASCII.GetString(data, 0, data.Length));
            }

            server4.ShutdownServer();
        }

        // uncomment if making DLL
        static void Main(string[] args)
        {
            // test mode
            int testMode = 0;

            switch(testMode)
            {
                default:
                case 0: // server (1 way)
                case 1:
                    ServerTest(true);
                    break;

                case 2: // server (4 way)
                    Server4Test();
                    break;
            }
        }
    }
}
