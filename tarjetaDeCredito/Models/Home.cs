using System;
using Microsoft.VisualBasic.CompilerServices;

namespace tarjetaDeCredito.Models
{
    public class Home
    {
        public String no { get; set; }
        public Boolean isValid { get; set; }
        public String brand { get; set; }
        public String year { get; set; }
        public String month { get; set; }
        public Boolean isExpired { get; set; }
    }
}