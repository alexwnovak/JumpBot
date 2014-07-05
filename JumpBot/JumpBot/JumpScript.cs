using System.Threading;
using JumpBot.Input;

namespace JumpBot
{
   public class JumpScript
   {
      private readonly InputCommand[] _inputCommands;

      internal JumpScript( InputCommand[] inputCommands )
      {
         _inputCommands = inputCommands;
      }

      public void Run()
      {
         var inputSimulator = new InputSimulator();

         foreach ( var inputCommand in _inputCommands )
         {
            switch ( inputCommand.CommandType )
            {
               case CommandType.KeyDown:
                  inputSimulator.Keyboard.KeyDown( inputCommand.VirtualKeyCode );
                  break;
               case CommandType.KeyUp:
                  inputSimulator.Keyboard.KeyUp( inputCommand.VirtualKeyCode );
                  break;
               case CommandType.KeyPress:
                  inputSimulator.Keyboard.KeyPress( inputCommand.VirtualKeyCode );
                  break;
               case CommandType.MouseLeftButtonDown:
                  inputSimulator.Mouse.LeftButtonDown();
                  break;
               case CommandType.MouseLeftButtonUp:
                  inputSimulator.Mouse.LeftButtonUp();
                  break;
               case CommandType.MouseLeftClick:
                  inputSimulator.Mouse.LeftButtonClick();
                  break;
               case CommandType.MouseMovement:
                  inputSimulator.Mouse.MoveMouseBy( inputCommand.MovementDeltaX, inputCommand.MovementDeltaY ); 
                  break;
               case CommandType.Wait:
                  Thread.Sleep( inputCommand.WaitDuration );
                  break;
            }
         }
      }
   }
}
