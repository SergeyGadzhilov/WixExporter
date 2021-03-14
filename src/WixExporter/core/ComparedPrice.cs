using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WixExporter.core
{
   class ComparedPrice : Price
   {
      private Price mOldPrice = new Price();

      public ComparedPrice(Price oldPrice, List<Price> prices, PriceFilter filter)
      {
         mOldPrice = oldPrice;
         foreach (var price in prices)
         {
            foreach (var offer in price.offers())
            {
               AddOffer(offer.Value);
            }
         }

         if (filter != null)
         {
            filter.apply(this);
            filter.apply(mOldPrice);
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
               if (oldOffers[offer.Key].Price != offer.Value.Price)
               {
                  var comparedOffer = new ComparedOffer(oldOffers[offer.Key], offer.Value);
                  comparedOffers.Add(offer.Key, comparedOffer);
               }
            }
            else
            {
               comparedOffers.Add(offer.Key, new ComparedOffer(offer.Value));
            }
         }

         return comparedOffers;
      }
   }
}
