using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Wolt.Entities.Enums;

namespace Wolt.BLL.DTOs.UserInteractDTOs
{
    public record OrderBasketDTO
    {
        [SwaggerSchema(ReadOnly = true)]
        public double TotalPrice { get; set; }
        public string? CardNumber { get; set; }
        public string? CVV { get; set; }
        public string? ExpireDate { get; set; }
        public PaymentType PaymentType { get; set; }
        public int? UserAddressId { get; set; }
        public OrderNewAddressDTO? OrderNewAddress { get; set; }
        public int? PromoCodeId { get; set; }
        [SwaggerSchema(ReadOnly = true)]
        public double OrderTotalPrice { get; set; }
    }
}
