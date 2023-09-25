using System.Net;
using System.Net.Sockets; 
using System.Text;

namespace Server
{
    class OurServer
    {
        TcpListener _server;

        public OurServer()
        {
            _server = new TcpListener(IPAddress.Parse("127.0.0.1"), 5555); //слушаем подключение
            _server.Start(); //Запускаем подключение

            LoopClients();
        }

        void LoopClients()// постоянно ловит клиентов
        {
            while (true)//принимает новые подключения бесконечно
            {
                TcpClient _client = _server.AcceptTcpClient();// плучили клиента

                Thread thread = new Thread(() => HandleClient(_client));//создали поток для клиента, => - анонимная ф-ия
                thread.Start(); //запускаем поток
            }
            
        }

        void HandleClient(TcpClient _client)
        {
            StreamReader _sReader = new StreamReader(_client.GetStream(), Encoding.UTF8); //получаем поток от соединения
            StreamWriter _sWriter = new StreamWriter(_client.GetStream(), Encoding.UTF8);

            while (true)//каждого нового клиента держим бесконечно
            {
                string? message = _sReader.ReadLine();
                Console.WriteLine($"Клиент написал - {message}");

                Console.WriteLine("Дайте сообщение клиенту: ");
                string? answer = Console.ReadLine();
                _sWriter.WriteLine(answer);
                _sWriter.Flush();
            }
        }
    }
}