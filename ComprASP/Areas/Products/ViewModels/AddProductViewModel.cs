using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace ComprASP.Areas.Products.ViewModels
{
    public class AddProductViewModel
    {
        [Required(ErrorMessage = "El campo Nombre es obligatorio")]
        public string ProductName { get; set; }
        public int? ProductId { get; set; }

        public int Quantity { get; set; } = 1;

        [Required(ErrorMessage = "El campo Mercado es obligatorio")]
        public int MarketId { get; set; }

        public SelectList? Markets { get; set; }

    }
}
