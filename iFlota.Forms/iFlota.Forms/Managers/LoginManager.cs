using iFlota.Forms.DataObjects;
using iFlota.Forms.Util;
using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace iFlota.Forms.Managers
{
    /// <summary>
    /// Manejador de la sesion de usuario
    /// </summary>
    /// <remarks>
    /// Permite hacer login en los servicios de Azure y guarda la información de la sesión de usuario
    /// </remarks>
    public class LoginManager : Singleton<LoginManager>
    {
 
        private bool autenticado = false;
        private MobileServiceUser mobileUser;
        private MobileServiceClient mobileClient;
        private Identidad identidad;
        private Usuario usuario;
        private IAutenticacionServicio autenticarServicio;
        /// <summary>
        /// Vehiculo escogido por el usuario
        /// </summary>
        public Vehiculo Vehiculo { get; set; }

        /// <summary>
        /// Cliente de conexion a Azure Mobile Services
        /// </summary>
        public MobileServiceClient MobileClient
        {
            get { return mobileClient; }
        }
        /// <summary>
        /// Usuario registrado ante el servicio de autenticación de azure 
        /// </summary>
        public MobileServiceUser MobileUser
        {
            get { return mobileUser; }
        }
        /// <summary>
        /// Indica si el usuario ya esta atenticado o no
        /// </summary>
        public bool Autenticado
        {
            get { return autenticado; }
        }

        public Usuario Usuario
        {
            get { return usuario; }
        }
        public LoginManager()
        {
            mobileClient = new MobileServiceClient(Constants.ApplicationURL);
            //Trae la referencia a la implementacion del login de azure de acuerdo al sistema operativo
            autenticarServicio = DependencyService.Get<IAutenticacionServicio>();
        }
        /// <summary>
        /// Registra el usuario de acuerdo al servicio escogido
        /// </summary>
        /// <param name="servicio">Servicio de autenticación contra el que se validaran las credenciales</param>
        /// <returns>Retorna verdadero si se logró hacer una atenticación exitosa</returns>
        public async Task<bool> Autenticar(MobileServiceAuthenticationProvider servicio)
        {
            var satisfactorio = false;
            try
            {
                mobileUser = await autenticarServicio.Login(servicio);
                mobileClient.CurrentUser = mobileUser;

                using (var clienteHTTP = new HttpClient())
                {
                    var url = Constants.ApplicationURL + "/.auth/me";

                    clienteHTTP.DefaultRequestHeaders.Add("X-ZUMO-AUTH", mobileUser.MobileServiceAuthenticationToken);

                    var response = await clienteHTTP.GetStringAsync(url);
                    response = response.Remove(0, 1);
                    response = response.Remove(response.Length - 1);

                    identidad = JsonConvert.DeserializeObject<Identidad>(response);

                    try
                    {
                        //trae la información del usuario en la base de datos
                        usuario = await UsuarioManager.Instancia.BuscarUsuario(identidad.UserId, identidad.ProviderName);
                        autenticado = true;
                    }
                    catch (Exception)
                    {
                        usuario = null;
                    }
                }

                //Si llegó hasta acá es que fue satisfactoria la llamada de los datos
                satisfactorio = true;
            }
            catch (Exception ex)
            {

                throw;
            }

            return satisfactorio;
        }
    }
}
