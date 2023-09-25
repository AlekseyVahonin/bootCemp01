namespace Server // пространство имен, для того чтобы можно было обрашаться к классам из другого cs
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Это наш сервер");
            OurServer server = new OurServer();
        }
    }
}
