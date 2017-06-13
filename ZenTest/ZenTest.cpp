// ZenTest.cpp : 定义控制台应用程序的入口点。
//

#include "stdafx.h"
#include<Windows.h>
#include"ZenTest.h"
#include<iomanip>
#include<fstream>
#include<sstream>
#include<string>

using namespace std;

char *logFile = "D:\abc.txt";

void WriteFile(const char*);

string num2str(int i)
{
	stringstream ss;
	ss << i;
	return ss.str();
}

string num2str(float i)
{
	stringstream ss;
	ss << i;
	return ss.str();
}

string num2str(byte i)
{
	stringstream ss;
	ss << i;
	return ss.str();
}


void LoadDll()
{
	HINSTANCE dllInstance = LoadLibrary("Zen1.dll");
	if (dllInstance == NULL)
	{
		FreeLibrary(dllInstance);
		//return "没找到Zen.dll";
	}
	pZenAddStone = (ZenAddStonePtr)GetProcAddress(dllInstance, DllZenAddStone);
	pZenClearBoard = (ZenClearBoardPtr)GetProcAddress(dllInstance, DllZenClearBoard);
	pZenFixedHandicap = (ZenFixedHandicapPtr)GetProcAddress(dllInstance, DllZenFixedHandicap);
	pZenGetBestMoveRate = (ZenGetBestMoveRatePtr)GetProcAddress(dllInstance, DllZenGetBestMoveRate);
	pZenGetBoardColor = (ZenGetBoardColorPtr)GetProcAddress(dllInstance, DllZenGetBoardColor);
	pZenGetHistorySize = (ZenGetHistorySizePtr)GetProcAddress(dllInstance, DllZenGetHistorySize);
	pZenGetNextColor = (ZenGetNextColorPtr)GetProcAddress(dllInstance, DllZenGetNextColor);
	pZenGetNumBlackPrisoners = (ZenGetNumBlackPrisonersPtr)GetProcAddress(dllInstance, DllZenGetNumBlackPrisoners);
	pZenGetNumWhitePrisoners = (ZenGetNumWhitePrisonersPtr)GetProcAddress(dllInstance, DllZenGetNumWhitePrisoners);
	pZenGetPriorKnowledge = (ZenGetPriorKnowledgePtr)GetProcAddress(dllInstance, DllZenGetPriorKnowledge);
	pZenGetTerritoryStatictics = (ZenGetTerritoryStaticticsPtr)GetProcAddress(dllInstance, DllZenGetTerritoryStatictics);
	pZenGetTopMoveInfo = (ZenGetTopMoveInfoPtr)GetProcAddress(dllInstance, DllZenGetTopMoveInfo);
	pZenInitialize = (ZenInitializePtr)GetProcAddress(dllInstance, DllZenInitialize);
	pZenIsInitialized = (ZenIsInitializedPtr)GetProcAddress(dllInstance, DllZenIsInitialized);
	pZenIsLegal = (ZenIsLegalPtr)GetProcAddress(dllInstance, DllZenIsLegal);
	pZenIsSuicide = (ZenIsSuicidePtr)GetProcAddress(dllInstance, DllZenIsSuicide);
	pZenIsThinking = (ZenIsThinkingPtr)GetProcAddress(dllInstance, DllZenIsThinking);
	pZenMakeShapeName = (ZenMakeShapeNamePtr)GetProcAddress(dllInstance, DllZenMakeShapeName);
	pZenPass = (ZenPassPtr)GetProcAddress(dllInstance, DllZenPass);
	pZenPlay = (ZenPlayPtr)GetProcAddress(dllInstance, DllZenPlay);
	pZenReadGeneratedMove = (ZenReadGeneratedMovePtr)GetProcAddress(dllInstance, DllZenReadGeneratedMove);
	pZenSetAmafWeightFactor = (ZenSetAmafWeightFactorPtr)GetProcAddress(dllInstance, DllZenSetAmafWeightFactor);
	pZenSetBoardSize = (ZenSetBoardSizePtr)GetProcAddress(dllInstance, DllZenSetBoardSize);
	pZenSetDCNN = (ZenSetDCNNPtr)GetProcAddress(dllInstance, DllZenSetDCNN);
	pZenSetKomi = (ZenSetKomiPtr)GetProcAddress(dllInstance, DllZenSetKomi);
	pZenSetMaxTime = (ZenSetMaxTimePtr)GetProcAddress(dllInstance, DllZenSetMaxTime);
	pZenSetNextColor = (ZenSetNextColorPtr)GetProcAddress(dllInstance, DllZenSetNextColor);
	pZenSetNumberOfSimulations = (ZenSetNumberOfSimulationsPtr)GetProcAddress(dllInstance, DllZenSetNumberOfSimulations);
	pZenSetNumberOfThreads = (ZenSetNumberOfThreadsPtr)GetProcAddress(dllInstance, DllZenSetNumberOfThreads);
	pZenSetPriorWeightFactor = (ZenSetPriorWeightFactorPtr)GetProcAddress(dllInstance, DllZenSetPriorWeightFactor);
	pZenStartThinking = (ZenStartThinkingPtr)GetProcAddress(dllInstance, DllZenStartThinking);
	pZenStopThinking = (ZenStopThinkingPtr)GetProcAddress(dllInstance, DllZenStopThinking);
	pZenTimeLeft = (ZenTimeLeftPtr)GetProcAddress(dllInstance, DllZenTimeLeft);
	pZenTimeSettings = (ZenTimeSettingsPtr)GetProcAddress(dllInstance, DllZenTimeSettings);
	pZenUndo = (ZenUndoPtr)GetProcAddress(dllInstance, DllZenUndo);
}

