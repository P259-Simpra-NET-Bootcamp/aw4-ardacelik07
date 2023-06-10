using SimApi.Base;
using SimApi.Data;
using SimApi.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimApi.Operation.CategorydapperService
{
    public interface IDapperCategoryService 
    {
        ApiResponse<List<Category>> GetAll();
        ApiResponse<Category> GetById(int id);

        ApiResponse<Category> DeleteById(int id);
    }
}
