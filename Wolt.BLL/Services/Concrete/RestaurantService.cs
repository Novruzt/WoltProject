using AutoMapper;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wolt.BLL.DTOs.RestaurantDTOs;
using Wolt.BLL.Services.Abstract;
using Wolt.Entities.Entities.RestaurantEntities;
using Wolt.Entities.Entities.UserEntities;
using WOLT.DAL.Repository.Abstract;
using WOLT.DAL.UnitOfWork.Abstract;

namespace Wolt.BLL.Services.Concrete
{
    public class RestaurantService : IRestaurantService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public RestaurantService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<List<GetAllRestaurantsDTO>> GetAllAsync()
        {
            List<Restaurant> datas = await _unitOfWork.RestaurantRepository.GetAllAsync();
            List<GetAllRestaurantsDTO> DTOs = _mapper.Map<List<GetAllRestaurantsDTO>>(datas);

            return DTOs;
        }

        public Task<List<Category>> GetAllCategoriesAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<UserComment>> GetAllCommentsAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Product>> GetAllProductsAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<GetRestaurantDTO> GetAsync(int id)
        {
            Restaurant data  = await _unitOfWork.RestaurantRepository.GetAsync(id);
            GetRestaurantDTO dto = _mapper.Map<GetRestaurantDTO>(data);

            return dto;

        }

        public Task<Category> GetCategoryAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetProductAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<UserReview>> GetUserReviewsAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
