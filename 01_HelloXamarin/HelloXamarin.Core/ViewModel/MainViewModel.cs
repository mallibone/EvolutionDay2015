using System;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace HelloXamarin.Core.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private string _message = string.Empty;
        private string _previousMessage = String.Empty;

        public MainViewModel()
        {
            if (IsInDesignMode)
            {
                PreviousMessage = "Previous message";
            }

            MessageCommand = new RelayCommand(SubmitMessage);
        }

        public RelayCommand MessageCommand { get; private set; }

        private void SubmitMessage()
        {
            PreviousMessage = Message;
        }

        public string PreviousMessage
        {
            get { return _previousMessage; }
            set
            {
                if (value == _previousMessage) return;
                _previousMessage = value;
                RaisePropertyChanged(propertyName: nameof(PreviousMessage));
            }
        }

        public string Message
        {
            get { return _message; }
            set
            {
                if (value == _message) return;
                _message = value;
                RaisePropertyChanged(propertyName: nameof(Message));
            }
        }
    }
}