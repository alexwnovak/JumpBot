#include "stdafx.h"
#include "Clock.h"

LARGE_INTEGER Clock::m_Frequency;

void Clock::Initialize()
{
   QueryPerformanceFrequency(&m_Frequency);
}

void Clock::Wait(LONGLONG milliseconds)
{
   LARGE_INTEGER startingTime, currentTime, elapsedTime;

   QueryPerformanceCounter(&startingTime);

   while (true)
   {
      QueryPerformanceCounter(&currentTime);

      elapsedTime.QuadPart = currentTime.QuadPart - startingTime.QuadPart;
      elapsedTime.QuadPart *= 1000;
      elapsedTime.QuadPart /= m_Frequency.QuadPart;

      if (elapsedTime.QuadPart > milliseconds)
      {
         break;
      }
   }
}