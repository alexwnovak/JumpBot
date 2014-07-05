// Type: WindowsInput.WindowsInputDeviceStateAdaptor
// Assembly: WindowsInput, Version=1.0.4.0, Culture=neutral, PublicKeyToken=9b287f7dc5073cad
// MVID: 776EB3EF-00F5-4F48-8D79-09AC1BD5E956
// Assembly location: C:\Git\alexwnovak\JumpBot\JumpBot\packages\InputSimulator.1.0.4.0\lib\net20\WindowsInput.dll

using JumpBot.Native;

namespace JumpBot.Input
{
   /// <summary>
   /// An implementation of <see cref="T:WindowsInput.IInputDeviceStateAdaptor"/> for Windows by calling the native <see cref="M:WindowsInput.Native.NativeMethods.GetKeyState(System.UInt16)"/> and <see cref="M:WindowsInput.Native.NativeMethods.GetAsyncKeyState(System.UInt16)"/> methods.
   /// 
   /// </summary>
   public class WindowsInputDeviceStateAdaptor : IInputDeviceStateAdaptor
   {
      /// <summary>
      /// Determines whether the specified key is up or down by calling the GetKeyState function. (See: http://msdn.microsoft.com/en-us/library/ms646301(VS.85).aspx)
      /// 
      /// </summary>
      /// <param name="keyCode">The <see cref="T:WindowsInput.Native.VirtualKeyCode"/> for the key.</param>
      /// <returns>
      /// <c>true</c> if the key is down; otherwise, <c>false</c>.
      /// 
      /// </returns>
      /// 
      /// <remarks>
      /// The key status returned from this function changes as a thread reads key messages from its message queue. The status does not reflect the interrupt-level state associated with the hardware. Use the GetAsyncKeyState function to retrieve that information.
      ///             An application calls GetKeyState in response to a keyboard-input message. This function retrieves the state of the key when the input message was generated.
      ///             To retrieve state information for all the virtual keys, use the GetKeyboardState function.
      ///             An application can use the virtual-key code constants VK_SHIFT, VK_CONTROL, and VK_MENU as values for Bthe nVirtKey parameter. This gives the status of the SHIFT, CTRL, or ALT keys without distinguishing between left and right. An application can also use the following virtual-key code constants as values for nVirtKey to distinguish between the left and right instances of those keys.
      ///             VK_LSHIFT
      ///             VK_RSHIFT
      ///             VK_LCONTROL
      ///             VK_RCONTROL
      ///             VK_LMENU
      ///             VK_RMENU
      /// 
      ///             These left- and right-distinguishing constants are available to an application only through the GetKeyboardState, SetKeyboardState, GetAsyncKeyState, GetKeyState, and MapVirtualKey functions.
      /// 
      /// </remarks>
      public bool IsKeyDown( VirtualKeyCode keyCode )
      {
         return (int) NativeMethods.GetKeyState( (ushort) keyCode ) < 0;
      }

      /// <summary>
      /// Determines whether the specified key is up or downby calling the <see cref="M:WindowsInput.Native.NativeMethods.GetKeyState(System.UInt16)"/> function. (See: http://msdn.microsoft.com/en-us/library/ms646301(VS.85).aspx)
      /// 
      /// </summary>
      /// <param name="keyCode">The <see cref="T:WindowsInput.Native.VirtualKeyCode"/> for the key.</param>
      /// <returns>
      /// <c>true</c> if the key is up; otherwise, <c>false</c>.
      /// 
      /// </returns>
      /// 
      /// <remarks>
      /// The key status returned from this function changes as a thread reads key messages from its message queue. The status does not reflect the interrupt-level state associated with the hardware. Use the GetAsyncKeyState function to retrieve that information.
      ///             An application calls GetKeyState in response to a keyboard-input message. This function retrieves the state of the key when the input message was generated.
      ///             To retrieve state information for all the virtual keys, use the GetKeyboardState function.
      ///             An application can use the virtual-key code constants VK_SHIFT, VK_CONTROL, and VK_MENU as values for Bthe nVirtKey parameter. This gives the status of the SHIFT, CTRL, or ALT keys without distinguishing between left and right. An application can also use the following virtual-key code constants as values for nVirtKey to distinguish between the left and right instances of those keys.
      ///             VK_LSHIFT
      ///             VK_RSHIFT
      ///             VK_LCONTROL
      ///             VK_RCONTROL
      ///             VK_LMENU
      ///             VK_RMENU
      /// 
      ///             These left- and right-distinguishing constants are available to an application only through the GetKeyboardState, SetKeyboardState, GetAsyncKeyState, GetKeyState, and MapVirtualKey functions.
      /// 
      /// </remarks>
      public bool IsKeyUp( VirtualKeyCode keyCode )
      {
         return !this.IsKeyDown( keyCode );
      }

