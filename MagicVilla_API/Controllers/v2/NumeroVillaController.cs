﻿using System.Net;
using AutoMapper;
using MagicVilla_API.Datos;
using MagicVilla_API.Modelos;
using MagicVilla_API.Modelos.Dto;
using MagicVilla_API.Repositorio.IRepositorio;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MagicVilla_API.Controllers.v2
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("2.0")]
    public class NumeroVillaController : ControllerBase
    {
        private readonly ILogger<NumeroVillaController> _logger;
        private readonly IVillaRepositorio _villaRepo;
        private readonly INumeroVillaRepositorio _numeroRepo;
        private readonly IMapper _mapper;
        protected APIResponse _response;
        public NumeroVillaController(ILogger<NumeroVillaController> logger, IVillaRepositorio villaRepo,
                                    INumeroVillaRepositorio numeroRepo, IMapper mapper)
        {
            _logger = logger;
            _villaRepo = villaRepo;
            _numeroRepo = numeroRepo;
            _mapper = mapper;
            _response = new();
        }

        //[MapToApiVersion("1.0")]
        //[HttpGet]
        //[Authorize(Roles = "admin")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //public async Task<ActionResult<APIResponse>> GetNumeroVillas()
        //{
        //    try
        //    {
        //        _logger.LogInformation("Obtener número de las Villas");

        //        IEnumerable<NumeroVilla> numeroVillaList = await _numeroRepo.ObtenerTodos(incluirPropiedades: "Villa");

        //        _response.Resultado = _mapper.Map<IEnumerable<NumeroVillaDto>>(numeroVillaList);
        //        _response.statusCode = HttpStatusCode.OK;

        //        return Ok(_response);
        //    }
        //    catch (Exception ex)
        //    {

        //        _response.IsExitoso = false;
        //        _response.ErrorMessages = new List<string>() { ex.ToString() };
        //    }
        //    return _response;
        //}

        [MapToApiVersion("2.0")]
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "valor1", "valor2" };
        }

        //[HttpGet("{id:int}", Name = "GetNumeroVilla")]
        //[Authorize(Roles = "admin")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //public async Task<ActionResult<APIResponse>> GetNumeroVilla(int id)
        //{
        //    try
        //    {
        //        if (id == 0)
        //        {
        //            _logger.LogError("Error al traer Villa Id " + id);
        //            _response.statusCode = HttpStatusCode.BadRequest;
        //            _response.IsExitoso = false;
        //            return BadRequest(_response);
        //        }
        //        //var villa = VillaStore.villaList.FirstOrDefault(v => v.Id == id);
        //        var numeroVilla = await _numeroRepo.Obtener(x => x.VillaNo == id, incluirPropiedades: "Villa");
        //        if (numeroVilla == null)
        //        {
        //            _response.statusCode = HttpStatusCode.NotFound;
        //            _response.IsExitoso = false;
        //            return NotFound(_response);
        //        }

        //        _response.Resultado = _mapper.Map<NumeroVillaDto>(numeroVilla);
        //        _response.statusCode = HttpStatusCode.OK;
        //        return Ok(_response);
        //    }
        //    catch (Exception ex)
        //    {

        //        _response.IsExitoso = false;
        //        _response.ErrorMessages = new List<string>() { ex.ToString() };
        //    }
        //    return _response;
        //}

        //[HttpPost]
        //[Authorize(Roles = "admin")]
        //[ProducesResponseType(StatusCodes.Status201Created)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //public async Task<ActionResult<APIResponse>> CrearNumeroVilla([FromBody] NumeroVillaCreateDto createDto)
        //{
        //    try
        //    {
        //        //Valida que se cumplan las DataAnotations del modelo
        //        if (!ModelState.IsValid)
        //        {
        //            return BadRequest(ModelState);
        //        }
        //        //Valida de que no se guarden dos registros con el mismo nombre validando con ModelState
        //        if (await _numeroRepo.Obtener(v => v.VillaNo == createDto.VillaNo) != null)
        //        {
        //            ModelState.AddModelError("ErrorMessages", "El número de Villa ya existe!");
        //            return BadRequest(ModelState);
        //        }
        //        if (await _villaRepo.Obtener(v => v.Id == createDto.VillaId) == null)
        //        {
        //            ModelState.AddModelError("ErrorMessages", "El Id de la Villa no existe!");
        //            return BadRequest(ModelState);
        //        }
        //        //Valida que no sea nullo el modelo que estoy creando
        //        if (createDto == null)
        //        {
        //            return BadRequest(createDto);
        //        }

        //        NumeroVilla modelo = _mapper.Map<NumeroVilla>(createDto);

        //        modelo.FechaCreacion = DateTime.Now;
        //        modelo.FechaActualizacion = DateTime.Now;
        //        await _numeroRepo.Crear(modelo);
        //        _response.Resultado = modelo;
        //        _response.statusCode = HttpStatusCode.Created;
        //        return CreatedAtRoute("GetNumeroVilla", new { id = modelo.VillaNo }, _response);
        //    }
        //    catch (Exception ex)
        //    {
        //        _response.IsExitoso = false;
        //        _response.ErrorMessages = new List<string>() { ex.ToString() };
        //    }
        //    return _response;
        //}

        //[HttpDelete("{id:int}")]
        //[Authorize(Roles = "admin")]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //public async Task<IActionResult> DeletNumeroVilla(int id)
        //{
        //    try
        //    {
        //        if (id == 0)
        //        {
        //            _response.IsExitoso = false;
        //            _response.statusCode = HttpStatusCode.BadRequest;
        //            return BadRequest(_response);
        //        }
        //        //Valida si existe el registro que se quiere eliminar
        //        var numeroVilla = await _numeroRepo.Obtener(v => v.VillaNo == id);
        //        if (numeroVilla == null)
        //        {
        //            _response.IsExitoso = false;
        //            _response.statusCode = HttpStatusCode.NotFound;
        //            return NotFound(_response);
        //        }
        //        await _numeroRepo.Remover(numeroVilla);

        //        _response.statusCode = HttpStatusCode.NoContent;

        //        return Ok(_response);
        //    }
        //    catch (Exception ex)
        //    {
        //        _response.IsExitoso = false;
        //        _response.ErrorMessages = new List<string>() { ex.ToString() };
        //    }
        //    return BadRequest(_response);
        //}

        //[HttpPut("{id:int}")]
        //[Authorize(Roles = "admin")]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //public async Task<IActionResult> UpdatNumeroVilla(int id, [FromBody] NumeroVillaUpdateDto updateDto)
        //{
        //    if (updateDto == null || id != updateDto.VillaNo)
        //    {
        //        _response.IsExitoso = false;
        //        _response.statusCode = HttpStatusCode.BadRequest;
        //        return BadRequest(_response);
        //    }

        //    if (await _villaRepo.Obtener(v => v.Id == updateDto.VillaId) == null)
        //    {
        //        ModelState.AddModelError("ErrorMessages", "El Id de la Villa no existe!");
        //        return BadRequest(ModelState);
        //    }

        //    NumeroVilla model = _mapper.Map<NumeroVilla>(updateDto);

        //    await _numeroRepo.Actualizar(model);
        //    _response.statusCode = HttpStatusCode.NoContent;

        //    return Ok(_response);
        //}
    }
}
