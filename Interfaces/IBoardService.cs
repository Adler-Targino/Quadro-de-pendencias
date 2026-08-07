using Quadro_de_pendencias.Models;
using Quadro_de_pendencias.ViewModels;

namespace Quadro_de_pendencias.Interfaces
{
    public interface IBoardService
    {
        Task<List<BoardModel>> GetAllBoardsAsync();
        Task<BoardModel> CreateGroupAsync(GroupModel model);
        Task<BoardModel> CreateBoardAsync(BoardModel model);
    }
}
