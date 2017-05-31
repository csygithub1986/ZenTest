using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ZenTestClient
{
    public class DllImport
    {
        const string DLLNAME = "Zen.dll";
        [System.Runtime.InteropServices.DllImportAttribute(DLLNAME, EntryPoint = "?ZenAddStone@@YA_NHHH@Z", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        public static extern bool AddStone(int param0, int param1, int param2);
        [System.Runtime.InteropServices.DllImportAttribute(DLLNAME, EntryPoint = "ClearBoard", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        public static extern void ClearBoard();
        [System.Runtime.InteropServices.DllImportAttribute(DLLNAME, EntryPoint = "FixedHandicap", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        public static extern void FixedHandicap(int param0);
        [System.Runtime.InteropServices.DllImportAttribute(DLLNAME, EntryPoint = "GetBestMoveRate", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        public static extern int GetBestMoveRate();
        [System.Runtime.InteropServices.DllImportAttribute(DLLNAME, EntryPoint = "GetBoardColor", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        public static extern int GetBoardColor(int param0, int param1);
        [System.Runtime.InteropServices.DllImportAttribute(DLLNAME, EntryPoint = "GetHistorySize", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        public static extern int GetHistorySize();
        [System.Runtime.InteropServices.DllImportAttribute(DLLNAME, EntryPoint = "GetNextColor", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        public static extern int GetNextColor();
        [System.Runtime.InteropServices.DllImportAttribute(DLLNAME, EntryPoint = "GetNumBlackPrisoners", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        public static extern int GetNumBlackPrisoners();
        [System.Runtime.InteropServices.DllImportAttribute(DLLNAME, EntryPoint = "GetNumWhitePrisoners", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        public static extern int GetNumWhitePrisoners();
        [System.Runtime.InteropServices.DllImportAttribute(DLLNAME, EntryPoint = "?ZenInitialize@@YAXPBD@Z", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        public static extern void Initialize();
        [System.Runtime.InteropServices.DllImportAttribute(DLLNAME, EntryPoint = "?ZenIsInitialized@@YA_NXZ", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        public static extern bool IsInitialized();
        [System.Runtime.InteropServices.DllImportAttribute(DLLNAME, EntryPoint = "IsLegal", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        public static extern bool IsLegal(int param0, int param1, int param2);
        [System.Runtime.InteropServices.DllImportAttribute(DLLNAME, EntryPoint = "IsSuicide", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        public static extern bool IsSuicide(int param0, int param1, int param2);
        [System.Runtime.InteropServices.DllImportAttribute(DLLNAME, EntryPoint = "IsThinking", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        public static extern bool IsThinking();
        [System.Runtime.InteropServices.DllImportAttribute(DLLNAME, EntryPoint = "MakeShapeName", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        public static extern void MakeShapeName(int param0, int param1, int param2, System.IntPtr param3, int param4);
        [System.Runtime.InteropServices.DllImportAttribute(DLLNAME, EntryPoint = "Pass", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        public static extern void Pass(int param0);
        [System.Runtime.InteropServices.DllImportAttribute(DLLNAME, EntryPoint = "Play", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        public static extern bool Play(int param0, int param1, int param2);
        [System.Runtime.InteropServices.DllImportAttribute(DLLNAME, EntryPoint = "SetAmafWeightFactor", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        public static extern void SetAmafWeightFactor(float param0);
        [System.Runtime.InteropServices.DllImportAttribute(DLLNAME, EntryPoint = "SetBoardSize", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        public static extern void SetBoardSize(int param0);
        [System.Runtime.InteropServices.DllImportAttribute(DLLNAME, EntryPoint = "SetDCNN", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        public static extern void SetDCNN(bool param0);
        [System.Runtime.InteropServices.DllImportAttribute(DLLNAME, EntryPoint = "SetKomi", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        public static extern void SetKomi(float param0);
        [System.Runtime.InteropServices.DllImportAttribute(DLLNAME, EntryPoint = "SetMaxTime", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        public static extern void SetMaxTime(float param0);
        [System.Runtime.InteropServices.DllImportAttribute(DLLNAME, EntryPoint = "SetNextColor", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        public static extern void SetNextColor(int param0);
        [System.Runtime.InteropServices.DllImportAttribute(DLLNAME, EntryPoint = "SetNumberOfSimulations", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        public static extern void SetNumberOfSimulations(int param0);
        [System.Runtime.InteropServices.DllImportAttribute(DLLNAME, EntryPoint = "SetNumberOfThreads", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        public static extern void SetNumberOfThreads(int param0);
        [System.Runtime.InteropServices.DllImportAttribute(DLLNAME, EntryPoint = "SetPriorWeightFactor", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        public static extern void SetPriorWeightFactor(float param0);
        [System.Runtime.InteropServices.DllImportAttribute(DLLNAME, EntryPoint = "StartThinking", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        public static extern void StartThinking(int param0);
        [System.Runtime.InteropServices.DllImportAttribute(DLLNAME, EntryPoint = "StopThinking", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        public static extern void StopThinking();
        [System.Runtime.InteropServices.DllImportAttribute(DLLNAME, EntryPoint = "TimeLeft", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        public static extern void TimeLeft(int param0, int param1, int param2);
        [System.Runtime.InteropServices.DllImportAttribute(DLLNAME, EntryPoint = "TimeSettings", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        public static extern void TimeSettings(int param0, int param1, int param2);
        [System.Runtime.InteropServices.DllImportAttribute(DLLNAME, EntryPoint = "Undo", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        public static extern bool Undo(int param0);
        [System.Runtime.InteropServices.DllImportAttribute(DLLNAME, EntryPoint = "GetTopMoveInfo", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        public static extern void GetTopMoveInfo(int param0, ref int param1, ref int param2, ref int param3, ref float param4, System.IntPtr param5, int param6);
        [System.Runtime.InteropServices.DllImportAttribute(DLLNAME, EntryPoint = "ReadGeneratedMove", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        public static extern void ReadGeneratedMove(ref int param0, ref int param1, ref bool param2, ref bool param3);
    }
}
