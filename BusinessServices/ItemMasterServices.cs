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
    public class ItemMasterServices : IItemMasterServices
    {
        private readonly UnitOfWork _unitOfWork;
        public ItemMasterServices()
        {
            _unitOfWork = new UnitOfWork();
        }

        public BusinessEntities.ItemMasterEntity GetItemById(int id)
        {
            BusinessEntities.ItemMasterEntity objItemMaster = new BusinessEntities.ItemMasterEntity();
            if (id == 0)
                return objItemMaster;

            var city = _unitOfWork.ItemMasterRepository.GetByID(id);
            if (city != null)
            {
                Mapper.CreateMap<ItemMaster, ItemMasterEntity>();
                var itemModel = Mapper.Map<ItemMaster, ItemMasterEntity>(city);
                return itemModel;
            }
            return null;
        }

       



        public IEnumerable<BusinessEntities.ItemMasterEntity> GetAllItem()
        {
            var city = _unitOfWork.ItemMasterRepository.GetAll().ToList();
            if (city.Any() && city!=null)
            {
               

                Mapper.CreateMap<ItemMaster,ItemMasterEntity>();
                var cityModel = Mapper.Map<List<ItemMaster>, List<ItemMasterEntity>>(city);
                return cityModel;
            }
            return null;
        }
        public int CreateItem(BusinessEntities.ItemMasterEntity ItemMasterEntity)
        {
            using (var scope = new TransactionScope())
            {
                var city = new ItemMaster
                {
                    CategoryName = ItemMasterEntity.CategoryName,
                    IsActive = Convert.ToBoolean(ItemMasterEntity.IsActive),
                    CreateDate = Convert.ToDateTime(ItemMasterEntity.CreateDate),
                    Rate = Convert.ToInt32(ItemMasterEntity.Rate),
                    OfferRate = Convert.ToInt32(ItemMasterEntity.OfferRate),
                    IsCOD = Convert.ToBoolean(ItemMasterEntity.IsActive),
                    SubCategoryName = ItemMasterEntity.SubCategoryName,
                    ImageName = ItemMasterEntity.ImageName,
                    IsFreeDel = Convert.ToBoolean(ItemMasterEntity.IsActive),
                
                    Position = Convert.ToInt32(ItemMasterEntity.Position),
                    Discount = Convert.ToInt32(ItemMasterEntity.Discount),
                    ItemName = ItemMasterEntity.ItemName.ToString(),

                    ShowFrontTop_3 = Convert.ToBoolean(ItemMasterEntity.ShowFrontTop_3),
                    ShowFrontMid_3 = Convert.ToBoolean(ItemMasterEntity.ShowFrontMid_3),
                    ShowFrontBottom_3 = Convert.ToBoolean(ItemMasterEntity.ShowFrontBottom_3),
                    ShowFrontSlider_10 = Convert.ToBoolean(ItemMasterEntity.ShowFrontSlider_10),
                    ShowLeftFront_5 = Convert.ToBoolean(ItemMasterEntity.ShowLeftFront_5),
                    ShowFrontSingle_1 = Convert.ToBoolean(ItemMasterEntity.ShowFrontSingle_1),
                    ShowTop3 = Convert.ToBoolean(ItemMasterEntity.ShowTop3),
                    ShowBottom9 = Convert.ToBoolean(ItemMasterEntity.ShowBottom9),
                    ShowSlider9 = Convert.ToBoolean(ItemMasterEntity.ShowSlider9),
                    ShowLeft5 = Convert.ToBoolean(ItemMasterEntity.ShowLeft5),
                    FrontPosition = Convert.ToInt32(ItemMasterEntity.FrontPosition),





                };
                _unitOfWork.ItemMasterRepository.Insert(city);
                _unitOfWork.Save();
                scope.Complete();
                return city.PK_ItemId ;
            }
        }
        public bool UpdateItem(int id, BusinessEntities.ItemMasterEntity ItemMasterEntity)
        {
            var success = false;
            if (ItemMasterEntity != null)
            {
                using (var scope = new TransactionScope())
                {
                    var city = _unitOfWork.ItemMasterRepository.GetByID(id);
                    if (city != null)
                    {
                        
                        city.ItemName = ItemMasterEntity.ItemName.ToString();
                        city.IsActive = Convert.ToBoolean(ItemMasterEntity.IsActive);
                        city.CreateDate = Convert.ToDateTime(ItemMasterEntity.CreateDate);

                        city.CategoryName = ItemMasterEntity.CategoryName;
                        city.IsActive = Convert.ToBoolean(ItemMasterEntity.IsActive);
                        city.CreateDate = Convert.ToDateTime(ItemMasterEntity.CreateDate);
                        city.Rate = Convert.ToInt32(ItemMasterEntity.Rate);
                        city.OfferRate = Convert.ToInt32(ItemMasterEntity.OfferRate);
                        city.IsCOD = Convert.ToBoolean(ItemMasterEntity.IsActive);
                        city.SubCategoryName = ItemMasterEntity.SubCategoryName;
                        city.ImageName = ItemMasterEntity.ImageName;
                        city.IsFreeDel = Convert.ToBoolean(ItemMasterEntity.IsActive);
                        city.Position = Convert.ToInt32(ItemMasterEntity.Position);
;                       city.Discount = Convert.ToInt32(ItemMasterEntity.Discount);
                        city.ItemName = ItemMasterEntity.ItemName.ToString();
                        city.ShowFrontTop_3 = Convert.ToBoolean(ItemMasterEntity.ShowFrontTop_3);
                        city.ShowFrontMid_3 = Convert.ToBoolean(ItemMasterEntity.ShowFrontMid_3);
                        city.ShowFrontBottom_3 = Convert.ToBoolean(ItemMasterEntity.ShowFrontBottom_3);
                        city.ShowFrontSlider_10 = Convert.ToBoolean(ItemMasterEntity.ShowFrontSlider_10);
                        city.ShowLeftFront_5 = Convert.ToBoolean(ItemMasterEntity.ShowLeftFront_5);
                        city.ShowFrontSingle_1 = Convert.ToBoolean(ItemMasterEntity.ShowFrontSingle_1);
                        city.ShowTop3 = Convert.ToBoolean(ItemMasterEntity.ShowTop3);
                        city.ShowBottom9 = Convert.ToBoolean(ItemMasterEntity.ShowBottom9);
                        city.ShowSlider9 = Convert.ToBoolean(ItemMasterEntity.ShowSlider9);
                        city.ShowLeft5 = Convert.ToBoolean(ItemMasterEntity.ShowLeft5);
                        city.FrontPosition = Convert.ToInt32(ItemMasterEntity.FrontPosition);









                        _unitOfWork.ItemMasterRepository.Update(city);
                        _unitOfWork.Save();
                        scope.Complete();
                        success = true;
                    }
                }
            }
            return success; 
        }
        public bool DeleteItem(int id)
        {
            var success = false;
            if (id > 0)
            {
                using (var scope = new TransactionScope())
                {
                    var city = _unitOfWork.ItemMasterRepository.GetByID(id);
                    if (city != null)
                    {
                        _unitOfWork.ItemMasterRepository.Delete(city);
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