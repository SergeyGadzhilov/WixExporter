using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WixExporter.core.db
{
   interface PriceDBReader
   {
      Price GetPrice();
   }
}
