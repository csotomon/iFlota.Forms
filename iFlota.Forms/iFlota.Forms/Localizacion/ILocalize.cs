using System.Globalization;


namespace iFlota.Forms.Localizacion
{
    public interface ILocalize
    {
        CultureInfo GetCurrentCultureInfo();
        void SetLocale(CultureInfo ci);
    }
}
