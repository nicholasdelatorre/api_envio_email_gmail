﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AspCore_Email.Models
{
    public class EmailModel
    {
        [Required, Display(Name = "Email de destino"), EmailAddress]
        public string Destino { get; set; }
        [Required, Display(Name = "Assunto")]
        public string Assunto { get; set; }
        [Required, Display(Name = "Mensagem")]
        public string Mensagem { get; set; }
    }
}
