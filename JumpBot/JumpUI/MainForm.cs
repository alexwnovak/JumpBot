using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace JumpUI
{
   public partial class MainForm : Form
   {
      private readonly Dictionary<int, Label> _labels = new Dictionary<int, Label>();
       
      public MainForm()
      {
         InitializeComponent();

         _labels[87] = _forwardLabel;
         _labels[65] = _strafeLeftLabel;
         _labels[83] = _backLabel;
         _labels[68] = _strafeRightLabel;

         _labels[67] = _duckLabel;
         _labels[32] = _jumpLabel;
         _labels[13] = _fireLabel;
      }

      private void MainForm_Load( object sender, System.EventArgs e )
      {
         int width = Screen.PrimaryScreen.Bounds.Width;
         int height = Screen.PrimaryScreen.Bounds.Height;

         Cursor.Position = new Point( 0, 0 );
      }

      private void MainForm_KeyDown( object sender, KeyEventArgs e )
      {
         Label label;

         if ( _labels.TryGetValue( e.KeyValue, out label ) )
         {
            label.BackColor = Color.SandyBrown;
         }
      }

      private void MainForm_KeyUp( object sender, KeyEventArgs e )
      {
         Label label;

         if ( _labels.TryGetValue( e.KeyValue, out label ) )
         {
            label.BackColor = Color.FromKnownColor( KnownColor.Control );
         }
      }
   }
}
