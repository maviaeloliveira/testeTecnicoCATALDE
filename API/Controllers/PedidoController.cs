using Application.Application.Exceptions;
using Application.DTOs.Pedido;
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
    public class PedidoController : ControllerBase
    {
        private readonly IPedidoService _service;
        private readonly IMapper _mapper;

        public PedidoController(IPedidoService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        /// <summary>
        /// Rota responsável por criar um pedido novo.
        /// </summary>
        /// <param name="pedidoInsertDTO"></param>
        /// <response code="200">o pedido foi criado com sucesso</response>
        /// <response code="400">Ocorreu algum erro ao criar o pedido</response>
        /// <returns></returns>
        [HttpPost("PostPedido")]
        public async Task<IActionResult> InserirPedido([FromBody] PedidoInsertDTO pedidoInsertDTO)
        {
            try
            {
                var pedidoInsert = _mapper.Map<Pedido>(pedidoInsertDTO);

                await _service.Add(pedidoInsert);

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
    }
}
