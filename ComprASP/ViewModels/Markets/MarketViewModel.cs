using System.ComponentModel.DataAnnotations;

namespace ComprASP.ViewModels.Markets
{
    public class MarketViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo Nombre es requerido")]
        public string Name { get; set; }
        
        public string? UserId { get; set; }

    }
}
