#pragma once
#define DllZenAddStone	"?ZenAddStone@@YA_NHHH@Z"  //	bool ZenAddStone(int,int,int)
#define DllZenClearBoard	"?ZenClearBoard@@YAXXZ"  //	void ZenClearBoard(void)
#define DllZenFixedHandicap	"?ZenFixedHandicap@@YAXH@Z"  //	void ZenFixedHandicap(int)
#define DllZenGetBestMoveRate	"?ZenGetBestMoveRate@@YAHXZ"  //	int ZenGetBestMoveRate(void)
#define DllZenGetBoardColor	"?ZenGetBoardColor@@YAHHH@Z"  //	int ZenGetBoardColor(int,int)
#define DllZenGetHistorySize	"?ZenGetHistorySize@@YAHXZ"  //	int ZenGetHistorySize(void)
#define DllZenGetNextColor	"?ZenGetNextColor@@YAHXZ"  //	int ZenGetNextColor(void)
#define DllZenGetNumBlackPrisoners	"?ZenGetNumBlackPrisoners@@YAHXZ"  //	int ZenGetNumBlackPrisoners(void)
#define DllZenGetNumWhitePrisoners	"?ZenGetNumWhitePrisoners@@YAHXZ"  //	int ZenGetNumWhitePrisoners(void)
#define DllZenGetPriorKnowledge	"?ZenGetPriorKnowledge@@YAXQAY0BD@H@Z"  //	void ZenGetPriorKnowledge(int (* const)[19])
#define DllZenGetTerritoryStatictics	"?ZenGetTerritoryStatictics@@YAXQAY0BD@H@Z"  //	void ZenGetTerritoryStatictics(int (* const)[19])
#define DllZenGetTopMoveInfo	"?ZenGetTopMoveInfo@@YAXHAAH00AAMPADH@Z"  //	void ZenGetTopMoveInfo(int,int &,int &,int &,float &,char *,int)
#define DllZenInitialize	"?ZenInitialize@@YAXPBD@Z"  //	void ZenInitialize(char const *)
#define DllZenIsInitialized	"?ZenIsInitialized@@YA_NXZ"  //	bool ZenIsInitialized(void)
#define DllZenIsLegal	"?ZenIsLegal@@YA_NHHH@Z"  //	bool ZenIsLegal(int,int,int)
#define DllZenIsSuicide	"?ZenIsSuicide@@YA_NHHH@Z"  //	bool ZenIsSuicide(int,int,int)
#define DllZenIsThinking	"?ZenIsThinking@@YA_NXZ"  //	bool ZenIsThinking(void)
#define DllZenMakeShapeName	"?ZenMakeShapeName@@YAXHHHPADH@Z"  //	void ZenMakeShapeName(int,int,int,char *,int)
#define DllZenPass	"?ZenPass@@YAXH@Z"  //	void ZenPass(int)
#define DllZenPlay	"?ZenPlay@@YA_NHHH@Z"  //	bool ZenPlay(int,int,int)
#define DllZenReadGeneratedMove	"?ZenReadGeneratedMove@@YAXAAH0AA_N1@Z"  //	void ZenReadGeneratedMove(int &,int &,bool &,bool &)
#define DllZenSetAmafWeightFactor	"?ZenSetAmafWeightFactor@@YAXM@Z"  //	void ZenSetAmafWeightFactor(float)
#define DllZenSetBoardSize	"?ZenSetBoardSize@@YAXH@Z"  //	void ZenSetBoardSize(int)
#define DllZenSetDCNN	"?ZenSetDCNN@@YAX_N@Z"  //	void ZenSetDCNN(bool)
#define DllZenSetKomi	"?ZenSetKomi@@YAXM@Z"  //	void ZenSetKomi(float)
#define DllZenSetMaxTime	"?ZenSetMaxTime@@YAXM@Z"  //	void ZenSetMaxTime(float)
#define DllZenSetNextColor	"?ZenSetNextColor@@YAXH@Z"  //	void ZenSetNextColor(int)
#define DllZenSetNumberOfSimulations	"?ZenSetNumberOfSimulations@@YAXH@Z"  //	void ZenSetNumberOfSimulations(int)
#define DllZenSetNumberOfThreads	"?ZenSetNumberOfThreads@@YAXH@Z"  //	void ZenSetNumberOfThreads(int)
#define DllZenSetPriorWeightFactor	"?ZenSetPriorWeightFactor@@YAXM@Z"  //	void ZenSetPriorWeightFactor(float)
#define DllZenStartThinking	"?ZenStartThinking@@YAXH@Z"  //	void ZenStartThinking(int)
#define DllZenStopThinking	"?ZenStopThinking@@YAXXZ"  //	void ZenStopThinking(void)
#define DllZenTimeLeft	"?ZenTimeLeft@@YAXHHH@Z"  //	void ZenTimeLeft(int,int,int)
#define DllZenTimeSettings	"?ZenTimeSettings@@YAXHHH@Z"  //	void ZenTimeSettings(int,int,int)
#define DllZenUndo	"?ZenUndo@@YA_NH@Z"  //	bool ZenUndo(int)


