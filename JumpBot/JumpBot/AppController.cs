namespace JumpBot
{
   public class AppController
   {
      public int Run( string[] arguments )
      {
         if ( arguments == null || arguments.Length == 0 )
         {
            return 1;
         }

         return 0;
      }
   }
}
