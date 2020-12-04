
using AutoMapper;
using TituloEmAtraso.Models;
using TituloEmAtraso.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TituloEmAtraso.Config 
{
    public class Mapping : Profile 
    {
        public Mapping()
        {
            CreateMap<TituloAtrasoDTO, TituloAtraso>();
            CreateMap<ParcelaDTO, Parcela>();

            CreateMap<TituloAtraso, ListaTituloAtrasoDTO>()
                .ForMember(dest => dest.QuantidadeParcelas, opt => opt.MapFrom(src => src.Parcelas.Count))
                .ForMember(dest => dest.DiasAtraso, opt => opt.MapFrom(src => CalculoDiasAtraso(src.Parcelas.OrderBy(x => x.DataVencimento).First().DataVencimento)))
                .ForMember(dest => dest.ValorOriginal, opt => opt.MapFrom(src => CalculoValorOriginal(src.Parcelas)))
                .ForMember(dest => dest.ValorAtualizado, opt => opt.MapFrom(src => CalculoValorAtualizado(src)));
                  
        
        }

        private double CalculoDiasAtraso(DateTime dataVencimento)
        {
            var data = DateTime.Now;

            return data.Subtract(dataVencimento).TotalDays;
        }

        private decimal CalculoValorOriginal(List<Parcela> parcelas)
        {
            return parcelas.Sum(x => x.ValorParcela);
        }

        public double CalculoValorAtualizado(TituloAtraso titulo)
        {
            var valorOriginal = CalculoValorOriginal(titulo.Parcelas);
            var juros = titulo.Juros;
            var valorMulta = valorOriginal * (titulo.Multa / 100);
            double valorJuros = 0;

            foreach (var item in titulo.Parcelas)
            {
                var diasAtraso = CalculoDiasAtraso(item.DataVencimento);
                valorJuros += ((((double)juros / 100) / 30) * diasAtraso) * (double)item.ValorParcela;
            }

            return (double)valorOriginal + (double)valorMulta + valorJuros;
        }
    }
}