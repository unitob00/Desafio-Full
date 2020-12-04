
using System;
using System.ComponentModel.DataAnnotations;

namespace TituloEmAtraso.Models
{
    public class Parcela
    {
      public Parcela(int numeroParcela, DateTime dataVencimento, decimal valorParcela)
      {
        Id = Guid.NewGuid();
        NumeroParcela = numeroParcela;
        DataVencimento = dataVencimento;
        ValorParcela = valorParcela;
      }
      [Key]
      public Guid Id { get; set; }
  
      [Required(ErrorMessage = "Este campo é obrigatorio")]
      public int NumeroParcela { get; set; }
  
      [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
      public DateTime DataVencimento { get; set; }
      
      [Range(1, int.MaxValue, ErrorMessage = "O valor da parcela deve ser maior que zero")]
      public decimal ValorParcela { get; set; }
      public Guid IdTituloAtraso { get; set; }
      public TituloAtraso TituloAtraso { get; set; }
    } 
}