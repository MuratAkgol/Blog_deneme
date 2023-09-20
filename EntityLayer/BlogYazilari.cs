using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class BlogYazilari
    {
        [DisplayName("ID")]
        public int Id { get; set; }
        [DisplayName("Başlık")]
        public string Baslik { get; set; }
        [DisplayName("İçerik")]
        public string Icerik { get; set; }
        [DisplayName("Tür")]
        public string TurId { get; set; }
        public byte[]? Resim { get; set; }
    }
}
