#include "stdafx.h"
#include "InputSimulator.h"
#include "Clock.h"
#include "ScriptLoader.h"
#include "BetterClock.h"

#include <Windows.h>
#include <iostream>
#include <string>

using namespace std;

HHOOK mouseHook;

LRESULT CALLBACK HookCallback(int nCode, WPARAM wParam, LPARAM lParam)
{
   cout << nCode << endl;
   return CallNextHookEx(mouseHook, nCode, wParam, lParam);
}

void MouseHook()
{
   cout << "Setting hook... ";
   
   mouseHook = SetWindowsHookEx( WH_MOUSE, HookCallback, NULL, 0 );

   if (mouseHook == NULL)
   {
      cout << "Failed" << endl;
      return;
   }

   cout << "done" << endl;

   // Wait

   string input;
   cin >> input;

   UnhookWindowsHookEx(mouseHook);
}

int _tmain(int argc, _TCHAR* argv[])
{
   MouseHook();

   return 0;

   //if (argc < 2)
   //{
   //   cout << "Syntax: jump <script>" << endl;
   //   return 0;
   //}

   //if (!ScriptLoader::Load(argv[1]))
   //{
   //   cout << "Failed to load script" << endl;
   //   return 1;
   //}

   Clock::Initialize();
   LONGLONG startTime = Clock::GetTime();

   //TIMECAPS timeCaps;
   //timeGetDevCaps( &timeCaps, sizeof( TIMECAPS ) );

   //BetterClock betterClock;

   //betterClock.Wait(50);

   Clock::Wait( 75 );

   // Done

   LONGLONG endTime = Clock::GetTime();
   cout << "Elapsed time: " << (endTime - startTime) << endl;

   //cout << "Waiting..." << endl;

   //Clock::Wait( 1000 );

   //cout << "Done";

   //return 0;

   //InputSimulator inputSimulator;

   //Sleep(2000);

   //inputSimulator.LeftClick();

   //return 0;

   //inputSimulator.KeyDown(0x57);

   //Sleep(1000);

   //inputSimulator.KeyUp(0x57);

   //inputSimulator.KeyPress(0x20);

   return 0;
}
