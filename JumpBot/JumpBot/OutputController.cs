using System;

namespace JumpBot
{
   public static class OutputController
   {
      public static void ShowSyntax()
      {
         Console.ForegroundColor = ConsoleColor.Blue;
         Console.WriteLine( "===== JumpBot Input Automation =====" );
         Console.WriteLine();

         Console.ForegroundColor = ConsoleColor.Gray;
         Console.WriteLine( "  Syntax: jump <script>" );
         Console.WriteLine();
      }

      public static void BeginParse( string fileName )
      {
         Console.ForegroundColor = ConsoleColor.Blue;
         Console.WriteLine( "===== JumpBot Input Automation =====" );
         Console.WriteLine();

         Console.ForegroundColor = ConsoleColor.Gray;
         Console.WriteLine( "Loading script: " + fileName );
      }

      public static void ParseFailed( string message )
      {
         Console.ForegroundColor = ConsoleColor.Red;
         Console.WriteLine( "===== Script Parse Failed =====" );
         Console.ForegroundColor = ConsoleColor.Gray;

         Console.WriteLine();
         Console.WriteLine( message );
         Console.WriteLine();

         Console.ReadKey();
      }

      public static void FatalError( string message )
      {
         Console.ForegroundColor = ConsoleColor.Red;
         Console.WriteLine( "===== Unexpected exception =====" );
         Console.WriteLine();

         Console.ForegroundColor = ConsoleColor.Gray;
         Console.WriteLine( message );
         Console.WriteLine();
      }

      public static void ParseSuccessful( string parseTime )
      {
         Console.ForegroundColor = ConsoleColor.Green;
         Console.WriteLine( "Script parsed successfully" );

         Console.ForegroundColor = ConsoleColor.Gray;
         Console.WriteLine( "Parse time: " + parseTime );
      }

      public static void Shutdown()
      {
         Console.WriteLine( "Script complete. Shutting down..." );
         Console.WriteLine();
      }
   }
}
