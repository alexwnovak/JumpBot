// Type: WindowsInput.KeyboardSimulator
// Assembly: WindowsInput, Version=1.0.4.0, Culture=neutral, PublicKeyToken=9b287f7dc5073cad
// MVID: 776EB3EF-00F5-4F48-8D79-09AC1BD5E956
// Assembly location: C:\Git\alexwnovak\JumpBot\JumpBot\packages\InputSimulator.1.0.4.0\lib\net20\WindowsInput.dll

using System;
using System.Collections.Generic;
using System.Threading;
using JumpBot.Native;

namespace JumpBot.Input
{
   /// <summary>
   /// Implements the <see cref="T:WindowsInput.IKeyboardSimulator"/> interface by calling the an <see cref="T:WindowsInput.IInputMessageDispatcher"/> to simulate Keyboard gestures.
   /// 
   /// </summary>
   public class KeyboardSimulator : IKeyboardSimulator
   {
      private readonly IInputSimulator _inputSimulator;
      /// <summary>
      /// The instance of the <see cref="T:WindowsInput.IInputMessageDispatcher"/> to use for dispatching <see cref="T:WindowsInput.Native.INPUT"/> messages.
      /// 
      /// </summary>
      private readonly IInputMessageDispatcher _messageDispatcher;

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
            return this._inputSimulator.Mouse;
         }
      }

      /// <summary>
      /// Initializes a new instance of the <see cref="T:WindowsInput.KeyboardSimulator"/> class using an instance of a <see cref="T:WindowsInput.WindowsInputMessageDispatcher"/> for dispatching <see cref="T:WindowsInput.Native.INPUT"/> messages.
      /// 
      /// </summary>
      /// <param name="inputSimulator">The <see cref="T:WindowsInput.IInputSimulator"/> that owns this instance.</param>
      public KeyboardSimulator( IInputSimulator inputSimulator )
      {
         if ( inputSimulator == null )
            throw new ArgumentNullException( "inputSimulator" );
         this._inputSimulator = inputSimulator;
         this._messageDispatcher = (IInputMessageDispatcher) new WindowsInputMessageDispatcher();
      }

      /// <summary>
      /// Initializes a new instance of the <see cref="T:WindowsInput.KeyboardSimulator"/> class using the specified <see cref="T:WindowsInput.IInputMessageDispatcher"/> for dispatching <see cref="T:WindowsInput.Native.INPUT"/> messages.
      /// 
      /// </summary>
      /// <param name="inputSimulator">The <see cref="T:WindowsInput.IInputSimulator"/> that owns this instance.</param><param name="messageDispatcher">The <see cref="T:WindowsInput.IInputMessageDispatcher"/> to use for dispatching <see cref="T:WindowsInput.Native.INPUT"/> messages.</param><exception cref="T:System.InvalidOperationException">If null is passed as the <paramref name="messageDispatcher"/>.</exception>
      internal KeyboardSimulator( IInputSimulator inputSimulator, IInputMessageDispatcher messageDispatcher )
      {
         if ( inputSimulator == null )
            throw new ArgumentNullException( "inputSimulator" );
         if ( messageDispatcher == null )
            throw new InvalidOperationException( string.Format( "The {0} cannot operate with a null {1}. Please provide a valid {1} instance to use for dispatching {2} messages.", (object) typeof( KeyboardSimulator ).Name, (object) typeof( IInputMessageDispatcher ).Name, (object) typeof( INPUT ).Name ) );
         this._inputSimulator = inputSimulator;
         this._messageDispatcher = messageDispatcher;
      }

      private void ModifiersDown( InputBuilder builder, IEnumerable<VirtualKeyCode> modifierKeyCodes )
      {
         if ( modifierKeyCodes == null )
            return;
         foreach ( VirtualKeyCode keyCode in modifierKeyCodes )
            builder.AddKeyDown( keyCode );
      }

      private void ModifiersUp( InputBuilder builder, IEnumerable<VirtualKeyCode> modifierKeyCodes )
      {
         if ( modifierKeyCodes == null )
            return;
         Stack<VirtualKeyCode> stack = new Stack<VirtualKeyCode>( modifierKeyCodes );
         while ( stack.Count > 0 )
            builder.AddKeyUp( stack.Pop() );
      }

      private void KeysPress( InputBuilder builder, IEnumerable<VirtualKeyCode> keyCodes )
      {
         if ( keyCodes == null )
            return;
         foreach ( VirtualKeyCode keyCode in keyCodes )
            builder.AddKeyPress( keyCode );
      }

      /// <summary>
      /// Sends the list of <see cref="T:WindowsInput.Native.INPUT"/> messages using the <see cref="T:WindowsInput.IInputMessageDispatcher"/> instance.
      /// 
      /// </summary>
      /// <param name="inputList">The <see cref="T:System.Array"/> of <see cref="T:WindowsInput.Native.INPUT"/> messages to send.</param>
      private void SendSimulatedInput( INPUT[] inputList )
      {
         this._messageDispatcher.DispatchInput( inputList );
      }

      /// <summary>
      /// Calls the Win32 SendInput method to simulate a KeyDown.
      /// 
      /// </summary>
      /// <param name="keyCode">The <see cref="T:WindowsInput.Native.VirtualKeyCode"/> to press</param>
      public IKeyboardSimulator KeyDown( VirtualKeyCode keyCode )
      {
         this.SendSimulatedInput( new InputBuilder().AddKeyDown( keyCode ).ToArray() );
         return (IKeyboardSimulator) this;
      }

      /// <summary>
      /// Calls the Win32 SendInput method to simulate a KeyUp.
      /// 
      /// </summary>
      /// <param name="keyCode">The <see cref="T:WindowsInput.Native.VirtualKeyCode"/> to lift up</param>
      public IKeyboardSimulator KeyUp( VirtualKeyCode keyCode )
      {
         this.SendSimulatedInput( new InputBuilder().AddKeyUp( keyCode ).ToArray() );
         return (IKeyboardSimulator) this;
      }

      /// <summary>
      /// Calls the Win32 SendInput method with a KeyDown and KeyUp message in the same input sequence in order to simulate a Key PRESS.
      /// 
      /// </summary>
      /// <param name="keyCode">The <see cref="T:WindowsInput.Native.VirtualKeyCode"/> to press</param>
      public IKeyboardSimulator KeyPress( VirtualKeyCode keyCode )
      {
         this.SendSimulatedInput( new InputBuilder().AddKeyPress( keyCode ).ToArray() );
         return (IKeyboardSimulator) this;
      }

      /// <summary>
      /// Simulates a key press for each of the specified key codes in the order they are specified.
      /// 
      /// </summary>
      /// <param name="keyCodes"/>
      public IKeyboardSimulator KeyPress( params VirtualKeyCode[] keyCodes )
      {
         InputBuilder builder = new InputBuilder();
         this.KeysPress( builder, (IEnumerable<VirtualKeyCode>) keyCodes );
         this.SendSimulatedInput( builder.ToArray() );
         return (IKeyboardSimulator) this;
      }

      /// <summary>
      /// Simulates a simple modified keystroke like CTRL-C where CTRL is the modifierKey and C is the key.
      ///             The flow is Modifier KeyDown, Key Press, Modifier KeyUp.
      /// 
      /// </summary>
      /// <param name="modifierKeyCode">The modifier key</param><param name="keyCode">The key to simulate</param>
      public IKeyboardSimulator ModifiedKeyStroke( VirtualKeyCode modifierKeyCode, VirtualKeyCode keyCode )
      {
         this.ModifiedKeyStroke( (IEnumerable<VirtualKeyCode>) new VirtualKeyCode[1]
      {
        modifierKeyCode
      }, (IEnumerable<VirtualKeyCode>) new VirtualKeyCode[1]
      {
        keyCode
      } );
         return (IKeyboardSimulator) this;
      }

      /// <summary>
      /// Simulates a modified keystroke where there are multiple modifiers and one key like CTRL-ALT-C where CTRL and ALT are the modifierKeys and C is the key.
      ///             The flow is Modifiers KeyDown in order, Key Press, Modifiers KeyUp in reverse order.
      /// 
      /// </summary>
      /// <param name="modifierKeyCodes">The list of modifier keys</param><param name="keyCode">The key to simulate</param>
      public IKeyboardSimulator ModifiedKeyStroke( IEnumerable<VirtualKeyCode> modifierKeyCodes, VirtualKeyCode keyCode )
      {
         this.ModifiedKeyStroke( modifierKeyCodes, (IEnumerable<VirtualKeyCode>) new VirtualKeyCode[1]
      {
        keyCode
      } );
         return (IKeyboardSimulator) this;
      }

      /// <summary>
      /// Simulates a modified keystroke where there is one modifier and multiple keys like CTRL-K-C where CTRL is the modifierKey and K and C are the keys.
      ///             The flow is Modifier KeyDown, Keys Press in order, Modifier KeyUp.
      /// 
      /// </summary>
      /// <param name="modifierKey">The modifier key</param><param name="keyCodes">The list of keys to simulate</param>
      public IKeyboardSimulator ModifiedKeyStroke( VirtualKeyCode modifierKey, IEnumerable<VirtualKeyCode> keyCodes )
      {
         this.ModifiedKeyStroke( (IEnumerable<VirtualKeyCode>) new VirtualKeyCode[1]
      {
        modifierKey
      }, keyCodes );
         return (IKeyboardSimulator) this;
      }

      /// <summary>
      /// Simulates a modified keystroke where there are multiple modifiers and multiple keys like CTRL-ALT-K-C where CTRL and ALT are the modifierKeys and K and C are the keys.
      ///             The flow is Modifiers KeyDown in order, Keys Press in order, Modifiers KeyUp in reverse order.
      /// 
      /// </summary>
      /// <param name="modifierKeyCodes">The list of modifier keys</param><param name="keyCodes">The list of keys to simulate</param>
      public IKeyboardSimulator ModifiedKeyStroke( IEnumerable<VirtualKeyCode> modifierKeyCodes, IEnumerable<VirtualKeyCode> keyCodes )
      {
         InputBuilder builder = new InputBuilder();
         this.ModifiersDown( builder, modifierKeyCodes );
         this.KeysPress( builder, keyCodes );
         this.ModifiersUp( builder, modifierKeyCodes );
         this.SendSimulatedInput( builder.ToArray() );
         return (IKeyboardSimulator) this;
      }

      /// <summary>
      /// Calls the Win32 SendInput method with a stream of KeyDown and KeyUp messages in order to simulate uninterrupted text entry via the keyboard.
      /// 
      /// </summary>
      /// <param name="text">The text to be simulated.</param>
      public IKeyboardSimulator TextEntry( string text )
      {
         if ( (long) text.Length > (long) int.MaxValue )
            throw new ArgumentException( string.Format( "The text parameter is too long. It must be less than {0} characters.", (object) (uint) int.MaxValue ), "text" );
         this.SendSimulatedInput( new InputBuilder().AddCharacters( text ).ToArray() );
         return (IKeyboardSimulator) this;
      }

      /// <summary>
      /// Simulates a single character text entry via the keyboard.
      /// 
      /// </summary>
      /// <param name="character">The unicode character to be simulated.</param>
      public IKeyboardSimulator TextEntry( char character )
      {
         this.SendSimulatedInput( new InputBuilder().AddCharacter( character ).ToArray() );
         return (IKeyboardSimulator) this;
      }

      /// <summary>
      /// Sleeps the executing thread to create a pause between simulated inputs.
      /// 
      /// </summary>
      /// <param name="millsecondsTimeout">The number of milliseconds to wait.</param>
      public IKeyboardSimulator Sleep( int millsecondsTimeout )
      {
         Thread.Sleep( millsecondsTimeout );
         return (IKeyboardSimulator) this;
      }

      /// <summary>
      /// Sleeps the executing thread to create a pause between simulated inputs.
      /// 
      /// </summary>
      /// <param name="timeout">The time to wait.</param>
      public IKeyboardSimulator Sleep( TimeSpan timeout )
      {
         Thread.Sleep( timeout );
         return (IKeyboardSimulator) this;
      }
   }
}
