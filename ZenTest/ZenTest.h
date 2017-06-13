#pragma once
//#define _EXTERN_C_  extern "C"  _declspec(dllexport)
#define _EXTERN_C_  extern   _declspec(dllexport)

#pragma region 函数名宏定义
#define DllZenAddStone "?ZenAddStone@@YA_NHHH@Z"  // bool ZenAddStone(int,int,int)
#define DllZenClearBoard "?ZenClearBoard@@YAXXZ"  // void ZenClearBoard(void)
#define DllZenFixedHandicap "?ZenFixedHandicap@@YAXH@Z"  // void ZenFixedHandicap(int)
#define DllZenGetBestMoveRate "?ZenGetBestMoveRate@@YAHXZ"  // int ZenGetBestMoveRate(void)
#define DllZenGetBoardColor "?ZenGetBoardColor@@YAHHH@Z"  // int ZenGetBoardColor(int,int)
#define DllZenGetHistorySize "?ZenGetHistorySize@@YAHXZ"  // int ZenGetHistorySize(void)
#define DllZenGetNextColor "?ZenGetNextColor@@YAHXZ"  // int ZenGetNextColor(void)
#define DllZenGetNumBlackPrisoners "?ZenGetNumBlackPrisoners@@YAHXZ"  // int ZenGetNumBlackPrisoners(void)
#define DllZenGetNumWhitePrisoners "?ZenGetNumWhitePrisoners@@YAHXZ"  // int ZenGetNumWhitePrisoners(void)
#define DllZenGetPriorKnowledge "?ZenGetPriorKnowledge@@YAXQAY0BD@H@Z"  // void ZenGetPriorKnowledge(int (* const)[19])
#define DllZenGetTerritoryStatictics "?ZenGetTerritoryStatictics@@YAXQAY0BD@H@Z"  // void ZenGetTerritoryStatictics(int (* const)[19])
#define DllZenGetTopMoveInfo "?ZenGetTopMoveInfo@@YAXHAAH00AAMPADH@Z"  // void ZenGetTopMoveInfo(int,int &,int &,int &,float &,char *,int)
#define DllZenInitialize "?ZenInitialize@@YAXPBD@Z"  // void ZenInitialize(char const *)
#define DllZenIsInitialized "?ZenIsInitialized@@YA_NXZ"  // bool ZenIsInitialized(void)
#define DllZenIsLegal "?ZenIsLegal@@YA_NHHH@Z"  // bool ZenIsLegal(int,int,int)
#define DllZenIsSuicide "?ZenIsSuicide@@YA_NHHH@Z"  // bool ZenIsSuicide(int,int,int)
#define DllZenIsThinking "?ZenIsThinking@@YA_NXZ"  // bool ZenIsThinking(void)
#define DllZenMakeShapeName "?ZenMakeShapeName@@YAXHHHPADH@Z"  // void ZenMakeShapeName(int,int,int,char *,int)
#define DllZenPass "?ZenPass@@YAXH@Z"  // void ZenPass(int)
#define DllZenPlay "?ZenPlay@@YA_NHHH@Z"  // bool ZenPlay(int,int,int)
#define DllZenReadGeneratedMove "?ZenReadGeneratedMove@@YAXAAH0AA_N1@Z"  // void ZenReadGeneratedMove(int &,int &,bool &,bool &)
#define DllZenSetAmafWeightFactor "?ZenSetAmafWeightFactor@@YAXM@Z"  // void ZenSetAmafWeightFactor(float)
#define DllZenSetBoardSize "?ZenSetBoardSize@@YAXH@Z"  // void ZenSetBoardSize(int)
#define DllZenSetDCNN "?ZenSetDCNN@@YAX_N@Z"  // void ZenSetDCNN(bool)
#define DllZenSetKomi "?ZenSetKomi@@YAXM@Z"  // void ZenSetKomi(float)
#define DllZenSetMaxTime "?ZenSetMaxTime@@YAXM@Z"  // void ZenSetMaxTime(float)
#define DllZenSetNextColor "?ZenSetNextColor@@YAXH@Z"  // void ZenSetNextColor(int)
#define DllZenSetNumberOfSimulations "?ZenSetNumberOfSimulations@@YAXH@Z"  // void ZenSetNumberOfSimulations(int)
#define DllZenSetNumberOfThreads "?ZenSetNumberOfThreads@@YAXH@Z"  // void ZenSetNumberOfThreads(int)
#define DllZenSetPriorWeightFactor "?ZenSetPriorWeightFactor@@YAXM@Z"  // void ZenSetPriorWeightFactor(float)
#define DllZenStartThinking "?ZenStartThinking@@YAXH@Z"  // void ZenStartThinking(int)
#define DllZenStopThinking "?ZenStopThinking@@YAXXZ"  // void ZenStopThinking(void)
#define DllZenTimeLeft "?ZenTimeLeft@@YAXHHH@Z"  // void ZenTimeLeft(int,int,int)
#define DllZenTimeSettings "?ZenTimeSettings@@YAXHHH@Z"  // void ZenTimeSettings(int,int,int)
#define DllZenUndo "?ZenUndo@@YA_NH@Z"  // bool ZenUndo(int)
#pragma endregion

