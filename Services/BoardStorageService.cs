using Quadro_de_pendencias.Interfaces;
using Quadro_de_pendencias.Models;

namespace Quadro_de_pendencias.Services
{
    public class BoardStorageService : IBoardService
    {
        public async Task<BoardModel> GetBoardAsync()
        {
            var board = new BoardModel();

            Guid auxGuid = Guid.NewGuid();
            board.Groups.Add(new CardGroupModel
            {
                Id = auxGuid,
                Name = "Aguardando Cliente"
            });

            board.Cards.Add(new CardModel
            {
                GroupId = auxGuid,
                Title = $"Card {auxGuid}",
                Description = "Description"
            });
            auxGuid = Guid.NewGuid();

            board.Groups.Add(new CardGroupModel
            {
                Id = auxGuid,
                Name = "Pendentes"
            });

            board.Cards.Add(new CardModel
            {
                GroupId = auxGuid,
                Title = $"Card {auxGuid}",
                Description = "Description"
            });
            auxGuid = Guid.NewGuid();

            board.Groups.Add(new CardGroupModel
            {
                Id = auxGuid,
                Name = "Acompanhamento"
            });

            board.Cards.Add(new CardModel
            {
                GroupId = auxGuid,
                Title = $"Card {auxGuid}",
                Description = "Description"
            });

            return board;
        }
    }
}
