#pragma once

#include <Windows.h>

class Clock
{
public:
   static void Initialize();
   static void Wait(LONGLONG milliseconds);
   static LONGLONG GetTime();

private:
   static LARGE_INTEGER m_Frequency;
};

