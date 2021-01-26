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
    public class ItemMasterController : ApiController
    {
        private readonly IItemMasterServices  _cityMasterServices;

        public ItemMasterController()
        {
            _cityMasterServices = new ItemMasterServices() ;
        }
        [HttpGet]
        public HttpResponseMessage Get()
        {
            var city = _cityMasterServices.GetAllItem();
            if (city == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Item not found");
            }
            var cityEntities = city as List<ItemMasterEntity> ?? city.ToList();
            if (cityEntities.Any())
                return Request.CreateResponse(HttpStatusCode.OK, cityEntities);
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Item not found");
        }

        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            var city = _cityMasterServices.GetItemById(id);
          
            if (city != null)
                return Request.CreateResponse(HttpStatusCode.OK, city);
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No City found for this id");

           
        }

        public int Post([FromBody] ItemMasterEntity cityMasterEntity)
        {
            return _cityMasterServices.CreateItem(cityMasterEntity);
        }

        public bool Put(int id, [FromBody] ItemMasterEntity cityMasterEntity)
        {
            if (id > 0)
            {
                return _cityMasterServices.UpdateItem(id, cityMasterEntity);
            }
            return false;
        }
        public bool Delete(int id)
        {
            if (id > 0)
                return _cityMasterServices.DeleteItem(id);
            return false;
        }

       

    }
}