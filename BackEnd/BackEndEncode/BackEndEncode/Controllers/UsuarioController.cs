using AutoMapper;
using BackEndEncode.Models;
using BackEndEncode.Models.DTO;
using BackEndEncode.Models.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndEncode.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {        
        private readonly IMapper _mapper;
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioController(IMapper mapper, IUsuarioRepository usuarioRepository)
        {
            _mapper = mapper;
            _usuarioRepository = usuarioRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var listUsuarios = await _usuarioRepository.GetListUsuarios();

                var listUsuariosDto = _mapper.Map<IEnumerable<UsuarioDTO>>(listUsuarios);

                return Ok(listUsuariosDto);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var usuario = await _usuarioRepository.GetUsuario(id);

                if (usuario == null)
                {
                    return NotFound();
                }

                var usuarioDto = _mapper.Map<UsuarioDTO>(usuario);

                return Ok(usuarioDto);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var usuario = await _usuarioRepository.GetUsuario(id);

                if (usuario == null)
                {
                    return NotFound();
                }

                await _usuarioRepository.DeleteUsuario(usuario);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UsuarioDTO usuarioDto)
        {
            try
            {
                var usuario = _mapper.Map<Usuario>(usuarioDto);

                if (id != usuario.Id)
                {
                    return BadRequest();
                }

                var usuarioItem = await _usuarioRepository.GetUsuario(id);

                if (usuarioItem == null)
                {
                    return NotFound();
                }

                await _usuarioRepository.UpdateUsuario(usuario);

                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        public async Task<IActionResult> Post(UsuarioDTO usuarioDto)
        {
            try
            {
                var usuario = _mapper.Map<Usuario>(usuarioDto);

                usuario = await _usuarioRepository.AddUsuario(usuario);

                var newUsuarioDto = _mapper.Map<UsuarioDTO>(usuario);
                return CreatedAtAction("Get", new { id = newUsuarioDto.Id }, newUsuarioDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
