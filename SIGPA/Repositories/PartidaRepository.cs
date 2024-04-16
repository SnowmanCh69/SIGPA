using SIGPA.Models;
using SIGPA.Context;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace SIGPA.Repositories
{
    public interface IPartidaRepository
    {
        Task<List<Partida>> GetAll();
        Task<Partida?> GetPartida(int id);
        Task<Partida> CreatePartida(int idUsuario, DateTime fechaInicioPartida, DateTime fechaFinPartida, int idNivel, string ubicacionJugador, int cantidadVidas, int idResiduos);
        Task<Partida> UpdatePartida(Partida partida);
        Task<Partida> DeletePartida(int id);
    }
    public class PartidaRepository : IPartidaRepository
    {
        private readonly ApplicationDbContext _db;
        public PartidaRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<List<Partida>> GetAll()
        {
            return await _db.Partida.ToListAsync();
        }
        public async Task<Partida?> GetPartida(int id)
        {
            return await _db.Partida.FirstOrDefaultAsync(e => e.IdPartida == id);
        }
        public async Task<Partida> CreatePartida(int idUsuario, DateTime fechaInicioPartida, DateTime fechaFinPartida, int idNivel, string ubicacionJugador, int cantidadVidas, int idResiduos)
        {
            // Obtener el usuario, nivel y residuos correspondientes a partir de sus IDs
            var usuario = await _db.Usuarios.FindAsync(idUsuario);
            var nivel = await _db.Nivel.FindAsync(idNivel);
            var residuos = await _db.Residuos.FindAsync(idResiduos);

            if (usuario == null || nivel == null || residuos == null)
            {
                // Manejar la situación en la que el usuario, nivel o residuos no existen
                throw new Exception("Usuario, Nivel o Residuos no encontrado");
            }

            // Crear una nueva instancia de Partida con los valores proporcionados
            Partida newPartida = new Partida
            {
                IdUsuario = idUsuario,
                FechaInicioPartida = fechaInicioPartida,
                FechaFinPartida = fechaFinPartida,
                IdNivel = idNivel,
                UbicacionJugador = ubicacionJugador,
                CantidadVidas = cantidadVidas,
                IdResiduos = idResiduos,
                Usuario = usuario,
                Nivel = nivel,
                Residuos = residuos
            };

            await _db.Partida.AddAsync(newPartida);
            await _db.SaveChangesAsync();
            return newPartida;
        }
        public async Task<Partida> UpdatePartida(Partida partida)
        {
            _db.Partida.Update(partida);
            await _db.SaveChangesAsync();
            return partida;
        }
        public async Task<Partida> DeletePartida(int id)
        {
            Partida partida = await GetPartida(id);

            return partida;
        }
    }
}
