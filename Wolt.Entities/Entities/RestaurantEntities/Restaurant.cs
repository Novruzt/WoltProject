﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wolt.Entities.Entities.BaseEntities;
using Wolt.Entities.Entities.UserEntities;

namespace Wolt.Entities.Entities.RestaurantEntities
{
    public class Restaurant:BaseEntity
    {
        public Restaurant()
        {
            Categories= new List<Category>();
            UserComments= new List<UserComment>();
        }
        public string Name { get; set; }
        public string BaseAddress { get; set; }
        public string Phone { get; set; }
        [MaxLength(100)]
        public string Description { get; set; }
        public ICollection<Category>? Categories { get; set; }
        public ICollection<UserComment>? UserComments { get; set; }

        // catogoreis (many to many)
        // product(food) 
        //Discount
    }
}
