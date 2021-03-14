using System.Windows.Forms;
using WixExporter.core;

namespace WixExporter
{
   public partial class PriceValidatorDialog : Form
   {
      public PriceValidatorDialog()
      {
         InitializeComponent();
      }

      public void ValidateOffer(Offer offer)
      {
         ValidateOfferName(offer);
      }

      private void ValidateOfferName(Offer offer)
      {
         while (string.IsNullOrEmpty(offer.Name) || offer.Name.Length > 80)
         {
            label_Reason.Text = "Max length for name is 80 symbols!";
            textBox_ID.Text = offer.Id;
            textBox_Editor.Text = offer.Name;
            if (ShowDialog() == DialogResult.OK)
            {
               offer.Name = textBox_Editor.Text;
               label_Reason.Text = "";
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
   }
}
