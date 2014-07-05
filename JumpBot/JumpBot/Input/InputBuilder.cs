// Type: WindowsInput.InputBuilder
// Assembly: WindowsInput, Version=1.0.4.0, Culture=neutral, PublicKeyToken=9b287f7dc5073cad
// MVID: 776EB3EF-00F5-4F48-8D79-09AC1BD5E956
// Assembly location: C:\Git\alexwnovak\JumpBot\JumpBot\packages\InputSimulator.1.0.4.0\lib\net20\WindowsInput.dll

using System;
using System.Collections;
using System.Collections.Generic;
using JumpBot.Native;

namespace JumpBot.Input
{
   /// <summary>
   /// A helper class for building a list of <see cref="T:WindowsInput.Native.INPUT"/> messages ready to be sent to the native Windows API.
   /// 
   /// </summary>
   internal class InputBuilder : IEnumerable<Native.INPUT>, IEnumerable
   {
      /// <summary>
      /// The public list of <see cref="T:WindowsInput.Native.INPUT"/> messages being built by this instance.
      /// 
      /// </summary>
      private readonly List<Native.INPUT> _inputList;

      /// <summary>
      /// Gets the <see cref="T:WindowsInput.Native.INPUT"/> at the specified position.
      /// 
      /// </summary>
      /// 
      /// <value>
      /// The <see cref="T:WindowsInput.Native.INPUT"/> message at the specified position.
      /// </value>
      public INPUT this[int position]
      {
         get
         {
            return this._inputList[position];
         }
      }

      /// <summary>
      /// Initializes a new instance of the <see cref="T:WindowsInput.InputBuilder"/> class.
      /// 
      /// </summary>
      public InputBuilder()
      {
         this._inputList = new List<Native.INPUT>();
      }

      /// <summary>
      /// Returns the list of <see cref="T:WindowsInput.Native.INPUT"/> messages as a <see cref="T:System.Array"/> of <see cref="T:WindowsInput.Native.INPUT"/> messages.
      /// 
      /// </summary>
      /// 
      /// <returns>
      /// The <see cref="T:System.Array"/> of <see cref="T:WindowsInput.Native.INPUT"/> messages.
      /// </returns>
      public INPUT[] ToArray()
      {
         return this._inputList.ToArray();
      }

      /// <summary>
      /// Returns an enumerator that iterates through the list of <see cref="T:WindowsInput.Native.INPUT"/> messages.
      /// 
      /// </summary>
      /// 
      /// <returns>
      /// A <see cref="T:System.Collections.Generic.IEnumerator`1"/> that can be used to iterate through the list of <see cref="T:WindowsInput.Native.INPUT"/> messages.
      /// 
      /// </returns>
      /// <filterpriority>1</filterpriority>
      public IEnumerator<Native.INPUT> GetEnumerator()
      {
         return (IEnumerator<Native.INPUT>) this._inputList.GetEnumerator();
      }

      IEnumerator IEnumerable.GetEnumerator()
      {
         return (IEnumerator) this.GetEnumerator();
      }

      /// <summary>
      /// Determines if the <see cref="T:WindowsInput.Native.VirtualKeyCode"/> is an ExtendedKey
      /// 
      /// </summary>
      /// <param name="keyCode">The key code.</param>
      /// <returns>
      /// true if the key code is an extended key; otherwise, false.
      /// </returns>
      /// 
      /// <remarks>
      /// The extended keys consist of the ALT and CTRL keys on the right-hand side of the keyboard; the INS, DEL, HOME, END, PAGE UP, PAGE DOWN, and arrow keys in the clusters to the left of the numeric keypad; the NUM LOCK key; the BREAK (CTRL+PAUSE) key; the PRINT SCRN key; and the divide (/) and ENTER keys in the numeric keypad.
      /// 
      ///             See http://msdn.microsoft.com/en-us/library/ms646267(v=vs.85).aspx Section "Extended-Key Flag"
      /// 
      /// </remarks>
      public static bool IsExtendedKey( VirtualKeyCode keyCode )
      {
         return keyCode == VirtualKeyCode.MENU || keyCode == VirtualKeyCode.LMENU || (keyCode == VirtualKeyCode.RMENU || keyCode == VirtualKeyCode.CONTROL) || (keyCode == VirtualKeyCode.RCONTROL || keyCode == VirtualKeyCode.INSERT || (keyCode == VirtualKeyCode.DELETE || keyCode == VirtualKeyCode.HOME)) || (keyCode == VirtualKeyCode.END || keyCode == VirtualKeyCode.PRIOR || (keyCode == VirtualKeyCode.NEXT || keyCode == VirtualKeyCode.RIGHT) || (keyCode == VirtualKeyCode.UP || keyCode == VirtualKeyCode.LEFT || (keyCode == VirtualKeyCode.DOWN || keyCode == VirtualKeyCode.NUMLOCK))) || (keyCode == VirtualKeyCode.CANCEL || keyCode == VirtualKeyCode.SNAPSHOT || keyCode == VirtualKeyCode.DIVIDE);
      }

