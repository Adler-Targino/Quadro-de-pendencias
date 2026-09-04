using Quadro_de_pendencias.Models;
using Quadro_de_pendencias.ViewModels;

namespace Quadro_de_pendencias.Interfaces
{
    public interface IBoardService
    {
        Task<List<BoardModel>> GetAllBoardsAsync();
        Task CreateBoardAsync(BoardModel model);
        Task UpdateBoardAsync(BoardModel model);
        Task RemoveBoardAsync(BoardModel model);
        Task CreateGroupAsync(GroupModel model);
        Task UpdateGroupAsync(GroupModel model);
        Task RemoveGroupAsync(GroupModel model);
        Task CreateCardAsync(CardModel model);
        Task UpdateCardAsync(CardModel model);
        Task UpdateCardCompletionAsync(CardModel model);
        Task RemoveCardAsync(CardModel model);
    }
}
