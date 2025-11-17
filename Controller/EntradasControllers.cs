using MapaEstoqueCD.Database.Dto;
using MapaEstoqueCD.Database.Dto.modal;
using MapaEstoqueCD.Services;

namespace MapaEstoqueCD.Controller
{
    public class EntradasControllers
    {
        public readonly EntradasService entradasService = new();
        

        public bool SetEntradaLivre(EntradaLvDto entradaLvDto)
        {
            try
            {
                entradaLvDto.userId = CacheMP.Instance.UserCurrent.UserId;
                entradasService.SetEntradaLivre(entradaLvDto);
            }
            catch (Exception)
            {

                throw;
            }
                return false;
        }
    }
}
