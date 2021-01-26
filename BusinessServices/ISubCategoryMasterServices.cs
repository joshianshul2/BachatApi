using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities;

namespace BusinessServices
{
    public interface ISubCategoryMasterServices
    {
        SubCategoryMasterEntity GetSubCategoryById(int id);

        IEnumerable<SubCategoryMasterEntity> GetAllSubCategory();
        int CreateSubCategory(SubCategoryMasterEntity SubCategoryMasterEntity);
        bool UpdateSubCategory(int id, SubCategoryMasterEntity subcategoryMasterEntity);
        bool DeleteSubCategory(int id);
    }
}
