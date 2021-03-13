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
         button_Update.Enabled = (
            Directory.Exists(textBox_Destination.Text)
         );
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
         const string DB_FILE = "db.xml";
         PriceDB db = new PriceDB(new YamlDBReader(DB_FILE), new YamlDBWriter(DB_FILE));

         enableForm(false);
         List<Price> prices = GetPrices();

         WixWritter writter = new WixWritter(prices, new CsvFormatter());
         writter.write(textBox_Destination.Text + "\\wix.csv");

         ComparedPrice comparedPrice = new ComparedPrice(db.GetPrice(), prices);
         foreach (var offer in comparedPrice.comparedOffers())
         {
            Console.WriteLine("Changed offer = " + offer.Key);
            Console.WriteLine("Prev price = " + offer.Value.oldPrice);
            Console.WriteLine("New price = " + offer.Value.Price);
         }

         UpdateDB(db, prices);

         MessageBox.Show("Done!");
         enableForm(true);
      }

      private void UpdateDB(PriceDB db, List<Price> prices)
      {
         foreach (var price in prices)
         {
            db.AddPrice(price);
         }
         db.Save();
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
   }
}
