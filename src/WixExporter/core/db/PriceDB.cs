using System.Xml;

namespace WixExporter.core.db
{
   class PriceDB
   {
      private PriceDBWriter mWriter = null;
      private Price mPrice = null;

      public PriceDB(PriceDBReader reader, PriceDBWriter writer)
      {
         mWriter = writer;
         mPrice = reader.GetPrice();
      }

      public Price GetPrice()
      {
         return mPrice;
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
         if (mWriter != null)
         {
            mWriter.SavePrice(mPrice);
         }
      }
   }
}
