using DocumentFormat.OpenXml.Wordprocessing;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Wolt.BLL.DTOs.UserInteractDTOs
{
    public record GetProductsForBasketDTO
    {
        [JsonIgnore]
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public double Price { get; set; }
        public string? Picture { get; set; }
        public int Quantity { get; set; }
    }
}
