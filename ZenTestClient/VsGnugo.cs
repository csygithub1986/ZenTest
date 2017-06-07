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
    /// 
    /// </summary>
    public class VsGnugo
    {
        public event Action<string, Action<int, string>> OnMsgOutput;
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

                string msg;
                try
                {
                    while ((msg = process.StandardOutput.ReadLine()) != null)
                    {
                        OnMsgOutput?.Invoke(msg, InputMove);
                    }
                }
                catch (Exception)
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
        }
        public void Exit()
        {
            process.StandardInput.WriteLine("quit");
            //process.Close();
            //process.Dispose();
        }
    }
}
