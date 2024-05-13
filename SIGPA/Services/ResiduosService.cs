using SIGPA.Models;
using SIGPA.Repositories;

namespace SIGPA.Services
{
    public interface IResiduosService
    {
        Task<IEnumerable<Residuos>> GetResiduos();
        Task<Residuos?> GetResiduo(int id);
        Task<Residuos> CreateResiduo(
           string NombreResiduo,
           DateOnly FechaRegistro,
           int IdEstadoResiduos,
           string CantidadRegistrada,
           int IdUsuario
     );
        Task<Residuos> UpdateResiduo(
           int IdResiduo,
           string? NombreResiduo,
           DateOnly? FechaRegistro,
           int? IdEstadoResiduos,
           string? CantidadRegistrada,
           int? IdUsuario
                  );
        Task<Residuos?> DeleteResiduo(int id);
       
    }
    public class ResiduosService (IResiduosRepository residuosRepository) : IResiduosService
    {
        public async Task<Residuos?> GetResiduo(int id)
        {
            return await residuosRepository.GetResiduo(id);
        }

        public async Task<IEnumerable<Residuos>> GetResiduos()
        {
            return await residuosRepository.GetResiduos();
        }

        public async Task<Residuos> CreateResiduo(
            string NombreResiduo,
            DateOnly FechaRegistro,
            int IdEstadoResiduos,
            string CantidadRegistrada,
            int IdUsuario
          )
        {
            return await residuosRepository.CreateResiduo(new Residuos
            {
                NombreResiduo = NombreResiduo,
                FechaRegistro = FechaRegistro,
                IdEstadoResiduos = IdEstadoResiduos,
                CantidadRegistrada = CantidadRegistrada,
                IdUsuario = IdUsuario
            });
        }

        public async Task<Residuos> UpdateResiduo(
             int IdResiduo,
             string? NombreResiduo,
             DateOnly? FechaRegistro,
             int? IdEstadoResiduos,
             string? CantidadRegistrada,
             int? IdUsuario
        )
        {
            Residuos? residuo = await residuosRepository.GetResiduo(IdResiduo);
            if (residuo == null) throw new Exception("Residuo not found");
            residuo.NombreResiduo = NombreResiduo ?? residuo.NombreResiduo;
            residuo.FechaRegistro = FechaRegistro ?? residuo.FechaRegistro;
            residuo.IdEstadoResiduos = IdEstadoResiduos ?? residuo.IdEstadoResiduos;
            residuo.CantidadRegistrada = CantidadRegistrada ?? residuo.CantidadRegistrada;
            residuo.IdUsuario = IdUsuario ?? residuo.IdUsuario;
            return await residuosRepository.UpdateResiduo(residuo);
        }

        public async Task<Residuos?> DeleteResiduo(int id)
        {
            return await residuosRepository.DeleteResiduo(id);
        }
    }
}