      /// <summary>
      /// Determines whether the physical key is up or down at the time the function is called regardless of whether the application thread has read the keyboard event from the message pump by calling the <see cref="M:WindowsInput.Native.NativeMethods.GetAsyncKeyState(System.UInt16)"/> function. (See: http://msdn.microsoft.com/en-us/library/ms646293(VS.85).aspx)
      /// 
      /// </summary>
      /// <param name="keyCode">The <see cref="T:WindowsInput.Native.VirtualKeyCode"/> for the key.</param>
      /// <returns>
      /// <c>true</c> if the key is down; otherwise, <c>false</c>.
      /// 
      /// </returns>
      /// 
      /// <remarks>
      /// The GetAsyncKeyState function works with mouse buttons. However, it checks on the state of the physical mouse buttons, not on the logical mouse buttons that the physical buttons are mapped to. For example, the call GetAsyncKeyState(VK_LBUTTON) always returns the state of the left physical mouse button, regardless of whether it is mapped to the left or right logical mouse button. You can determine the system's current mapping of physical mouse buttons to logical mouse buttons by calling
      ///             Copy CodeGetSystemMetrics(SM_SWAPBUTTON) which returns TRUE if the mouse buttons have been swapped.
      /// 
      ///             Although the least significant bit of the return value indicates whether the key has been pressed since the last query, due to the pre-emptive multitasking nature of Windows, another application can call GetAsyncKeyState and receive the "recently pressed" bit instead of your application. The behavior of the least significant bit of the return value is retained strictly for compatibility with 16-bit Windows applications (which are non-preemptive) and should not be relied upon.
      /// 
      ///             You can use the virtual-key code constants VK_SHIFT, VK_CONTROL, and VK_MENU as values for the vKey parameter. This gives the state of the SHIFT, CTRL, or ALT keys without distinguishing between left and right.
      /// 
      ///             Windows NT/2000/XP: You can use the following virtual-key code constants as values for vKey to distinguish between the left and right instances of those keys.
      /// 
      ///             Code Meaning
      ///             VK_LSHIFT Left-shift key.
      ///             VK_RSHIFT Right-shift key.
      ///             VK_LCONTROL Left-control key.
      ///             VK_RCONTROL Right-control key.
      ///             VK_LMENU Left-menu key.
      ///             VK_RMENU Right-menu key.
      /// 
      ///             These left- and right-distinguishing constants are only available when you call the GetKeyboardState, SetKeyboardState, GetAsyncKeyState, GetKeyState, and MapVirtualKey functions.
      /// 
      /// </remarks>
      public bool IsHardwareKeyDown( VirtualKeyCode keyCode )
      {
         return (int) NativeMethods.GetAsyncKeyState( (ushort) keyCode ) < 0;
      }

