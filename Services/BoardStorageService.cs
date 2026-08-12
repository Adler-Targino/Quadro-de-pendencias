using Quadro_de_pendencias.Interfaces;
using Quadro_de_pendencias.Models;

namespace Quadro_de_pendencias.Services
{
    public class BoardStorageService : IBoardService
    {
        public async Task<List<BoardModel>> GetAllBoardsAsync()
        {
            var board1 = new BoardModel();
            board1.Id = Guid.Parse("5bc1a716-dddb-45fc-863f-465c9a4e18eb");

            Guid auxGuid = Guid.NewGuid();
            List<CardModel> Cards = new List<CardModel>();
            
            Cards.Add(new CardModel
            {
                GroupId = auxGuid,
                Title = $"Card 1 {auxGuid}",
                Description = "Description"
            });

            board1.Groups.Add(new GroupModel
            {
                Id = auxGuid,
                Name = "Aguardando Cliente",
                Cards = Cards
            });

            Cards.Clear();

            auxGuid = Guid.NewGuid();

            board1.Groups.Add(new GroupModel
            {
                Id = auxGuid,
                Name = "Pendentes",
                Cards = Cards
            });

            Cards.Clear();

            Cards.Add(new CardModel
            {
                GroupId = auxGuid,
                Title = $"Card 2 {auxGuid}",
                Description = "Description"
            });

            auxGuid = Guid.NewGuid();

            Cards.Add(new CardModel
            {
                GroupId = auxGuid,
                Title = $"Card 3 {auxGuid}",
                Description = "Description"
            });

            board1.Groups.Add(new GroupModel
            {
                Id = auxGuid,
                Name = "Acompanhamento",
                Cards = Cards
            });

            var board2 = new BoardModel();

            board2.Id = Guid.Parse("5bc1a716-dddb-45fc-863f-465c9a4e18ec");
            board2.Title = "Board2";
            board2.Description = "Description2";

            board2.Groups.Add(new GroupModel
            {
                Id = auxGuid,
                Name = "Aguardando Cliente"
            });

            auxGuid = Guid.NewGuid();

            board2.Groups.Add(new GroupModel
            {
                Id = auxGuid,
                Name = "Pendentes"
            });

            auxGuid = Guid.NewGuid();

            board2.Groups.Add(new GroupModel
            {
                Id = auxGuid,
                Name = "Acompanhamento"
            });


            var boards = new List<BoardModel>();

            boards.Add(board1);
            boards.Add(board2);

            return boards;
        }

        public async Task CreateBoardAsync(BoardModel model)
        {
            throw new NotImplementedException();
        }

        public async Task CreateGroupAsync(GroupModel model)
        {
            throw new NotImplementedException();
        }

        public async Task CreateCardAsync(CardModel model)
        {
            throw new NotImplementedException();
        }
    }
}
