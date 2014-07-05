// Type: WindowsInput.MouseSimulator
// Assembly: WindowsInput, Version=1.0.4.0, Culture=neutral, PublicKeyToken=9b287f7dc5073cad
// MVID: 776EB3EF-00F5-4F48-8D79-09AC1BD5E956
// Assembly location: C:\Git\alexwnovak\JumpBot\JumpBot\packages\InputSimulator.1.0.4.0\lib\net20\WindowsInput.dll

using System;
using System.Threading;
using JumpBot.Native;

namespace JumpBot.Input
{
   /// <summary>
   /// Implements the <see cref="T:WindowsInput.IMouseSimulator"/> interface by calling the an <see cref="T:WindowsInput.IInputMessageDispatcher"/> to simulate Mouse gestures.
   /// 
   /// </summary>
   public class MouseSimulator : IMouseSimulator
   {
      private const int MouseWheelClickSize = 120;
      private readonly IInputSimulator _inputSimulator;
      /// <summary>
      /// The instance of the <see cref="T:WindowsInput.IInputMessageDispatcher"/> to use for dispatching <see cref="T:WindowsInput.Native.INPUT"/> messages.
      /// 
      /// </summary>
      private readonly IInputMessageDispatcher _messageDispatcher;

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
            return this._inputSimulator.Keyboard;
         }
      }

      /// <summary>
      /// Initializes a new instance of the <see cref="T:WindowsInput.MouseSimulator"/> class using an instance of a <see cref="T:WindowsInput.WindowsInputMessageDispatcher"/> for dispatching <see cref="T:WindowsInput.Native.INPUT"/> messages.
      /// 
      /// </summary>
      /// <param name="inputSimulator">The <see cref="T:WindowsInput.IInputSimulator"/> that owns this instance.</param>
      public MouseSimulator( IInputSimulator inputSimulator )
      {
         if ( inputSimulator == null )
            throw new ArgumentNullException( "inputSimulator" );
         this._inputSimulator = inputSimulator;
         this._messageDispatcher = (IInputMessageDispatcher) new WindowsInputMessageDispatcher();
      }

      /// <summary>
      /// Initializes a new instance of the <see cref="T:WindowsInput.MouseSimulator"/> class using the specified <see cref="T:WindowsInput.IInputMessageDispatcher"/> for dispatching <see cref="T:WindowsInput.Native.INPUT"/> messages.
      /// 
      /// </summary>
      /// <param name="inputSimulator">The <see cref="T:WindowsInput.IInputSimulator"/> that owns this instance.</param><param name="messageDispatcher">The <see cref="T:WindowsInput.IInputMessageDispatcher"/> to use for dispatching <see cref="T:WindowsInput.Native.INPUT"/> messages.</param><exception cref="T:System.InvalidOperationException">If null is passed as the <paramref name="messageDispatcher"/>.</exception>
      internal MouseSimulator( IInputSimulator inputSimulator, IInputMessageDispatcher messageDispatcher )
      {
         if ( inputSimulator == null )
            throw new ArgumentNullException( "inputSimulator" );
         if ( messageDispatcher == null )
            throw new InvalidOperationException( string.Format( "The {0} cannot operate with a null {1}. Please provide a valid {1} instance to use for dispatching {2} messages.", (object) typeof( MouseSimulator ).Name, (object) typeof( IInputMessageDispatcher ).Name, (object) typeof( INPUT ).Name ) );
         this._inputSimulator = inputSimulator;
         this._messageDispatcher = messageDispatcher;
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
      /// Simulates mouse movement by the specified distance measured as a delta from the current mouse location in pixels.
      /// 
      /// </summary>
      /// <param name="pixelDeltaX">The distance in pixels to move the mouse horizontally.</param><param name="pixelDeltaY">The distance in pixels to move the mouse vertically.</param>
      public IMouseSimulator MoveMouseBy( int pixelDeltaX, int pixelDeltaY )
      {
         this.SendSimulatedInput( new InputBuilder().AddRelativeMouseMovement( pixelDeltaX, pixelDeltaY ).ToArray() );
         return (IMouseSimulator) this;
      }

      /// <summary>
      /// Simulates mouse movement to the specified location on the primary display device.
      /// 
      /// </summary>
      /// <param name="absoluteX">The destination's absolute X-coordinate on the primary display device where 0 is the extreme left hand side of the display device and 65535 is the extreme right hand side of the display device.</param><param name="absoluteY">The destination's absolute Y-coordinate on the primary display device where 0 is the top of the display device and 65535 is the bottom of the display device.</param>
      public IMouseSimulator MoveMouseTo( double absoluteX, double absoluteY )
      {
         this.SendSimulatedInput( new InputBuilder().AddAbsoluteMouseMovement( (int) Math.Truncate( absoluteX ), (int) Math.Truncate( absoluteY ) ).ToArray() );
         return (IMouseSimulator) this;
      }

      /// <summary>
      /// Simulates mouse movement to the specified location on the Virtual Desktop which includes all active displays.
      /// 
      /// </summary>
      /// <param name="absoluteX">The destination's absolute X-coordinate on the virtual desktop where 0 is the left hand side of the virtual desktop and 65535 is the extreme right hand side of the virtual desktop.</param><param name="absoluteY">The destination's absolute Y-coordinate on the virtual desktop where 0 is the top of the virtual desktop and 65535 is the bottom of the virtual desktop.</param>
      public IMouseSimulator MoveMouseToPositionOnVirtualDesktop( double absoluteX, double absoluteY )
      {
         this.SendSimulatedInput( new InputBuilder().AddAbsoluteMouseMovementOnVirtualDesktop( (int) Math.Truncate( absoluteX ), (int) Math.Truncate( absoluteY ) ).ToArray() );
         return (IMouseSimulator) this;
      }

      /// <summary>
      /// Simulates a mouse left button down gesture.
      /// 
      /// </summary>
      public IMouseSimulator LeftButtonDown()
      {
         this.SendSimulatedInput( new InputBuilder().AddMouseButtonDown( MouseButton.LeftButton ).ToArray() );
         return (IMouseSimulator) this;
      }

      /// <summary>
      /// Simulates a mouse left button up gesture.
      /// 
      /// </summary>
      public IMouseSimulator LeftButtonUp()
      {
         this.SendSimulatedInput( new InputBuilder().AddMouseButtonUp( MouseButton.LeftButton ).ToArray() );
         return (IMouseSimulator) this;
      }

      /// <summary>
      /// Simulates a mouse left-click gesture.
      /// 
      /// </summary>
      public IMouseSimulator LeftButtonClick()
      {
         this.SendSimulatedInput( new InputBuilder().AddMouseButtonClick( MouseButton.LeftButton ).ToArray() );
         return (IMouseSimulator) this;
      }

      /// <summary>
      /// Simulates a mouse left button double-click gesture.
      /// 
      /// </summary>
      public IMouseSimulator LeftButtonDoubleClick()
      {
         this.SendSimulatedInput( new InputBuilder().AddMouseButtonDoubleClick( MouseButton.LeftButton ).ToArray() );
         return (IMouseSimulator) this;
      }

      /// <summary>
      /// Simulates a mouse right button down gesture.
      /// 
      /// </summary>
      public IMouseSimulator RightButtonDown()
      {
         this.SendSimulatedInput( new InputBuilder().AddMouseButtonDown( MouseButton.RightButton ).ToArray() );
         return (IMouseSimulator) this;
      }

      /// <summary>
      /// Simulates a mouse right button up gesture.
      /// 
      /// </summary>
      public IMouseSimulator RightButtonUp()
      {
         this.SendSimulatedInput( new InputBuilder().AddMouseButtonUp( MouseButton.RightButton ).ToArray() );
         return (IMouseSimulator) this;
      }

      /// <summary>
      /// Simulates a mouse right button click gesture.
      /// 
      /// </summary>
      public IMouseSimulator RightButtonClick()
      {
         this.SendSimulatedInput( new InputBuilder().AddMouseButtonClick( MouseButton.RightButton ).ToArray() );
         return (IMouseSimulator) this;
      }

      /// <summary>
      /// Simulates a mouse right button double-click gesture.
      /// 
      /// </summary>
      public IMouseSimulator RightButtonDoubleClick()
      {
         this.SendSimulatedInput( new InputBuilder().AddMouseButtonDoubleClick( MouseButton.RightButton ).ToArray() );
         return (IMouseSimulator) this;
      }

      /// <summary>
      /// Simulates a mouse X button down gesture.
      /// 
      /// </summary>
      /// <param name="buttonId">The button id.</param>
      public IMouseSimulator XButtonDown( int buttonId )
      {
         this.SendSimulatedInput( new InputBuilder().AddMouseXButtonDown( buttonId ).ToArray() );
         return (IMouseSimulator) this;
      }

      /// <summary>
      /// Simulates a mouse X button up gesture.
      /// 
      /// </summary>
      /// <param name="buttonId">The button id.</param>
      public IMouseSimulator XButtonUp( int buttonId )
      {
         this.SendSimulatedInput( new InputBuilder().AddMouseXButtonUp( buttonId ).ToArray() );
         return (IMouseSimulator) this;
      }

      /// <summary>
      /// Simulates a mouse X button click gesture.
      /// 
      /// </summary>
      /// <param name="buttonId">The button id.</param>
      public IMouseSimulator XButtonClick( int buttonId )
      {
         this.SendSimulatedInput( new InputBuilder().AddMouseXButtonClick( buttonId ).ToArray() );
         return (IMouseSimulator) this;
      }

      /// <summary>
      /// Simulates a mouse X button double-click gesture.
      /// 
      /// </summary>
      /// <param name="buttonId">The button id.</param>
      public IMouseSimulator XButtonDoubleClick( int buttonId )
      {
         this.SendSimulatedInput( new InputBuilder().AddMouseXButtonDoubleClick( buttonId ).ToArray() );
         return (IMouseSimulator) this;
      }

      /// <summary>
      /// Simulates mouse vertical wheel scroll gesture.
      /// 
      /// </summary>
      /// <param name="scrollAmountInClicks">The amount to scroll in clicks. A positive value indicates that the wheel was rotated forward, away from the user; a negative value indicates that the wheel was rotated backward, toward the user.</param>
      public IMouseSimulator VerticalScroll( int scrollAmountInClicks )
      {
         this.SendSimulatedInput( new InputBuilder().AddMouseVerticalWheelScroll( scrollAmountInClicks * 120 ).ToArray() );
         return (IMouseSimulator) this;
      }

      /// <summary>
      /// Simulates a mouse horizontal wheel scroll gesture. Supported by Windows Vista and later.
      /// 
      /// </summary>
      /// <param name="scrollAmountInClicks">The amount to scroll in clicks. A positive value indicates that the wheel was rotated to the right; a negative value indicates that the wheel was rotated to the left.</param>
      public IMouseSimulator HorizontalScroll( int scrollAmountInClicks )
      {
         this.SendSimulatedInput( new InputBuilder().AddMouseHorizontalWheelScroll( scrollAmountInClicks * 120 ).ToArray() );
         return (IMouseSimulator) this;
      }

      /// <summary>
      /// Sleeps the executing thread to create a pause between simulated inputs.
      /// 
      /// </summary>
      /// <param name="millsecondsTimeout">The number of milliseconds to wait.</param>
      public IMouseSimulator Sleep( int millsecondsTimeout )
      {
         Thread.Sleep( millsecondsTimeout );
         return (IMouseSimulator) this;
      }

      /// <summary>
      /// Sleeps the executing thread to create a pause between simulated inputs.
      /// 
      /// </summary>
      /// <param name="timeout">The time to wait.</param>
      public IMouseSimulator Sleep( TimeSpan timeout )
      {
         Thread.Sleep( timeout );
         return (IMouseSimulator) this;
      }
   }
}
