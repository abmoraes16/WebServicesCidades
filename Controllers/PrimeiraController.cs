using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebServicesCidades.Models;

namespace WebServicesCidades.Controllers
{
    //Vamos definir a rota para a requisição do serviço
    [Route("api/[controller]")]
    public class PrimeiraController:Controller
    {
        Cidades cidade = new Cidades();
        DAOCidades dao = new DAOCidades();

        //[HttpGet("{id}")] 
        [HttpGet] 
        public IEnumerable<Cidades> Get(){
            return dao.Listar();
        }

        [HttpGet("{id}",Name="CidadeAtual")]
        public Cidades Get(int id){
            return dao.Listar().Where(x=>x.Id==id).FirstOrDefault();
        }
        [HttpPost]        
        public IActionResult Post([FromBody]Cidades cidade){
            dao.Cadastro(cidade);
            return CreatedAtRoute("CidadeAtual",new{Id=cidade.Id},cidade);
        }

        [HttpPut]        
        public IActionResult Put([FromBody]Cidades cidade){
            dao.Atualizar(cidade);
            return CreatedAtRoute("CidadeAtual",new{Id=cidade.Id},cidade);
        } 

        [HttpDelete("{id}")]
        public IActionResult Excluir(int id){
            dao.Excluir(id).ToString();
            return Ok(id);
        }

    }
}