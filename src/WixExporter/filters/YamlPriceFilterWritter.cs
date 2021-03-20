using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WixExporter.core;
using WixExporter.db;

namespace WixExporter.filters
{
   class YamlPriceFilterWritter : YamlDBWriter
   {
      public YamlPriceFilterWritter(string url) : base(url)
      {
      }
      override protected void SaveCategories(Price price)
      {
      }

      override protected void SaveOffers(Price price)
      {
         var writer = GetWriter();
         writer.WriteStartElement("offers");

         foreach (var offer in price.offers())
         {
            var offerData = offer.Value;
            writer.WriteStartElement("offer");
            writer.WriteAttributeString("id", offer.Key);
            writer.WriteAttributeString("instock", offer.Value.Quantity);
            writer.WriteElementString("name", offerData.Name);
            writer.WriteElementString("description", offerData.Description);
            writer.WriteEndElement(); //offer
         }

         writer.WriteEndElement(); //offers
      }
   }
}
