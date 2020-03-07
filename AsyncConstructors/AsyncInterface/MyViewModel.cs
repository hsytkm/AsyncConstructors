using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace AsyncConstructors
{
    public sealed class MyViewModel : INotifyPropertyChanged, IAsyncInitialization
    {
        public string Message
        {
            get => _message;
            private set
            {
                if (_message != value)
                {
                    _message = value;
                    RaisePropertyChanged(nameof(Message));
                }
            }
        }
        private string _message = "Uninitialized";

        public MyViewModel()
        {
            InitializationNotifier = NotifyTask.Create(InitializeAsync());
        }

        public NotifyTask InitializationNotifier { get; private set; }
        public Task Initialization => InitializationNotifier.Task;

        private async Task InitializeAsync()
        {
            await Task.Delay(3000); // asynchronous initialization

            Message = $"Completed InitializeAsync()";
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged([CallerMemberName]string propertyName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    }
}
