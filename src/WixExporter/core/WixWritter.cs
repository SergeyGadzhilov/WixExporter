using System.Text;
using System.IO;
using System.Collections.Generic;

namespace WixExporter.core
{
   class WixWritter
   {
      private List<Price> mPrices = new List<Price>();
      private WixFormatter mFormatter;
      public WixWritter(List<Price> prices, WixFormatter formatter)
      {
         mPrices = prices;
         mFormatter = formatter;
      }

      public WixWritter(Price price, WixFormatter formatter)
      {
         mPrices.Add(price);
         mFormatter = formatter;
      }

      public void write(string path)
      {
         StringBuilder data = new StringBuilder();
         data.AppendLine(mFormatter.Header());

         foreach (var price in mPrices)
         {
            foreach (var offer in price.offers())
            {
               data.AppendLine(mFormatter.Offer(offer.Value));
            }
         }

         File.WriteAllText(path, data.ToString());
      }
   }
}
