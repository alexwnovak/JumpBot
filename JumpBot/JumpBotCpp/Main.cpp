#include "stdafx.h"
#include "InputSimulator.h"
#include "Clock.h"
#include "ScriptLoader.h"

#include <Windows.h>
#include <iostream>

using namespace std;

int _tmain(int argc, _TCHAR* argv[])
{
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

   cout << "Running in 2 seconds..." << endl;

   Clock::Initialize();
   Clock::Wait( 2000 );

   // Ctap

   const int Key_W = 17;
   const int Key_Duck = 42;
   const int Key_Jump = 57;

   InputSimulator simulator;

   simulator.KeyDown( Key_W );

   Clock::Wait( 1000 );

   simulator.KeyDown( Key_Duck );
   Clock::Wait( 150 );
   simulator.KeyUp( Key_Duck );
   simulator.KeyPress( Key_Jump );
   simulator.LeftClick();

   simulator.KeyUp( Key_W );

   //Clock::Initialize();

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
