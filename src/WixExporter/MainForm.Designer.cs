
namespace WixExporter
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
      protected override void Dispose(bool disposing)
      {
         if (disposing && (components != null))
         {
            components.Dispose();
         }
         base.Dispose(disposing);
      }

      #region Windows Form Designer generated code

      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
         this.label_Destination = new System.Windows.Forms.Label();
         this.textBox_Destination = new System.Windows.Forms.TextBox();
         this.button_LookupDestination = new System.Windows.Forms.Button();
         this.button_Update = new System.Windows.Forms.Button();
         this.SuspendLayout();
         // 
         // label_Destination
         // 
         this.label_Destination.AutoSize = true;
         this.label_Destination.Location = new System.Drawing.Point(24, 25);
         this.label_Destination.Name = "label_Destination";
         this.label_Destination.Size = new System.Drawing.Size(79, 17);
         this.label_Destination.TabIndex = 1;
         this.label_Destination.Text = "Destination";
         // 
         // textBox_Destination
         // 
         this.textBox_Destination.Location = new System.Drawing.Point(107, 26);
         this.textBox_Destination.Name = "textBox_Destination";
         this.textBox_Destination.Size = new System.Drawing.Size(367, 22);
         this.textBox_Destination.TabIndex = 3;
         this.textBox_Destination.TextChanged += new System.EventHandler(this.textBox_Destination_TextChanged);
         // 
         // button_LookupDestination
         // 
         this.button_LookupDestination.Location = new System.Drawing.Point(473, 25);
         this.button_LookupDestination.Name = "button_LookupDestination";
         this.button_LookupDestination.Size = new System.Drawing.Size(40, 24);
         this.button_LookupDestination.TabIndex = 5;
         this.button_LookupDestination.Text = "...";
         this.button_LookupDestination.UseVisualStyleBackColor = true;
         this.button_LookupDestination.Click += new System.EventHandler(this.button_LookupDestination_Click);
         // 
         // button_Update
         // 
         this.button_Update.Enabled = false;
         this.button_Update.Location = new System.Drawing.Point(438, 67);
         this.button_Update.Name = "button_Update";
         this.button_Update.Size = new System.Drawing.Size(75, 31);
         this.button_Update.TabIndex = 6;
         this.button_Update.Text = "Update";
         this.button_Update.UseVisualStyleBackColor = true;
         this.button_Update.Click += new System.EventHandler(this.button_Update_Click);
         // 
         // MainForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(537, 121);
         this.Controls.Add(this.button_Update);
         this.Controls.Add(this.button_LookupDestination);
         this.Controls.Add(this.textBox_Destination);
         this.Controls.Add(this.label_Destination);
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "MainForm";
         this.Text = "WixExporter";
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion
      private System.Windows.Forms.Label label_Destination;
      private System.Windows.Forms.TextBox textBox_Destination;
      private System.Windows.Forms.Button button_LookupDestination;
      private System.Windows.Forms.Button button_Update;
   }
}

