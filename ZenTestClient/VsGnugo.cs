using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ZenTestClient
{
    /// <summary>
    /// 注意：
    /// 1、gnugo纵坐标位1~19，非0~18
    /// 2、跳过了I坐标，H过了是J
    /// 3、纵坐标1在底部，19在顶部，和zen相反（但不影响程序逻辑）
    /// </summary>
    public class VsGnugo
    {
        public event Func<string, Action<int, string>, bool> OnMsgOutput;
        Process process;
        public void Start()
        {
            new Thread(() =>
            {
                ProcessStartInfo psi = new ProcessStartInfo(@"gnugo.exe");
                psi.RedirectStandardOutput = true;
                psi.RedirectStandardInput = true;
                psi.WindowStyle = ProcessWindowStyle.Hidden;
                psi.UseShellExecute = false;
                process = Process.Start(psi);
                process.StandardInput.WriteLine("1 fixed_handicap 9");

                string msg;
                try
                {
                    while ((msg = process.StandardOutput.ReadLine()) != null)
                    {
                        if (msg == null || msg.Length <= 2)
                        {
                            continue;
                        }
                        if (msg.StartsWith("=1"))
                        {
                            continue;
                        }
                        bool isOver = (bool)OnMsgOutput?.Invoke(msg, InputMove);//"= resign"
                        if (msg.Contains("resign")|| msg.Contains("PASS")|| isOver)
                        {
                            process.StandardInput.WriteLine("quit");
                            return;
                        }
                    }
                }
                catch (Exception ex)
                {
                    return;
                }

            }).Start();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="color">1 white,2 black</param>
        /// <param name="move">格式"A1"</param>
        public void InputMove(int color, string move)
        {
            process.StandardInput.WriteLine("play " + (color == 1 ? "white " : "black ") + move);
            process.StandardInput.WriteLine("genmove " + (color == 1 ? "black" : "white"));
            //Console.WriteLine("gnugo\t" + (3 - color));
        }

        public void GenMove(int color)
        {
            process.StandardInput.WriteLine("genmove " + (color == 2 ? "black" : "white"));
        }

        public void Exit()
        {
            process.StandardInput.WriteLine("quit");
            //process.Close();
            //process.Dispose();
        }
    }
}
