namespace JumpUI
{
   partial class MainForm
   {
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.IContainer components = null;

      /// <summary>
      /// Clean up any resources being used.
      /// </summary>
      /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
      protected override void Dispose( bool disposing )
      {
         if ( disposing && (components != null) )
         {
            components.Dispose();
         }
         base.Dispose( disposing );
      }

      #region Windows Form Designer generated code

      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
         this._backLabel = new System.Windows.Forms.Label();
         this._forwardLabel = new System.Windows.Forms.Label();
         this._strafeLeftLabel = new System.Windows.Forms.Label();
         this._strafeRightLabel = new System.Windows.Forms.Label();
         this._fireLabel = new System.Windows.Forms.Label();
         this._duckLabel = new System.Windows.Forms.Label();
         this._jumpLabel = new System.Windows.Forms.Label();
         this.SuspendLayout();
         // 
         // _backLabel
         // 
         this._backLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this._backLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this._backLabel.Location = new System.Drawing.Point(84, 86);
         this._backLabel.Name = "_backLabel";
         this._backLabel.Size = new System.Drawing.Size(50, 50);
         this._backLabel.TabIndex = 0;
         this._backLabel.Text = "S";
         this._backLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
         // 
         // _forwardLabel
         // 
         this._forwardLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this._forwardLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this._forwardLabel.Location = new System.Drawing.Point(84, 29);
         this._forwardLabel.Name = "_forwardLabel";
         this._forwardLabel.Size = new System.Drawing.Size(50, 50);
         this._forwardLabel.TabIndex = 0;
         this._forwardLabel.Text = "W";
         this._forwardLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
         // 
         // _strafeLeftLabel
         // 
         this._strafeLeftLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this._strafeLeftLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this._strafeLeftLabel.Location = new System.Drawing.Point(28, 86);
         this._strafeLeftLabel.Name = "_strafeLeftLabel";
         this._strafeLeftLabel.Size = new System.Drawing.Size(50, 50);
         this._strafeLeftLabel.TabIndex = 0;
         this._strafeLeftLabel.Text = "A";
         this._strafeLeftLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
         // 
         // _strafeRightLabel
         // 
         this._strafeRightLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this._strafeRightLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this._strafeRightLabel.Location = new System.Drawing.Point(140, 86);
         this._strafeRightLabel.Name = "_strafeRightLabel";
         this._strafeRightLabel.Size = new System.Drawing.Size(50, 50);
         this._strafeRightLabel.TabIndex = 0;
         this._strafeRightLabel.Text = "D";
         this._strafeRightLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
         // 
         // _fireLabel
         // 
         this._fireLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this._fireLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this._fireLabel.Location = new System.Drawing.Point(316, 86);
         this._fireLabel.Name = "_fireLabel";
         this._fireLabel.Size = new System.Drawing.Size(99, 50);
         this._fireLabel.TabIndex = 0;
         this._fireLabel.Text = "Fire";
         this._fireLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
         // 
         // _duckLabel
         // 
         this._duckLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this._duckLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this._duckLabel.Location = new System.Drawing.Point(84, 174);
         this._duckLabel.Name = "_duckLabel";
         this._duckLabel.Size = new System.Drawing.Size(140, 50);
         this._duckLabel.TabIndex = 0;
         this._duckLabel.Text = "Duck";
         this._duckLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
         // 
         // _jumpLabel
         // 
         this._jumpLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this._jumpLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this._jumpLabel.Location = new System.Drawing.Point(230, 174);
         this._jumpLabel.Name = "_jumpLabel";
         this._jumpLabel.Size = new System.Drawing.Size(140, 50);
         this._jumpLabel.TabIndex = 0;
         this._jumpLabel.Text = "Jump";
         this._jumpLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
         // 
         // MainForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(444, 253);
         this.Controls.Add(this._forwardLabel);
         this.Controls.Add(this._jumpLabel);
         this.Controls.Add(this._duckLabel);
         this.Controls.Add(this._fireLabel);
         this.Controls.Add(this._strafeRightLabel);
         this.Controls.Add(this._strafeLeftLabel);
         this.Controls.Add(this._backLabel);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
         this.KeyPreview = true;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "MainForm";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
         this.Text = "JumpBot UI";
         this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
         this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyUp);
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.Label _backLabel;
      private System.Windows.Forms.Label _forwardLabel;
      private System.Windows.Forms.Label _strafeLeftLabel;
      private System.Windows.Forms.Label _strafeRightLabel;
      private System.Windows.Forms.Label _fireLabel;
      private System.Windows.Forms.Label _duckLabel;
      private System.Windows.Forms.Label _jumpLabel;
   }
}

