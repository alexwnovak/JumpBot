#include "stdafx.h"
#include "InputSimulator.h"

#include <Windows.h>
#include <iostream>

using namespace std;

LARGE_INTEGER Frequency;

void Wait(LONGLONG duration)
{
   LARGE_INTEGER StartingTime, EndingTime, ElapsedMicroseconds;
   LARGE_INTEGER CurrentTime;


   QueryPerformanceCounter(&StartingTime);

   while (true)
   {
      QueryPerformanceCounter(&CurrentTime);

      ElapsedMicroseconds.QuadPart = CurrentTime.QuadPart - StartingTime.QuadPart;
      ElapsedMicroseconds.QuadPart *= 1000;
      ElapsedMicroseconds.QuadPart /= Frequency.QuadPart;

      if (ElapsedMicroseconds.QuadPart > duration)
      {
         break;
      }
   }

   //// Activity to be timed

   //QueryPerformanceCounter(&EndingTime);
   //ElapsedMicroseconds.QuadPart = EndingTime.QuadPart - StartingTime.QuadPart;


   ////
   //// We now have the elapsed number of ticks, along with the
   //// number of ticks-per-second. We use these values
   //// to convert to the number of elapsed microseconds.
   //// To guard against loss-of-precision, we convert
   //// to microseconds *before* dividing by ticks-per-second.
   ////

   //ElapsedMicroseconds.QuadPart *= 1000000;
   //ElapsedMicroseconds.QuadPart /= Frequency.QuadPart;
}

int _tmain(int argc, _TCHAR* argv[])
{
   QueryPerformanceFrequency(&Frequency);

   cout << "Waiting..." << endl;

   Wait( 1000 );

   cout << "Done";

   return 0;

   InputSimulator inputSimulator;

   Sleep(2000);

   inputSimulator.LeftClick();

   return 0;

   inputSimulator.KeyDown(0x57);

   Sleep(1000);

   inputSimulator.KeyUp(0x57);

   inputSimulator.KeyPress(0x20);

   return 0;
}
