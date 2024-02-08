using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using STILA.Application.Abstract;
using STILA.Application.DTOs.Category;
using STILA.Domain.Entities;
using STILA.WebApi.Message;

namespace STILA.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CategoriesController : ControllerBase
	{
		private readonly ICategoryReadRepository categoryReadRepository;
		private readonly ICategoryWriteRepository categoryWriteRepository;
        public CategoriesController(ICategoryReadRepository categoryReadRepository, ICategoryWriteRepository categoryWriteRepository)
        {
			this.categoryReadRepository = categoryReadRepository;
			this.categoryWriteRepository = categoryWriteRepository;
        }

		#region GetCategoriesAsync
		[HttpGet("GetCategoriesAsync")]
		public async Task<IActionResult> GetCategoriesAsync()
		{
			List<Category> categories = await categoryReadRepository.GetAllAsync();
			return Ok(categories);
		}
		#endregion

		#region GetCategoryAsync
		[HttpGet("GetCategoryAsync/{id}")]
		public async Task<IActionResult> GetCategoryAsync(int? id)
		{
			if (id == null)
				return StatusCode(StatusCodes.Status404NotFound, new Respone { Status = "404 Error", Message = "Id cannot be null" });
			Category category = await categoryReadRepository.GetAsync(x => x.Id == id);
			if (category == null)
				return StatusCode(StatusCodes.Status400BadRequest, new Respone { Status = "400 Error", Message = "Id is not entered correctly" });

			return Ok(category);
		}
		#endregion

		#region AddAsync
		[HttpPost("AddAsync")]
		public async Task<IActionResult> AddAsync(CategoryAddDto categoryAdd)
		{
			Category category = new Category
			{
				Name = categoryAdd.Name,
			};

			await categoryWriteRepository.AddAsync(category);
			return Ok(StatusCode(StatusCodes.Status200OK, new Respone { Status="200",Message="Success"}));
		} 
		#endregion

		#region Delete
		[HttpDelete("Delete/{id}")]
		public IActionResult Delete(int? id)
		{
			if (id == null)
				return StatusCode(StatusCodes.Status404NotFound, new Respone { Status = "404 Error", Message = "Id cannot be null" });
			Category category = categoryReadRepository.Get(x => x.Id == id);
			if(category == null)
				return StatusCode(StatusCodes.Status400BadRequest, new Respone { Status = "400 Error", Message = "Id is not entered correctly" });

			categoryWriteRepository.Delete(category);
			return Ok(StatusCode(StatusCodes.Status200OK, new Respone { Status = "200 Ok", Message = "Success" }));
		}
		#endregion

		#region ActivityAsync
		[HttpGet("ActivityAsync/{id}")]
		public async Task<IActionResult> ActivityAsync(int? id)
		{
			if (id == null)
				return StatusCode(StatusCodes.Status404NotFound, new Respone { Status = "404 Error", Message = "Id cannot be null" });
			Category category = await categoryReadRepository.GetAsync(x => x.Id == id);
			if(category==null)
				return StatusCode(StatusCodes.Status400BadRequest, new Respone { Status = "400 Error", Message = "Id is not entered correctly" });

			await categoryWriteRepository.ActivityAsync(category);
			return Ok(StatusCode(StatusCodes.Status200OK, new Respone { Status = "200 Ok", Message = "Success" }));
		}
		#endregion

	}
}
