namespace JumpBot
{
   internal static class Program
   {
      private static void InitDependencyInjection()
      {
         Dependency.CreateUnityContainer();
         Dependency.RegisterType<IScriptLoader, ScriptLoader>();
         Dependency.RegisterType<IFileSystem, FileSystem>();
      }

      internal static void Main( string[] arguments )
      {
         InitDependencyInjection();

         new AppController().Run( arguments );
      }
   }
}
