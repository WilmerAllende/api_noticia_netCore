using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ws_wa_noticias.Models;
using ws_wa_noticias.Services;

namespace ws_wa_noticias.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoticiaController : ControllerBase
    {
        private readonly NoticiaService _noticiaService;
        public NoticiaController(NoticiaService noticiaService)
        {
            _noticiaService = noticiaService;
        }
        [HttpGet]
        [Route("obtener")]
        public IActionResult Obtener()
        {
            var resultado = _noticiaService.Obtener();
            return Ok(resultado);
        }

        [HttpPost]
        [Route("agregar")]
        public IActionResult Agregar([FromBody] Noticia _noticia)
        {
            bool estado = _noticiaService.AgregarNoticia(_noticia);
            if (estado)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut]
        [Route("editar")]
        public IActionResult Editar([FromBody] Noticia _noticia)
        {
            bool estado = _noticiaService.EditarNoticia(_noticia);
            if (estado)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        [Route("eliminar/{id}")]
        public IActionResult Eliminar(int id)
        {
            bool estado = _noticiaService.EliminarNoticia(id);
            if (estado)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("buscarNoticia/{titulo}")]
        public IActionResult BuscarNoticiaTitulo(string titulo)
        {
            var resultado = _noticiaService.BuscarNoticiaTitulo(titulo);
            return Ok(resultado);
        }
    }
}