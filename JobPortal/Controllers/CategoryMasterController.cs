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
    public class CategoryMasterController : ApiController
    {
        private readonly ICategoryMasterServices  _cityMasterServices;

        public CategoryMasterController()
        {
            _cityMasterServices = new CategoryMasterServices() ;
        }
        [HttpGet]
        public HttpResponseMessage Get()
        {
            var city = _cityMasterServices.GetAllCategory();
            if (city == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "City not found");
            }
            var cityEntities = city as List<CategoryMasterEntity> ?? city.ToList();
            if (cityEntities.Any())
                return Request.CreateResponse(HttpStatusCode.OK, cityEntities);
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "City not found");
        }

        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            var city = _cityMasterServices.GetCategoryById(id);
          
            if (city != null)
                return Request.CreateResponse(HttpStatusCode.OK, city);
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No City found for this id");

           
        }

        public int Post([FromBody] CategoryMasterEntity cityMasterEntity)
        {
            return _cityMasterServices.CreateCategory(cityMasterEntity);
        }

        public bool Put(int id, [FromBody] CategoryMasterEntity cityMasterEntity)
        {
            if (id > 0)
            {
                return _cityMasterServices.UpdateCategory(id, cityMasterEntity);
            }
            return false;
        }
        public bool Delete(int id)
        {
            if (id > 0)
                return _cityMasterServices.DeleteCategory(id);
            return false;
        }

       

    }
}