using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;

namespace DomainPCL
{
    public class GameControllerModel : ViewModelBase
    {
    }

    public class GamePice : ObservableObject
    {
        private bool _isEnable;
        private string _content;

        public bool IsEnable
        {
            get { return _isEnable; }
            set
            {
                Set(()=> IsEnable, ref _isEnable, value);
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
    }
}
