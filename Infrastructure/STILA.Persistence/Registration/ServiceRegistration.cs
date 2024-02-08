using Microsoft.Extensions.DependencyInjection;
using STILA.Application.Abstract;
using STILA.Persistence.EntityFramework;

namespace STILA.Persistence.Registration
{
	public static class ServiceRegistration
	{
		public static void AddPersistencesServices(this IServiceCollection services)
		{
			services.AddScoped<IPostReadRepository,PostReadRepository>();
			services.AddScoped<IPostWriteRepository,PostWriteRepository>();

			services.AddScoped<ICategoryReadRepository,CategoryReadRepository>();
			services.AddScoped<ICategoryWriteRepository,CategoryWriteRepository>();

			services.AddScoped<IGenderReadRepository,GenderReadRepository>();
			services.AddScoped<IGenderWriteRepository,GenderWriteRepository>();
		}
	}
} 