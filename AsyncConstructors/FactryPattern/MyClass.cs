using System;
using System.Threading.Tasks;

namespace AsyncConstructors
{
    /// <summary>
    /// FactoryPattern
    /// </summary>
    public sealed class MyClass
    {
        private MyData _asyncData;

        private MyClass() { }

        public static Task<MyClass> CreateAsync()
        {
            var ret = new MyClass();
            return ret.InitializeAsync();
        }

        private async Task<MyClass> InitializeAsync()
        {
            _asyncData = await GetDataAsync();
            return this;
        }

        private static async Task<MyData> GetDataAsync()
        {
            await Task.Delay(100);
            return new MyData();
        }

    }
}
