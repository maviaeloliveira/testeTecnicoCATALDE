using Application.Application.Exceptions;
using Application.DTOs.Ocorrencia;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OcorrenciaController : ControllerBase
    {
        private readonly IOcorrenciaService _service;
        private readonly IMapper _mapper;

        public OcorrenciaController(IOcorrenciaService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }


        /// <summary>
        /// Rota responsável por criar uma ocorrencia.
        /// </summary>
        /// <param name="ocorrenciaInsertDTO"></param>
        /// <response code="200">a ocorrencia foi criada com sucesso</response>
        /// <response code="400">Ocorreu algum erro ao criar a ocorrencia</response>
        /// <returns></returns>
        [HttpPost("PostOcorrencia")]
        public async Task<IActionResult> InserirOcorrencia([FromBody] OcorrenciaInsertDTO ocorrenciaInsertDTO)
        {
            try
            {
                var ocorrenciaInsert = _mapper.Map<Ocorrencia>(ocorrenciaInsertDTO);

                await _service.Add(ocorrenciaInsert);

                return Ok(201);
            }
            catch (BusinessException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                   "Ocorreu um problema ao tratar a sua solicitação.");
            }
        }

        /// <summary>
        /// Rota responsável por excluir uma ocorrencia
        /// </summary>
        /// <param name="id">identificador da ocorrencia</param>
        /// <returns></returns>
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<OcorrenciaDTO>> Delete(int id)
        {
            try
            {
                await _service.Remove(id);
                return Ok(204);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (BusinessException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                   "Ocorreu um problema ao tratar a sua solicitação.");
            }
        }
    }
}
