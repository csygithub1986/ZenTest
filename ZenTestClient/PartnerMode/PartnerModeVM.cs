using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZenTestClient
{
    public class PartnerModeVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public PartnerModeVM()
        {
            _GameSetting = new AISetting();
        }

        public AISetting GameSetting
        {
            get { return _GameSetting; }
            set
            {
                if (_GameSetting != value)
                {
                    _GameSetting = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("GameSetting"));
                }
            }
        }
        private AISetting _GameSetting;

    }
}
