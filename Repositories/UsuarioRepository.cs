using TarefasBackEnd.Models;

namespace TarefasBackEnd.Repositories
{
    public interface IUsuarioRepository
    {
        Usuario Read(string email, string senha);
        void Create(Usuario usuario);
        void Delete(Guid id);
        void Update(Guid guid, Tarefa tarefa);
        void Save();
    }

    public class UsuarioRepository : IUsuarioRepository

    {

        private readonly DataContext _context;

        public UsuarioRepository(DataContext context)
        {
            _context = context;
        }

        public void Create(Usuario usuario)
        {
            usuario.Id = Guid.NewGuid();
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Usuario Read(string email, string senha)
        {
            return _context.Usuarios.SingleOrDefault(
                usuario => usuario.Email == email && usuario.Senha == senha);
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(Guid guid, Tarefa tarefa)
        {
            throw new NotImplementedException();
        }
    }
}
