using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WixExporter.core
{
   public interface PriceFilter
   {
      void apply(Price price);
      void addOffer(Offer offer);
      void Save();
   }
}
