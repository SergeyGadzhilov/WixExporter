using System;
using System.Collections.Generic;
using WixExporter.core;
using WixExporter.core.db;
using System.Xml;
using System.Windows.Forms;

namespace WixExporter.db
{
   class YamlDBReader : PriceDBReader
   {
      private Price mPrice = new Price();
      public YamlDBReader(string url)
      {
         if (!String.IsNullOrWhiteSpace(url))
         {
            try
            {
               XmlDocument Xml = new XmlDocument();
               Xml.Load(url);
               ReadCategories(Xml);
               ReadOffers(Xml);
            }
            catch (System.Exception ex)
            {
               MessageBox.Show("Cannot read url: " + url + ". Error message: " + ex.Message);
            }
         }
      }
      public Price GetPrice()
      {
         return mPrice;
      }

      private void ReadCategories(XmlDocument xml)
      {
         XmlNodeList xmlNodeList = xml.GetElementsByTagName("category");

         foreach (XmlNode xmlNode in xmlNodeList)
         {
            Category category = new Category();
            category.Id = xmlNode.Attributes["id"].Value;
            category.Name = xmlNode.InnerText;

            mPrice.AddCategory(category);
         }
      }

      private void ReadOffers(XmlDocument xml)
      {
         XmlNodeList xmlNodeList = xml.GetElementsByTagName("offer");

         foreach (XmlNode xmlNode in xmlNodeList)
         {
            Offer offer = new Offer();
            offer.Id = GetValue(xmlNode.Attributes["id"]);
            offer.Price = GetValue(xmlNode.SelectSingleNode("price"));
            offer.CurrencyId = GetValue(xmlNode.SelectSingleNode("currencyId"));
            offer.Category = GetCategory(xmlNode);
            offer.Name = GetValue(xmlNode.SelectSingleNode("name"));
            offer.Model = GetValue(xmlNode.SelectSingleNode("model"));
            offer.Quantity = GetValue(xmlNode.Attributes["instock"]);
            offer.Vendor = GetValue(xmlNode.SelectSingleNode("vendor"));
            offer.Description = GetValue(xmlNode.SelectSingleNode("description"));

            foreach (XmlNode picture in xmlNode.SelectNodes("picture"))
            {
               offer.AddPicuture(picture.InnerText);
            }

            foreach (XmlNode param in xmlNode.SelectNodes("param"))
            {
               Param item = new Param();
               item.Name = param.Attributes["name"].Value;
               item.Value = param.InnerText;
               offer.AddParam(item);
            }

            mPrice.AddOffer(offer);
         }
      }
      private Category GetCategory(XmlNode node)
      {
         Category category = new Category();
         Dictionary<string, Category> categories = mPrice.categories();
         string key = GetValue(node.SelectSingleNode("categoryId"));
         if (!String.IsNullOrEmpty(key) && categories.ContainsKey(key))
         {
            category = categories[key];
         }

         return category;
      }

      private string GetValue(XmlAttribute attribute)
      {
         string data = "";

         if (attribute != null)
         {
            data = attribute.Value;
         }

         return data;
      }

      private string GetValue(XmlNode node)
      {
         string data = "";

         if (node != null)
         {
            data = node.InnerText;
         }

         return data;
      }
   }
}
