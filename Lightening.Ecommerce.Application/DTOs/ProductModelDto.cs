using Lightening.Ecommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lightening.Ecommerce.Application.DTOs
{
    public class ProductModelDto
    {
        public int ProductModelId { get; set; }
        public string Name { get; set; } = null!;
        public ICollection<ProductModelProductDescriptionCultureDto> ProductModelProductDescriptionCultures { get; set; }
        public ICollection<ProductDetailsDto> Products { get; set; }
    }
}
