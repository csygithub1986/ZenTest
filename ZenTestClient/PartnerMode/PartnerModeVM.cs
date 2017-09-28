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
            _GameSetting = new PlayerSetting[4];
            string[] headerNames = { "黑1", "白1", "黑2", "白2" };
            int[] colors = { 2, 1, 2, 1 };
            for (int i = 0; i < 4; i++)
            {
                _GameSetting[i] = new PlayerSetting() { HeaderName = headerNames[i], Color = colors[i] };
            }
            GameLoopTime = 1;
        }

        public PlayerSetting[] GameSetting
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
        private PlayerSetting[] _GameSetting;

        /// <summary>
        /// 用于棋力自测或者和其他软件对测时，测试的盘数。与人下请设定为1
        /// </summary>
        public int GameLoopTime
        {
            get { return _GameLoopTime; }
            set
            {
                if (_GameLoopTime != value)
                {
                    _GameLoopTime = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("GameLoopTime"));
                }
            }
        }
        private int _GameLoopTime;

    }
}
