using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WixExporter.core;


namespace WixExporter
{
   class ComparedPiceGridView
   {
      public ComparedPiceGridView(DataGridView view, ComparedPrice price)
      {
         view.Rows.Clear();
         foreach (var offer in price.comparedOffers())
         {
            object[] data = {
               offer.Key, 
               offer.Value.oldPrice, 
               offer.Value.Price
            };
            view.Rows.Add(data);
         }
      }
   }
}
