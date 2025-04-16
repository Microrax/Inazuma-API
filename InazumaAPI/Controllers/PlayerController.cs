using Microsoft.AspNetCore.Mvc;
using InazumaAPI.Application.Commands;
using InazumaAPI.Application.CommandBuss;
using InazumaAPI.Application.QueryBuss;
using InazumaAPI.Application.Querys;
using InazumaAPI.Domain.Aggregates.Players;
using System.ComponentModel.DataAnnotations;
using Mysqlx;

namespace InazumaAPI.Api.Controllers
{

    [ApiController]
    [Route("/api/v1/players")]
    public class PlayerController : ControllerBase
    {

        public readonly ICommandBus _commandBus;
        public readonly IQueryBus _queryBus;

        public PlayerController(ICommandBus commandBus, IQueryBus queryBus)
        {
            _commandBus = commandBus;
            _queryBus = queryBus;
        }

        [HttpGet("/NombreId")]
        public async Task<IActionResult> GetPlayer([StringLength(100, ErrorMessage = "NameMaxLength")] string NombreId)
        {
            try
            {
                return Ok(await _queryBus.SendAsync<GetPlayerQuery, PlayerModel>(new GetPlayerQuery(NombreId)));
            }
            catch(InvalidOperationException)
            {
                return NotFound(new { message = "El jugador no existe." });
            }
            catch(Exception)
            {
                return StatusCode(500, new { message = "Error en el servidor."});
            }   
        }

        [HttpGet("/Stat")]
        public async Task<IEnumerable<PlayerModel>> GetAllPlayersByStat([StringLength(100, ErrorMessage = "NameMaxLength")] string Stat)
        {

             return await _queryBus.SendAsync<GetAllPlayersQuery, IEnumerable<PlayerModel>>(new GetAllPlayersQuery(Stat));
            
        }

        [HttpPost]
        public async Task<IActionResult> AddPlayer([FromBody] AddPlayerCommand command)
        {
            try
            {
                await _commandBus.SendAsync(command);
                return StatusCode(201, "Jugador añadido a la base de datos.");
            }
            catch (InvalidOperationException)
            {
                return StatusCode(409, "El jugador ya existe en la base de datos.");
            }
            catch(ArgumentException)
            {
                return StatusCode(400, "Cuerpo mal construido.");
            }
            catch (Exception)
            {
                return StatusCode(500, "Error en el servidor");
            }
            
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePlayer([FromBody] PutPlayerCommand command)
        {
            try
            {
                await _commandBus.SendAsync(command);
                return StatusCode(201, "Jugador actualizado en la base de datos.");
            }
            catch (InvalidOperationException)
            {
                return StatusCode(409, "El jugador no existe en la base de datos.");
            }
            catch (ArgumentException)
            {
                return StatusCode(400, "Cuerpo mal construido.");
            }
            catch (Exception)
            {
                return StatusCode(500, "Error en el servidor");
            }

        }

        [HttpDelete]
        public async Task<IActionResult> DeletePlayer([FromBody] DeletePlayerCommand command)
        {
            try
            {
                await _commandBus.SendAsync(command);
                return StatusCode(201, "Jugador eliminado de la base de datos.");
            }
            catch (InvalidOperationException)
            {
                return StatusCode(409, "El jugador no existe en la base de datos.");
            }
            catch (ArgumentException)
            {
                return StatusCode(400, "Cuerpo mal construido.");
            }
            catch (Exception)
            {
                return StatusCode(500, "Error en el servidor");
            }

        }
    }
}
