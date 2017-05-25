// ZenTest.cpp : 定义控制台应用程序的入口点。
//

#include "stdafx.h"
#include "ZenTest.h"
#include<Windows.h>

void LoadDll()
{
	HINSTANCE dllInstance = LoadLibrary("Zen.dll");
	if (dllInstance == NULL)
	{
		FreeLibrary(dllInstance);
		//return "没找到Zen.dll";
	}
	pZenAddStone = (ZenAddStone)GetProcAddress(dllInstance, DllZenAddStone);
	pZenClearBoard = (ZenClearBoard)GetProcAddress(dllInstance, DllZenClearBoard);
	pZenFixedHandicap = (ZenFixedHandicap)GetProcAddress(dllInstance, DllZenFixedHandicap);
	pZenGetBestMoveRate = (ZenGetBestMoveRate)GetProcAddress(dllInstance, DllZenGetBestMoveRate);
	pZenGetBoardColor = (ZenGetBoardColor)GetProcAddress(dllInstance, DllZenGetBoardColor);
	pZenGetHistorySize = (ZenGetHistorySize)GetProcAddress(dllInstance, DllZenGetHistorySize);
	pZenGetNextColor = (ZenGetNextColor)GetProcAddress(dllInstance, DllZenGetNextColor);
	pZenGetNumBlackPrisoners = (ZenGetNumBlackPrisoners)GetProcAddress(dllInstance, DllZenGetNumBlackPrisoners);
	pZenGetNumWhitePrisoners = (ZenGetNumWhitePrisoners)GetProcAddress(dllInstance, DllZenGetNumWhitePrisoners);
	pZenGetPriorKnowledge = (ZenGetPriorKnowledge)GetProcAddress(dllInstance, DllZenGetPriorKnowledge);
	pZenGetTerritoryStatictics = (ZenGetTerritoryStatictics)GetProcAddress(dllInstance, DllZenGetTerritoryStatictics);
	pZenGetTopMoveInfo = (ZenGetTopMoveInfo)GetProcAddress(dllInstance, DllZenGetTopMoveInfo);
	pZenInitialize = (ZenInitialize)GetProcAddress(dllInstance, DllZenInitialize);
	pZenIsInitialized = (ZenIsInitialized)GetProcAddress(dllInstance, DllZenIsInitialized);
	pZenIsLegal = (ZenIsLegal)GetProcAddress(dllInstance, DllZenIsLegal);
	pZenIsSuicide = (ZenIsSuicide)GetProcAddress(dllInstance, DllZenIsSuicide);
	pZenIsThinking = (ZenIsThinking)GetProcAddress(dllInstance, DllZenIsThinking);
	pZenMakeShapeName = (ZenMakeShapeName)GetProcAddress(dllInstance, DllZenMakeShapeName);
	pZenPass = (ZenPass)GetProcAddress(dllInstance, DllZenPass);
	pZenPlay = (ZenPlay)GetProcAddress(dllInstance, DllZenPlay);
	pZenReadGeneratedMove = (ZenReadGeneratedMove)GetProcAddress(dllInstance, DllZenReadGeneratedMove);
	pZenSetAmafWeightFactor = (ZenSetAmafWeightFactor)GetProcAddress(dllInstance, DllZenSetAmafWeightFactor);
	pZenSetBoardSize = (ZenSetBoardSize)GetProcAddress(dllInstance, DllZenSetBoardSize);
	pZenSetDCNN = (ZenSetDCNN)GetProcAddress(dllInstance, DllZenSetDCNN);
	pZenSetKomi = (ZenSetKomi)GetProcAddress(dllInstance, DllZenSetKomi);
	pZenSetMaxTime = (ZenSetMaxTime)GetProcAddress(dllInstance, DllZenSetMaxTime);
	pZenSetNextColor = (ZenSetNextColor)GetProcAddress(dllInstance, DllZenSetNextColor);
	pZenSetNumberOfSimulations = (ZenSetNumberOfSimulations)GetProcAddress(dllInstance, DllZenSetNumberOfSimulations);
	pZenSetNumberOfThreads = (ZenSetNumberOfThreads)GetProcAddress(dllInstance, DllZenSetNumberOfThreads);
	pZenSetPriorWeightFactor = (ZenSetPriorWeightFactor)GetProcAddress(dllInstance, DllZenSetPriorWeightFactor);
	pZenStartThinking = (ZenStartThinking)GetProcAddress(dllInstance, DllZenStartThinking);
	pZenStopThinking = (ZenStopThinking)GetProcAddress(dllInstance, DllZenStopThinking);
	pZenTimeLeft = (ZenTimeLeft)GetProcAddress(dllInstance, DllZenTimeLeft);
	pZenTimeSettings = (ZenTimeSettings)GetProcAddress(dllInstance, DllZenTimeSettings);
	pZenUndo = (ZenUndo)GetProcAddress(dllInstance, DllZenUndo);

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

