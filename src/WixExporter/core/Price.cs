using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WixExporter.core
{
   interface Price
   {
      Dictionary<string, Category> categories();
      Dictionary<string, Offer> offers();
   }
}
