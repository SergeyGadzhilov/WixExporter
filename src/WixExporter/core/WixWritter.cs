using System.Text;
using System.IO;


namespace WixExporter.core
{
   class WixWritter
   {
      private Price mPrice;
      private WixFormatter mFormatter;
      public WixWritter(Price price, WixFormatter formatter)
      {
         mPrice = price;
         mFormatter = formatter;
      }

      public void write(string path)
      {
         StringBuilder data = new StringBuilder();
         data.AppendLine(mFormatter.Header());
         foreach (var offer in mPrice.offers())
         {
            data.AppendLine(mFormatter.Offer(offer.Value));
         }
         File.WriteAllText(path, data.ToString());
      }
   }
}
