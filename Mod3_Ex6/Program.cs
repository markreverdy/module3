namespace Mod3_Ex6
{
    class Program
    {
        static void Main(string[] args)
        {
            MessageBox messageBox = new MessageBox();

            // Subscribe to the WindowClosed event with a lambda expression
            messageBox.WindowClosed += state =>
            {
                if (state == State.Ok)
                {
                    Console.WriteLine("The operation has been confirmed.");
                }
                else if (state == State.Cancel)
                {
                    Console.WriteLine("The operation was rejected.");
                }
            };

            // Call the Open method to simulate opening a message box
            messageBox.Open();

            // Prevent the application from closing immediately
            Console.ReadKey();
        }
    }
}