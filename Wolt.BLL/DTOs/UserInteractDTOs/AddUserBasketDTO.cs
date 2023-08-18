using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wolt.Entities.Entities.RestaurantEntities;
using Wolt.Entities.Entities.UserEntities;
using Wolt.Entities.Entities.WoltEntities;

namespace Wolt.BLL.DTOs.UserInteractDTOs
{
    public record AddUserBasketDTO
    {
        [SwaggerSchema(ReadOnly = true)]
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public int? PromoCodeId { get; set; }
    }
}
