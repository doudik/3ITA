namespace ConnectionManager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ConnectionManager manager = ConnectionManager.Manager;
            manager.Connect();
            manager.RemoveUser("Pepa");
            manager.Disconnect();
        }
    }
}