using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wolt.BLL.DTOs.Others;
using Wolt.Entities.Entities.UserEntities;

namespace Wolt.BLL.AutoMappers
{
    public class ThingsMapper:Profile
    {
        public ThingsMapper()
        {

            CreateMap<UserComment, UserCommentDTO>();
        }
    }
}
