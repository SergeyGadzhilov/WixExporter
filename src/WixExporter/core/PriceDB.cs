using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace WixExporter.core
{
   class PriceDB
   {
      private Price mPrice = new Price();
      private const string DB_FILE = "db.xml";

      public Price Price {
         get => mPrice;
         set => mPrice = value;
      }

      public void AddPrice(Price price)
      {
         foreach (var category in price.categories())
         {
            mPrice.AddCategory(category.Value);
         }

         foreach (var offer in price.offers())
         {
            mPrice.AddOffer(offer.Value);
         }
      }
      public void Save()
      {
         XmlWriter db = XmlWriter.Create(DB_FILE, new XmlWriterSettings { Indent = true });
         db.WriteStartElement("shop");
         SavePrice(db);
         db.WriteEndElement();
         db.Close();
      }

      private void SavePrice(XmlWriter writer)
      {
         SaveCategories(writer);
         SaveOffers(writer);
      }

      private void SaveCategories(XmlWriter writer)
      {
         writer.WriteStartElement("categories");
         foreach (var category in mPrice.categories())
         {
            writer.WriteStartElement("category");
            writer.WriteAttributeString("id", category.Key);
            writer.WriteString(category.Value.Name);
            writer.WriteEndElement();
         }

         writer.WriteEndElement();
      }

      private void SaveOffers(XmlWriter writer)
      {
         writer.WriteStartElement("offers");
         foreach (var offer in mPrice.offers())
         {
            writer.WriteStartElement("offer");
            writer.WriteAttributeString("id", offer.Key);

            var offerData = offer.Value;
            writer.WriteElementString("price", offerData.Price);
            writer.WriteElementString("categoryId", offerData.Category.Id);
            
            foreach (var picture in offerData.Pictures)
            {
               writer.WriteElementString("picture", picture);
            }
            
            writer.WriteElementString("name", offerData.Name);
            writer.WriteElementString("model", offerData.Model);
            writer.WriteElementString("vendor", offerData.Vendor);
            writer.WriteElementString("description", offerData.Description);
            
            foreach (var param in offerData.Params)
            {
               writer.WriteStartElement("param");
               writer.WriteAttributeString("name", param.Name);
               writer.WriteString(param.Value);
               writer.WriteEndElement();
            }

            writer.WriteEndElement(); //offer
         }
         writer.WriteEndElement(); //offers
      }
   }
}
