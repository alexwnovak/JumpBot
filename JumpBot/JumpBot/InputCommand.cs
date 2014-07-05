using JumpBot.Input;
using JumpBot.Native;

namespace JumpBot
{
   public struct InputCommand
   {
      public CommandType CommandType;
      public VirtualKeyCode VirtualKeyCode;
      public MouseButton MouseButton;
      public int MovementDeltaX;
      public int MovementDeltaY;
      public int WaitDuration;
   }
}
