
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
         this.OffersGrid = new System.Windows.Forms.DataGridView();
         this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.OldPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.NewPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.button_Save = new System.Windows.Forms.Button();
         this.button_ExportSelected = new System.Windows.Forms.Button();
         this.button_ExportAll = new System.Windows.Forms.Button();
         ((System.ComponentModel.ISupportInitialize)(this.OffersGrid)).BeginInit();
         this.SuspendLayout();
         // 
         // label_Destination
         // 
         this.label_Destination.AutoSize = true;
         this.label_Destination.Location = new System.Drawing.Point(12, 242);
         this.label_Destination.Name = "label_Destination";
         this.label_Destination.Size = new System.Drawing.Size(79, 17);
         this.label_Destination.TabIndex = 1;
         this.label_Destination.Text = "Destination";
         // 
         // textBox_Destination
         // 
         this.textBox_Destination.Location = new System.Drawing.Point(97, 239);
         this.textBox_Destination.Name = "textBox_Destination";
         this.textBox_Destination.Size = new System.Drawing.Size(382, 22);
         this.textBox_Destination.TabIndex = 3;
         this.textBox_Destination.TextChanged += new System.EventHandler(this.textBox_Destination_TextChanged);
         // 
         // button_LookupDestination
         // 
         this.button_LookupDestination.Location = new System.Drawing.Point(485, 237);
         this.button_LookupDestination.Name = "button_LookupDestination";
         this.button_LookupDestination.Size = new System.Drawing.Size(40, 24);
         this.button_LookupDestination.TabIndex = 5;
         this.button_LookupDestination.Text = "...";
         this.button_LookupDestination.UseVisualStyleBackColor = true;
         this.button_LookupDestination.Click += new System.EventHandler(this.button_LookupDestination_Click);
         // 
         // button_Update
         // 
         this.button_Update.Location = new System.Drawing.Point(95, 279);
         this.button_Update.Name = "button_Update";
         this.button_Update.Size = new System.Drawing.Size(75, 31);
         this.button_Update.TabIndex = 6;
         this.button_Update.Text = "Update";
         this.button_Update.UseVisualStyleBackColor = true;
         this.button_Update.Click += new System.EventHandler(this.button_Update_Click);
         // 
         // OffersGrid
         // 
         this.OffersGrid.AllowUserToAddRows = false;
         this.OffersGrid.AllowUserToDeleteRows = false;
         this.OffersGrid.AllowUserToResizeRows = false;
         this.OffersGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
         this.OffersGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.OldPrice,
            this.NewPrice});
         this.OffersGrid.Location = new System.Drawing.Point(2, 1);
         this.OffersGrid.Name = "OffersGrid";
         this.OffersGrid.ReadOnly = true;
         this.OffersGrid.RowHeadersVisible = false;
         this.OffersGrid.RowHeadersWidth = 51;
         this.OffersGrid.RowTemplate.Height = 24;
         this.OffersGrid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
         this.OffersGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
         this.OffersGrid.Size = new System.Drawing.Size(536, 228);
         this.OffersGrid.TabIndex = 7;
         // 
         // ID
         // 
         this.ID.HeaderText = "ID";
         this.ID.MinimumWidth = 6;
         this.ID.Name = "ID";
         this.ID.ReadOnly = true;
         this.ID.Width = 133;
         // 
         // OldPrice
         // 
         this.OldPrice.HeaderText = "Old Price";
         this.OldPrice.MinimumWidth = 6;
         this.OldPrice.Name = "OldPrice";
         this.OldPrice.ReadOnly = true;
         this.OldPrice.Width = 133;
         // 
         // NewPrice
         // 
         this.NewPrice.HeaderText = "New Price";
         this.NewPrice.MinimumWidth = 6;
         this.NewPrice.Name = "NewPrice";
         this.NewPrice.ReadOnly = true;
         this.NewPrice.Width = 133;
         // 
         // button_Save
         // 
         this.button_Save.Enabled = false;
         this.button_Save.Location = new System.Drawing.Point(176, 279);
         this.button_Save.Name = "button_Save";
         this.button_Save.Size = new System.Drawing.Size(75, 31);
         this.button_Save.TabIndex = 8;
         this.button_Save.Text = "Save";
         this.button_Save.UseVisualStyleBackColor = true;
         this.button_Save.Click += new System.EventHandler(this.button_Save_Click);
         // 
         // button_ExportSelected
         // 
         this.button_ExportSelected.Enabled = false;
         this.button_ExportSelected.Location = new System.Drawing.Point(257, 279);
         this.button_ExportSelected.Name = "button_ExportSelected";
         this.button_ExportSelected.Size = new System.Drawing.Size(132, 31);
         this.button_ExportSelected.TabIndex = 9;
         this.button_ExportSelected.Text = "Export Selected";
         this.button_ExportSelected.UseVisualStyleBackColor = true;
         this.button_ExportSelected.Click += new System.EventHandler(this.button_Export_Click);
         // 
         // button_ExportAll
         // 
         this.button_ExportAll.Enabled = false;
         this.button_ExportAll.Location = new System.Drawing.Point(396, 279);
         this.button_ExportAll.Name = "button_ExportAll";
         this.button_ExportAll.Size = new System.Drawing.Size(129, 31);
         this.button_ExportAll.TabIndex = 10;
         this.button_ExportAll.Text = "Export All";
         this.button_ExportAll.UseVisualStyleBackColor = true;
         this.button_ExportAll.Click += new System.EventHandler(this.button_ExportAll_Click);
         // 
         // MainForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
         this.ClientSize = new System.Drawing.Size(537, 322);
         this.Controls.Add(this.button_ExportAll);
         this.Controls.Add(this.button_ExportSelected);
         this.Controls.Add(this.button_Save);
         this.Controls.Add(this.OffersGrid);
         this.Controls.Add(this.button_Update);
         this.Controls.Add(this.button_LookupDestination);
         this.Controls.Add(this.textBox_Destination);
         this.Controls.Add(this.label_Destination);
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "MainForm";
         this.Text = "WixExporter";
         ((System.ComponentModel.ISupportInitialize)(this.OffersGrid)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion
      private System.Windows.Forms.Label label_Destination;
      private System.Windows.Forms.TextBox textBox_Destination;
      private System.Windows.Forms.Button button_LookupDestination;
      private System.Windows.Forms.Button button_Update;
      private System.Windows.Forms.DataGridView OffersGrid;
      private System.Windows.Forms.DataGridViewTextBoxColumn ID;
      private System.Windows.Forms.DataGridViewTextBoxColumn OldPrice;
      private System.Windows.Forms.DataGridViewTextBoxColumn NewPrice;
      private System.Windows.Forms.Button button_Save;
      private System.Windows.Forms.Button button_ExportSelected;
      private System.Windows.Forms.Button button_ExportAll;
   }
}

