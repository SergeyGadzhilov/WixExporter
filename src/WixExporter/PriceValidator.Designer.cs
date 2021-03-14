
namespace WixExporter
{
   partial class PriceValidatorDialog
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
         this.textBox_Editor = new System.Windows.Forms.TextBox();
         this.button_OK = new System.Windows.Forms.Button();
         this.label_Reason = new System.Windows.Forms.Label();
         this.label_ID = new System.Windows.Forms.Label();
         this.textBox_ID = new System.Windows.Forms.TextBox();
         this.SuspendLayout();
         // 
         // textBox_Editor
         // 
         this.textBox_Editor.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
         this.textBox_Editor.Location = new System.Drawing.Point(12, 93);
         this.textBox_Editor.Multiline = true;
         this.textBox_Editor.Name = "textBox_Editor";
         this.textBox_Editor.Size = new System.Drawing.Size(637, 276);
         this.textBox_Editor.TabIndex = 0;
         // 
         // button_OK
         // 
         this.button_OK.Location = new System.Drawing.Point(574, 384);
         this.button_OK.Name = "button_OK";
         this.button_OK.Size = new System.Drawing.Size(75, 23);
         this.button_OK.TabIndex = 1;
         this.button_OK.Text = "Ok";
         this.button_OK.UseVisualStyleBackColor = true;
         this.button_OK.Click += new System.EventHandler(this.button_OK_Click);
         // 
         // label_Reason
         // 
         this.label_Reason.AutoSize = true;
         this.label_Reason.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
         this.label_Reason.ForeColor = System.Drawing.Color.Red;
         this.label_Reason.Location = new System.Drawing.Point(12, 67);
         this.label_Reason.Name = "label_Reason";
         this.label_Reason.Size = new System.Drawing.Size(0, 23);
         this.label_Reason.TabIndex = 2;
         // 
         // label_ID
         // 
         this.label_ID.AutoSize = true;
         this.label_ID.Location = new System.Drawing.Point(9, 16);
         this.label_ID.Name = "label_ID";
         this.label_ID.Size = new System.Drawing.Size(24, 13);
         this.label_ID.TabIndex = 3;
         this.label_ID.Text = "ID: ";
         // 
         // textBox_ID
         // 
         this.textBox_ID.Location = new System.Drawing.Point(43, 13);
         this.textBox_ID.Name = "textBox_ID";
         this.textBox_ID.ReadOnly = true;
         this.textBox_ID.Size = new System.Drawing.Size(201, 20);
         this.textBox_ID.TabIndex = 4;
         // 
         // PriceValidatorDialog
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(661, 419);
         this.Controls.Add(this.textBox_ID);
         this.Controls.Add(this.label_ID);
         this.Controls.Add(this.label_Reason);
         this.Controls.Add(this.button_OK);
         this.Controls.Add(this.textBox_Editor);
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "PriceValidatorDialog";
         this.Text = "PriceValidator";
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.TextBox textBox_Editor;
      private System.Windows.Forms.Button button_OK;
      private System.Windows.Forms.Label label_Reason;
      private System.Windows.Forms.Label label_ID;
      private System.Windows.Forms.TextBox textBox_ID;
   }
}