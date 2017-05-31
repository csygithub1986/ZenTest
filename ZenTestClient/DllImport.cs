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
        [System.Runtime.InteropServices.DllImportAttribute(DLLNAME, EntryPoint = "?ZenClearBoard@@YAXXZ", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        public static extern void ClearBoard();
        [System.Runtime.InteropServices.DllImportAttribute(DLLNAME, EntryPoint = "?ZenFixedHandicap@@YAXH@Z", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        public static extern void FixedHandicap(int param0);
        [System.Runtime.InteropServices.DllImportAttribute(DLLNAME, EntryPoint = "?ZenGetBestMoveRate@@YAHXZ", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        public static extern int GetBestMoveRate();
        [System.Runtime.InteropServices.DllImportAttribute(DLLNAME, EntryPoint = "?ZenGetBoardColor@@YAHHH@Z", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        public static extern int GetBoardColor(int param0, int param1);
        [System.Runtime.InteropServices.DllImportAttribute(DLLNAME, EntryPoint = "?ZenGetHistorySize@@YAHXZ", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        public static extern int GetHistorySize();
        [System.Runtime.InteropServices.DllImportAttribute(DLLNAME, EntryPoint = "?ZenGetNextColor@@YAHXZ", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        public static extern int GetNextColor();
        [System.Runtime.InteropServices.DllImportAttribute(DLLNAME, EntryPoint = "?ZenGetNumBlackPrisoners@@YAHXZ", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        public static extern int GetNumBlackPrisoners();
        [System.Runtime.InteropServices.DllImportAttribute(DLLNAME, EntryPoint = "?ZenGetNumWhitePrisoners@@YAHXZ", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        public static extern int GetNumWhitePrisoners();
        [System.Runtime.InteropServices.DllImportAttribute(DLLNAME, EntryPoint = "?ZenInitialize@@YAXPBD@Z", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        public static extern void Initialize();
        [System.Runtime.InteropServices.DllImportAttribute(DLLNAME, EntryPoint = "?ZenIsInitialized@@YA_NXZ", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        public static extern bool IsInitialized();
        [System.Runtime.InteropServices.DllImportAttribute(DLLNAME, EntryPoint = "?ZenIsLegal@@YA_NHHH@Z", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        public static extern bool IsLegal(int param0, int param1, int param2);
        [System.Runtime.InteropServices.DllImportAttribute(DLLNAME, EntryPoint = "?ZenIsSuicide@@YA_NHHH@Z", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        public static extern bool IsSuicide(int param0, int param1, int param2);
        [System.Runtime.InteropServices.DllImportAttribute(DLLNAME, EntryPoint = "?ZenIsThinking@@YA_NXZ", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        public static extern bool IsThinking();
        [System.Runtime.InteropServices.DllImportAttribute(DLLNAME, EntryPoint = "?ZenMakeShapeName@@YAXHHHPADH@Z", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        public static extern void MakeShapeName(int param0, int param1, int param2, System.IntPtr param3, int param4);
        [System.Runtime.InteropServices.DllImportAttribute(DLLNAME, EntryPoint = "?ZenPass@@YAXH@Z", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        public static extern void Pass(int param0);
        [System.Runtime.InteropServices.DllImportAttribute(DLLNAME, EntryPoint = "?ZenPlay@@YA_NHHH@Z", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        public static extern bool Play(int param0, int param1, int param2);
        [System.Runtime.InteropServices.DllImportAttribute(DLLNAME, EntryPoint = "?ZenSetAmafWeightFactor@@YAXM@Z", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        public static extern void SetAmafWeightFactor(float param0);
        [System.Runtime.InteropServices.DllImportAttribute(DLLNAME, EntryPoint = "?ZenSetBoardSize@@YAXH@Z", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        public static extern void SetBoardSize(int param0);
        [System.Runtime.InteropServices.DllImportAttribute(DLLNAME, EntryPoint = "?ZenSetDCNN@@YAX_N@Z", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        public static extern void SetDCNN(bool param0);
        [System.Runtime.InteropServices.DllImportAttribute(DLLNAME, EntryPoint = "?ZenSetKomi@@YAXM@Z", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        public static extern void SetKomi(float param0);
        [System.Runtime.InteropServices.DllImportAttribute(DLLNAME, EntryPoint = "?ZenSetMaxTime@@YAXM@Z", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        public static extern void SetMaxTime(float param0);
        [System.Runtime.InteropServices.DllImportAttribute(DLLNAME, EntryPoint = "?ZenSetNextColor@@YAXH@Z", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        public static extern void SetNextColor(int param0);
        [System.Runtime.InteropServices.DllImportAttribute(DLLNAME, EntryPoint = "?ZenSetNumberOfSimulations@@YAXH@Z", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        public static extern void SetNumberOfSimulations(int param0);
        [System.Runtime.InteropServices.DllImportAttribute(DLLNAME, EntryPoint = "?ZenSetNumberOfThreads@@YAXH@Z", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        public static extern void SetNumberOfThreads(int param0);
        [System.Runtime.InteropServices.DllImportAttribute(DLLNAME, EntryPoint = "?ZenSetPriorWeightFactor@@YAXM@Z", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        public static extern void SetPriorWeightFactor(float param0);
        [System.Runtime.InteropServices.DllImportAttribute(DLLNAME, EntryPoint = "?ZenStartThinking@@YAXH@Z", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        public static extern void StartThinking(int param0);
        [System.Runtime.InteropServices.DllImportAttribute(DLLNAME, EntryPoint = "?ZenStopThinking@@YAXXZ", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        public static extern void StopThinking();
        [System.Runtime.InteropServices.DllImportAttribute(DLLNAME, EntryPoint = "?ZenTimeLeft@@YAXHHH@Z", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        public static extern void TimeLeft(int param0, int param1, int param2);
        [System.Runtime.InteropServices.DllImportAttribute(DLLNAME, EntryPoint = "?ZenTimeSettings@@YAXHHH@Z", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        public static extern void TimeSettings(int param0, int param1, int param2);
        [System.Runtime.InteropServices.DllImportAttribute(DLLNAME, EntryPoint = "?ZenUndo@@YA_NH@Z", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        public static extern bool Undo(int param0);
        [System.Runtime.InteropServices.DllImportAttribute(DLLNAME, EntryPoint = "?ZenGetTopMoveInfo@@YAXHAAH00AAMPADH@Z", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        public static extern void GetTopMoveInfo(int param0, ref int param1, ref int param2, ref int param3, ref float param4, System.IntPtr param5, int param6);
        [System.Runtime.InteropServices.DllImportAttribute(DLLNAME, EntryPoint = "?ZenReadGeneratedMove@@YAXAAH0AA_N1@Z", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        public static extern void ReadGeneratedMove(ref int param0, ref int param1, ref bool param2, ref bool param3);

        [System.Runtime.InteropServices.DllImportAttribute(DLLNAME, EntryPoint = "?ZenGetPriorKnowledge@@YAXQAY0BD@H@Z", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        public static extern void GetPriorKnowledge(IntPtr param0);

        [System.Runtime.InteropServices.DllImportAttribute(DLLNAME, EntryPoint = "?ZenGetTerritoryStatictics@@YAXQAY0BD@H@Z", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        public static extern void GetTerritoryStatictics(IntPtr param0);
    }
}
