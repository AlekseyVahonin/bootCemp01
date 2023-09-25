using System.Net.Sockets; //Подключаем библиотеки для работы с TCP
using System.Text;

namespace Client //Пространство имен, для того чтобы можно было обрашаться к классам из другого cs
{
    class OurClien
    {
        TcpClient _client = new TcpClient("127.0.0.1", 5555);
        StreamWriter _sWriter;

        public OurClien()
        {
            _client = new TcpClient("127.0.0.1", 5555); //соединение
            _sWriter = new StreamWriter(_client.GetStream(), Encoding.UTF8); //поток отправляет данные с клиента на сервер

            HandelComunication();
        }

        void HandelComunication() //метод с бесконечным циклом, для того чтобы держать соединение постоянно(особенность TCP)
        {
            while(true)
            {
                Console.Write("> ");
                string? message = Console.ReadLine();
                _sWriter.WriteLine(message); //отправляем сообщение серверу
                _sWriter.Flush(); //отправить немедленно и очистить буфер 
            }
        }
    }
}