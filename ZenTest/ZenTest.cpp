// ZenTest.cpp : 定义控制台应用程序的入口点。
//

#include "stdafx.h"
#include<Windows.h>

//extern void ZenClearBoard();
typedef void(*ZenClear)(int);

int main()
{
	ZenClear maopao1;
	HINSTANCE hdll;
	hdll = LoadLibrary("Zen.dll");
	if (hdll == NULL)
	{
		FreeLibrary(hdll);
	}
	//maopao1 = (ZenClear)GetProcAddress(hdll, "?ZenClearBoard@@YAXXZ");
	maopao1 = (ZenClear)GetProcAddress(hdll, "?ZenSetBoardSize@@YAXH@Z");
	if (maopao1 == NULL)
	{
		FreeLibrary(hdll);
	}

	//maopao1 = (ZenClear)0x00069220;
	(*maopao1)(19);

	return 0;
}

