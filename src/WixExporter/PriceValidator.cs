using System.Windows.Forms;
using WixExporter.core;
using System;
using System.Drawing;

namespace WixExporter
{
   public partial class PriceValidatorDialog : Form
   {
      private PriceFilter mFilter = null;
      public PriceValidatorDialog(PriceFilter filter)
      {
         InitializeComponent();
         mFilter = filter;
      }

      public void ValidatePrice(Price price)
      {
         foreach (var offer in price.offers())
         {
            ValidateOffer(offer.Value);
         }
      }

      public bool ValidateOffer(Offer offer)
      {
         if (!offer.IsDeleted)
         {
            ValidateOfferName(offer);
         }
         return offer.IsDeleted;
      }

      private void ValidateOfferName(Offer offer)
      {
         while (string.IsNullOrEmpty(offer.Name) || offer.Name.Length > 80)
         {
            label_Reason.Text = "Max length for name is 80 symbols! \n Lenght: " + offer.Name.Length.ToString();
            textBox_ID.Text = offer.Id;
            textBox_Editor.Text = offer.Name;
            if (ShowDialog() == DialogResult.OK)
            {
               offer.Name = textBox_Editor.Text;
               label_Reason.Text = "";
               if (mFilter != null)
               {
                  mFilter.addOffer(offer);
                  mFilter.Save();
               }
            }
            else
            {
               break;
            }
         }
      }

      private void button_OK_Click(object sender, System.EventArgs e)
      {
         DialogResult = DialogResult.OK;
         Close();
      }

      private void textBox_Editor_KeyDown(object sender, KeyEventArgs e)
      {
         if (e.KeyCode == Keys.Enter)
         {
            if (e.Modifiers != Keys.Shift)
            {
               button_OK_Click(sender, e);
            }
         }
      }

      private void PriceValidatorDialog_KeyDown(object sender, KeyEventArgs e)
      {
         if (e.KeyCode == Keys.Enter)
         {
            button_OK_Click(sender, e);
         }
      }

      private void button_Cut_Click(object sender, EventArgs e)
      {
         if (textBox_Editor.Text.Length > 80)
         {
            textBox_Editor.Text = textBox_Editor.Text.Substring(0, 80);
         }
         button_OK.Focus();
      }

      private void textBox_Editor_TextChanged(object sender, EventArgs e)
      {
         if (textBox_Editor.Text.Length > 80)
         {
            label_Reason.ForeColor = Color.FromName("Red");
            label_Reason.Text = "Max length for name is 80 symbols!\nLenght: " + textBox_Editor.Text.Length.ToString();
         }
         else
         {
            label_Reason.Text = "\nLenght: " + textBox_Editor.Text.Length.ToString();
            label_Reason.ForeColor = Color.FromName("Balck");
         }
      }
   }
}
