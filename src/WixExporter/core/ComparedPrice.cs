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

      private void addDeletedOffers(Dictionary<string, Offer> deletedOffers, Dictionary<string, ComparedOffer> destination)
      {
         if (deletedOffers.Count > 0)
         {
            foreach (var offer in deletedOffers)
            {
               if (destination.ContainsKey(offer.Key))
               {
                  destination[offer.Key].IsDeleted = true;
               }
               else
               {
                  offer.Value.IsDeleted = true;
                  destination.Add(offer.Key, new ComparedOffer(offer.Value));
               }
            }
         }
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
                   oldOffers[offer.Key].Quantity != offer.Value.Quantity ||
                   oldOffers[offer.Key].IsAvailable != offer.Value.IsAvailable)
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

         addDeletedOffers(oldOffers, comparedOffers);

         return comparedOffers;
      }
   }
}
