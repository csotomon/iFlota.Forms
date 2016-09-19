using System.Globalization;


namespace iFlota.Forms.Localizacion
{
    /// <summary>
    /// Interfaz para el manejo de la localización multiplataforma
    /// </summary>
    public interface ILocalize
    {
        /// <summary>
        /// Obtiene la cultura configurada en el dispositivo
        /// </summary>
        /// <returns>Configuracion actual</returns>
        CultureInfo GetCurrentCultureInfo();
        /// <summary>
        /// Setea la cultura deseada en la aplicación
        /// </summary>
        /// <param name="ci">Cultura deseada</param>
        void SetLocale(CultureInfo ci);
    }
}
