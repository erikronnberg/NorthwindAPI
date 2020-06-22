using AutoMapper;
using Microsoft.Ajax.Utilities;
using NorthwindAPI.Data;
using NorthwindAPI.Data.Entities;
using NorthwindAPI.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

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

        [ActionName("getSingleSupplierById")]
        public async Task<IHttpActionResult> GetSingleAsync(int id)
        {
            try
            {
                var result = await _repository.GetSuppliersAsync(id);
                if (result != null)
                {
                    var mappedResult = _mapper.Map<SupplierModel>(result);
                    return Ok(mappedResult);
                }
            }
            catch
            {
                return InternalServerError();
            }
            return BadRequest();
        }

        [ActionName("deleteSupplierById")]
        public async Task<IHttpActionResult> Delete(int id)
        {
            try
            {
                var supplier = await _repository.GetSuppliersAsync(id);
                _repository.DeleteSupplier(supplier);
                if (await _repository.SaveChangesAsync())
                    return Ok("Deleted");
            }
            catch
            {
                return InternalServerError();
            }
            return BadRequest();
        }
        
        [ActionName("postSupplier")]
        public async Task<IHttpActionResult> Post(SupplierModel model)
        {
            try
            {
                if (ModelState.IsValid && model != null)
                {
                    var supplier = _mapper.Map<Supplier>(model);
                    _repository.AddSupplier(supplier);
                    if (await _repository.SaveChangesAsync())
                    {
                        var newModel = _mapper.Map<SupplierModel>(supplier);
                        return CreatedAtRoute("", "", newModel);
                    }
                }
            }
            catch
            {
                return InternalServerError();
            }
            return BadRequest();
        }
        
        [ActionName("putSupplierById")]
        public async Task<IHttpActionResult> Patch(SupplierModel model, int id)
        {
            try
            {
                if (ModelState.IsValid && model != null)
                {
                    model.SupplierID = id;
                    var supplier = await _repository.GetSuppliersAsync(id);

                    _mapper.Map(model, supplier);
                    _repository.UpdateSupplier(supplier);
                    if (await _repository.SaveChangesAsync())
                    {
                        var newModel = _mapper.Map<SupplierModel>(supplier);
                        return Ok(newModel);
                    }
                }
            }
            catch
            {
                return InternalServerError();
            }
            return BadRequest();
        }
    }
}