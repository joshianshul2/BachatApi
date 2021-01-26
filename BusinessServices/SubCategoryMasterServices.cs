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
    public class SubCategoryMasterServices :ISubCategoryMasterServices
    {
        private readonly UnitOfWork _unitOfWork;
        public SubCategoryMasterServices()
        {
            _unitOfWork = new UnitOfWork();
        }

        public BusinessEntities.SubCategoryMasterEntity GetSubCategoryById(int id)
        {
            BusinessEntities.SubCategoryMasterEntity objSubCategoryMaster = new BusinessEntities.SubCategoryMasterEntity();
            if (id == 0)
                return objSubCategoryMaster;

            var city = _unitOfWork.SubCategoryMasterRepository.GetByID(id);
            if (city != null)
            {
                Mapper.CreateMap<SubCategoryMaster, SubCategoryMasterEntity>();
                var subcategoryModel = Mapper.Map<SubCategoryMaster, SubCategoryMasterEntity>(city);
                return subcategoryModel;
            }
            return null;
        }

       



        public IEnumerable<BusinessEntities.SubCategoryMasterEntity> GetAllSubCategory()
        {
            var city = _unitOfWork.SubCategoryMasterRepository.GetAll().ToList();
            if (city.Any())
            {
                Mapper.CreateMap<SubCategoryMaster, SubCategoryMasterEntity>();
                var cityModel = Mapper.Map<List<SubCategoryMaster>, List<SubCategoryMasterEntity>>(city);
                return cityModel;
            }
            return null;
        }
        public int CreateSubCategory(BusinessEntities.SubCategoryMasterEntity SubCategoryMasterEntity)
        {
            using (var scope = new TransactionScope())
            {
                var city = new SubCategoryMaster
                {
                    CategoryName = SubCategoryMasterEntity.CategoryName,
                    IsActive = Convert.ToBoolean(   SubCategoryMasterEntity.IsActive),
                    CreateDate = Convert.ToDateTime(SubCategoryMasterEntity.CreateDate )
             
                };
                _unitOfWork.SubCategoryMasterRepository.Insert(city);
                _unitOfWork.Save();
                scope.Complete();
                return city.PK_SubCategoryId ;
            }
        }
        public bool UpdateSubCategory(int id, BusinessEntities.SubCategoryMasterEntity SubCategoryMasterEntity)
        {
            var success = false;
            if (SubCategoryMasterEntity != null)
            {
                using (var scope = new TransactionScope())
                {
                    var city = _unitOfWork.SubCategoryMasterRepository.GetByID(id);
                    if (city != null)
                    {
                        city.CategoryName = SubCategoryMasterEntity.CategoryName;
                        city.IsActive = Convert.ToBoolean(SubCategoryMasterEntity.IsActive);
                        city.CreateDate = Convert.ToDateTime(SubCategoryMasterEntity.CreateDate);

                        _unitOfWork.SubCategoryMasterRepository.Update(city);
                        _unitOfWork.Save();
                        scope.Complete();
                        success = true;
                    }
                }
            }
            return success; 
        }
        public bool DeleteSubCategory(int id)
        {
            var success = false;
            if (id > 0)
            {
                using (var scope = new TransactionScope())
                {
                    var city = _unitOfWork.SubCategoryMasterRepository.GetByID(id);
                    if (city != null)
                    {
                        _unitOfWork.SubCategoryMasterRepository.Delete(city);
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