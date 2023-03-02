using Application.Models;
using Domain.Entidades;

namespace Application.Services.Interfaces
{
    public interface IGraficoService
    {
        GraficoModel Grafico(List<Grafico> consulta);
    }
}
