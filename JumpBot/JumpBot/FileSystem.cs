using System.IO;

namespace JumpBot
{
   public class FileSystem : IFileSystem
   {
      public bool FileExists( string filePath )
      {
         return File.Exists( filePath );
      }
   }
}
