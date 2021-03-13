using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WixExporter.core
{
   class Offer
   {
      private string mId = "";
      private string mPrice = "";
      private string mCurrencyId = "";
      private Category mCategory = new Category();
      private string mName = "";
      private string mDescription = "";
      private string mModel = "";
      private string mVendor = "";
      private string mQuantity = "";
      private List<string> mPictures = new List<string>();
      private List<Param> mParams = new List<Param>();

      public Offer()
      {
      }

      public Offer(Offer offer)
      {
         Id = offer.Id;
         Price = offer.Price;
         CurrencyId = offer.CurrencyId;
         Category = offer.Category;
         Name = offer.Name;
         Description = offer.Description;
         Model = offer.Model;
         Vendor = offer.Vendor;
         Quantity = offer.Quantity;
         Pictures = offer.Pictures;
         Params = offer.Params;
      }

      public string Id { get => mId; set => mId = value; }
      public string Price { get => mPrice; set => mPrice = value; }
      public string CurrencyId { get => mCurrencyId; set => mCurrencyId = value; }
      public Category Category { get => mCategory; set => mCategory = value; }
      public string Name { get => mName; set => mName = value; }
      public string Description { get => mDescription; set => mDescription = value; }
      public string Model { get => mModel; set => mModel = value; }
      public string Vendor { get => mVendor; set => mVendor = value; }
      public string Quantity { get => mQuantity; set => mQuantity = value; }
      public List<string> Pictures { get => mPictures; set => mPictures = value; }
      internal List<Param> Params { get => mParams; set => mParams = value; }

      public void AddPicuture(string path)
      {
         mPictures.Add(path);
      }

      public void AddParam(Param param)
      {
         mParams.Add(param);
      }
   }
}
