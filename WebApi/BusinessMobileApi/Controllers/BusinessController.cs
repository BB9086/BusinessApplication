using AutoMapper;
using BusinessMobileApi.Data;
using BusinessMobileApi.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace BusinessMobileApi.Controllers
{
    [ApiController]
    public class BusinessController : ControllerBase
    {
        private readonly IBusinessRepo _repository;
        private readonly IMapper _mapper;

        public BusinessController(IBusinessRepo repository, IMapper mapper)
        {
                _repository= repository;
                _mapper= mapper;
        }

        //GET api/business
        [HttpGet]
        [Authorize]
        [Route("api/business")]
        public ActionResult<IEnumerable<StoreReadDto>> GetAllStores()
        {
            var storeItems = _repository.GetAllStores();

            if (storeItems.Count() != 0)
            {
                return Ok(_mapper.Map<IEnumerable<StoreReadDto>>(storeItems));
            }
            return NotFound();
        }

        //GET api/business/GetStoreInfoByMonths/{id}
        [HttpGet]
        [Authorize]
        [Route("api/business/GetStoreInfoByMonths/{id}")]
        public ActionResult<IEnumerable<StoreReadDto>> GetStoreInfoByMonths(int id)
        {
            var storeIncomesPerMonth = _repository.GetAllStoreIncomesPerMonth(id);

            if(storeIncomesPerMonth.Count() != 0)
            {
                return Ok(_mapper.Map<IEnumerable<StoreMonthReadDto>>(storeIncomesPerMonth));
            }
            return NotFound();
        }

        //GET api/business/GetStoreInfoByYears/{id}
        [HttpGet]
        [Authorize]
        [Route("api/business/GetStoreInfoByYears/{id}")]
        public ActionResult<IEnumerable<StoreReadDto>> GetStoreInfoByYears(int id)
        {
            var storeIncomesPerYear = _repository.GetAllStoreIncomesPerYear(id);

            if (storeIncomesPerYear.Count() != 0)
            {
                return Ok(_mapper.Map<IEnumerable<StoreYearReadDto>>(storeIncomesPerYear));
            }
            return NotFound();
        }





    }
}
