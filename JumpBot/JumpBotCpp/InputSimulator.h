#pragma once

class InputSimulator
{
public:
   InputSimulator();
   ~InputSimulator();

   void KeyDown(int scanCode);
   void KeyUp(int scanCode);
   void KeyPress(int scanCode);

   void LeftClick();
};

