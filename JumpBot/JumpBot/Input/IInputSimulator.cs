// Type: WindowsInput.IInputSimulator
// Assembly: WindowsInput, Version=1.0.4.0, Culture=neutral, PublicKeyToken=9b287f7dc5073cad
// MVID: 776EB3EF-00F5-4F48-8D79-09AC1BD5E956
// Assembly location: C:\Git\alexwnovak\JumpBot\JumpBot\packages\InputSimulator.1.0.4.0\lib\net20\WindowsInput.dll

namespace JumpBot.Input
{
   /// <summary>
   /// The contract for a service that simulates Keyboard and Mouse input and Hardware Input Device state detection for the Windows Platform.
   /// 
   /// </summary>
   public interface IInputSimulator
   {
      /// <summary>
      /// Gets the <see cref="T:WindowsInput.IKeyboardSimulator"/> instance for simulating Keyboard input.
      /// 
      /// </summary>
      /// 
      /// <value>
      /// The <see cref="T:WindowsInput.IKeyboardSimulator"/> instance.
      /// </value>
      IKeyboardSimulator Keyboard { get; }

      /// <summary>
      /// Gets the <see cref="T:WindowsInput.IMouseSimulator"/> instance for simulating Mouse input.
      /// 
      /// </summary>
      /// 
      /// <value>
      /// The <see cref="T:WindowsInput.IMouseSimulator"/> instance.
      /// </value>
      IMouseSimulator Mouse { get; }

      /// <summary>
      /// Gets the <see cref="T:WindowsInput.IInputDeviceStateAdaptor"/> instance for determining the state of the various input devices.
      /// 
      /// </summary>
      /// 
      /// <value>
      /// The <see cref="T:WindowsInput.IInputDeviceStateAdaptor"/> instance.
      /// </value>
      IInputDeviceStateAdaptor InputDeviceState { get; }
   }
}
