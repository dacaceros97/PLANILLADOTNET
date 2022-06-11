using System.ComponentModel.DataAnnotations;

namespace CRUDPLANILLA.Models
{
    public class Usuario
    {
        [Key]
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string UsuarioLogin { get; set; }
        public string PasswordLogin { get; set; }
        public string NoDPI { get; set; }
        public decimal SalarioBase { get; set; }
        public decimal BonoDecreto { get; set; }
        [Display(Name = "Fecha de la queja")]
        [Required(ErrorMessage = "El {0} es obligatorio.")]
        public DateTime? FechaNacimiento { get; set; }
        public List<HijoEmpleados> hijosEmpleado { get; set; }
    }

    public class HijoEmpleados
    {
        [Key]
        public int Id_Registro { get; set; }
        public int CantHijos { get; set; }
    }
}
