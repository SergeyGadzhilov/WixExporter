
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
         this.label_Source = new System.Windows.Forms.Label();
         this.label_Destination = new System.Windows.Forms.Label();
         this.textBox_Source = new System.Windows.Forms.TextBox();
         this.textBox_Destination = new System.Windows.Forms.TextBox();
         this.button_LookupSource = new System.Windows.Forms.Button();
         this.button_LookupDestination = new System.Windows.Forms.Button();
         this.button_Convert = new System.Windows.Forms.Button();
         this.SuspendLayout();
         // 
         // label_Source
         // 
         this.label_Source.AutoSize = true;
         this.label_Source.Location = new System.Drawing.Point(24, 27);
         this.label_Source.Name = "label_Source";
         this.label_Source.Size = new System.Drawing.Size(53, 17);
         this.label_Source.TabIndex = 0;
         this.label_Source.Text = "Source";
         // 
         // label_Destination
         // 
         this.label_Destination.AutoSize = true;
         this.label_Destination.Location = new System.Drawing.Point(24, 84);
         this.label_Destination.Name = "label_Destination";
         this.label_Destination.Size = new System.Drawing.Size(79, 17);
         this.label_Destination.TabIndex = 1;
         this.label_Destination.Text = "Destination";
         // 
         // textBox_Source
         // 
         this.textBox_Source.Location = new System.Drawing.Point(107, 24);
         this.textBox_Source.Name = "textBox_Source";
         this.textBox_Source.Size = new System.Drawing.Size(367, 22);
         this.textBox_Source.TabIndex = 2;
         this.textBox_Source.TextChanged += new System.EventHandler(this.textBox_Source_TextChanged);
         // 
         // textBox_Destination
         // 
         this.textBox_Destination.Location = new System.Drawing.Point(107, 81);
         this.textBox_Destination.Name = "textBox_Destination";
         this.textBox_Destination.Size = new System.Drawing.Size(367, 22);
         this.textBox_Destination.TabIndex = 3;
         this.textBox_Destination.TextChanged += new System.EventHandler(this.textBox_Destination_TextChanged);
         // 
         // button_LookupSource
         // 
         this.button_LookupSource.Location = new System.Drawing.Point(473, 23);
         this.button_LookupSource.Name = "button_LookupSource";
         this.button_LookupSource.Size = new System.Drawing.Size(40, 27);
         this.button_LookupSource.TabIndex = 4;
         this.button_LookupSource.Text = "...";
         this.button_LookupSource.UseVisualStyleBackColor = true;
         this.button_LookupSource.Click += new System.EventHandler(this.button_LookupSource_Click);
         // 
         // button_LookupDestination
         // 
         this.button_LookupDestination.Location = new System.Drawing.Point(473, 80);
         this.button_LookupDestination.Name = "button_LookupDestination";
         this.button_LookupDestination.Size = new System.Drawing.Size(40, 27);
         this.button_LookupDestination.TabIndex = 5;
         this.button_LookupDestination.Text = "...";
         this.button_LookupDestination.UseVisualStyleBackColor = true;
         this.button_LookupDestination.Click += new System.EventHandler(this.button_LookupDestination_Click);
         // 
         // button_Convert
         // 
         this.button_Convert.Enabled = false;
         this.button_Convert.Location = new System.Drawing.Point(438, 143);
         this.button_Convert.Name = "button_Convert";
         this.button_Convert.Size = new System.Drawing.Size(75, 31);
         this.button_Convert.TabIndex = 6;
         this.button_Convert.Text = "Convert";
         this.button_Convert.UseVisualStyleBackColor = true;
         this.button_Convert.Click += new System.EventHandler(this.button_Convert_Click);
         // 
         // MainForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(537, 201);
         this.Controls.Add(this.button_Convert);
         this.Controls.Add(this.button_LookupDestination);
         this.Controls.Add(this.button_LookupSource);
         this.Controls.Add(this.textBox_Destination);
         this.Controls.Add(this.textBox_Source);
         this.Controls.Add(this.label_Destination);
         this.Controls.Add(this.label_Source);
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "MainForm";
         this.Text = "WixExporter";
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Label label_Source;
      private System.Windows.Forms.Label label_Destination;
      private System.Windows.Forms.TextBox textBox_Source;
      private System.Windows.Forms.TextBox textBox_Destination;
      private System.Windows.Forms.Button button_LookupSource;
      private System.Windows.Forms.Button button_LookupDestination;
      private System.Windows.Forms.Button button_Convert;
   }
}

