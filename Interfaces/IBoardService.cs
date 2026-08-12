using Quadro_de_pendencias.Models;
using Quadro_de_pendencias.ViewModels;

namespace Quadro_de_pendencias.Interfaces
{
    public interface IBoardService
    {
        Task<List<BoardModel>> GetAllBoardsAsync();
        Task CreateGroupAsync(GroupModel model);
        Task CreateBoardAsync(BoardModel model);
        Task CreateCardAsync(CardModel model);
    }
}
