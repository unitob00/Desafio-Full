using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TituloEmAtraso.Data;
using TituloEmAtraso.Models;
using TituloEmAtraso.DTO;
using TituloEmAtraso.Services;
using TituloEmAtraso.Interfaces;

[Route("v1/titulos")]
public class TituloAtrasoController : ControllerBase 
{
    private readonly IMapper _mapper;
    private readonly ITituloAtrasoService _service;
    public TituloAtrasoController(IMapper mapper, ITituloAtrasoService service)
    {
        _mapper = mapper;
        _service = service;
    }

    [HttpGet]
    [Route("")]
    public async Task<ActionResult<List<ListaTituloAtrasoDTO>>> Get() 
    {
          var retorno = await _service.Listar();

          if (retorno.Count == 0 || retorno == null)
              return NotFound("Nenhum titulo encontrado no momento");


          return Ok(_mapper.Map<List<ListaTituloAtrasoDTO>>(retorno));
    }

    [HttpGet]
    [Route("{id:Guid}")]
    public async Task<ActionResult<TituloAtraso>> GetById(Guid id) 
    {
          var retorno = await _service.BuscarPorId(id);

          if (retorno == null)
              return NotFound("Nenhum titulo encontrado para o identificador fornecido");

          return Ok(retorno);
    }

    [HttpPost]
    [Route("")]
    public async Task<ActionResult<TituloAtraso>> Post([FromBody]TituloAtrasoDTO model) 
    {
        if (!ModelState.IsValid)
          return BadRequest(ModelState);

        var existeTitulo = await _service.BuscarPorNumeroTitulo(model.NumeroTitulo);

        if (existeTitulo != null)
          return BadRequest("Já existe titulo cadastro para o numero do titulo");

        try 
        {
          var titulo =  _mapper.Map<TituloAtraso>(model);
          List<Parcela> parcelas = _mapper.Map<List<Parcela>>(model.parcelas);
          
          return Ok(await _service.Add(titulo, parcelas));
        }
        catch
        {
          return BadRequest(new { message = "Não foi possível criar o Titulo em Atraso"});
        }
    }
}
