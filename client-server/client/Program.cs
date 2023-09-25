namespace Client // пространство имен, для того чтобы можно было обрашаться к классам из другого cs
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Это наш клиент");
            OurClien ourClien = new OurClien(); //создаем клиента
        }
    }
}
