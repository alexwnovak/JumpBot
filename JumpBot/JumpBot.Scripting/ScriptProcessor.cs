namespace JumpBot.Scripting
{
   /// <summary>
   /// Ingests a raw list of commands and expands the mouse movement instructions to their final form.
   /// </summary>
   public static class ScriptProcessor
   {
      public static InputCommand[] Process( InputCommand[] inputCommands )
      {
         foreach ( var inputCommand in inputCommands )
         {
            if ( inputCommand.CommandType == CommandType.MouseMovement )
            {
               
            }
         }

         return inputCommands;
      }
   }
}
