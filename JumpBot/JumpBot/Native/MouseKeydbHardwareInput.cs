// Type: WindowsInput.Native.MOUSEKEYBDHARDWAREINPUT
// Assembly: WindowsInput, Version=1.0.4.0, Culture=neutral, PublicKeyToken=9b287f7dc5073cad
// MVID: 776EB3EF-00F5-4F48-8D79-09AC1BD5E956
// Assembly location: C:\Git\alexwnovak\JumpBot\JumpBot\packages\InputSimulator.1.0.4.0\lib\net20\WindowsInput.dll

using System.Runtime.InteropServices;

namespace JumpBot.Native
{
   /// <summary>
   /// The combined/overlayed structure that includes Mouse, Keyboard and Hardware Input message data (see: http://msdn.microsoft.com/en-us/library/ms646270(VS.85).aspx)
   /// 
   /// </summary>
   [StructLayout( LayoutKind.Explicit )]
   internal struct MOUSEKEYBDHARDWAREINPUT
   {
      /// <summary>
      /// The <see cref="T:WindowsInput.Native.MOUSEINPUT"/> definition.
      /// 
      /// </summary>
      [FieldOffset( 0 )]
      public MOUSEINPUT Mouse;
      /// <summary>
      /// The <see cref="T:WindowsInput.Native.KEYBDINPUT"/> definition.
      /// 
      /// </summary>
      [FieldOffset( 0 )]
      public KEYBDINPUT Keyboard;
      /// <summary>
      /// The <see cref="T:WindowsInput.Native.HARDWAREINPUT"/> definition.
      /// 
      /// </summary>
      [FieldOffset( 0 )]
      public HARDWAREINPUT Hardware;
   }
}
