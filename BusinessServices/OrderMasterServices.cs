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
    public class OrderMasterServices :IOrderMasterServices
    {
        private readonly UnitOfWork _unitOfWork;
        public OrderMasterServices()
        {
            _unitOfWork = new UnitOfWork();
        }

        public BusinessEntities.OrderMasterEntity GetOrderById(int id)
        {
            BusinessEntities.OrderMasterEntity objOrderMaster = new BusinessEntities.OrderMasterEntity();
            if (id == 0)
                return objOrderMaster;

            var city = _unitOfWork.OrderMasterRepository.GetByID(id);
            if (city != null)
            {
                Mapper.CreateMap<OrderMaster, OrderMasterEntity>();
                var OrderModel = Mapper.Map<OrderMaster, OrderMasterEntity>(city);
                return OrderModel;
            }
            return null;
        }

       



        public IEnumerable<BusinessEntities.OrderMasterEntity> GetAllOrder()
        {
            var city = _unitOfWork.OrderMasterRepository.GetAll().ToList();
            if (city.Any())
            {
                Mapper.CreateMap<OrderMaster, OrderMasterEntity>();
                var cityModel = Mapper.Map<List<OrderMaster>, List<OrderMasterEntity>>(city);
                return cityModel;
            }
            return null;
        }
        public int CreateOrder(BusinessEntities.OrderMasterEntity OrderMasterEntity)
        {
            using (var scope = new TransactionScope())
            {
                var city = new OrderMaster
                {
                    FullName = OrderMasterEntity.FullName,
                    MobileNo = OrderMasterEntity.MobileNo,
                    LandMark = OrderMasterEntity.LandMark,
                    City = OrderMasterEntity.City,
                    AddressType = OrderMasterEntity.AddressType,
                    

                };
                _unitOfWork.OrderMasterRepository.Insert(city);
                _unitOfWork.Save();
                scope.Complete();
                return city.Sno ;
            }
        }
        public bool UpdateOrder(int id, BusinessEntities.OrderMasterEntity OrderMasterEntity)
        {
            var success = false;
            if (OrderMasterEntity != null)
            {
                using (var scope = new TransactionScope())
                {
                    var city = _unitOfWork.OrderMasterRepository.GetByID(id);
                    if (city != null)
                    {
                        city.FullName = OrderMasterEntity.FullName;
                        city.MobileNo = OrderMasterEntity.MobileNo;
                        city.LandMark = OrderMasterEntity.LandMark;
                        city.City = OrderMasterEntity.City;
                        city.AddressType = OrderMasterEntity.AddressType;
                        _unitOfWork.OrderMasterRepository.Update(city);
                        _unitOfWork.Save();
                        scope.Complete();
                        success = true;
                    }
                }
            }
            return success; 
        }
        public bool DeleteOrder(int id)
        {
            var success = false;
            if (id > 0)
            {
                using (var scope = new TransactionScope())
                {
                    var city = _unitOfWork.OrderMasterRepository.GetByID(id);
                    if (city != null)
                    {
                        _unitOfWork.OrderMasterRepository.Delete(city);
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