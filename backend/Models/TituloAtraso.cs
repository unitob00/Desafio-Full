
using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace TituloEmAtraso.Models
{
  public class TituloAtraso
  {
    public TituloAtraso(int numeroTitulo,string nome, string cpf, decimal juros, decimal multa)
    {
      this.Id = Guid.NewGuid();
      this.NumeroTitulo = numeroTitulo;
      this.Nome = nome;
      this.Cpf = cpf;
      this.Juros = juros;
      this.Multa = multa;
    }

    [Key]
    public Guid Id { get; set; }
    
    [Required(ErrorMessage = "Este campo é obrigatorio")]
    public int NumeroTitulo { get; set; }
    
    [Required(ErrorMessage = "Este campo é obrigatorio")]
    [MaxLength(100, ErrorMessage = "Este campo deve conter 100 caracteres")]
    [MinLength(3, ErrorMessage = "Este campo deve conter 3 caracteres")]
    public string Nome { get; set; }
    
    [Required(ErrorMessage = "Este campo é obrigatorio")]
    [MaxLength(11, ErrorMessage = "Este campo deve conter 11 caracteres")]
    [MinLength(11, ErrorMessage = "Este campo deve conter 11 caracteres")]
    public string Cpf { get; set; }

    [Required(ErrorMessage = "Este campo é obrigatorio")]
    public decimal Juros { get; set; }

    [Required(ErrorMessage = "Este campo é obrigatorio")]
    public decimal Multa { get; set; }

    public List<Parcela> Parcelas { get; set; }

  }
}