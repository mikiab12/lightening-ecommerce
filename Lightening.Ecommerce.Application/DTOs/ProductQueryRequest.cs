using Lightening.Ecommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lightening.Ecommerce.Application.DTOs
{
    public class ProductQueryRequest
    {
        public int? PageSize { get; set; } = 30;
        public int? Page { get; set; } = 1;
        public int? CategoryId { get; set; }
        public int? SubCategoryId { get; set; }
    }
}
