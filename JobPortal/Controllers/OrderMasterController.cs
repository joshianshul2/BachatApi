using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BusinessEntities;
using BusinessServices;

namespace WebApiIms.Controllers
{
    public class OrderMasterController : ApiController
    {
        private readonly IOrderMasterServices  _cityMasterServices;

        public OrderMasterController()
        {
            _cityMasterServices = new OrderMasterServices() ;
        }
        [HttpGet]
        public HttpResponseMessage Get()
        {
            var city = _cityMasterServices.GetAllOrder();
            if (city == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "City not found");
            }
            var cityEntities = city as List<OrderMasterEntity> ?? city.ToList();
            if (cityEntities.Any())
                return Request.CreateResponse(HttpStatusCode.OK, cityEntities);
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "City not found");
        }

        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            var city = _cityMasterServices.GetOrderById(id);
          
            if (city != null)
                return Request.CreateResponse(HttpStatusCode.OK, city);
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No City found for this id");

           
        }

        public int Post([FromBody] OrderMasterEntity cityMasterEntity)
        {
            return _cityMasterServices.CreateOrder(cityMasterEntity);
        }

        public bool Put(int id, [FromBody] OrderMasterEntity cityMasterEntity)
        {
            if (id > 0)
            {
                return _cityMasterServices.UpdateOrder(id, cityMasterEntity);
            }
            return false;
        }
        public bool Delete(int id)
        {
            if (id > 0)
                return _cityMasterServices.DeleteOrder(id);
            return false;
        }

       

    }
}