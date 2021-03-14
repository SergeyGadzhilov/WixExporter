using System.Collections.Generic;
using WixExporter.core;

namespace WixExporter.formatters
{
   class CsvFormatter : WixFormatter
   {
      public string Header()
      {
          List<string> header = new List<string>(){
            "handleId",
            "fieldType",
            "name",
            "description",
            "productImageUrl",
            "collection",
            "sku",
            "ribbon",
            "price",
            "surcharge",
            "visible",
            "discountMode",
            "discountValue",
            "inventory",
            "weight",
            "productOptionName1",
            "productOptionType1",
            "productOptionDescription1",
            "productOptionName2",
            "productOptionType2",
            "productOptionDescription2",
            "productOptionName3",
            "productOptionType3",
            "productOptionDescription3",
            "productOptionName4",
            "productOptionType4",
            "productOptionDescription4",
            "productOptionName5",
            "productOptionType5",
            "productOptionDescription5",
            "productOptionName6",
            "productOptionType6",
            "productOptionDescription6",
            "additionalInfoTitle1",
            "additionalInfoDescription1",
            "additionalInfoTitle2",
            "additionalInfoDescription2",
            "additionalInfoTitle3",
            "additionalInfoDescription3",
            "additionalInfoTitle4",
            "additionalInfoDescription4",
            "additionalInfoTitle5",
            "additionalInfoDescription5",
            "additionalInfoTitle6",
            "additionalInfoDescription6",
            "customTextField1",
            "customTextCharLimit1",
            "customTextMandatory1"
         };
         return Format(header);
      }

      public string Offer(Offer offer)
      {
         var csvOffer = GetTemplate();
         csvOffer[0] = offer.Id;
         csvOffer[2] = FormatString(offer.Name);
         csvOffer[3] = FormatString(offer.Description);
         csvOffer[4] = string.Join(";", offer.Pictures);
         csvOffer[6] = offer.Id;
         csvOffer[8] = FormatString(offer.Price);
         csvOffer[13] = offer.Quantity;
         csvOffer[33] = FormatString(Properties.Settings.Default.ParamTitle);
         csvOffer[34] = FormatCharacteristics(offer);

         return Format(csvOffer);
      }

      private string FormatCharacteristics(Offer offer)
      {
         List<string> description = new List<string>();

         foreach (var param in offer.Params)
         {
            description.Add(param.ToString());
         }

         return  FormatString(string.Join("<br>", description));
      }

      private string FormatString(string data)
      {
         return "\"" + data.Replace("\"", "\"\"") + "\"";
      }

      private string Format(List<string> data)
      {
         return string.Join(",", data);
      }

      private List<string> GetTemplate()
      {
         List<string> template = new List<string>(48);
         for (int i = 0; i < 48; ++i)
         {
            template.Add("");
         }
 
         template[1] = "Product";

         return template;
      }
   }
}
