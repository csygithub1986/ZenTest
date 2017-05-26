using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ZenTestClient
{
    public class DllImport
    {
        const string DLLNAME = "ZenTest.dll";
        [System.Runtime.InteropServices.DllImportAttribute(DLLNAME, EntryPoint = "AddStone")]
        public static extern bool AddStone(int param0, int param1, int param2);
        [System.Runtime.InteropServices.DllImportAttribute(DLLNAME, EntryPoint = "ClearBoard")]
        public static extern void ClearBoard();
        [System.Runtime.InteropServices.DllImportAttribute(DLLNAME, EntryPoint = "FixedHandicap")]
        public static extern void FixedHandicap(int param0);
        [System.Runtime.InteropServices.DllImportAttribute(DLLNAME, EntryPoint = "GetBestMoveRate")]
        public static extern int GetBestMoveRate();
        [System.Runtime.InteropServices.DllImportAttribute(DLLNAME, EntryPoint = "GetBoardColor")]
        public static extern int GetBoardColor(int param0, int param1);
        [System.Runtime.InteropServices.DllImportAttribute(DLLNAME, EntryPoint = "GetHistorySize")]
        public static extern int GetHistorySize();
        [System.Runtime.InteropServices.DllImportAttribute(DLLNAME, EntryPoint = "GetNextColor")]
        public static extern int GetNextColor();
        [System.Runtime.InteropServices.DllImportAttribute(DLLNAME, EntryPoint = "GetNumBlackPrisoners")]
        public static extern int GetNumBlackPrisoners();
        [System.Runtime.InteropServices.DllImportAttribute(DLLNAME, EntryPoint = "GetNumWhitePrisoners")]
        public static extern int GetNumWhitePrisoners();
        [System.Runtime.InteropServices.DllImportAttribute(DLLNAME, EntryPoint = "Initialize")]
        public static extern void Initialize();
        [System.Runtime.InteropServices.DllImportAttribute(DLLNAME, EntryPoint = "IsInitialized")]
        public static extern bool IsInitialized();
        [System.Runtime.InteropServices.DllImportAttribute(DLLNAME, EntryPoint = "IsLegal")]
        public static extern bool IsLegal(int param0, int param1, int param2);
        [System.Runtime.InteropServices.DllImportAttribute(DLLNAME, EntryPoint = "IsSuicide")]
        public static extern bool IsSuicide(int param0, int param1, int param2);
        [System.Runtime.InteropServices.DllImportAttribute(DLLNAME, EntryPoint = "IsThinking")]
        public static extern bool IsThinking();
        [System.Runtime.InteropServices.DllImportAttribute(DLLNAME, EntryPoint = "MakeShapeName")]
        public static extern void MakeShapeName(int param0, int param1, int param2, System.IntPtr param3, int param4);
        [System.Runtime.InteropServices.DllImportAttribute(DLLNAME, EntryPoint = "Pass")]
        public static extern void Pass(int param0);
        [System.Runtime.InteropServices.DllImportAttribute(DLLNAME, EntryPoint = "Play")]
        public static extern bool Play(int param0, int param1, int param2);
        [System.Runtime.InteropServices.DllImportAttribute(DLLNAME, EntryPoint = "SetAmafWeightFactor")]
        public static extern void SetAmafWeightFactor(float param0);
        [System.Runtime.InteropServices.DllImportAttribute(DLLNAME, EntryPoint = "SetBoardSize")]
        public static extern void SetBoardSize(int param0);
        [System.Runtime.InteropServices.DllImportAttribute(DLLNAME, EntryPoint = "SetDCNN")]
        public static extern void SetDCNN(bool param0);
        [System.Runtime.InteropServices.DllImportAttribute(DLLNAME, EntryPoint = "SetKomi")]
        public static extern void SetKomi(float param0);
        [System.Runtime.InteropServices.DllImportAttribute(DLLNAME, EntryPoint = "SetMaxTime")]
        public static extern void SetMaxTime(float param0);
        [System.Runtime.InteropServices.DllImportAttribute(DLLNAME, EntryPoint = "SetNextColor")]
        public static extern void SetNextColor(int param0);
        [System.Runtime.InteropServices.DllImportAttribute(DLLNAME, EntryPoint = "SetNumberOfSimulations")]
        public static extern void SetNumberOfSimulations(int param0);
        [System.Runtime.InteropServices.DllImportAttribute(DLLNAME, EntryPoint = "SetNumberOfThreads")]
        public static extern void SetNumberOfThreads(int param0);
        [System.Runtime.InteropServices.DllImportAttribute(DLLNAME, EntryPoint = "SetPriorWeightFactor")]
        public static extern void SetPriorWeightFactor(float param0);
        [System.Runtime.InteropServices.DllImportAttribute(DLLNAME, EntryPoint = "StartThinking")]
        public static extern void StartThinking(int param0);
        [System.Runtime.InteropServices.DllImportAttribute(DLLNAME, EntryPoint = "StopThinking")]
        public static extern void StopThinking();
        [System.Runtime.InteropServices.DllImportAttribute(DLLNAME, EntryPoint = "TimeLeft")]
        public static extern void TimeLeft(int param0, int param1, int param2);
        [System.Runtime.InteropServices.DllImportAttribute(DLLNAME, EntryPoint = "TimeSettings")]
        public static extern void TimeSettings(int param0, int param1, int param2);
        [System.Runtime.InteropServices.DllImportAttribute(DLLNAME, EntryPoint = "Undo")]
        public static extern bool Undo(int param0);
        [System.Runtime.InteropServices.DllImportAttribute(DLLNAME, EntryPoint = "GetTopMoveInfo")]
        public static extern void GetTopMoveInfo(int param0, ref int param1, ref int param2, ref int param3, ref float param4, System.IntPtr param5, int param6);
        [System.Runtime.InteropServices.DllImportAttribute(DLLNAME, EntryPoint = "ReadGeneratedMove")]
        public static extern void ReadGeneratedMove(ref int param0, ref int param1, ref bool param2, ref bool param3);
    }
}
