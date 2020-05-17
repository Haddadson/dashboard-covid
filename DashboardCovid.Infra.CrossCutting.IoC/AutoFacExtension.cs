using Autofac;
using System.Reflection;

namespace DashboardCovid.Infra.CrossCutting.IoC
{
	public static class AutoFacExtension
	{
		public static void AddAutofacServiceProvider(this ContainerBuilder builder)
		{
			builder.RegistrarServices();
			builder.RegistrarRepositorio();
		}

		private static void RegistrarServices(this ContainerBuilder builder)
		{
			builder.RegisterAssemblyTypes(Assembly.Load("DashboardCovid.Domain")).AsImplementedInterfaces();
		}

		private static void RegistrarRepositorio(this ContainerBuilder builder)
		{
			builder.RegisterAssemblyTypes(Assembly.Load("DashboardCovid.Data")).AsImplementedInterfaces();
		}
	}
}
