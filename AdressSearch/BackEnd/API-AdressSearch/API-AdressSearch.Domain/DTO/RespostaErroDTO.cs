﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_AdressSearch.Domain.DTO
{
    public class RespostaErroDTO
    {
        public int Status { get; set; }
        public string? Error { get; set; }
    }
}
