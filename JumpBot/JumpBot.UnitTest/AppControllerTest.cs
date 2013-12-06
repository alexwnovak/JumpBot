using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JumpBot.UnitTest
{
   [TestClass]
   public class AppControllerTest
   {
      [TestMethod]
      public void Run_NullArguments_ReturnsExitCodeOne()
      {
         var appController = new AppController();

         int exitCode = appController.Run( null );

         Assert.AreEqual( 1, exitCode );
      }
   }
}
