using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using STILA.Application.Abstract;
using STILA.Domain.Entities;
using STILA.WebApi.Message;

namespace STILA.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PostsController : ControllerBase
	{
		private readonly IPostReadRepository postReadRepository;
		private readonly IPostWriteRepository postWriteRepository;

        public PostsController(IPostReadRepository postReadRepository, IPostWriteRepository postWriteRepository)
        {
			this.postReadRepository = postReadRepository;
			this.postWriteRepository = postWriteRepository;
        }

		#region AddAsync
		[HttpPost("AddAsync")]
		public async Task<ActionResult> AddAsync(Post post) 
		{

			return Ok(StatusCodes.Status200OK);
		}
		#endregion

		#region Activity
		[HttpGet("ActivityAsync/{id}")]
		public async Task<ActionResult> ActivityAsync(int? id)
		{
			if (id == null)
				return StatusCode(StatusCodes.Status404NotFound, new Respone { Status="404 Error", Message = "Id cannot be null"});
			Post post = await postReadRepository.GetAsync(x=>x.Id == id);
			if (post == null)
				return StatusCode(StatusCodes.Status400BadRequest, new Respone { Status = "400 Error", Message = "Id is not entered correctly" });

			await postWriteRepository.ActivityAsync(post);
			return Ok(StatusCode(StatusCodes.Status200OK, new Respone { Status = "200 Ok", Message = "Success" }));
		}
		#endregion
	}
}
