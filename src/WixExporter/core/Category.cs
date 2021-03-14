using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WixExporter
{
   public class Category
   {
      private string mId = "";
      private string mName = "";
      public string Id
      {
         get => mId;
         set => mId = value;
      }
      public string Name {
         get => mName;
         set => mName = value;
      }
   }
}
