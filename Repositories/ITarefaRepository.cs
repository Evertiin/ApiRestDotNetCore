﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TarefasBackEnd.Models;
using Microsoft.EntityFrameworkCore.InMemory;

namespace TarefasBackEnd.Repositories
{
    public interface ITarefaRepository
    {
        List<Tarefa> Read();
        void Create(Tarefa tarefa);
        void Delete(Guid id);
        void Update(Guid guid, Tarefa tarefa);
        void Save();
    }



    namespace ContosoUniversity.DAL
    {
        public class TarefaRepository : ITarefaRepository
        {
            private readonly DataContext _context;

            public TarefaRepository(DataContext context)
            {
                _context = context;
            }

            public void Create(Tarefa tarefa)
            {
                tarefa.Id = Guid.NewGuid();
                _context.Add(tarefa);
                _context.SaveChanges();
                

            }

            public void Delete(Guid id)
            {
                var tarefa = _context.Tarefas.Find(id);
                _context.Entry(tarefa).State = EntityState.Deleted;
                _context.SaveChanges();
            }

            public List<Tarefa> Read()
            {
                return _context.Tarefas.ToList();
            }

            public void Save()
            {
                throw new NotImplementedException();
            }

            public void Update(Guid id,Tarefa tarefa)
            {
                var _tarefa = _context.Tarefas.Find(id);
                _tarefa.Nome = tarefa.Nome;
                _tarefa.Concluida = tarefa.Concluida;

                _context.Entry(_tarefa).State = EntityState.Modified;
                _context.SaveChanges();
            }
        }
    }
}
