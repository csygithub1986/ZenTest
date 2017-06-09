#pragma once
#define _EXTERN_C_  extern "C"  _declspec(dllexport)

#pragma region �������궨��
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

#pragma region ����ָ��궨��
typedef bool(*ZenAddStone)(int, int, int);//������add����������
typedef void(*ZenClearBoard)(void);//�������
typedef void(*ZenFixedHandicap)(int);//��������
typedef int(*ZenGetBestMoveRate)(void);//Ҫ���кܳ�ʱ�䣡��
typedef int(*ZenGetBoardColor)(int, int);//�鿴����ĳһ�����ɫ
typedef int(*ZenGetHistorySize)(void);//��ʷ����
typedef int(*ZenGetNextColor)(void);//�鿴��һ����˭��
typedef int(*ZenGetNumBlackPrisoners)(void);//�鿴��������
typedef int(*ZenGetNumWhitePrisoners)(void);//�鿴��������
typedef void(*ZenGetPriorKnowledge)(int(*const)[19]);//���ӵķ�ֵ
typedef void(*ZenGetTerritoryStatictics)(int(*const)[19]);//������ĳһ�㱻���Ƶķ�ֵ��1000��ȫ�ڿ��ƣ�-1000Ϊ�׿���
typedef void(*ZenGetTopMoveInfo)(int, int &, int &, int &, float &, char *, int);
typedef void(*ZenInitialize)(char const *);//��ʼ��
typedef bool(*ZenIsInitialized)(void);//�Ƿ��ʼ��
typedef bool(*ZenIsLegal)(int, int, int);//ָ�������ӵķ�Χ�Ƿ�Ϸ���û���жϽ���������ɫ
typedef bool(*ZenIsSuicide)(int, int, int);//                   ?????�㲻����19���������12��������ȫ������suicide
typedef bool(*ZenIsThinking)(void);//                           ????Ϊ������thinking
typedef void(*ZenMakeShapeName)(int, int, int, char *, int);
typedef void(*ZenPass)(int);//pass
typedef bool(*ZenPlay)(int, int, int);//���ӣ�Ӱ��nextcolor��history
typedef void(*ZenReadGeneratedMove)(int &, int &, bool &, bool &);
typedef void(*ZenSetAmafWeightFactor)(float);
typedef void(*ZenSetBoardSize)(int);//�������̴�С
typedef void(*ZenSetDCNN)(bool);
typedef void(*ZenSetKomi)(float);//������Ŀ
typedef void(*ZenSetMaxTime)(float);
typedef void(*ZenSetNextColor)(int);//������һ������ɫ
typedef void(*ZenSetNumberOfSimulations)(int);//����־�е�Playout��Ӧ�����1000��Ҫ��1s��
typedef void(*ZenSetNumberOfThreads)(int);
typedef void(*ZenSetPriorWeightFactor)(float);
typedef void(*ZenStartThinking)(int);//��ʼ˼��
typedef void(*ZenStopThinking)(void);//ֹͣ˼��
typedef void(*ZenTimeLeft)(int, int, int);
typedef void(*ZenTimeSettings)(int, int, int);
typedef bool(*ZenUndo)(int);//����
#pragma endregion

#pragma region ����ָ������
ZenInitialize pZenInitialize;//ok
ZenClearBoard pZenClearBoard;//ok
							 ///get
ZenGetHistorySize pZenGetHistorySize;// int ZenGetHistorySize(void)
ZenGetBestMoveRate pZenGetBestMoveRate;// int ZenGetBestMoveRate(void)
ZenGetBoardColor pZenGetBoardColor;// int ZenGetBoardColor(int,int)
ZenGetNextColor pZenGetNextColor;// int ZenGetNextColor(void)
ZenGetNumBlackPrisoners pZenGetNumBlackPrisoners;// int ZenGetNumBlackPrisoners(void)
ZenGetNumWhitePrisoners pZenGetNumWhitePrisoners;// int ZenGetNumWhitePrisoners(void)
ZenGetPriorKnowledge pZenGetPriorKnowledge;// void ZenGetPriorKnowledge(int (* const)[19])
ZenGetTerritoryStatictics pZenGetTerritoryStatictics;// void ZenGetTerritoryStatictics(int (* const)[19])
ZenGetTopMoveInfo pZenGetTopMoveInfo;// void ZenGetTopMoveInfo(int,int &,int &,int &,float &,char *,int)

									 ///set
