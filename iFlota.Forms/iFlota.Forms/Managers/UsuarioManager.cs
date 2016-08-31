using iFlota.Forms.DataObjects;
using iFlota.Forms.Util;
using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iFlota.Forms.Managers
{
    public class UsuarioManager:Singleton<UsuarioManager>
    {
        private IMobileServiceTable<Usuario> tabla;

        public UsuarioManager()
        {
            //Inicializacion del cliente de azure

            tabla = LoginManager.Instancia.MobileClient.GetTable<Usuario>();
        }

        public async Task<Usuario> InsertUsuario(Usuario usuario)
        {
            try
            {
                await tabla.InsertAsync(usuario);
                return usuario;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Usuario> GetUsuarioAsync(string id)
        {
            try
            {
                Usuario usuario = await tabla.LookupAsync(id);
                return usuario;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ObservableCollection<Usuario>> GetObjetosAsync(bool syncItems = false)
        {
            try
            {
                IEnumerable<Usuario> objetos = await tabla.ToEnumerableAsync();

                return new ObservableCollection<Usuario>(objetos);
            }
            catch (MobileServiceInvalidOperationException msioe)
            {
                Debug.WriteLine(@"Invalid sync operation: {0}", msioe.Message);
            }
            catch (Exception e)
            {
                Debug.WriteLine(@"Sync error: {0}", e.Message);
            }
            return null;
        }

        public async Task<Usuario> BuscarUsuario(string email, string conector)
        {
            try
            {
                //List<Usuario> datos = await tabla.Where(a => a.Email == email && a.Conector == conector).ToListAsync();
                var datos = await tabla.ReadAsync<Usuario>("$filter=Email eq '" + email + "' and Conector eq '" + conector + "'&$expand=Vehiculos");
                var enumerador = datos.GetEnumerator();
                if (enumerador.MoveNext())
                {
                    return enumerador.Current;
                }
                else
                    return null;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
    
}