int main()
{
	LoadDll();
	(*pZenInitialize)("myzen");
	(*pZenClearBoard)();
	(*pZenSetBoardSize)(19);
	(*pZenSetKomi)(6.5);
	bool isinitialized = (*pZenIsInitialized)();
	//(*pZenPlay)(0,0,0);
	//bool isThinking = (*pZenIsThinking)();
	/*(*pZenStartThinking)(0);*/
	//while ((*pZenIsThinking)())
	//{
	//}
	/*(*pZenPlay)(0,0,0);
	int a, b; bool ba, bb;
	pZenReadGeneratedMove(a, b, ba, bb);*/


	(*pZenAddStone)(3, 3, 1);

	int size = (*pZenGetHistorySize)();//0
									   //int rate = (*pZenGetBestMoveRate)();
	int boardColor = (*pZenGetBoardColor)(1, 1);//0
	int nextColor = (*pZenGetNextColor)();//2
	int bp = (*pZenGetNumBlackPrisoners)();//0
	int wp = (*pZenGetNumWhitePrisoners)();//0
	int arrayKnowledge[19][19];
	int(*knowledge)[19] = arrayKnowledge;
	(*pZenGetPriorKnowledge)(knowledge);//当前局面选点分值（先验知识）
	int arrayStatictics[19][19];
	int(*statictics)[19] = arrayStatictics;
	(*pZenGetTerritoryStatictics)(statictics);
	//(*pZenGetTopMoveInfo)();

	(*pZenAddStone)(3, 3, 0);
	boardColor = (*pZenGetBoardColor)(3, 3);
	nextColor = (*pZenGetNextColor)();
	(*pZenGetPriorKnowledge)(knowledge);//当前局面选点分值（先验知识）
	(*pZenGetTerritoryStatictics)(statictics);

	(*pZenAddStone)(9, 9, 2);
	boardColor = (*pZenGetBoardColor)(9, 9);
	nextColor = (*pZenGetNextColor)();
	(*pZenGetPriorKnowledge)(knowledge);//当前局面选点分值（先验知识）
	(*pZenGetTerritoryStatictics)(statictics);

	return 0;
}


#pragma region 函数定义

bool ZenAddStone(int a, int b, int c)
{
	ostringstream s1;
	s1 << "ZenAddStone " << a << " " << b << " " << c;
	WriteFile(s1.str().c_str());
	return  (*pZenAddStone)(a, b, c);
}

void ZenClearBoard(void)
{
	ostringstream s1;
	s1 << "ZenClearBoard ";
	WriteFile(s1.str().c_str());
	return	(*pZenClearBoard)();
}

