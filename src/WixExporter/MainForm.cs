using System;
using System.IO;
using System.Windows.Forms;
using WixExporter.core;
using WixExporter.core.db;
using WixExporter.db;
using WixExporter.formatters;
using System.Collections.Generic;

namespace WixExporter
{
   public partial class MainForm : Form
   {
      private const string DB_FILE = "db.xml";
      private PriceDB mDB = new PriceDB(new YamlDBReader(DB_FILE), new YamlDBWriter(DB_FILE));
      private List<Price> mPrices = new List<Price>();
      public MainForm()
      {
         InitializeComponent();
         mPrices = GetPrices();
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
      }
      private void textBox_Destination_TextChanged(object sender, EventArgs e)
      {
         updateControls();
      }

      private void enableForm(bool enable)
      {
         button_Update.Enabled = enable;
         textBox_Destination.Enabled = enable;
      }

      private void button_Update_Click(object sender, EventArgs e)
      {
         enableForm(false);

         //WixWritter writter = new WixWritter(prices, new CsvFormatter());
         //writter.write(textBox_Destination.Text + "\\wix.csv");

         ComparedPrice comparedPrice = new ComparedPrice(mDB.GetPrice(), mPrices);
         ComparedPiceGridView table = new ComparedPiceGridView(OffersGrid, comparedPrice);

         MessageBox.Show("Done!");
         enableForm(true);
      }
      private void UpdateDB()
      {
         foreach (var price in mPrices)
         {
            mDB.AddPrice(price);
         }
         mDB.Save();
      }

      private List<Price> GetPrices()
      {
         List<Price> prices = new List<Price>();

         foreach (var source in Properties.Settings.Default.Sources)
         {
            var reader = new YamlDBReader(source);
            prices.Add(reader.GetPrice());
         }

         return prices;
      }
      private void button_Save_Click(object sender, EventArgs e)
      {
         enableForm(false);
         UpdateDB();
         MessageBox.Show("Done!");
         enableForm(true);
      }
   }
}