      /// <summary>
      /// Determines whether the physical key is up or down at the time the function is called regardless of whether the application thread has read the keyboard event from the message pump by calling the <see cref="M:WindowsInput.Native.NativeMethods.GetAsyncKeyState(System.UInt16)"/> function. (See: http://msdn.microsoft.com/en-us/library/ms646293(VS.85).aspx)
      /// 
      /// </summary>
      /// <param name="keyCode">The <see cref="T:WindowsInput.Native.VirtualKeyCode"/> for the key.</param>
      /// <returns>
      /// <c>true</c> if the key is up; otherwise, <c>false</c>.
      /// 
      /// </returns>
      /// 
      /// <remarks>
      /// The GetAsyncKeyState function works with mouse buttons. However, it checks on the state of the physical mouse buttons, not on the logical mouse buttons that the physical buttons are mapped to. For example, the call GetAsyncKeyState(VK_LBUTTON) always returns the state of the left physical mouse button, regardless of whether it is mapped to the left or right logical mouse button. You can determine the system's current mapping of physical mouse buttons to logical mouse buttons by calling
      ///             Copy CodeGetSystemMetrics(SM_SWAPBUTTON) which returns TRUE if the mouse buttons have been swapped.
      /// 
      ///             Although the least significant bit of the return value indicates whether the key has been pressed since the last query, due to the pre-emptive multitasking nature of Windows, another application can call GetAsyncKeyState and receive the "recently pressed" bit instead of your application. The behavior of the least significant bit of the return value is retained strictly for compatibility with 16-bit Windows applications (which are non-preemptive) and should not be relied upon.
      /// 
      ///             You can use the virtual-key code constants VK_SHIFT, VK_CONTROL, and VK_MENU as values for the vKey parameter. This gives the state of the SHIFT, CTRL, or ALT keys without distinguishing between left and right.
      /// 
      ///             Windows NT/2000/XP: You can use the following virtual-key code constants as values for vKey to distinguish between the left and right instances of those keys.
      /// 
      ///             Code Meaning
      ///             VK_LSHIFT Left-shift key.
      ///             VK_RSHIFT Right-shift key.
      ///             VK_LCONTROL Left-control key.
      ///             VK_RCONTROL Right-control key.
      ///             VK_LMENU Left-menu key.
      ///             VK_RMENU Right-menu key.
      /// 
      ///             These left- and right-distinguishing constants are only available when you call the GetKeyboardState, SetKeyboardState, GetAsyncKeyState, GetKeyState, and MapVirtualKey functions.
      /// 
      /// </remarks>
      public bool IsHardwareKeyUp( VirtualKeyCode keyCode )
      {
         return !this.IsHardwareKeyDown( keyCode );
      }

      /// <summary>
      /// Determines whether the toggling key is toggled on (in-effect) or not by calling the <see cref="M:WindowsInput.Native.NativeMethods.GetKeyState(System.UInt16)"/> function.  (See: http://msdn.microsoft.com/en-us/library/ms646301(VS.85).aspx)
      /// 
      /// </summary>
      /// <param name="keyCode">The <see cref="T:WindowsInput.Native.VirtualKeyCode"/> for the key.</param>
      /// <returns>
      /// <c>true</c> if the toggling key is toggled on (in-effect); otherwise, <c>false</c>.
      /// 
      /// </returns>
      /// 
      /// <remarks>
      /// The key status returned from this function changes as a thread reads key messages from its message queue. The status does not reflect the interrupt-level state associated with the hardware. Use the GetAsyncKeyState function to retrieve that information.
      ///             An application calls GetKeyState in response to a keyboard-input message. This function retrieves the state of the key when the input message was generated.
      ///             To retrieve state information for all the virtual keys, use the GetKeyboardState function.
      ///             An application can use the virtual-key code constants VK_SHIFT, VK_CONTROL, and VK_MENU as values for the nVirtKey parameter. This gives the status of the SHIFT, CTRL, or ALT keys without distinguishing between left and right. An application can also use the following virtual-key code constants as values for nVirtKey to distinguish between the left and right instances of those keys.
      ///             VK_LSHIFT
      ///             VK_RSHIFT
      ///             VK_LCONTROL
      ///             VK_RCONTROL
      ///             VK_LMENU
      ///             VK_RMENU
      /// 
      ///             These left- and right-distinguishing constants are available to an application only through the GetKeyboardState, SetKeyboardState, GetAsyncKeyState, GetKeyState, and MapVirtualKey functions.
      /// 
      /// </remarks>
      public bool IsTogglingKeyInEffect( VirtualKeyCode keyCode )
      {
         return ((int) NativeMethods.GetKeyState( (ushort) keyCode ) & 1) == 1;
      }
   }
}
