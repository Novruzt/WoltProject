using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wolt.BLL.DTOs.Others;
using Wolt.BLL.Services.Abstract;
using Wolt.Entities.Entities.UserEntities;
using WOLT.DAL.Repository.Concrete;
using WOLT.DAL.UnitOfWork.Abstract;

namespace Wolt.BLL.Services.Concrete
{
    public class ThingsService : IThingsService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
       

        public ThingsService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            
        }
        public async Task<UserCommentDTO> GetUserCommentAsync(int userId, int restId)
        {

            UserComment comment = await _unitOfWork.ThingsRepository.GetUserCommentAsync(userId, restId);


            if (comment != null)
            {
                UserCommentDTO dto = _mapper.Map<UserCommentDTO>(comment);
                return dto;
            }

            return null;
        }
    }
}
