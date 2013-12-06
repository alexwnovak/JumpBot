namespace JumpBot
{
   public interface IScriptLoader
   {
      JumpScript LoadFromFile( string filePath );
   }
}