#pragma region 函数指针宏定义
typedef bool(*ZenAddStonePtr)(int, int, int);//单纯的add，并非落子
typedef void(*ZenClearBoardPtr)(void);//清空棋盘
typedef void(*ZenFixedHandicapPtr)(int);//设置让子
typedef int(*ZenGetBestMoveRatePtr)(void);//要运行很长时间！！
typedef int(*ZenGetBoardColorPtr)(int, int);//查看棋盘某一点的颜色
typedef int(*ZenGetHistorySizePtr)(void);//历史步数
typedef int(*ZenGetNextColorPtr)(void);//查看下一步该谁走
typedef int(*ZenGetNumBlackPrisonersPtr)(void);//查看被吃子数
typedef int(*ZenGetNumWhitePrisonersPtr)(void);//查看被吃子数
typedef void(*ZenGetPriorKnowledgePtr)(int(*const)[19]);//落子的分值
typedef void(*ZenGetTerritoryStaticticsPtr)(int(*const)[19]);//棋盘上某一点被控制的分值，1000完全黑控制，-1000为白控制
typedef void(*ZenGetTopMoveInfoPtr)(int, int &, int &, int &, float &, char *, int);
typedef void(*ZenInitializePtr)(char const *);//初始化
typedef bool(*ZenIsInitializedPtr)(void);//是否初始化
typedef bool(*ZenIsLegalPtr)(int, int, int);//指的是落子的范围是否合法，没有判断禁入点或者颜色
typedef bool(*ZenIsSuicidePtr)(int, int, int);//                   ?????搞不懂，19个横坐标和12个纵坐标全部都是suicide
typedef bool(*ZenIsThinkingPtr)(void);//                           ????为何总是thinking
typedef void(*ZenMakeShapeNamePtr)(int, int, int, char *, int);
typedef void(*ZenPassPtr)(int);//pass
typedef bool(*ZenPlayPtr)(int, int, int);//落子，影响nextcolor和history
typedef void(*ZenReadGeneratedMovePtr)(int &, int &, bool &, bool &);
typedef void(*ZenSetAmafWeightFactorPtr)(float);
typedef void(*ZenSetBoardSizePtr)(int);//设置棋盘大小
typedef void(*ZenSetDCNNPtr)(bool);
typedef void(*ZenSetKomiPtr)(float);//设置贴目
typedef void(*ZenSetMaxTimePtr)(float);
typedef void(*ZenSetNextColorPtr)(int);//设置下一步的颜色
typedef void(*ZenSetNumberOfSimulationsPtr)(int);//与日志中的Playout对应，大概1000需要跑1s。
typedef void(*ZenSetNumberOfThreadsPtr)(int);
typedef void(*ZenSetPriorWeightFactorPtr)(float);
typedef void(*ZenStartThinkingPtr)(int);//开始思考
typedef void(*ZenStopThinkingPtr)(void);//停止思考
typedef void(*ZenTimeLeftPtr)(int, int, int);
typedef void(*ZenTimeSettingsPtr)(int, int, int);
typedef bool(*ZenUndoPtr)(int);//悔棋
#pragma endregion

#pragma region 函数指针申明
ZenInitializePtr pZenInitialize;//ok
ZenClearBoardPtr pZenClearBoard;//ok
							 ///get
ZenGetHistorySizePtr pZenGetHistorySize;// int ZenGetHistorySize(void)
ZenGetBestMoveRatePtr pZenGetBestMoveRate;// int ZenGetBestMoveRate(void)
ZenGetBoardColorPtr pZenGetBoardColor;// int ZenGetBoardColor(int,int)
ZenGetNextColorPtr pZenGetNextColor;// int ZenGetNextColor(void)
ZenGetNumBlackPrisonersPtr pZenGetNumBlackPrisoners;// int ZenGetNumBlackPrisoners(void)
ZenGetNumWhitePrisonersPtr pZenGetNumWhitePrisoners;// int ZenGetNumWhitePrisoners(void)
ZenGetPriorKnowledgePtr pZenGetPriorKnowledge;// void ZenGetPriorKnowledge(int (* const)[19])
ZenGetTerritoryStaticticsPtr pZenGetTerritoryStatictics;// void ZenGetTerritoryStatictics(int (* const)[19])
ZenGetTopMoveInfoPtr pZenGetTopMoveInfo;// void ZenGetTopMoveInfo(int,int &,int &,int &,float &,char *,int)

									 ///set
