using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RegistroUsuario.Entidades
{
    public class Usuarios
    {
        [Key]
        public int UsuarioId {get; set; }
        public string Nombre { get; set; }
        public string Clave { get; set; }
    }
}
