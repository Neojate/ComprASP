using System.ComponentModel.DataAnnotations;

namespace ComprASP.Data
{
    public class Market
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo Nombre es requerido")]
        public string Name { get; set; }
        
        public string? UserId { get; set; }

        public User? User { get; set; } 
    }
}
