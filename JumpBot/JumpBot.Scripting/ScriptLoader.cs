using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using WindowsInput.Native;

namespace JumpBot.Scripting
{
   public static class ScriptLoader
   {
      public static JumpScript LoadFromFile( string filePath )
      {
         var inputCommands = new List<InputCommand>();

         using ( var streamReader = new StreamReader( filePath ) )
         {
            int lineNumber = 0;

            while ( !streamReader.EndOfStream )
            {
               lineNumber++;
               string line = streamReader.ReadLine().Trim();

               if ( string.IsNullOrWhiteSpace( line ) ||  line.StartsWith( "#" ) )
               {
                  continue;
               }

               // Tokenize this line into its command and parameter

               var delimiterArray = new[]
               {
                  " "
               };

               var tokens = line.Split( delimiterArray, StringSplitOptions.RemoveEmptyEntries ).Select( x => x.Trim() ).ToList();  

               // Send it off for processing

               string command = tokens[0];
               string parameter = tokens[1];

               try
               {
                  var inputCommand = ProcessTokens( command, parameter );

                  inputCommands.Add( inputCommand );
               }
               catch ( ScriptParseException ex )
               {
                  ex.LineNumber = lineNumber;

                  throw;
               }
            }   
         }

         return new JumpScript( inputCommands.ToArray() );
      }

      private static VirtualKeyCode ToVirtualKeyCode( string key )
      {
         VirtualKeyCode virtualKeyCode;

         if ( key.StartsWith( "@" ) )
         {
            string rawScanCodeText = key.Replace( "@", string.Empty );

            int rawScanCode;

            if ( !int.TryParse( rawScanCodeText, out rawScanCode ) )
            {
               throw new ScriptParseException( "Scan code must be an integer: " + key );
            }

            return (VirtualKeyCode) rawScanCode;
         }

         if ( Enum.TryParse( key, true, out virtualKeyCode ) )
         {
            return virtualKeyCode;
         }

         if ( Enum.TryParse( "VK_" + key, true, out virtualKeyCode ) )
         {
            return virtualKeyCode;
         }

         if ( key.Equals( "enter", StringComparison.InvariantCultureIgnoreCase ) )
         {
            return VirtualKeyCode.RETURN;
         }

         throw new ScriptParseException( "Unrecognized key: " + key );
      }

      private static int GetWaitDuration( string value )
      {
         int duration;

         if ( !int.TryParse( value, out duration ) )
         {
            throw new ScriptParseException( "Duration must be an integer in milliseconds: " + value );
         }

         return duration;
      }

      private static Tuple<int, int> ToMovementDelta( string parameter )
      {
         var tokens = parameter.Split( ',' );

         if ( tokens.Length != 2 )
         {
            throw new ScriptParseException( "Mouse movement must be in the form x,y: " + parameter );
         }

         int deltaX;

         if ( !int.TryParse( tokens[0], out deltaX ) )
         {
            throw new ScriptParseException( "Mouse movement X delta must be an integer in pixels: " + tokens[0] );
         }

         int deltaY;

         if ( !int.TryParse( tokens[1], out deltaY ) )
         {
            throw new ScriptParseException( "Mouse movement Y delta must be an integer in pixels: " + tokens[1] );
         }

         return new Tuple<int, int>( deltaX, deltaY );
      }

      private static InputCommand ProcessTokens( string command, string parameter )
      {
         var inputCommand = new InputCommand();

         switch ( command )
         {
            case "down":
            {
               inputCommand.CommandType = CommandType.KeyDown;

               inputCommand.VirtualKeyCode = ToVirtualKeyCode( parameter );

               break;
            }
            case "up":
            {
               inputCommand.CommandType = CommandType.KeyUp;

               inputCommand.VirtualKeyCode = ToVirtualKeyCode( parameter ); 

               break;
            }
            case "press":
            {
               inputCommand.CommandType = CommandType.KeyPress;

               inputCommand.VirtualKeyCode = ToVirtualKeyCode( parameter ); 

               break;
            }
            case "mouse":
            {
               inputCommand.CommandType = CommandType.MouseMovement;

               Tuple<int, int> movementDelta = ToMovementDelta( parameter );

               inputCommand.MovementDeltaX = movementDelta.Item1;
               inputCommand.MovementDeltaY = movementDelta.Item2;

               break;
            }
            case "wait":
            {
               inputCommand.CommandType = CommandType.Wait;

               inputCommand.WaitDuration = GetWaitDuration( parameter );

               break;
            }
            default:
            {
               throw new ScriptParseException( "Unrecognized command: " + command );
            }
         }

         return inputCommand;
      }
   }
}
