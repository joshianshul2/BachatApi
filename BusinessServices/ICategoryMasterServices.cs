using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities;

namespace BusinessServices
{
    public interface ICategoryMasterServices
    {
        CategoryMasterEntity GetCategoryById(int id);
       
        IEnumerable<CategoryMasterEntity> GetAllCategory();
        int CreateCategory(CategoryMasterEntity CategoryMasterEntity);
        bool UpdateCategory(int id, CategoryMasterEntity categoryMasterEntity);
        bool DeleteCategory(int id);
    }
}