ZenSetNextColor pZenSetNextColor;
ZenSetAmafWeightFactor pZenSetAmafWeightFactor;
ZenSetBoardSize pZenSetBoardSize;//ok
ZenSetDCNN pZenSetDCNN;//������
ZenSetKomi pZenSetKomi;//ok
ZenSetMaxTime pZenSetMaxTime;//
ZenSetNumberOfSimulations pZenSetNumberOfSimulations;
ZenSetNumberOfThreads pZenSetNumberOfThreads;
ZenSetPriorWeightFactor pZenSetPriorWeightFactor;

ZenAddStone pZenAddStone;
ZenFixedHandicap pZenFixedHandicap;
ZenIsInitialized pZenIsInitialized;//
ZenIsLegal pZenIsLegal;
ZenIsSuicide pZenIsSuicide;
ZenIsThinking pZenIsThinking;
ZenMakeShapeName pZenMakeShapeName;
ZenPass pZenPass;
ZenPlay pZenPlay;
ZenReadGeneratedMove pZenReadGeneratedMove;//
ZenStartThinking pZenStartThinking;
ZenStopThinking pZenStopThinking;
ZenTimeLeft pZenTimeLeft;
ZenTimeSettings pZenTimeSettings;
ZenUndo pZenUndo;
#pragma endregion

#pragma region Extern
_EXTERN_C_ 	 bool AddStone(int, int, int);
_EXTERN_C_ 	 void ClearBoard(void) ;
_EXTERN_C_ 	 void FixedHandicap(int);
_EXTERN_C_ 	 int GetBestMoveRate(void);
_EXTERN_C_ 	 int GetBoardColor(int, int);
_EXTERN_C_ 	 int GetHistorySize(void);
_EXTERN_C_ 	 int GetNextColor(void);
_EXTERN_C_ 	 int GetNumBlackPrisoners(void);
_EXTERN_C_ 	 int GetNumWhitePrisoners(void);
_EXTERN_C_ 	 void GetPriorKnowledge(int(*const)[19]);
_EXTERN_C_ 	 void GetTerritoryStatictics(int(*const)[19]);
_EXTERN_C_ 	 void GetTopMoveInfo(int, int &, int &, int &, float &, char *, int);
_EXTERN_C_ 	 void Initialize();
_EXTERN_C_ 	 bool IsInitialized(void);
_EXTERN_C_ 	 bool IsLegal(int, int, int);
_EXTERN_C_ 	 bool IsSuicide(int, int, int);
_EXTERN_C_ 	 bool IsThinking(void);
_EXTERN_C_ 	 void MakeShapeName(int, int, int, char *, int);
_EXTERN_C_ 	 void Pass(int);
_EXTERN_C_ 	 bool Play(int, int, int);
_EXTERN_C_ 	 void ReadGeneratedMove(int &, int &, bool &, bool &);
_EXTERN_C_ 	 void SetAmafWeightFactor(float);
_EXTERN_C_ 	 void SetBoardSize(int);
_EXTERN_C_ 	 void SetDCNN(bool);
_EXTERN_C_ 	 void SetKomi(float);
_EXTERN_C_ 	 void SetMaxTime(float);
_EXTERN_C_ 	 void SetNextColor(int);
_EXTERN_C_ 	 void SetNumberOfSimulations(int);
_EXTERN_C_ 	 void SetNumberOfThreads(int);
_EXTERN_C_ 	 void SetPriorWeightFactor(float);
_EXTERN_C_ 	 void StartThinking(int);
_EXTERN_C_ 	 void StopThinking(void);
_EXTERN_C_ 	 void TimeLeft(int, int, int);
_EXTERN_C_ 	 void TimeSettings(int, int, int);
_EXTERN_C_ 	 bool Undo(int);
#pragma endregion

/*
2�Ǻڣ�1�ǰף�0�ǿ�
Addstone������1��2�����⣬����Ϊ��1

*/
