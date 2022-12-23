using AutoMapper;
using BackEndEncode.Models;
using BackEndEncode.Models.DTO;
using BackEndEncode.Models.Repository;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndEncode.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [ApiController]
    public class ActividadController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IActividadRepository _actividadRepository;

        public ActividadController(IMapper mapper, IActividadRepository actividadRepository)
        {
            _mapper = mapper;
            _actividadRepository = actividadRepository;
        }


        [HttpPost]
        public async Task<IActionResult> Post(ActividadDTO actividadDto)
        {
            try
            {
                var actividad = _mapper.Map<Actividad>(actividadDto);


                actividad.FechaCreacion = DateTime.Now;

                actividad = await _actividadRepository.AddActividad(actividad);

                var newActividadDto = _mapper.Map<ActividadDTO>(actividad);

                return CreatedAtAction("Get", new { id = newActividadDto.Id }, newActividadDto);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var listActividades = await _actividadRepository.GetListActividades();

                List<ActividadDTO> listActividadesDto = new List<ActividadDTO>();
                foreach (var actividad in listActividades)
                {
                    ActividadDTO actividadDTO = new ActividadDTO();

                    actividadDTO.ActividadDescripcion = actividad.ActividadDescripcion;
                    actividadDTO.Id = actividad.Id;
                    actividadDTO.IdUsuario = actividad.IdUsuario;
                    actividadDTO.FechaCreacion = actividad.FechaCreacion;
                    actividadDTO.Nombre = actividad.IdUsuarioNavigation.Nombre + " " + actividad.IdUsuarioNavigation.Apellido;

                    listActividadesDto.Add(actividadDTO);

                }

                return Ok(listActividadesDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
