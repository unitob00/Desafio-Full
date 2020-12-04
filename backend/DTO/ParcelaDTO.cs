
using System;
using System.ComponentModel.DataAnnotations;

namespace TituloEmAtraso.DTO
{
    public class ParcelaDTO
    {
      public ParcelaDTO(int numeroParcela, DateTime dataVencimento, decimal valorParcela)
      {
        NumeroParcela = numeroParcela;
        DataVencimento = dataVencimento;
        ValorParcela = valorParcela;
      }
  
      [Required(ErrorMessage = "Este campo é obrigatorio")]
      public int NumeroParcela { get; set; }
  
      [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
      public DateTime DataVencimento { get; set; }
      
      [Range(1, int.MaxValue, ErrorMessage = "O valor da parcela deve ser maior que zero")]
      public decimal ValorParcela { get; set; }
    } 
}