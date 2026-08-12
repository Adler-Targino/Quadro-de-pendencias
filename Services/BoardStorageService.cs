using Microsoft.EntityFrameworkCore;
using Quadro_de_pendencias.Data;
using Quadro_de_pendencias.Interfaces;
using Quadro_de_pendencias.Models;

namespace Quadro_de_pendencias.Services
{
    public class BoardStorageService : IBoardService
    {
        private readonly AppDbContext _db;

        public BoardStorageService(AppDbContext db)
        {
            _db = db;
        }

        public async Task<List<BoardModel>> GetAllBoardsAsync()
        {
            if(!await _db.Boards.AnyAsync())
            {
                _db.Boards.Add(new BoardModel());
                await _db.SaveChangesAsync();
            }

            return await _db.Boards
                .Include(board => board.Groups)
                    .ThenInclude(group => group.Cards)
                .AsNoTracking()
                .OrderBy(board => board.CreatedAt)
                .ToListAsync();
        }

        public async Task CreateBoardAsync(BoardModel model)
        {
            _db.Boards.Add(model);
            await _db.SaveChangesAsync();
        }

        public async Task CreateGroupAsync(GroupModel model)
        {
            _db.Groups.Add(model);
            await _db.SaveChangesAsync();
        }

        public async Task CreateCardAsync(CardModel model)
        {
            _db.Cards.Add(model);
            await _db.SaveChangesAsync();
        }
    }
}
