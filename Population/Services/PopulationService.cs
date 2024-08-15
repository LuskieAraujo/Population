using Population.Models;
using Population.Repositories;

namespace Population.Services;

public class PopulationService
{
	private PopulationRepository _repo = new PopulationRepository();
	public List<DemographicInfo> FiltrarPopulacaoPais(string code, string entity)
	{
		try
		{
			var codigoInvalido = code == "_";
			return _repo.FiltrarPopulacao(codigoInvalido, codigoInvalido ? entity : code);
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
			return new List<DemographicInfo>();
		}
	}
	public List<Tuple<string, string>> ListarCodigos()
	{
		try
		{
			return _repo.ListarCodigos();
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
			return new List<Tuple<string, string>>();
		}
	}
}