      /// <summary>
      /// Adds a key down to the list of <see cref="T:WindowsInput.Native.INPUT"/> messages.
      /// 
      /// </summary>
      /// <param name="keyCode">The <see cref="T:WindowsInput.Native.VirtualKeyCode"/>.</param>
      /// <returns>
      /// This <see cref="T:WindowsInput.InputBuilder"/> instance.
      /// </returns>
      public InputBuilder AddKeyDown( VirtualKeyCode keyCode )
      {
         this._inputList.Add( new INPUT()
         {
            Type = 1U,
            Data =
            {
               Keyboard = new KEYBDINPUT()
               {
                  //KeyCode = (ushort) keyCode,
                  Scan = (ushort) keyCode,
                  Flags = 0x08U | ( InputBuilder.IsExtendedKey( keyCode ) ? 1U : 0U ),
                  Time = 0U,
                  ExtraInfo = IntPtr.Zero
               }
            }
         } );
         return this;
      }

      /// <summary>
      /// Adds a key up to the list of <see cref="T:WindowsInput.Native.INPUT"/> messages.
      /// 
      /// </summary>
      /// <param name="keyCode">The <see cref="T:WindowsInput.Native.VirtualKeyCode"/>.</param>
      /// <returns>
      /// This <see cref="T:WindowsInput.InputBuilder"/> instance.
      /// </returns>
      public InputBuilder AddKeyUp( VirtualKeyCode keyCode )
      {
         this._inputList.Add( new INPUT()
         {
            Type = 1U,
            Data =
            {
               Keyboard = new KEYBDINPUT()
               {
                  //KeyCode = (ushort) keyCode,
                  Scan = (ushort) keyCode,
                  Flags = 0x08U | ( InputBuilder.IsExtendedKey( keyCode ) ? 3U : 2U ),
                  Time = 0U,
                  ExtraInfo = IntPtr.Zero
               }
            }
         } );
         return this;
      }

      /// <summary>
      /// Adds a key press to the list of <see cref="T:WindowsInput.Native.INPUT"/> messages which is equivalent to a key down followed by a key up.
      /// 
      /// </summary>
      /// <param name="keyCode">The <see cref="T:WindowsInput.Native.VirtualKeyCode"/>.</param>
      /// <returns>
      /// This <see cref="T:WindowsInput.InputBuilder"/> instance.
      /// </returns>
      public InputBuilder AddKeyPress( VirtualKeyCode keyCode )
      {
         this.AddKeyDown( keyCode );
         this.AddKeyUp( keyCode );
         return this;
      }

      /// <summary>
      /// Adds the character to the list of <see cref="T:WindowsInput.Native.INPUT"/> messages.
      /// 
      /// </summary>
      /// <param name="character">The <see cref="T:System.Char"/> to be added to the list of <see cref="T:WindowsInput.Native.INPUT"/> messages.</param>
      /// <returns>
      /// This <see cref="T:WindowsInput.InputBuilder"/> instance.
      /// </returns>
      public InputBuilder AddCharacter( char character )
      {
         ushort num = (ushort) character;
         INPUT input1 = new INPUT()
         {
            Type = 1U,
            Data =
            {
               Keyboard = new KEYBDINPUT()
               {
                  KeyCode = (ushort) 0,
                  Scan = num,
                  Flags = 4U,
                  Time = 0U,
                  ExtraInfo = IntPtr.Zero
               }
            }
         };
         INPUT input2 = new INPUT()
         {
            Type = 1U,
            Data =
            {
               Keyboard = new KEYBDINPUT()
               {
                  KeyCode = (ushort) 0,
                  Scan = num,
                  Flags = 6U,
                  Time = 0U,
                  ExtraInfo = IntPtr.Zero
               }
            }
         };
         if ( ((int) num & 65280) == 57344 )
         {
            input1.Data.Keyboard.Flags |= 1U;
            input2.Data.Keyboard.Flags |= 1U;
         }
         this._inputList.Add( input1 );
         this._inputList.Add( input2 );
         return this;
      }

