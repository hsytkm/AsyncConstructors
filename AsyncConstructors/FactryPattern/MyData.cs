using System;
using System.Threading.Tasks;

namespace AsyncConstructors
{
    public class MyData
    {
        public bool Result { get; private set; }

        public async Task GetDataAsync()
        {
            await Task.Delay(100);
            Result = true;
        }
    }
}
