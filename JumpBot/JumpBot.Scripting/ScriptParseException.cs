using System;
using System.Runtime.Serialization;

namespace JumpBot.Scripting
{
   [Serializable]
   public class ScriptParseException : Exception
   {
      public int LineNumber
      {
         get;
         set;
      }

      public ScriptParseException()
      {
      }

      public ScriptParseException( string message )
         : base( message )
      {
      }

      public ScriptParseException( string message, Exception inner )
         : base( message, inner )
      {
      }

      protected ScriptParseException( SerializationInfo info, StreamingContext context )
         : base( info, context )
      {
      }
   }
}
