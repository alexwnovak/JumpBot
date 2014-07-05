using WindowsInput;
using WindowsInput.Native;

namespace JumpBot.Scripting
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
