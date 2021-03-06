﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.InLock.WebApi.DataBaseFirst.Domains;
using Senai.InLock.WebApi.DataBaseFirst.Interfaces;
using Senai.InLock.WebApi.DataBaseFirst.Repositories;

namespace Senai.InLock.WebApi.DataBaseFirst.Controllers
{
    [Route("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class JogosController : ControllerBase
    {
        private IJogoRepository _jogoRepository;

        public JogosController()
        {
            _jogoRepository = new JogoRepository();
        }

        [HttpGet]
        public List<Jogos> Get()
        {
            return _jogoRepository.Listar();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_jogoRepository.BuscarPorId(id));
        }

        [HttpPost]
        public IActionResult Post(Jogos novoJogo)
        {
            _jogoRepository.Cadastrar(novoJogo);

            return StatusCode(201);
        }

        [HttpPut]
        public IActionResult PutIdCorpo(int id,Jogos jogoAtualizado)
        {
            Jogos jogoBuscado = _jogoRepository.BuscarPorId(jogoAtualizado.IdJogo);

            if(jogoBuscado != null)
            {
                try
                {
                    _jogoRepository.Atualizar(id,jogoAtualizado);

                    return NoContent();
                }

                catch (Exception erro)
                {
                    return BadRequest(erro);
                }
            }

            return NotFound
               (
                new
                {
                    mensagem ="Jogo não encontrado",
                    erro = true
                }

                );
            }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            // Faz a chamada para o método .Deletar();
            _jogoRepository.Deletar(id);

            // Retorna um status code com uma mensagem personalizada
            return Ok("Jogo deletado");
        }
    }
    }