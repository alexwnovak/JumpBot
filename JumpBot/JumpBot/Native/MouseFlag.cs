// Type: WindowsInput.Native.MouseFlag
// Assembly: WindowsInput, Version=1.0.4.0, Culture=neutral, PublicKeyToken=9b287f7dc5073cad
// MVID: 776EB3EF-00F5-4F48-8D79-09AC1BD5E956
// Assembly location: C:\Git\alexwnovak\JumpBot\JumpBot\packages\InputSimulator.1.0.4.0\lib\net20\WindowsInput.dll

using System;

namespace JumpBot.Native
{
   /// <summary>
   /// The set of MouseFlags for use in the Flags property of the <see cref="T:WindowsInput.Native.MOUSEINPUT"/> structure. (See: http://msdn.microsoft.com/en-us/library/ms646273(VS.85).aspx)
   /// 
   /// </summary>
   [Flags]
   internal enum MouseFlag : uint
   {
      Move = 1U,
      LeftDown = 2U,
      LeftUp = 4U,
      RightDown = 8U,
      RightUp = 16U,
      MiddleDown = 32U,
      MiddleUp = 64U,
      XDown = 128U,
      XUp = 256U,
      VerticalWheel = 2048U,
      HorizontalWheel = 4096U,
      VirtualDesk = 16384U,
      Absolute = 32768U,
   }
}