      /// <summary>
      /// Adds all of the characters in the specified <see cref="T:System.Collections.Generic.IEnumerable`1"/> of <see cref="T:System.Char"/>.
      /// 
      /// </summary>
      /// <param name="characters">The characters to add.</param>
      /// <returns>
      /// This <see cref="T:WindowsInput.InputBuilder"/> instance.
      /// </returns>
      public InputBuilder AddCharacters( IEnumerable<char> characters )
      {
         foreach ( char character in characters )
            this.AddCharacter( character );
         return this;
      }

      /// <summary>
      /// Adds the characters in the specified <see cref="T:System.String"/>.
      /// 
      /// </summary>
      /// <param name="characters">The string of <see cref="T:System.Char"/> to add.</param>
      /// <returns>
      /// This <see cref="T:WindowsInput.InputBuilder"/> instance.
      /// </returns>
      public InputBuilder AddCharacters( string characters )
      {
         return this.AddCharacters( (IEnumerable<char>) characters.ToCharArray() );
      }

      /// <summary>
      /// Moves the mouse relative to its current position.
      /// 
      /// </summary>
      /// <param name="x"/><param name="y"/>
      /// <returns>
      /// This <see cref="T:WindowsInput.InputBuilder"/> instance.
      /// </returns>
      public InputBuilder AddRelativeMouseMovement( int x, int y )
      {
         INPUT input = new INPUT()
         {
            Type = 0U
         };
         input.Data.Mouse.Flags = 1U;
         input.Data.Mouse.X = x;
         input.Data.Mouse.Y = y;
         this._inputList.Add( input );
         return this;
      }

      /// <summary>
      /// Move the mouse to an absolute position.
      /// 
      /// </summary>
      /// <param name="absoluteX"/><param name="absoluteY"/>
      /// <returns>
      /// This <see cref="T:WindowsInput.InputBuilder"/> instance.
      /// </returns>
      public InputBuilder AddAbsoluteMouseMovement( int absoluteX, int absoluteY )
      {
         INPUT input = new INPUT()
         {
            Type = 0U
         };
         input.Data.Mouse.Flags = 32769U;
         input.Data.Mouse.X = absoluteX;
         input.Data.Mouse.Y = absoluteY;
         this._inputList.Add( input );
         return this;
      }

      /// <summary>
      /// Move the mouse to the absolute position on the virtual desktop.
      /// 
      /// </summary>
      /// <param name="absoluteX"/><param name="absoluteY"/>
      /// <returns>
      /// This <see cref="T:WindowsInput.InputBuilder"/> instance.
      /// </returns>
      public InputBuilder AddAbsoluteMouseMovementOnVirtualDesktop( int absoluteX, int absoluteY )
      {
         INPUT input = new INPUT()
         {
            Type = 0U
         };
         input.Data.Mouse.Flags = 49153U;
         input.Data.Mouse.X = absoluteX;
         input.Data.Mouse.Y = absoluteY;
         this._inputList.Add( input );
         return this;
      }

      /// <summary>
      /// Adds a mouse button down for the specified button.
      /// 
      /// </summary>
      /// <param name="button"/>
      /// <returns>
      /// This <see cref="T:WindowsInput.InputBuilder"/> instance.
      /// </returns>
      public InputBuilder AddMouseButtonDown( MouseButton button )
      {
         INPUT input = new INPUT()
         {
            Type = 0U
         };
         input.Data.Mouse.Flags = (uint) InputBuilder.ToMouseButtonDownFlag( button );
         this._inputList.Add( input );
         return this;
      }

      /// <summary>
      /// Adds a mouse button down for the specified button.
      /// 
      /// </summary>
      /// <param name="xButtonId"/>
      /// <returns>
      /// This <see cref="T:WindowsInput.InputBuilder"/> instance.
      /// </returns>
      public InputBuilder AddMouseXButtonDown( int xButtonId )
      {
         INPUT input = new INPUT()
         {
            Type = 0U
         };
         input.Data.Mouse.Flags = 128U;
         input.Data.Mouse.MouseData = (uint) xButtonId;
         this._inputList.Add( input );
         return this;
      }

      /// <summary>
      /// Adds a mouse button up for the specified button.
      /// 
      /// </summary>
      /// <param name="button"/>
      /// <returns>
      /// This <see cref="T:WindowsInput.InputBuilder"/> instance.
      /// </returns>
      public InputBuilder AddMouseButtonUp( MouseButton button )
      {
         INPUT input = new INPUT()
         {
            Type = 0U
         };
         input.Data.Mouse.Flags = (uint) InputBuilder.ToMouseButtonUpFlag( button );
         this._inputList.Add( input );
         return this;
      }

