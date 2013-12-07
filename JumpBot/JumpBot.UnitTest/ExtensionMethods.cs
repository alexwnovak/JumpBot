namespace JumpBot.UnitTest
{
   public static class ExtensionMethods
   {
      public static T[] AsArray<T>( this T instance )
      {
         return new[]
         {
            instance
         };
      }
   }
}
