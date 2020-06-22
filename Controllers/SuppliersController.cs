using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using NorthwindAPI.Models;
using NorthwindAPI.Data;
using AutoMapper;

namespace NorthwindAPI.Controllers
{
    public class SuppliersController : ApiController
    {
        private readonly INorthwindRepository _repository;
        private readonly IMapper _mapper;
        public SuppliersController(INorthwindRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<IHttpActionResult> Get()
        {
            try
            {
                var result = await _repository.GetAllSuppliersAsync();
                var mappedResult = _mapper.Map<IEnumerable<SupplierModel>>(result);
                return Ok(mappedResult);
            }
            catch
            {
                return InternalServerError();
            }
        }
    }
}
