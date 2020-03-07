using System;
using System.Threading.Tasks;

namespace AsyncConstructors
{
    public sealed class MyComposedType : IAsyncInitialization
    {
        private readonly MyFundamentalType _fundamental;

        public MyComposedType(MyFundamentalType fundamental)
        {
            _fundamental = fundamental;
            Initialization = InitializeAsync();
        }

        public Task Initialization { get; private set; }

        private async Task InitializeAsync()
        {
            // Asynchronously wait for the fundamental instance to initialize.
            if (_fundamental is IAsyncInitialization asyncFundamental)
                await asyncFundamental.Initialization;

            // Do our own initialization (synchronous or asynchronous).
            await Task.Delay(100);
        }
    }
}
