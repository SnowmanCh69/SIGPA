using SIGPA.Models;
using SIGPA.Repositories;

namespace SIGPA.Services
{
    public interface IMetodoControlService
    {
        Task<IEnumerable<MetodoControl>> GetMetodosControl();
        Task<MetodoControl?> GetMetodoControl(int id);
        Task<MetodoControl> CreateMetodoControl(
           string NombreMetodoControl,
           string DescripcionMetodoControl
        );
        Task<MetodoControl> UpdateMetodoControl(
         int IdMetodoControl,
         string? NombreMetodoControl,
         string? DescripcionMetodoControl
        );
        Task<MetodoControl> DeleteMetodoControl(int id);
        
    }
    public class MetodoControlService(IMetodoControlRepository metodoControlRepository): IMetodoControlService
    {
        
        public async Task<MetodoControl?> GetMetodoControl(int id)
        {
            return await metodoControlRepository.GetMetodoControl(id);
        }

        public async Task<IEnumerable<MetodoControl>> GetMetodosControl()
        {
            return await metodoControlRepository.GetMetodosControl();
        }

        public async Task<MetodoControl> CreateMetodoControl(
            string NombreMetodoControl,
            string DescripcionMetodoControl
         )
        {
            return await metodoControlRepository.CreateMetodoControl(new MetodoControl
            {
                NombreMetodoControl = NombreMetodoControl,
                DescripcionMetodoControl = DescripcionMetodoControl
            });
        }

        public async Task<MetodoControl> UpdateMetodoControl(
           int IdMetodoControl,
           string? NombreMetodoControl,
           string? DescripcionMetodoControl
          )
        {
            MetodoControl? metodoControl = await metodoControlRepository.GetMetodoControl(IdMetodoControl);
            if (metodoControl == null) throw new Exception("MetodoControl not found");
            metodoControl.NombreMetodoControl = NombreMetodoControl ?? metodoControl.NombreMetodoControl;
            metodoControl.DescripcionMetodoControl = DescripcionMetodoControl ?? metodoControl.DescripcionMetodoControl;
            return await metodoControlRepository.UpdateMetodoControl(metodoControl);
        }

        public async Task<MetodoControl> DeleteMetodoControl(int id)
        {
            return await metodoControlRepository.DeleteMetodoControl(id);
        }
        
    }
    
}
