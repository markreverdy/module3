using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mod3_Ex6
{
    public class MessageBox
    {
        // Define the delegate for the event
        public delegate void WindowClosedHandler(State state);

        // Define the event
        public event WindowClosedHandler WindowClosed;

        // The async method simulating the message box behavior
        public async void Open()
        {
            Console.WriteLine("A window is open.");

            // Wait for 3 seconds
            await Task.Delay(3000);

            Console.WriteLine("The window was closed by the user.");

            // Generate a random value of State (either Ok or Cancel)
            Random rand = new Random();
            State randomState = (State)rand.Next(0, 2);

            // Invoke the event
            WindowClosed?.Invoke(randomState);
        }
    }
}