ZenSetNextColorPtr pZenSetNextColor;
ZenSetAmafWeightFactorPtr pZenSetAmafWeightFactor;
ZenSetBoardSizePtr pZenSetBoardSize;//ok
ZenSetDCNNPtr pZenSetDCNN;//神经网络
ZenSetKomiPtr pZenSetKomi;//ok
ZenSetMaxTimePtr pZenSetMaxTime;//
ZenSetNumberOfSimulationsPtr pZenSetNumberOfSimulations;
ZenSetNumberOfThreadsPtr pZenSetNumberOfThreads;
ZenSetPriorWeightFactorPtr pZenSetPriorWeightFactor;

ZenAddStonePtr pZenAddStone;
ZenFixedHandicapPtr pZenFixedHandicap;
ZenIsInitializedPtr pZenIsInitialized;//
ZenIsLegalPtr pZenIsLegal;
ZenIsSuicidePtr pZenIsSuicide;
ZenIsThinkingPtr pZenIsThinking;
ZenMakeShapeNamePtr pZenMakeShapeName;
ZenPassPtr pZenPass;
ZenPlayPtr pZenPlay;
ZenReadGeneratedMovePtr pZenReadGeneratedMove;//
ZenStartThinkingPtr pZenStartThinking;
ZenStopThinkingPtr pZenStopThinking;
ZenTimeLeftPtr pZenTimeLeft;
ZenTimeSettingsPtr pZenTimeSettings;
ZenUndoPtr pZenUndo;
#pragma endregion

#pragma region Extern
_EXTERN_C_ 	 bool ZenAddStone(int, int, int);
_EXTERN_C_ 	 void ZenClearBoard(void) ;
_EXTERN_C_ 	 void ZenFixedHandicap(int);
_EXTERN_C_ 	 int ZenGetBestMoveRate(void);
_EXTERN_C_ 	 int ZenGetBoardColor(int, int);
_EXTERN_C_ 	 int ZenGetHistorySize(void);
_EXTERN_C_ 	 int ZenGetNextColor(void);
_EXTERN_C_ 	 int ZenGetNumBlackPrisoners(void);
_EXTERN_C_ 	 int ZenGetNumWhitePrisoners(void);
_EXTERN_C_ 	 void ZenGetPriorKnowledge(int(*const)[19]);
_EXTERN_C_ 	 void ZenGetTerritoryStatictics(int(*const)[19]);
_EXTERN_C_ 	 void ZenGetTopMoveInfo(int, int &, int &, int &, float &, char *, int);
_EXTERN_C_ 	 void ZenInitialize(char const *);
_EXTERN_C_ 	 bool ZenIsInitialized(void);
_EXTERN_C_ 	 bool ZenIsLegal(int, int, int);
_EXTERN_C_ 	 bool ZenIsSuicide(int, int, int);
_EXTERN_C_ 	 bool ZenIsThinking(void);
_EXTERN_C_ 	 void ZenMakeShapeName(int, int, int, char *, int);
_EXTERN_C_ 	 void ZenPass(int);
_EXTERN_C_ 	 bool ZenPlay(int, int, int);
_EXTERN_C_ 	 void ZenReadGeneratedMove(int &, int &, bool &, bool &);
_EXTERN_C_ 	 void ZenSetAmafWeightFactor(float);
_EXTERN_C_ 	 void ZenSetBoardSize(int);
_EXTERN_C_ 	 void ZenSetDCNN(bool);
_EXTERN_C_ 	 void ZenSetKomi(float);
_EXTERN_C_ 	 void ZenSetMaxTime(float);
_EXTERN_C_ 	 void ZenSetNextColor(int);
_EXTERN_C_ 	 void ZenSetNumberOfSimulations(int);
_EXTERN_C_ 	 void ZenSetNumberOfThreads(int);
_EXTERN_C_ 	 void ZenSetPriorWeightFactor(float);
_EXTERN_C_ 	 void ZenStartThinking(int);
_EXTERN_C_ 	 void ZenStopThinking(void);
_EXTERN_C_ 	 void ZenTimeLeft(int, int, int);
_EXTERN_C_ 	 void ZenTimeSettings(int, int, int);
_EXTERN_C_ 	 bool ZenUndo(int);
#pragma endregion

/*
2是黑，1是白，0是空
Addstone，除了1和2，以外，都认为是1

*/
