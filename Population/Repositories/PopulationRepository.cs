using Population.Models;
using System.Data;
using System.Data.SqlClient;

namespace Population.Repositories;

public class PopulationRepository
{
	public List<DemographicInfo> FiltrarPopulacao(bool codigoInvalido, string code)
	{
		var result = new List<DemographicInfo>();

		using (var conn = new SqlConnection(Connection.ConnString()))
		{
			conn.Open();
			var comma = new SqlCommand("ListarPopulacaoEntidade")
			{ CommandType = CommandType.StoredProcedure, Connection = conn };
			comma.Parameters.AddWithValue("invalidCode", codigoInvalido);
			comma.Parameters.AddWithValue("value", code);

			SqlDataReader reader = comma.ExecuteReader();

			while (reader.Read())
			{
				result.Add(new DemographicInfo
				{
					Code = reader["Code"].ToString(),
					Entity = reader["Entity"].ToString(),
					Year = Convert.ToInt32(reader["Year"]),
					Population = reader["Population"].ToString()
				});
			}
		}

		return result;
	}
	public List<Tuple<string, string>> ListarCodigos()
	{
		var result = new List<Tuple<string, string>>();

		using (var conn = new SqlConnection(Connection.ConnString()))
		{
			conn.Open();
			SqlDataReader reader = new SqlCommand("ListarCodigosEntidades")
			{ CommandType = CommandType.StoredProcedure, Connection = conn }.ExecuteReader();

			while (reader.Read())
				result.Add(new Tuple<string, string>(reader["code"].ToString(), reader["entity"].ToString()));
		}

		return result;
	}
}
