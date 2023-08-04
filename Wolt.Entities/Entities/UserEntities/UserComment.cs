using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wolt.Entities.Entities.BaseEntities;
using Wolt.Entities.Entities.RestaurantEntities;

namespace Wolt.Entities.Entities.UserEntities
{
    public class UserComment:BaseEntity
    {
        public int UserId { get; set; }
        public User User { get; set; }
        [MaxLength(100)]
        public string? Details { get; set; }
        public DateTime CommentDate { get; set; }
        public int RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; }
        // Restaurant and Id
    }
}
