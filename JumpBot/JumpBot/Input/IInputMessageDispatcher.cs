// Type: WindowsInput.IInputMessageDispatcher
// Assembly: WindowsInput, Version=1.0.4.0, Culture=neutral, PublicKeyToken=9b287f7dc5073cad
// MVID: 776EB3EF-00F5-4F48-8D79-09AC1BD5E956
// Assembly location: C:\Git\alexwnovak\JumpBot\JumpBot\packages\InputSimulator.1.0.4.0\lib\net20\WindowsInput.dll

using JumpBot.Native;

namespace JumpBot.Input
{
   /// <summary>
   /// The contract for a service that dispatches <see cref="T:WindowsInput.Native.INPUT"/> messages to the appropriate destination.
   /// 
   /// </summary>
   internal interface IInputMessageDispatcher
   {
      /// <summary>
      /// Dispatches the specified list of <see cref="T:WindowsInput.Native.INPUT"/> messages in their specified order.
      /// 
      /// </summary>
      /// <param name="inputs">The list of <see cref="T:WindowsInput.Native.INPUT"/> messages to be dispatched.</param><exception cref="T:System.ArgumentException">If the <paramref name="inputs"/> array is empty.</exception><exception cref="T:System.ArgumentNullException">If the <paramref name="inputs"/> array is null.</exception><exception cref="T:System.Exception">If the any of the commands in the <paramref name="inputs"/> array could not be sent successfully.</exception>
      void DispatchInput( INPUT[] inputs );
   }
}
