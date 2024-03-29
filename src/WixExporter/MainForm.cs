﻿using System;
using System.IO;
using System.Windows.Forms;
using WixExporter.core;
using WixExporter.db;
using WixExporter.formatters;
using WixExporter.filters;
using System.Collections.Generic;
using System.Threading;

namespace WixExporter
{
   public partial class MainForm : Form
   {
      private const string DB_FILE = "db.xml";
      private ComparedPrice mPrice = new ComparedPrice();
      ComparedPiceGridView mTable = null;
      public MainForm()
      {
         InitializeComponent();
         mTable = new ComparedPiceGridView(OffersGrid);
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
         button_Save.Enabled = mPrice.comparedOffers().Count > 0;
         button_ExportSelected.Enabled = (
            Directory.Exists(textBox_Destination.Text) &&
            button_Save.Enabled &&
            mTable.GetSelected().Count > 0
         );
         button_ExportAll.Enabled = Directory.Exists(textBox_Destination.Text) && button_Save.Enabled;
      }

      private void textBox_Destination_TextChanged(object sender, EventArgs e)
      {
         updateControls();
      }

      private void enableForm(bool enable)
      {
         if (enable)
         {
            updateControls();
         }
         else
         {
            button_Save.Enabled = enable;
            button_ExportSelected.Enabled = enable;
            button_ExportAll.Enabled = enable;
         }

         button_Update.Enabled = enable;
         textBox_Destination.Enabled = enable;
      }

      private void button_Update_Click(object sender, EventArgs e)
      {
         enableForm(false);

         this.progressBar1.Value = 0;
         this.progressBar1.Visible = true;
         mTable.Clear();
         
         mPrice = GetPrice();
         this.progressBar1.Visible = false;
         mTable.SetData(mPrice);
         
         MessageBox.Show("Done!");
         enableForm(true);
      }

      private ComparedPrice GetPrice()
      {
         var db = new YamlDBReader(DB_FILE);
         List<Price> prices = readPrices();
         YamlPriceFilter filter = new YamlPriceFilter("filter.xml");

         return new ComparedPrice(db.GetPrice(), prices, filter);
      }

      private List<Price> readPrices()
      {
         List<Price> prices = new List<Price>();
         this.progressBar1.Maximum = Properties.Settings.Default.Sources.Count;
         this.progressBar1.Step = 1;
         foreach (var source in Properties.Settings.Default.Sources)
         {
            var reader = new YamlDBReader(source);
            prices.Add(reader.GetPrice());
            this.progressBar1.PerformStep();
            Thread.Sleep(Properties.Settings.Default.Delay);
         }

         return prices;
      }

      private void button_Save_Click(object sender, EventArgs e)
      {
         enableForm(false);
         var db = new YamlDBWriter(DB_FILE);
         db.SavePrice(mPrice);
         MessageBox.Show("Done!");
         enableForm(true);
      }

      private void button_Export_Click(object sender, EventArgs e)
      {
         enableForm(false);

         Price price = new Price();
         PriceValidatorDialog priceValidator = new PriceValidatorDialog(mPrice.GetFilter());
         var offers = mPrice.comparedOffers();

         foreach (var offerID in mTable.GetSelected())
         {
            if (priceValidator.ValidateOffer(offers[offerID]))
            {
               price.AddOffer(offers[offerID]);
            }
         }

         WixWritter writter = new WixWritter(price, new CsvFormatter());
         writter.write(textBox_Destination.Text + "\\wix.csv");

         mPrice.ApplyFilter();

         MessageBox.Show("Done!");
         enableForm(true);
      }

      private void button_ExportAll_Click(object sender, EventArgs e)
      {
         enableForm(false);

         Price price = new Price();
         PriceValidatorDialog priceValidator = new PriceValidatorDialog(mPrice.GetFilter());
         foreach (var offer in mPrice.comparedOffers())
         {
            if (priceValidator.ValidateOffer(offer.Value))
            {
               price.AddOffer(offer.Value);
            }
         }

         WixWritter writter = new WixWritter(price, new CsvFormatter());
         writter.write(textBox_Destination.Text + "\\wix.csv");


         mPrice.ApplyFilter();

         MessageBox.Show("Done!");
         enableForm(true);
      }
   }
}
