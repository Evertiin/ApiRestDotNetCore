using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.InMemory;
using Newtonsoft.Json;


namespace TarefasBackEnd.Models
{

    public class Tarefa
    {

        public Guid Id { get; set; }

        public Guid Usuario { get; set; }

        [Required]
        public string Nome { get; set; }

        public bool Concluida { get; set; } = false;
        
        [JsonProperty("dateTime")]
        public DateTime DataTarefa { get; set; }
        

        public Tarefa()
        {
            DataTarefa = DateTime.Now;
        }
    }


    
     
}