      /// <summary>
      /// Adds a mouse button up for the specified button.
      /// 
      /// </summary>
      /// <param name="xButtonId"/>
      /// <returns>
      /// This <see cref="T:WindowsInput.InputBuilder"/> instance.
      /// </returns>
      public InputBuilder AddMouseXButtonUp( int xButtonId )
      {
         INPUT input = new INPUT()
         {
            Type = 0U
         };
         input.Data.Mouse.Flags = 256U;
         input.Data.Mouse.MouseData = (uint) xButtonId;
         this._inputList.Add( input );
         return this;
      }

      /// <summary>
      /// Adds a single click of the specified button.
      /// 
      /// </summary>
      /// <param name="button"/>
      /// <returns>
      /// This <see cref="T:WindowsInput.InputBuilder"/> instance.
      /// </returns>
      public InputBuilder AddMouseButtonClick( MouseButton button )
      {
         return this.AddMouseButtonDown( button ).AddMouseButtonUp( button );
      }

      /// <summary>
      /// Adds a single click of the specified button.
      /// 
      /// </summary>
      /// <param name="xButtonId"/>
      /// <returns>
      /// This <see cref="T:WindowsInput.InputBuilder"/> instance.
      /// </returns>
      public InputBuilder AddMouseXButtonClick( int xButtonId )
      {
         return this.AddMouseXButtonDown( xButtonId ).AddMouseXButtonUp( xButtonId );
      }

      /// <summary>
      /// Adds a double click of the specified button.
      /// 
      /// </summary>
      /// <param name="button"/>
      /// <returns>
      /// This <see cref="T:WindowsInput.InputBuilder"/> instance.
      /// </returns>
      public InputBuilder AddMouseButtonDoubleClick( MouseButton button )
      {
         return this.AddMouseButtonClick( button ).AddMouseButtonClick( button );
      }

      /// <summary>
      /// Adds a double click of the specified button.
      /// 
      /// </summary>
      /// <param name="xButtonId"/>
      /// <returns>
      /// This <see cref="T:WindowsInput.InputBuilder"/> instance.
      /// </returns>
      public InputBuilder AddMouseXButtonDoubleClick( int xButtonId )
      {
         return this.AddMouseXButtonClick( xButtonId ).AddMouseXButtonClick( xButtonId );
      }

      /// <summary>
      /// Scroll the vertical mouse wheel by the specified amount.
      /// 
      /// </summary>
      /// <param name="scrollAmount"/>
      /// <returns>
      /// This <see cref="T:WindowsInput.InputBuilder"/> instance.
      /// </returns>
      public InputBuilder AddMouseVerticalWheelScroll( int scrollAmount )
      {
         INPUT input = new INPUT()
         {
            Type = 0U
         };
         input.Data.Mouse.Flags = 2048U;
         input.Data.Mouse.MouseData = (uint) scrollAmount;
         this._inputList.Add( input );
         return this;
      }

      /// <summary>
      /// Scroll the horizontal mouse wheel by the specified amount.
      /// 
      /// </summary>
      /// <param name="scrollAmount"/>
      /// <returns>
      /// This <see cref="T:WindowsInput.InputBuilder"/> instance.
      /// </returns>
      public InputBuilder AddMouseHorizontalWheelScroll( int scrollAmount )
      {
         INPUT input = new INPUT()
         {
            Type = 0U
         };
         input.Data.Mouse.Flags = 4096U;
         input.Data.Mouse.MouseData = (uint) scrollAmount;
         this._inputList.Add( input );
         return this;
      }

      private static MouseFlag ToMouseButtonDownFlag( MouseButton button )
      {
         switch ( button )
         {
            case MouseButton.LeftButton:
               return MouseFlag.LeftDown;
            case MouseButton.MiddleButton:
               return MouseFlag.MiddleDown;
            case MouseButton.RightButton:
               return MouseFlag.RightDown;
            default:
               return MouseFlag.LeftDown;
         }
      }

      private static MouseFlag ToMouseButtonUpFlag( MouseButton button )
      {
         switch ( button )
         {
            case MouseButton.LeftButton:
               return MouseFlag.LeftUp;
            case MouseButton.MiddleButton:
               return MouseFlag.MiddleUp;
            case MouseButton.RightButton:
               return MouseFlag.RightUp;
            default:
               return MouseFlag.LeftUp;
         }
      }
   }
}
