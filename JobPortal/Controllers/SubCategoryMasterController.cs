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
    public class SubCategoryMasterController : ApiController
    {
        private readonly ISubCategoryMasterServices  _cityMasterServices;

        public SubCategoryMasterController()
        {
            _cityMasterServices = new SubCategoryMasterServices() ;
        }
        [HttpGet]
        public HttpResponseMessage Get()
        {
            var city = _cityMasterServices.GetAllSubCategory();
            if (city == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "City not found");
            }
            var cityEntities = city as List<SubCategoryMasterEntity> ?? city.ToList();
            if (cityEntities.Any())
                return Request.CreateResponse(HttpStatusCode.OK, cityEntities);
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "City not found");
        }

        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            var city = _cityMasterServices.GetSubCategoryById(id);
          
            if (city != null)
                return Request.CreateResponse(HttpStatusCode.OK, city);
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No City found for this id");

           
        }

        public int Post([FromBody] SubCategoryMasterEntity cityMasterEntity)
        {
            return _cityMasterServices.CreateSubCategory(cityMasterEntity);
        }

        public bool Put(int id, [FromBody] SubCategoryMasterEntity cityMasterEntity)
        {
            if (id > 0)
            {
                return _cityMasterServices.UpdateSubCategory(id, cityMasterEntity);
            }
            return false;
        }
        public bool Delete(int id)
        {
            if (id > 0)
                return _cityMasterServices.DeleteSubCategory(id);
            return false;
        }

       

    }
}