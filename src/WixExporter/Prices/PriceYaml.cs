using System;
using System.Collections.Generic;
using WixExporter.core;
using System.Xml;

namespace WixExporter.Prices.Yaml
{
   class PriceYaml : Price
   {
      private XmlDocument mXml = new XmlDocument();

      public PriceYaml(string path)
      {
         if (!String.IsNullOrWhiteSpace(path))
         {
            mXml.Load(path);
         }
      }

      public Dictionary<string, Category> categories()
      {
         Dictionary<string, Category> categories = new Dictionary<string, Category>();
         XmlNodeList xmlNodeList = mXml.GetElementsByTagName("category");

         foreach (XmlNode xmlNode in xmlNodeList)
         {
            Category category = new Category();
            category.Id = xmlNode.Attributes["id"].Value;
            category.Name = xmlNode.InnerText;

            categories.Add(category.Id, category);
         }

         return categories;
      }

      public Dictionary<string, Offer> offers()
      {
         Dictionary<string, Offer> offers = new Dictionary<string, Offer>();
         XmlNodeList xmlNodeList = mXml.GetElementsByTagName("offer");

         foreach (XmlNode xmlNode in xmlNodeList)
         {
            Offer offer = new Offer();
            offer.Id = xmlNode.Attributes["id"].Value;
            offer.IsAvailable = (xmlNode.Attributes["available"].InnerText != "false");
            offer.Price = GetValue(xmlNode.SelectSingleNode("price"));
            offer.CurrencyId = GetValue(xmlNode.SelectSingleNode("currencyId"));
            offer.Category = GetCategory(xmlNode);
            offer.Name = GetValue(xmlNode.SelectSingleNode("name"));
            offer.Model = GetValue(xmlNode.SelectSingleNode("model"));
            offer.Quantity = GetValue(xmlNode.SelectSingleNode("stock_quantity"));
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

            offers.Add(offer.Id, offer);
         }

         return offers;
      }

      private Category GetCategory(XmlNode node)
      {
         Category category = new Category();
         Dictionary<string, Category> categories = this.categories();
         string key = GetValue(node.SelectSingleNode("categoryId"));
         if (categories.ContainsKey(key))
         {
            category = categories[key];
         }

         return category;
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
