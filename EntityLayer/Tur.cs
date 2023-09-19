using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class Tur
    {
        public int Id { get; set; }
        [DisplayName("Türler")]
        public string Turler { get; set; }
    }
}
