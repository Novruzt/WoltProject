using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Wolt.Entities.Entities.RestaurantEntities;

namespace Wolt.BLL.DTOs.UserProfileDTOs
{
    public record GetOrderProductsDTO
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
