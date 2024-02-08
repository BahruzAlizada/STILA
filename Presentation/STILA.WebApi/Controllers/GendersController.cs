using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using STILA.Application.Abstract;
using STILA.Application.DTOs.Gender;
using STILA.Domain.Entities;
using STILA.Persistence.EntityFramework;
using STILA.WebApi.Message;

namespace STILA.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class GendersController : ControllerBase
	{
		private readonly IGenderReadRepository genderReadRepository;
		private readonly IGenderWriteRepository genderWriteRepository;

        public GendersController(IGenderWriteRepository genderWriteRepository, IGenderReadRepository genderReadRepository)
        {
			this.genderReadRepository = genderReadRepository;
			this.genderWriteRepository=genderWriteRepository;
        }

		#region AddAsync
		[HttpPost("AddAsync")]
		public async Task<IActionResult> AddAsync(GenderAddDto genderAdd)
		{
			await genderWriteRepository.AddDtoAsync(genderAdd);
			return Ok(StatusCode(StatusCodes.Status200OK, new Respone { Status = "200Ok", Message = "Success" }));
		}
		#endregion

		#region Delete
		[HttpDelete("Delete/{id}")]
		public ActionResult Delete(int? id)
		{
			if (id == null)
				return StatusCode(StatusCodes.Status404NotFound, new Respone { Status = "404 Error", Message = "Id cannot be null" });
			Gender gender =  genderReadRepository.Get(x => x.Id == id);
			if (gender == null)
				return StatusCode(StatusCodes.Status400BadRequest, new Respone { Status = "400 Error", Message = "Id is not entered correctly" });

			genderWriteRepository.Delete(gender);
			return Ok(StatusCode(StatusCodes.Status200OK, new Respone { Status = "200 Ok", Message = "Success" }));
		}
		#endregion

		#region ActivityAsync
		[HttpGet("ActivityAsync/{id}")]
		public async Task<IActionResult> ActivityAsync(int? id)
		{
			if (id == null)
				return StatusCode(StatusCodes.Status404NotFound, new Respone { Status = "404 Error", Message = "Id cannot be null" });
			Gender gender = await genderReadRepository.GetAsync(x => x.Id == id);
			if (gender == null)
				return StatusCode(StatusCodes.Status400BadRequest, new Respone { Status = "400 Error", Message = "Id is not entered correctly" });

			await genderWriteRepository.ActivityAsync(gender);
			return Ok(StatusCode(StatusCodes.Status200OK, new Respone { Status = "200 Ok", Message = "Success" }));
		}
		#endregion
	}
}
