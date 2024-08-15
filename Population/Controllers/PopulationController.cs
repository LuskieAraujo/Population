using Microsoft.AspNetCore.Mvc;
using Population.Models;
using Population.Services;

namespace Population.Controllers
{
	public class PopulationController : Controller
	{
		private PopulationService _serv = new PopulationService();
		public IActionResult Index()
		{
			return View();
		}
		public List<DemographicInfo> Filter(string code, string entity)
		{
			return _serv.FiltrarPopulacaoPais(code, entity);
		}
		public List<Tuple<string, string>> CodesList()
		{
			return _serv.ListarCodigos();
		}
	}
}
