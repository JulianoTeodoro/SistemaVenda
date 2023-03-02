using Application.Models;
using Application.Services.Interfaces;
using Domain.Entidades;

namespace Application.Services
{
    public class GraficoService : IGraficoService
    {
        public GraficoModel Grafico(List<Grafico> consulta)
        {
            string valores = string.Empty;
            string labels = string.Empty;
            string cores = string.Empty;

            var random = new Random();

            for (int i = 0; i < consulta.Count; i++)
            {
                valores += consulta[i].TotalVendido.ToString() + ",";
                labels += "'" + consulta[i].Descricao.ToString() + "',";
                cores += "'" + String.Format("#{0:X6}", random.Next(0x100000) + "',");
            }

            var model = new GraficoModel
            {
                Labels = labels,
                Valores = valores,
                Cores = cores
            };

            return model;
        }
    }
}
