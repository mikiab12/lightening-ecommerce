using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lightening.Ecommerce.Application.DTOs
{
    public class ProductModelSummaryDto
    {
        public int ProductModelId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? ProductThumbnailId { get; set; }
        public decimal? ProductListPrice { get; set; }
    }
}
