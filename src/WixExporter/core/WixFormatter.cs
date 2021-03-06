namespace WixExporter.core
{
   interface WixFormatter
   {
      string Header();
      string Offer(Offer offer);
   }
}
