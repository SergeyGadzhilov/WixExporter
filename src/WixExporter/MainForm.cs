using System;
using System.IO;
using System.Windows.Forms;
using WixExporter.Prices.Yaml;
using WixExporter.core;
using WixExporter.formatters;

namespace WixExporter
{
   public partial class MainForm : Form
   {
      public MainForm()
      {
         InitializeComponent();
      }

      private void button_LookupSource_Click(object sender, EventArgs e)
      {
         OpenFileDialog source = new OpenFileDialog();
         source.Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*";
         if (source.ShowDialog() == DialogResult.OK)
         {
            textBox_Source.Text = source.FileName;
            updateControls();
         }
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
            File.Exists(textBox_Source.Text) &&
            Directory.Exists(textBox_Destination.Text)
         );
      }
      private void textBox_Destination_TextChanged(object sender, EventArgs e)
      {
         updateControls();
      }

      private void textBox_Source_TextChanged(object sender, EventArgs e)
      {
         updateControls();
      }

      private void enableForm(bool enable)
      {
         button_Convert.Enabled = enable;
         textBox_Destination.Enabled = enable;
         textBox_Source.Enabled = enable;
      }

      private void button_Convert_Click(object sender, EventArgs e)
      {
         enableForm(false);
         PriceYaml price = new PriceYaml(textBox_Source.Text);
         CsvFormatter formatter = new CsvFormatter();
         WixWritter writter = new WixWritter(price, formatter);
         writter.write(textBox_Destination.Text + "\\wix.csv");
         MessageBox.Show("Done!");
         enableForm(true);
      }
   }
}
