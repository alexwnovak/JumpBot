// Type: WindowsInput.WindowsInputMessageDispatcher
// Assembly: WindowsInput, Version=1.0.4.0, Culture=neutral, PublicKeyToken=9b287f7dc5073cad
// MVID: 776EB3EF-00F5-4F48-8D79-09AC1BD5E956
// Assembly location: C:\Git\alexwnovak\JumpBot\JumpBot\packages\InputSimulator.1.0.4.0\lib\net20\WindowsInput.dll

using System;
using System.Runtime.InteropServices;
using JumpBot.Native;

namespace JumpBot.Input
{
   /// <summary>
   /// Implements the <see cref="T:WindowsInput.IInputMessageDispatcher"/> by calling <see cref="M:WindowsInput.Native.NativeMethods.SendInput(System.UInt32,WindowsInput.Native.INPUT[],System.Int32)"/>.
   /// 
   /// </summary>
   internal class WindowsInputMessageDispatcher : IInputMessageDispatcher
   {
      /// <summary>
      /// Dispatches the specified list of <see cref="T:WindowsInput.Native.INPUT"/> messages in their specified order by issuing a single called to <see cref="M:WindowsInput.Native.NativeMethods.SendInput(System.UInt32,WindowsInput.Native.INPUT[],System.Int32)"/>.
      /// 
      /// </summary>
      /// <param name="inputs">The list of <see cref="T:WindowsInput.Native.INPUT"/> messages to be dispatched.</param><exception cref="T:System.ArgumentException">If the <paramref name="inputs"/> array is empty.</exception><exception cref="T:System.ArgumentNullException">If the <paramref name="inputs"/> array is null.</exception><exception cref="T:System.Exception">If the any of the commands in the <paramref name="inputs"/> array could not be sent successfully.</exception>
      public void DispatchInput( INPUT[] inputs )
      {
         if ( inputs == null )
            throw new ArgumentNullException( "inputs" );
         if ( inputs.Length == 0 )
            throw new ArgumentException( "The input array was empty", "inputs" );
         if ( (long) NativeMethods.SendInput( (uint) inputs.Length, inputs, Marshal.SizeOf( typeof( INPUT ) ) ) != (long) inputs.Length )
            throw new Exception( "Some simulated input commands were not sent successfully. The most common reason for this happening are the security features of Windows including User Interface Privacy Isolation (UIPI). Your application can only send commands to applications of the same or lower elevation. Similarly certain commands are restricted to Accessibility/UIAutomation applications. Refer to the project home page and the code samples for more information." );
      }
   }
}
