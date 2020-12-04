using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TituloEmAtraso.Data;
using TituloEmAtraso.Interfaces;
using TituloEmAtraso.Models;

namespace TituloEmAtraso.Services
{
    public class TituloAtrasoService : ITituloAtrasoService
    {
        private readonly DataContext _context;
        public TituloAtrasoService(DataContext context)
        {
            _context = context;
        }
        public async Task<TituloAtraso> Add(TituloAtraso titulo, List<Parcela> parcelas) 
        {
            _context.TituloAtraso.Add(titulo);

            for (int i = 0; i < parcelas.Count; i++)
            {
                parcelas[i].IdTituloAtraso = titulo.Id;
            }

            _context.Parcela.AddRange(parcelas);

            await _context.SaveChangesAsync();
            return titulo;
        }

        public async Task<TituloAtraso> BuscarPorId(Guid id)
        {
            return await _context.TituloAtraso.Where(x => x.Id == id).Include(x => x.Parcelas).AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task<TituloAtraso> BuscarPorNumeroTitulo(int numeroTitulo)
        {
            return await _context.TituloAtraso.AsNoTracking().Where(x => x.NumeroTitulo == numeroTitulo).FirstOrDefaultAsync();
        }

        public async Task<List<TituloAtraso>> Listar()
        {
            return await _context.TituloAtraso.Include(x => x.Parcelas).AsNoTracking().ToListAsync();
        }
    }
}
