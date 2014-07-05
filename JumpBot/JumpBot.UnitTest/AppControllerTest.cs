//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Moq;

//namespace JumpBot.UnitTest
//{
//   [TestClass]
//   public class AppControllerTest
//   {
//      [TestInitialize]
//      public void Initialize()
//      {
//         Dependency.CreateUnityContainer();
//      }

//      [TestMethod]
//      public void Run_NullArguments_ReturnsExitCodeOne()
//      {
//         var appController = new AppController();

//         int exitCode = appController.Run( null );

//         Assert.AreEqual( 1, exitCode );
//      }

//      [TestMethod]
//      public void Run_EmptyArguments_ReturnsExitCodeOne()
//      {
//         var appController = new AppController();

//         int exitCode = appController.Run( new string[0] );

//         Assert.AreEqual( 1, exitCode );
//      }

//      [TestMethod]
//      public void Run_HasFilePathArgument_PassesToScriptLoader()
//      {
//         const string filePath = "SomeScript.txt";

//         // Setup

//         var fileSystemMock = new Mock<IFileSystem>();
//         fileSystemMock.Setup( fs => fs.FileExists( filePath ) ).Returns( true );
//         Dependency.RegisterInstance( fileSystemMock.Object );

//         var scriptLoaderMock = new Mock<IScriptLoader>();
//         Dependency.RegisterInstance( scriptLoaderMock.Object );

//         // Test

//         var appController = new AppController();

//         appController.Run( filePath.AsArray() );

//         // Assert

//         scriptLoaderMock.Verify( sl => sl.LoadFromFile( filePath ), Times.Once );
//      }

//      [TestMethod]
//      public void Run_FileDoesNotExist_ReturnsExitCodeOne()
//      {
//         const string filePath = "SomeScript.txt";

//         // Setup

//         var fileSystemMock = new Mock<IFileSystem>();
//         Dependency.RegisterInstance( fileSystemMock.Object );

//         // Test

//         var appController = new AppController();

//         int exitCode = appController.Run( filePath.AsArray() );

//         // Assert

//         Assert.AreEqual( 1, exitCode );
//      }
//   }
//}
