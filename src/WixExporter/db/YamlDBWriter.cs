using System;
using System.Xml;
using WixExporter.core;
using WixExporter.core.db;

namespace WixExporter.db
{
   class YamlDBWriter : PriceDBWriter
   {
       private XmlWriter mWriter = null;

      public YamlDBWriter(string url)
      {
         mWriter = XmlWriter.Create(url, new XmlWriterSettings { Indent = true });
      }

      public void SavePrice(Price price)
      {
        mWriter.WriteStartElement("shop");

        SaveCategories(price);
        SaveOffers(price);

        mWriter.WriteEndElement();
        mWriter.Close();
      }
      private void SaveCategories(Price price)
      {
         mWriter.WriteStartElement("categories");
         foreach (var category in price.categories())
         {
            mWriter.WriteStartElement("category");
            mWriter.WriteAttributeString("id", category.Key);
            mWriter.WriteString(category.Value.Name);
            mWriter.WriteEndElement();
         }

         mWriter.WriteEndElement();
      }

      private void SaveOffers(Price price)
      {
         mWriter.WriteStartElement("offers");
         foreach (var offer in price.offers())
         {
            mWriter.WriteStartElement("offer");
            mWriter.WriteAttributeString("id", offer.Key);
            mWriter.WriteAttributeString("instock", offer.Value.Quantity);

            var offerData = offer.Value;
            mWriter.WriteElementString("price", offerData.Price);
            mWriter.WriteElementString("categoryId", offerData.Category.Id);

            foreach (var picture in offerData.Pictures)
            {
               mWriter.WriteElementString("picture", picture);
            }

            mWriter.WriteElementString("name", offerData.Name);
            mWriter.WriteElementString("model", offerData.Model);
            mWriter.WriteElementString("vendor", offerData.Vendor);
            mWriter.WriteElementString("description", offerData.Description);

            foreach (var param in offerData.Params)
            {
               mWriter.WriteStartElement("param");
               mWriter.WriteAttributeString("name", param.Name);
               mWriter.WriteString(param.Value);
               mWriter.WriteEndElement();
            }

            mWriter.WriteEndElement(); //offer
         }
         mWriter.WriteEndElement(); //offers
      }
   }
}
