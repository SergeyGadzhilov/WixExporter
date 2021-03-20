using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WixExporter.core
{
   public class Price
   {
      private Dictionary<string, Category> mCategories = new Dictionary<string, Category>();
      private Dictionary<string, Offer> mOffers = new Dictionary<string, Offer>();
      public Dictionary<string, Category> categories()
      {
         return mCategories;
      }
      public Dictionary<string, Offer> offers()
      {
         return mOffers;
      }
      public void AddCategory(Category category)
      {
         if (mCategories.ContainsKey(category.Id))
         {
            mCategories[category.Id] = category;
         }
         else
         {
            mCategories.Add(category.Id, category);
         }
      }
      public void AddOffer(Offer offer)
      {
         if (mOffers.ContainsKey(offer.Id))
         {
            mOffers[offer.Id] = offer;
         }
         else
         {
            mOffers.Add(offer.Id, offer);
         }
      }
   }
}
