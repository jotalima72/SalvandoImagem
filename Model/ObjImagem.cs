using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace testeBanco.Model
{
    class ObjImagem
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        [Column(TypeName = "BLOB")]
        public byte[] Imagem { get; set; }
    }
}
