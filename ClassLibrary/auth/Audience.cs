﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.auth
{
    public class Audience
    {
        public string Secret { get; set; }
        public string Issuer { get; set; }
        public string Aud { get; set; }
    }
}
