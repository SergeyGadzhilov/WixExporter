using System;
using System.IO;
using System.Windows.Forms;
using WixExporter.Prices.Yaml;
using WixExporter.core;
using WixExporter.formatters;
using System.Collections.Generic;

namespace WixExporter
{
   public partial class MainForm : Form
   {
      public MainForm()
      {
         InitializeComponent();
      }

      private void button_LookupDestination_Click(object sender, EventArgs e)
      {
         FolderBrowserDialog destination = new FolderBrowserDialog();
         if (destination.ShowDialog() == DialogResult.OK)
         {
            textBox_Destination.Text = destination.SelectedPath;
            updateControls();
         }
      }

      private void updateControls()
      {
         button_Convert.Enabled = (
            Directory.Exists(textBox_Destination.Text)
         );
      }
      private void textBox_Destination_TextChanged(object sender, EventArgs e)
      {
         updateControls();
      }

      private void enableForm(bool enable)
      {
         button_Convert.Enabled = enable;
         textBox_Destination.Enabled = enable;
      }

      private void button_Convert_Click(object sender, EventArgs e)
      {
         enableForm(false);
         CsvFormatter formatter = new CsvFormatter();
         WixWritter writter = new WixWritter(GetPrices(), formatter);
         writter.write(textBox_Destination.Text + "\\wix.csv");
         MessageBox.Show("Done!");
         enableForm(true);
      }

      private List<Price> GetPrices()
      {
         List<Price> prices = new List<Price>();

         foreach (var source in Properties.Settings.Default.Sources)
         {
            prices.Add(new PriceYaml(source));
         }

         return prices;
      }
   }
}
