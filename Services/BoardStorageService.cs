using Quadro_de_pendencias.Interfaces;
using Quadro_de_pendencias.Models;

namespace Quadro_de_pendencias.Services
{
    public class BoardStorageService : IBoardService
    {
        public async Task<List<BoardModel>> GetAllBoardsAsync()
        {
            var board1 = new BoardModel();

            Guid auxGuid = Guid.NewGuid();
            board1.Groups.Add(new GroupModel
            {
                Id = auxGuid,
                Name = "Aguardando Cliente"
            });

            board1.Cards.Add(new CardModel
            {
                GroupId = auxGuid,
                Title = $"Card {auxGuid}",
                Description = "Description"
            });
            auxGuid = Guid.NewGuid();

            board1.Groups.Add(new GroupModel
            {
                Id = auxGuid,
                Name = "Pendentes"
            });

            board1.Cards.Add(new CardModel
            {
                GroupId = auxGuid,
                Title = $"Card {auxGuid}",
                Description = "Description"
            });
            auxGuid = Guid.NewGuid();

            board1.Groups.Add(new GroupModel
            {
                Id = auxGuid,
                Name = "Acompanhamento"
            });

            board1.Cards.Add(new CardModel
            {
                GroupId = auxGuid,
                Title = $"Card {auxGuid}",
                Description = "Description"
            });


            var board2 = new BoardModel();

            board2.Title = "Board2";
            board2.Description = "Description2";

            board2.Groups.Add(new GroupModel
            {
                Id = auxGuid,
                Name = "Aguardando Cliente"
            });

            board2.Cards.Add(new CardModel
            {
                GroupId = auxGuid,
                Title = $"Card {auxGuid}",
                Description = "Description"
            });
            auxGuid = Guid.NewGuid();

            board2.Groups.Add(new GroupModel
            {
                Id = auxGuid,
                Name = "Pendentes"
            });

            board2.Cards.Add(new CardModel
            {
                GroupId = auxGuid,
                Title = $"Card {auxGuid}",
                Description = "Description"
            });
            auxGuid = Guid.NewGuid();

            board2.Groups.Add(new GroupModel
            {
                Id = auxGuid,
                Name = "Acompanhamento"
            });

            board2.Cards.Add(new CardModel
            {
                GroupId = auxGuid,
                Title = $"Card {auxGuid}",
                Description = "Description"
            });

            var boards = new List<BoardModel>();

            boards.Add(board1);
            boards.Add(board2);

            //boards.Add(board1);
            //boards.Add(board2);

            //boards.Add(board1);
            //boards.Add(board2);

            //boards.Add(board1);
            //boards.Add(board2);

            //boards.Add(board1);
            //boards.Add(board2);

            //boards.Add(board1);
            //boards.Add(board2);

            return boards;
        }

        public async Task<BoardModel> CreateGroupAsync(GroupModel model)
        {
            throw new NotImplementedException();
        }

        public async Task<BoardModel> CreateBoardAsync(BoardModel model)
        {
            throw new NotImplementedException();
        }
    }
}