void ZenFixedHandicap(int a)
{
	ostringstream s1;
	s1 << "ZenFixedHandicap " << a;
	WriteFile(s1.str().c_str());
	return	(*pZenFixedHandicap)(a);
}

int ZenGetBestMoveRate(void)
{
	ostringstream s1;
	s1 << "ZenGetBestMoveRate ";
	WriteFile(s1.str().c_str());
	return	(*pZenGetBestMoveRate)();
}

int ZenGetBoardColor(int a, int b)
{
	ostringstream s1;
	s1 << "ZenGetBoardColor " << a << " " << b;
	WriteFile(s1.str().c_str());
	return	(*pZenGetBoardColor)(a, b);
}

int ZenGetHistorySize(void)
{
	ostringstream s1;
	s1 << "ZenGetHistorySize ";
	WriteFile(s1.str().c_str());
	return	(*pZenGetHistorySize)();
}

int ZenGetNextColor(void)
{
	ostringstream s1;
	s1 << "ZenGetNextColor ";
	WriteFile(s1.str().c_str());
	return	(*pZenGetNextColor)();
}

int ZenGetNumBlackPrisoners(void)
{
	ostringstream s1;
	s1 << "ZenGetNumBlackPrisoners ";
	WriteFile(s1.str().c_str());
	return	(*pZenGetNumBlackPrisoners)();
}

int ZenGetNumWhitePrisoners(void)
{
	ostringstream s1;
	s1 << "ZenGetNumWhitePrisoners ";
	WriteFile(s1.str().c_str());
	return	(*pZenGetNumWhitePrisoners)();
}

void ZenGetPriorKnowledge(int(*const a)[19])
{
	ostringstream s1;
	s1 << "ZenGetPriorKnowledge " << a;
	WriteFile(s1.str().c_str());
	return	(*pZenGetPriorKnowledge)(a);
}

void ZenGetTerritoryStatictics(int(*const a)[19])
{
	ostringstream s1;
	s1 << "ZenGetTerritoryStatictics " << a;
	WriteFile(s1.str().c_str());
	return	(*pZenGetTerritoryStatictics)(a);
}

void ZenGetTopMoveInfo(int a, int  &b, int &c, int &d, float &e, char *f, int g)
{
	ostringstream s1;
	s1 << "ZenGetTopMoveInfo " << a << " " << b << " " << c << " " << d << " " << e << " " << f << " " << g;
	WriteFile(s1.str().c_str());
	return	(*pZenGetTopMoveInfo)(a, b, c, d, e, f, g);
}

void ZenInitialize(char const * a)
{
	ostringstream s1;
	s1 << "ZenInitialize " << a;
	WriteFile(s1.str().c_str());
	return	(*pZenInitialize)(a);
}

bool ZenIsInitialized(void)
{
	ostringstream s1;
	s1 << "ZenIsInitialized ";
	WriteFile(s1.str().c_str());
	return	(*pZenIsInitialized)();
}

bool ZenIsLegal(int a, int b, int c)
{
	ostringstream s1;
	s1 << "ZenIsLegal " << a << " " << b << " " << c;
	WriteFile(s1.str().c_str());
	return	(*pZenIsLegal)(a, b, c);
}

bool ZenIsSuicide(int a, int b, int c)
{
	ostringstream s1;
	s1 << "ZenIsSuicide " << a << " " << b << " " << c;
	WriteFile(s1.str().c_str());
	return	(*pZenIsSuicide)(a, b, c);
}

bool ZenIsThinking(void)
{
	ostringstream s1;
	s1 << "ZenIsThinking ";
	WriteFile(s1.str().c_str());
	return	(*pZenIsThinking)();
}

void ZenMakeShapeName(int a, int b, int c, char *d, int e)
{
	ostringstream s1;
	s1 << "ZenMakeShapeName " << a << " " << b << " " << c << " " << d << " " << e;
	WriteFile(s1.str().c_str());
	return	(*pZenMakeShapeName)(a, b, c, d, e);
}

void ZenPass(int a)
{
	ostringstream s1;
	s1 << "ZenPass " << a;
	WriteFile(s1.str().c_str());
	return	(*pZenPass)(a);
}

