﻿using System;
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
      private DataGridView mView = null;
      public ComparedPiceGridView(DataGridView view)
      {
         mView = view;
      }

      public void SetData(ComparedPrice price)
      {
         mView.Rows.Clear();
         foreach (var offer in price.comparedOffers())
         {
            object[] data = {
               offer.Key,
               offer.Value.oldPrice,
               offer.Value.Price
            };

            mView.Rows.Add(data);
         }
      }

      public List<string> GetSelected()
      {
         List<string> selection = new List<string>();
         
         foreach (DataGridViewRow row in mView.SelectedRows)
         {
            selection.Add(row.Cells["ID"].Value.ToString());
         }

         return selection;
      }
   }
}
