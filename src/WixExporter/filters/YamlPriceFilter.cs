using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WixExporter.core;
using WixExporter.db;

namespace WixExporter.filters
{
   class YamlPriceFilter : PriceFilter
   {
      private string mUrl = "";
      private Price mFilterPrice = new Price();
      public YamlPriceFilter(string url)
      {
         mUrl = url;
         var reader = new YamlDBReader(url);
         mFilterPrice = reader.GetPrice();
      }

      public void addOffer(Offer offer)
      {
         mFilterPrice.AddOffer(offer);
      }

      public void apply(Price price)
      {
         var offersFilter = mFilterPrice.offers();
         foreach (var offer in price.offers())
         {
            if (offersFilter.ContainsKey(offer.Key))
            {
               offer.Value.Name = GetValue(offer.Value.Name, offersFilter[offer.Key].Name);
               offer.Value.Description = GetValue(offer.Value.Description, offersFilter[offer.Key].Description);
            }
         }
      }

      public void Save()
      {
         var writer = new YamlPriceFilterWritter(mUrl);
         writer.SavePrice(mFilterPrice);
      }

      private string GetValue(string offer, string filter)
      {
         return (String.IsNullOrWhiteSpace(filter) ? offer : filter);
      }
   }
}
