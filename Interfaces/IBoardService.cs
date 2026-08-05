using Quadro_de_pendencias.Models;

namespace Quadro_de_pendencias.Interfaces
{
    public interface IBoardService
    {
        Task<BoardModel> GetBoardAsync();
    }
}
