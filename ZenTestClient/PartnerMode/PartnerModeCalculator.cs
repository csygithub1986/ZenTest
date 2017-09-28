using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ZenTestClient
{
    public class PartnerModeCalculator
    {
        private int blackTime;
        private int whiteTime;
        //private int 

        public PartnerModeCalculator()
        {

        }


        public void Start(int totalCount)
        {
            while (totalCount > 0)
            {
                bool isOver = false;
                int nextColor = 2;
                while (isOver)
                {
                    //Execute(nextColor,)
                }
                totalCount--;
            }
        }



        public void Execute(int nextColor, int time, Action<int, int, int, bool, bool> callback)
        {
            new Thread(() =>
            {
                DllImport.StartThinking(nextColor);
                Thread.Sleep(time * 1000);
                DllImport.StopThinking();
                int x = 0, y = 0;
                bool isPass = false, isResign = false;
                DllImport.ReadGeneratedMove(ref x, ref y, ref isPass, ref isResign);
                callback.Invoke(nextColor, x, y, isPass, isResign);
            }).Start();
        }



    }
}
