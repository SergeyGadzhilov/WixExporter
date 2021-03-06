using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WixExporter.core
{
   class Param
   {
      private string mName = "";
      private string mValue = "";

      public string Name
      {
         get => mName;
         set => mName = value;
      }

      public string Value
      {
         get => mValue;
         set => mValue = value;
      }

      public override string ToString()
      {
         return mName + ": " + mValue;
      }
   }
}
