using System.ComponentModel.DataAnnotations;

namespace CRUDPLANILLA.Models
{
    public class Planilla
    {
        [Key]
        public int Id_Registro { get; set; }
        public int Id_Usuario { get; set; }
        public decimal IGSS { get; set; }
        public decimal IRTRA { get; set; }
        public decimal SalarioTotal { get; set; }
        public decimal SalarioLiquido { get; set; }
    }
}
