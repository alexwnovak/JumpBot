using System;
using System.Runtime.InteropServices;

namespace JumpBot
{
   public static class Win32
   {
      [DllImport( "user32.dll", EntryPoint = "FindWindow", SetLastError = true )]
      public static extern IntPtr FindWindow( string lpClassName, string lpWindowName );

      [DllImport( "user32.dll", SetLastError = true )]
      public static extern IntPtr BringWindowToTop( IntPtr hWnd );
   }
}