typedef bool(*ZenAddStone)(int, int, int);
typedef void(*ZenClearBoard)(void);
typedef void(*ZenFixedHandicap)(int);
typedef int(*ZenGetBestMoveRate)(void);
typedef int(*ZenGetBoardColor)(int, int);
typedef int(*ZenGetHistorySize)(void);
typedef int(*ZenGetNextColor)(void);
typedef int(*ZenGetNumBlackPrisoners)(void);
typedef int(*ZenGetNumWhitePrisoners)(void);
typedef void(*ZenGetPriorKnowledge)(int(*const)[19]);
typedef void(*ZenGetTerritoryStatictics)(int(*const)[19]);
typedef void(*ZenGetTopMoveInfo)(int, int &, int &, int &, float &, char *, int);
typedef void(*ZenInitialize)(char const *);
typedef bool(*ZenIsInitialized)(void);
typedef bool(*ZenIsLegal)(int, int, int);
typedef bool(*ZenIsSuicide)(int, int, int);
typedef bool(*ZenIsThinking)(void);
typedef void(*ZenMakeShapeName)(int, int, int, char *, int);
typedef void(*ZenPass)(int);
typedef bool(*ZenPlay)(int, int, int);
typedef void(*ZenReadGeneratedMove)(int &, int &, bool &, bool &);
typedef void(*ZenSetAmafWeightFactor)(float);
typedef void(*ZenSetBoardSize)(int);
typedef void(*ZenSetDCNN)(bool);
typedef void(*ZenSetKomi)(float);
typedef void(*ZenSetMaxTime)(float);
typedef void(*ZenSetNextColor)(int);
typedef void(*ZenSetNumberOfSimulations)(int);
typedef void(*ZenSetNumberOfThreads)(int);
typedef void(*ZenSetPriorWeightFactor)(float);
typedef void(*ZenStartThinking)(int);
typedef void(*ZenStopThinking)(void);
typedef void(*ZenTimeLeft)(int, int, int);
typedef void(*ZenTimeSettings)(int, int, int);
typedef bool(*ZenUndo)(int);


ZenAddStone	pZenAddStone;
ZenClearBoard	pZenClearBoard;
ZenFixedHandicap	pZenFixedHandicap;
ZenGetBestMoveRate	pZenGetBestMoveRate;
ZenGetBoardColor	pZenGetBoardColor;
ZenGetHistorySize	pZenGetHistorySize;
ZenGetNextColor	pZenGetNextColor;
ZenGetNumBlackPrisoners	pZenGetNumBlackPrisoners;
ZenGetNumWhitePrisoners	pZenGetNumWhitePrisoners;
ZenGetPriorKnowledge	pZenGetPriorKnowledge;
ZenGetTerritoryStatictics	pZenGetTerritoryStatictics;
ZenGetTopMoveInfo	pZenGetTopMoveInfo;
ZenInitialize	pZenInitialize;
ZenIsInitialized	pZenIsInitialized;
ZenIsLegal	pZenIsLegal;
ZenIsSuicide	pZenIsSuicide;
ZenIsThinking	pZenIsThinking;
ZenMakeShapeName	pZenMakeShapeName;
ZenPass	pZenPass;
ZenPlay	pZenPlay;
ZenReadGeneratedMove	pZenReadGeneratedMove;
ZenSetAmafWeightFactor	pZenSetAmafWeightFactor;
ZenSetBoardSize	pZenSetBoardSize;
ZenSetDCNN	pZenSetDCNN;
ZenSetKomi	pZenSetKomi;
ZenSetMaxTime	pZenSetMaxTime;
ZenSetNextColor	pZenSetNextColor;
ZenSetNumberOfSimulations	pZenSetNumberOfSimulations;
ZenSetNumberOfThreads	pZenSetNumberOfThreads;
ZenSetPriorWeightFactor	pZenSetPriorWeightFactor;
ZenStartThinking	pZenStartThinking;
ZenStopThinking	pZenStopThinking;
ZenTimeLeft	pZenTimeLeft;
ZenTimeSettings	pZenTimeSettings;
ZenUndo	pZenUndo;

 //void LoadDll();
