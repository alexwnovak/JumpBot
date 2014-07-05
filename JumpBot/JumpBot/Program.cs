using System;
using System.Collections;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;


namespace JumpBot
{
   internal static class Program
   {
      //private static Process _jumpBotUIProcess;

      //private static void InitDependencyInjection()
      //{
      //   Dependency.CreateUnityContainer();
      //   //Dependency.RegisterType<IScriptLoader, ScriptLoader>();
      //   Dependency.RegisterType<IFileSystem, FileSystem>();
      //}

      //private static void LaunchAndFocus()
      //{
      //   var windowHandle = Win32.FindWindow( null, "JumpBot UI" );

      //   if ( windowHandle == IntPtr.Zero )
      //   {
      //      _jumpBotUIProcess = Process.Start( @"C:\Temp\JumpBotUI\JumpUI.exe" );

      //      Thread.Sleep( 200 );

      //      windowHandle = Win32.FindWindow( null, "JumpBot UI" );
      //   }

      //   Win32.BringWindowToTop( windowHandle );

      //   CenterMouseCursor();
      //}

      //private static void ShutDown()
      //{
      //   if ( _jumpBotUIProcess != null )
      //   {
      //      _jumpBotUIProcess.Kill();
      //   }
      //}

      //private static void CenterMouseCursor()
      //{
      //   int width = Screen.PrimaryScreen.Bounds.Width;
      //   int height = Screen.PrimaryScreen.Bounds.Height;

      //   Cursor.Position = new Point( width / 2, height / 2 );
      //}

      private static void Countdown()
      {
         int seconds = 3;

         while ( seconds > 0 )
         {
            Console.WriteLine( "Starting in {0} seconds...", seconds );

            Thread.Sleep( 1000 );

            seconds--;
         }

         Console.WriteLine( "Running script..." );
      }

      private static JumpScript LoadScript( string fileName )
      {
         JumpScript script = null;
         
         try
         {
            script = ScriptLoader.LoadFromFile( fileName );
         }
         catch ( ScriptParseException ex )
         {
            OutputController.ParseFailed( string.Format( "Line {0}: {1}", ex.LineNumber, ex.Message ) );
            Environment.Exit( 1 );
         }
         catch ( Exception ex )
         {
            OutputController.FatalError( string.Format( "Unexpected exception:" + Environment.NewLine + ex ) );
            Environment.Exit( 1 );
         }

         return script;
      }

      internal static int Main( string[] arguments )
      {
         if ( arguments.Length == 0 )
         {
            OutputController.ShowSyntax();
            return 1;
         }

         OutputController.BeginParse( arguments[0] );

         // Load script

         var startTime = DateTime.Now;

         var jumpScript = LoadScript( arguments[0] );

         OutputController.ParseSuccessful( (DateTime.Now - startTime).ToString( @"mm\:ss\.fff"  ) );

         // Prepare to run

         Countdown();

         // Run

         jumpScript.Run();

         // Shut down

         OutputController.Shutdown();

         return 0;
      }
   }
}
