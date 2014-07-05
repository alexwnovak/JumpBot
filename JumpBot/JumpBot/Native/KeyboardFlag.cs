// Type: WindowsInput.Native.KeyboardFlag
// Assembly: WindowsInput, Version=1.0.4.0, Culture=neutral, PublicKeyToken=9b287f7dc5073cad
// MVID: 776EB3EF-00F5-4F48-8D79-09AC1BD5E956
// Assembly location: C:\Git\alexwnovak\JumpBot\JumpBot\packages\InputSimulator.1.0.4.0\lib\net20\WindowsInput.dll

using System;

namespace JumpBot.Native
{
   /// <summary>
   /// Specifies various aspects of a keystroke. This member can be certain combinations of the following values.
   /// 
   /// </summary>
   [Flags]
   internal enum KeyboardFlag : uint
   {
      ExtendedKey = 1U,
      KeyUp = 2U,
      Unicode = 4U,
      ScanCode = 8U,
   }
}
