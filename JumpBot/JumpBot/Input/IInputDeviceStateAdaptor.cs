// Type: WindowsInput.IInputDeviceStateAdaptor
// Assembly: WindowsInput, Version=1.0.4.0, Culture=neutral, PublicKeyToken=9b287f7dc5073cad
// MVID: 776EB3EF-00F5-4F48-8D79-09AC1BD5E956
// Assembly location: C:\Git\alexwnovak\JumpBot\JumpBot\packages\InputSimulator.1.0.4.0\lib\net20\WindowsInput.dll

using JumpBot.Native;

namespace JumpBot.Input
{
   /// <summary>
   /// The contract for a service that interprets the state of input devices.
   /// 
   /// </summary>
   public interface IInputDeviceStateAdaptor
   {
      /// <summary>
      /// Determines whether the specified key is up or down.
      /// 
      /// </summary>
      /// <param name="keyCode">The <see cref="T:WindowsInput.Native.VirtualKeyCode"/> for the key.</param>
      /// <returns>
      /// <c>true</c> if the key is down; otherwise, <c>false</c>.
      /// 
      /// </returns>
      bool IsKeyDown( VirtualKeyCode keyCode );

      /// <summary>
      /// Determines whether the specified key is up or down.
      /// 
      /// </summary>
      /// <param name="keyCode">The <see cref="T:WindowsInput.Native.VirtualKeyCode"/> for the key.</param>
      /// <returns>
      /// <c>true</c> if the key is up; otherwise, <c>false</c>.
      /// 
      /// </returns>
      bool IsKeyUp( VirtualKeyCode keyCode );

      /// <summary>
      /// Determines whether the physical key is up or down at the time the function is called regardless of whether the application thread has read the keyboard event from the message pump.
      /// 
      /// </summary>
      /// <param name="keyCode">The <see cref="T:WindowsInput.Native.VirtualKeyCode"/> for the key.</param>
      /// <returns>
      /// <c>true</c> if the key is down; otherwise, <c>false</c>.
      /// 
      /// </returns>
      bool IsHardwareKeyDown( VirtualKeyCode keyCode );

      /// <summary>
      /// Determines whether the physical key is up or down at the time the function is called regardless of whether the application thread has read the keyboard event from the message pump.
      /// 
      /// </summary>
      /// <param name="keyCode">The <see cref="T:WindowsInput.Native.VirtualKeyCode"/> for the key.</param>
      /// <returns>
      /// <c>true</c> if the key is up; otherwise, <c>false</c>.
      /// 
      /// </returns>
      bool IsHardwareKeyUp( VirtualKeyCode keyCode );

      /// <summary>
      /// Determines whether the toggling key is toggled on (in-effect) or not.
      /// 
      /// </summary>
      /// <param name="keyCode">The <see cref="T:WindowsInput.Native.VirtualKeyCode"/> for the key.</param>
      /// <returns>
      /// <c>true</c> if the toggling key is toggled on (in-effect); otherwise, <c>false</c>.
      /// 
      /// </returns>
      bool IsTogglingKeyInEffect( VirtualKeyCode keyCode );
   }
}
