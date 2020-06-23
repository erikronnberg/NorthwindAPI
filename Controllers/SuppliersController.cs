using AutoMapper;
using Microsoft.Ajax.Utilities;
using NorthwindAPI.Data;
using NorthwindAPI.Data.Entities;
using NorthwindAPI.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
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
                var result = await _repository.GetAllSuppliersAsync();
                if (result != null)
                {
                    var mappedResult = _mapper.Map<IEnumerable<SupplierModel>>(result);
                    return Ok(mappedResult);
                }
                else return NotFound();
        }

        [ActionName("getSingleSupplierById")]
        public async Task<IHttpActionResult> GetSingleAsync(int id)
        {
                var result = await _repository.GetSuppliersAsync(id);
                if (result != null)
                {
                    var mappedResult = _mapper.Map<SupplierModel>(result);
                    return Ok(mappedResult);
                }
                else return NotFound();
        }

        [ActionName("deleteSupplierById")]
        public async Task<IHttpActionResult> Delete(int id)
        {
            try
            {
                var supplier = await _repository.GetSuppliersAsync(id);
                _repository.DeleteSupplier(supplier);
                if (await _repository.SaveChangesAsync())
                    return Ok(string.Format("Supplier with id {0} has been deleted", id));
                else return BadRequest();
            }
            catch
            {
                return InternalServerError();
            }
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
                    else return NotFound();
                }
                else return BadRequest();
            }
            catch
            {
                return InternalServerError();
            }
        }
    }
}