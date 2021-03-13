using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WixExporter.core
{
   class ComparedOffer : Offer
   {
      private Offer mOldOffer = new Offer();

      public ComparedOffer(Offer newOffer) : base(newOffer)
      {
      }

      public ComparedOffer(Offer oldOffer, Offer newOffer) : base(newOffer)
      {
         OldOffer = oldOffer;
      }

      internal Offer OldOffer
      {
         get => mOldOffer;
         set => mOldOffer = value;
      }

      public string oldId { get => OldOffer.Id; set => OldOffer.Id = value; }
      public string oldPrice { get => OldOffer.Price; set => OldOffer.Price = value; }
      public string oldCurrencyId { get => OldOffer.CurrencyId; set => OldOffer.CurrencyId = value; }
      public Category oldCategory { get => OldOffer.Category; set => OldOffer.Category = value; }
      public string oldName { get => OldOffer.Name; set => OldOffer.Name = value; }
      public string oldDescription { get => OldOffer.Description; set => OldOffer.Description = value; }
      public string oldModel { get => OldOffer.Model; set => OldOffer.Model = value; }
      public string oldVendor { get => OldOffer.Vendor; set => OldOffer.Vendor = value; }
      public string oldQuantity { get => OldOffer.Quantity; set => OldOffer.Quantity = value; }
      public List<string> oldPictures { get => OldOffer.Pictures; set => OldOffer.Pictures = value; }
      internal List<Param> oldParams { get => OldOffer.Params; set => OldOffer.Params = value; }
   }
}
