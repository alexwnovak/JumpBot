// Type: WindowsInput.InputSimulator
// Assembly: WindowsInput, Version=1.0.4.0, Culture=neutral, PublicKeyToken=9b287f7dc5073cad
// MVID: 776EB3EF-00F5-4F48-8D79-09AC1BD5E956
// Assembly location: C:\Git\alexwnovak\JumpBot\JumpBot\packages\InputSimulator.1.0.4.0\lib\net20\WindowsInput.dll

namespace JumpBot.Input
{
   /// <summary>
   /// Implements the <see cref="T:WindowsInput.IInputSimulator"/> interface to simulate Keyboard and Mouse input and provide the state of those input devices.
   /// 
   /// </summary>
   public class InputSimulator : IInputSimulator
   {
      /// <summary>
      /// The <see cref="T:WindowsInput.IKeyboardSimulator"/> instance to use for simulating keyboard input.
      /// 
      /// </summary>
      private readonly IKeyboardSimulator _keyboardSimulator;
      /// <summary>
      /// The <see cref="T:WindowsInput.IMouseSimulator"/> instance to use for simulating mouse input.
      /// 
      /// </summary>
      private readonly IMouseSimulator _mouseSimulator;
      /// <summary>
      /// The <see cref="T:WindowsInput.IInputDeviceStateAdaptor"/> instance to use for interpreting the state of the input devices.
      /// 
      /// </summary>
      private readonly IInputDeviceStateAdaptor _inputDeviceState;

      /// <summary>
      /// Gets the <see cref="T:WindowsInput.IKeyboardSimulator"/> instance for simulating Keyboard input.
      /// 
      /// </summary>
      /// 
      /// <value>
      /// The <see cref="T:WindowsInput.IKeyboardSimulator"/> instance.
      /// </value>
      public IKeyboardSimulator Keyboard
      {
         get
         {
            return this._keyboardSimulator;
         }
      }

      /// <summary>
      /// Gets the <see cref="T:WindowsInput.IMouseSimulator"/> instance for simulating Mouse input.
      /// 
      /// </summary>
      /// 
      /// <value>
      /// The <see cref="T:WindowsInput.IMouseSimulator"/> instance.
      /// </value>
      public IMouseSimulator Mouse
      {
         get
         {
            return this._mouseSimulator;
         }
      }

      /// <summary>
      /// Gets the <see cref="T:WindowsInput.IInputDeviceStateAdaptor"/> instance for determining the state of the various input devices.
      /// 
      /// </summary>
      /// 
      /// <value>
      /// The <see cref="T:WindowsInput.IInputDeviceStateAdaptor"/> instance.
      /// </value>
      public IInputDeviceStateAdaptor InputDeviceState
      {
         get
         {
            return this._inputDeviceState;
         }
      }

      /// <summary>
      /// Initializes a new instance of the <see cref="T:WindowsInput.InputSimulator"/> class using the specified <see cref="T:WindowsInput.IKeyboardSimulator"/>, <see cref="T:WindowsInput.IMouseSimulator"/> and <see cref="T:WindowsInput.IInputDeviceStateAdaptor"/> instances.
      /// 
      /// </summary>
      /// <param name="keyboardSimulator">The <see cref="T:WindowsInput.IKeyboardSimulator"/> instance to use for simulating keyboard input.</param><param name="mouseSimulator">The <see cref="T:WindowsInput.IMouseSimulator"/> instance to use for simulating mouse input.</param><param name="inputDeviceStateAdaptor">The <see cref="T:WindowsInput.IInputDeviceStateAdaptor"/> instance to use for interpreting the state of input devices.</param>
      public InputSimulator( IKeyboardSimulator keyboardSimulator, IMouseSimulator mouseSimulator, IInputDeviceStateAdaptor inputDeviceStateAdaptor )
      {
         this._keyboardSimulator = keyboardSimulator;
         this._mouseSimulator = mouseSimulator;
         this._inputDeviceState = inputDeviceStateAdaptor;
      }

      /// <summary>
      /// Initializes a new instance of the <see cref="T:WindowsInput.InputSimulator"/> class using the default <see cref="T:WindowsInput.KeyboardSimulator"/>, <see cref="T:WindowsInput.MouseSimulator"/> and <see cref="T:WindowsInput.WindowsInputDeviceStateAdaptor"/> instances.
      /// 
      /// </summary>
      public InputSimulator()
      {
         this._keyboardSimulator = (IKeyboardSimulator) new KeyboardSimulator( (IInputSimulator) this );
         this._mouseSimulator = (IMouseSimulator) new MouseSimulator( (IInputSimulator) this );
         this._inputDeviceState = (IInputDeviceStateAdaptor) new WindowsInputDeviceStateAdaptor();
      }
   }
}
