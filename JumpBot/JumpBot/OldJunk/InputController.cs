//using System.Diagnostics;

//namespace JumpBot
//{
//   public static class InputController
//   {
//      public static void KeyPress( VirtualKeyShort key )
//      {
//         // Key Down

//         var keyDownInput = new KEYBDINPUT
//         {
//            wVk = key,
//            time = 1
//         };

//         var inputDown = new INPUT
//         {
//            type = 1,
//            U = new InputUnion
//            {
//               ki = keyDownInput
//            }
//         };

//         // Key Up

//         var keyUpInput = new KEYBDINPUT
//         {
//            wVk = key,
//            time = 100,
//            dwFlags = KEYEVENTF.KEYUP
//         };

//         var inputUp = new INPUT
//         {
//            type = 1,
//            U = new InputUnion
//            {
//               ki = keyUpInput
//            }
//         };

//         var inputs = new[]
//         {
//            inputDown,
//            inputUp
//         };

//         uint eventsSent = Input32.SendInput( 2, inputs, INPUT.Size );

//         Debug.WriteLine( "Events sent: " + eventsSent );
//      }
//   }
//}
