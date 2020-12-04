using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TituloEmAtraso.Models;

namespace TituloEmAtraso.Interfaces
{
    public interface ITituloAtrasoService
    {
        public Task<TituloAtraso> Add(TituloAtraso titulo, List<Parcela> parcelas);

        public Task<TituloAtraso> BuscarPorNumeroTitulo(int numeroTitulo);

        public Task<TituloAtraso> BuscarPorId(Guid id);

        public Task<List<TituloAtraso>> Listar();
    }
}
