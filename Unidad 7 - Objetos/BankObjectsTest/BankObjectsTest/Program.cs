namespace BankObjectsTest
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var account = new BankAccount("Kendra");
            Console.WriteLine($"Account {account.Number} was created for {account.Owner} with {account.Balance}.");



        }
    }
}