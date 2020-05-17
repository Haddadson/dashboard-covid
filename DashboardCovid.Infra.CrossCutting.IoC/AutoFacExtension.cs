using Autofac;
using System.Reflection;

namespace DashboardCovid.Infra.CrossCutting.IoC
{
	public static class AutoFacExtension
	{
		//Registra os assemblies das classes para uso de injeção de dependência
		public static void AddAutofacServiceProvider(this ContainerBuilder builder)
		{
			builder.RegistrarServices();
			builder.RegistrarRepositorio();
		}

		//Registra as classes de domínio (Services) para injeção de dependência
		private static void RegistrarServices(this ContainerBuilder builder)
		{
			builder.RegisterAssemblyTypes(Assembly.Load("DashboardCovid.Domain")).AsImplementedInterfaces();
		}

		//Registra as classes de dados (Repositórios) para injeção de dependência
		private static void RegistrarRepositorio(this ContainerBuilder builder)
		{
			builder.RegisterAssemblyTypes(Assembly.Load("DashboardCovid.Data")).AsImplementedInterfaces();
		}
	}
}
