using AsyncConstructors;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace AsyncConstructors.CLI
{
    // Async OOP 2: Constructors
    // https://blog.stephencleary.com/2013/01/async-oop-2-constructors.html
    class Program
    {
        static async Task Main(string[] args)
        {
            // FactoryPattern
            var cls1 = await MyClass.CreateAsync();
            Debug.WriteLine("MyClass is Created. (Initialized)");

            // IAsyncInterface
            var cls2 = new MyFundamentalType();
            Debug.WriteLine("MyFundamentalType is Created. (Uninitialized)");

            await cls2.Initialization;
            Debug.WriteLine("MyFundamentalType is initialized.");

        }
    }
}
