using GalaSoft.MvvmLight;

namespace DomainPCL
{
    public class GamePiece : ObservableObject
    {
        private bool _isEnabled;
        private string _content;

        public bool IsEnabled
        {
            get { return _isEnabled; }
            set
            {
                Set(()=> IsEnabled, ref _isEnabled, value);
            }
        }

        public string Content
        {
            get { return _content; }
            set
            {
                Set(()=> Content,ref _content, value);
            }
        }
        
        public GamePiece()
        {
            Content = null;
            IsEnabled = true;
        }   
    }
}