bool ZenPlay(int a, int b, int c)
{
	ostringstream s1;
	s1 << "ZenPlay " << a << " " << b << " " << c;
	WriteFile(s1.str().c_str());
	return	(*pZenPlay)(a, b, c);
}

void ZenReadGeneratedMove(int &a, int &b, bool &c, bool &d)
{
	ostringstream s1;
	s1 << "ZenReadGeneratedMove " << a << " " << b << " " << c << " " << d;
	WriteFile(s1.str().c_str());
	return	(*pZenReadGeneratedMove)(a, b, c, d);
}

void ZenSetAmafWeightFactor(float a)
{
	ostringstream s1;
	s1 << "ZenSetAmafWeightFactor " << a;
	WriteFile(s1.str().c_str());
	return	(*pZenSetAmafWeightFactor)(a);
}

void ZenSetBoardSize(int a)
{
	ostringstream s1;
	s1 << "ZenSetBoardSize " << a;
	WriteFile(s1.str().c_str());
	return	(*pZenSetBoardSize)(a);
}

void ZenSetDCNN(bool a)
{
	ostringstream s1;
	s1 << "ZenSetDCNN " << a;
	WriteFile(s1.str().c_str());
	return	(*pZenSetDCNN)(a);
}

void ZenSetKomi(float a)
{
	ostringstream s1;
	s1 << "ZenSetKomi " << a;
	WriteFile(s1.str().c_str());
	return	(*pZenSetKomi)(a);
}

void ZenSetMaxTime(float a)
{
	ostringstream s1;
	s1 << "ZenSetMaxTime ";
	WriteFile(s1.str().c_str());
	return	(*pZenSetMaxTime)(a);
}

void ZenSetNextColor(int a)
{
	ostringstream s1;
	s1 << "ZenSetNextColor " << a;
	WriteFile(s1.str().c_str());
	return	(*pZenSetNextColor)(a);
}

void ZenSetNumberOfSimulations(int a)
{
	ostringstream s1;
	s1 << "ZenSetNumberOfSimulations " << a;
	WriteFile(s1.str().c_str());
	return	(*pZenSetNumberOfSimulations)(a);
}

void ZenSetNumberOfThreads(int a)
{
	ostringstream s1;
	s1 << "ZenSetNumberOfThreads " << a;
	WriteFile(s1.str().c_str());
	return	(*pZenSetNumberOfThreads)(a);
}

void ZenSetPriorWeightFactor(float a)
{
	ostringstream s1;
	s1 << "ZenSetPriorWeightFactor " << a;
	WriteFile(s1.str().c_str());
	return	(*pZenSetPriorWeightFactor)(a);
}

void ZenStartThinking(int a)
{
	ostringstream s1;
	s1 << "ZenStartThinking " << a;
	WriteFile(s1.str().c_str());
	return	(*pZenStartThinking)(a);
}

void ZenStopThinking(void)
{
	ostringstream s1;
	s1 << "ZenStopThinking ";
	WriteFile(s1.str().c_str());
	return	(*pZenStopThinking)();
}

void ZenTimeLeft(int a, int b, int c)
{
	ostringstream s1;
	s1 << "ZenTimeLeft " << a << " " << b << " " << c;
	WriteFile(s1.str().c_str());
	return	(*pZenTimeLeft)(a, b, c);
}

void ZenTimeSettings(int a, int b, int c)
{
	ostringstream s1;
	s1 << "ZenTimeSettings " << a << " " << b << " " << c;
	WriteFile(s1.str().c_str());
	return	(*pZenTimeSettings)(a, b, c);
}

bool ZenUndo(int a)
{
	ostringstream s1;
	s1 << "ZenUndo " << a;
	WriteFile(s1.str().c_str());
	return	(*pZenUndo)(a);
}
#pragma endregion

void WriteFile(const char *msg)
{
	ofstream f1("d:\\zenTest.txt", ios::app);//打开文件用于写，若文件不存在就创建它
	if (!f1)
		return;//打开文件失败则结束运行
	f1 << msg << endl;//使用插入运算符写文件内容
	f1.close();//关闭文件
}

