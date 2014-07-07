#include "stdafx.h"
#include "InputSimulator.h"

#include <Windows.h>

InputSimulator::InputSimulator()
{
}

InputSimulator::~InputSimulator()
{
}

void InputSimulator::KeyDown(int scanCode)
{
   INPUT input;
   ZeroMemory(&input, sizeof(INPUT));

   input.type = INPUT_KEYBOARD;
   input.ki.wVk = scanCode;
   input.ki.wScan = scanCode;
   input.ki.dwFlags = 0x00 | KEYEVENTF_SCANCODE;

   SendInput(1, &input, sizeof(INPUT));
}

void InputSimulator::KeyUp(int scanCode)
{
   INPUT input;
   ZeroMemory(&input, sizeof(INPUT));

   input.type = INPUT_KEYBOARD;
   input.ki.wVk = scanCode;
   input.ki.wScan = scanCode;
   input.ki.dwFlags = KEYEVENTF_KEYUP | KEYEVENTF_SCANCODE;

   SendInput(1, &input, sizeof(INPUT));
}

void InputSimulator::KeyPress(int scanCode)
{
   INPUT inputs[2];
   ZeroMemory(inputs, 0, sizeof(INPUT) * 2);

   // First is KeyDown event

   inputs[0].type = INPUT_KEYBOARD;
   inputs[0].ki.wVk = scanCode;
   inputs[0].ki.wScan = scanCode;
   inputs[0].ki.dwFlags = 0x00 | KEYEVENTF_SCANCODE;

   // Second is KeyUp event

   inputs[1].type = INPUT_KEYBOARD;
   inputs[1].ki.wVk = scanCode;
   inputs[1].ki.wScan = scanCode;
   inputs[1].ki.dwFlags = KEYEVENTF_KEYUP | KEYEVENTF_SCANCODE;

   SendInput(2, inputs, sizeof(INPUT));
}

void InputSimulator::LeftClick()
{
   INPUT inputs[2];
   ZeroMemory(inputs, sizeof(INPUT) * 2);

   // First is MouseLeftDown event

   inputs[0].mi.dwFlags = MOUSEEVENTF_LEFTDOWN;
   inputs[1].mi.dwFlags = MOUSEEVENTF_LEFTUP;

   SendInput(2, inputs, sizeof(INPUT));
}