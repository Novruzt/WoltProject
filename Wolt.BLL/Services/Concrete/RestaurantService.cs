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

        public async Task<List<GetAllCategoriesDTO>> GetAllCategoriesAsync(int id)
        {
            List<Category> datas =  await _unitOfWork.RestaurantRepository.GetAllCategoriesAsync(id);
            List<GetAllCategoriesDTO> DTOs = _mapper.Map<List<GetAllCategoriesDTO>>(datas);

            int num = 0;


            if(datas.Count > 0 && datas!=null) 
               for(int  i = 0; i<datas.Count; i++)
               {
                  for(int j=0; j < datas[i].Products.Count; j++)
                  {
                    num++;
                  }

                  DTOs[i].Foods=num;
                  num = 0;
               }
                    

            return DTOs;    

        }

        public async Task<List<GetAllUserCommentsForRestaurantDTO>> GetAllCommentsAsync(int id)
        {
           List<UserComment> datas = await _unitOfWork.RestaurantRepository.GetAllCommentsAsync(id);

            List<GetAllUserCommentsForRestaurantDTO> DTOs = _mapper.Map<List<GetAllUserCommentsForRestaurantDTO>>(datas);

            return DTOs;

        }

        public async Task<List<GetAllProductsDTO>> GetAllProductsAsync(int id)
        {
            List<Product> datas = await _unitOfWork.RestaurantRepository.GetAllProductsAsync(id);
            List<GetAllProductsDTO> DTOs= _mapper.Map<List<GetAllProductsDTO>>(datas);

            return DTOs;
        }

        public async Task<GetRestaurantDTO> GetAsync(int id)
        {
            Restaurant data  = await _unitOfWork.RestaurantRepository.GetAsync(id);

            int num = 0;
            
            if(data != null)
                foreach (UserComment item in data.UserComments)
                    num++;
                


            GetRestaurantDTO dto = _mapper.Map<GetRestaurantDTO>(data);

            if(dto!= null)
            dto.Comments = num;

            return dto;

        }

        public async Task<GetProductDTO> GetProductAsync(int id)
        {
            Product data = await _unitOfWork.RestaurantRepository.GetProductAsync(id);
            List<UserReview> reviews = await _unitOfWork.RestaurantRepository.GetUserReviewsAsync(id);


            if (reviews != null)
            {

            }
            double sum = 0;
            int num = 0;

            if (data != null && reviews.Count!=0)
                foreach(UserReview item in reviews)
                {
                    sum+=item.Score;
                    num++;
                }

            double avg = 0;

            if (num > 0)
                avg+=sum/num;
            
                    
                
                

            GetProductDTO DTO = _mapper.Map<GetProductDTO>(data);

            if(DTO!=null)
            DTO.AverageScore = avg;

            return DTO;

        }
        public async Task<List<GetAllReviewsForProductDTO>> GetUserReviewsAsync(int id)
        {
            List<UserReview> datas = await _unitOfWork.RestaurantRepository.GetUserReviewsAsync(id);
            List<GetAllReviewsForProductDTO> DTOs = _mapper.Map<List<GetAllReviewsForProductDTO>>(datas);

            return DTOs;

        }
    }
}
