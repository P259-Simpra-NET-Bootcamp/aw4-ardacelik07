using AutoMapper;
using Serilog;
using SimApi.Base;
using SimApi.Data;
using SimApi.Data.Uow;
using SimApi.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimApi.Operation.CategorydapperService
{
    public class DapperCategoryService :IDapperCategoryService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public DapperCategoryService(IUnitOfWork unitOfWork, IMapper mapper) 
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public virtual ApiResponse<List<Category>> GetAll()
        {
            try
            {
                var entityList = unitOfWork.DapperRepository<Category>().GetAll();
               
                return new ApiResponse<List<Category>>(entityList);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "GetAll Exception");
                return new ApiResponse<List<Category>>(ex.Message);
            }
        }
        public virtual ApiResponse<Category> GetById(int id)
        {
            try
            {
                var entityList = unitOfWork.DapperRepository<Category>().GetById(id);

                return new ApiResponse<Category>(entityList);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "GetAll Exception");
                return new ApiResponse<Category>(ex.Message);
            }
        }
        public virtual ApiResponse<Category> DeleteById(int id)
        {
            try
            {
                 unitOfWork.DapperRepository<Category>().DeleteById(id);

                return new ApiResponse<Category>(true);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "GetAll Exception");
                return new ApiResponse<Category>(ex.Message);
            }
        }

    }
}
