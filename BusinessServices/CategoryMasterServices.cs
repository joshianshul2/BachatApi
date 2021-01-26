using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities;
using DataModel.UnitOfWork;
using DataModel;
using System.Transactions;
using AutoMapper;


namespace BusinessServices
{
    public class CategoryMasterServices :ICategoryMasterServices
    {
        private readonly UnitOfWork _unitOfWork;
        public CategoryMasterServices()
        {
            _unitOfWork = new UnitOfWork();
        }

        public BusinessEntities.CategoryMasterEntity GetCategoryById(int id)
        {
            BusinessEntities.CategoryMasterEntity objCategoryMaster = new BusinessEntities.CategoryMasterEntity();
            if (id == 0)
                return objCategoryMaster;

            var city = _unitOfWork.CategoryMasterRepository.GetByID(id);
            if (city != null)
            {
                Mapper.CreateMap<CategoryMaster, CategoryMasterEntity>();
                var categoryModel = Mapper.Map<CategoryMaster, CategoryMasterEntity>(city);
                return categoryModel;
            }
            return null;
        }

       



        public IEnumerable<BusinessEntities.CategoryMasterEntity> GetAllCategory()
        {
            var city = _unitOfWork.CategoryMasterRepository.GetAll().ToList();
            if (city.Any())
            {
                Mapper.CreateMap<CategoryMaster, CategoryMasterEntity>();
                var cityModel = Mapper.Map<List<CategoryMaster>, List<CategoryMasterEntity>>(city);
                return cityModel;
            }
            return null;
        }
        public int CreateCategory(BusinessEntities.CategoryMasterEntity CategoryMasterEntity)
        {
            using (var scope = new TransactionScope())
            {
                var city = new CategoryMaster
                {
                    CategoryName = CategoryMasterEntity.CategoryName,
                    IsActive = Convert.ToBoolean(   CategoryMasterEntity.IsActive),
                    CreateDate = Convert.ToDateTime(CategoryMasterEntity.CreateDate )
             
                };
                _unitOfWork.CategoryMasterRepository.Insert(city);
                _unitOfWork.Save();
                scope.Complete();
                return city.PK_CategoryId ;
            }
        }
        public bool UpdateCategory(int id, BusinessEntities.CategoryMasterEntity CategoryMasterEntity)
        {
            var success = false;
            if (CategoryMasterEntity != null)
            {
                using (var scope = new TransactionScope())
                {
                    var city = _unitOfWork.CategoryMasterRepository.GetByID(id);
                    if (city != null)
                    {
                        city.CategoryName = CategoryMasterEntity.CategoryName;
                        city.IsActive = Convert.ToBoolean(CategoryMasterEntity.IsActive);
                        city.CreateDate = Convert.ToDateTime(CategoryMasterEntity.CreateDate);

                        _unitOfWork.CategoryMasterRepository.Update(city);
                        _unitOfWork.Save();
                        scope.Complete();
                        success = true;
                    }
                }
            }
            return success; 
        }
        public bool DeleteCategory(int id)
        {
            var success = false;
            if (id > 0)
            {
                using (var scope = new TransactionScope())
                {
                    var city = _unitOfWork.CategoryMasterRepository.GetByID(id);
                    if (city != null)
                    {
                        _unitOfWork.CategoryMasterRepository.Delete(city);
                        _unitOfWork.Save();
                        scope.Complete();
                        success = true;
                    }
                }
            }
            return success;
        }
    }
}