using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace AsyncConstructors
{
    public sealed class MyFundamentalType : IAsyncInitialization
    {
        public MyFundamentalType()
        {
            Initialization = InitializeAsync();
        }

        public Task Initialization { get; private set; }

        private async Task InitializeAsync()
        {
            // Asynchronously initialize this instance.
            await Task.Delay(100);
            Debug.WriteLine("Called MyFundamentalType.InitializeAsync()");
        }
    }
}
