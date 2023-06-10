using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SimApi.Base;
using SimApi.Data;
using SimApi.Data.Repository;
using SimApi.Operation.CategorydapperService;
using SimApi.Schema;

namespace SimApi.Service.Controllers;


[EnableMiddlewareLogger]
[ResponseGuid]
[Route("simapi/v1/[controller]")]
[ApiController]
public class CategoryDapperController : ControllerBase
{
    private ICategoryRepository repository;
    private IMapper mapper;
    private IDapperCategoryService _service;
    public CategoryDapperController(ICategoryRepository repository, IMapper mapper, IDapperCategoryService service)
    {
        this.repository = repository;
        this.mapper = mapper;
        _service = service;
    }


    [HttpGet]
    public ApiResponse<List<Category>> GetAll()
    {
        var list = _service.GetAll();
      
        return list;
    }

    [HttpGet("{id}")]
    public ApiResponse<Category> GetById(int id)
    {
        var row = _service.GetById(id);
        
        return row;
    }

   

    [HttpPost]
    public CategoryResponse Post([FromBody] CategoryRequest request)
    {
        var entity = mapper.Map<Category>(request);
        repository.Insert(entity);
        repository.Complete();

        var mapped = mapper.Map<Category, CategoryResponse>(entity);
        return mapped;
    }

    [HttpPut("{id}")]
    public void Put(int id, [FromBody] CategoryRequest request)
    {
        request.Id = id;
        var entity = mapper.Map<Category>(request);
        repository.Update(entity);
        repository.Complete();
    }


    [HttpDelete("{id}")]
    public void Delete(int id)
    {
        _service.DeleteById(id);
    }

}
