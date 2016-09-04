using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iFlota.Forms.Servicios
{
    class AutenticacionServicio : IAutenticacionServicio
    {
        public bool EstaAutenticado
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public Task<bool> AutenticarAsync()
        {
            throw new NotImplementedException();
        }

        public Task<string> GetTokenAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> SalirAsync()
        {
            throw new NotImplementedException();
        }
    }
}
