﻿using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iFlota.Forms.Util
{
    public interface IAutenticar
    {
        Task<bool> Autenticar(MobileServiceAuthenticationProvider servicio);
    }
}
