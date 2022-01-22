using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WixExporter.core
{
   class ComparedPrice : Price
   {
      private PriceFilter mFilter = null;
      private Price mOldPrice = new Price();

      public ComparedPrice()
      {
      }

      public ComparedPrice(Price oldPrice, List<Price> prices, PriceFilter filter)
      {
         mFilter = filter;
         mOldPrice = oldPrice;
         foreach (var price in prices)
         {
            foreach (var offer in price.offers())
            {
               AddOffer(offer.Value);
            }
         }

         ApplyFilter();
      }

      public void ApplyFilter()
      {
         if (mFilter != null)
         {
            mFilter.apply(this);
            mFilter.apply(mOldPrice);
         }
      }

      public PriceFilter GetFilter()
      {
         return mFilter;
      }

      public Dictionary<string, ComparedOffer> comparedOffers()
      {
         Dictionary<string, ComparedOffer> comparedOffers = new Dictionary<string, ComparedOffer>(offers().Count);
         Dictionary<string, Offer> oldOffers = mOldPrice.offers();

         foreach (var offer in offers())
         {
            if (oldOffers.ContainsKey(offer.Key))
            {
               if (oldOffers[offer.Key].Price != offer.Value.Price ||
                   oldOffers[offer.Key].Quantity != offer.Value.Quantity)
               {
                  var comparedOffer = new ComparedOffer(oldOffers[offer.Key], offer.Value);
                  comparedOffers.Add(offer.Key, comparedOffer);
               }
               oldOffers.Remove(offer.Key);
            }
            else
            {
               comparedOffers.Add(offer.Key, new ComparedOffer(offer.Value));
            }
         }

         if (oldOffers.Count > 0)
         {
            foreach (var offer in oldOffers)
            {
               offer.Value.IsDeleted = true;
               offer.Value.Price = "deleted";
               offer.Value.Quantity = "deleted";
               comparedOffers.Add(offer.Key, new ComparedOffer(offer.Value));
            }
         }

         return comparedOffers;
      }
   }
}
