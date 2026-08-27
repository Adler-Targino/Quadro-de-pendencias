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

        public async Task UpdateBoardAsync(BoardModel model)
        {
            var entry = await _db.Boards.FindAsync(model.Id);

            if (entry is null)
                return;

            entry.Title = model.Title;
            entry.Description = model.Description;

            _db.Boards.Update(entry);
            await _db.SaveChangesAsync();
        }

        public async Task RemoveBoardAsync(BoardModel model)
        {
            var board = await _db.Boards.FindAsync(model.Id);

            if (board is null)
                return;

            _db.Boards.Remove(board);
            await _db.SaveChangesAsync();
        }

        public async Task CreateGroupAsync(GroupModel model)
        {
            _db.Groups.Add(model);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateGroupAsync(GroupModel model)
        {
            var entry = await _db.Groups.FindAsync(model.Id);

            if (entry is null)
                return;

            entry.Name = model.Name;
            entry.Color = model.Color;
            entry.Order = model.Order;

            _db.Groups.Update(entry);
            await _db.SaveChangesAsync();
        }

        public async Task RemoveGroupAsync(GroupModel model)
        {
            var entry = await _db.Groups.FindAsync(model.Id);

            if (entry is null)
                return;

            _db.Groups.Remove(entry);
            await _db.SaveChangesAsync();
        }

        public async Task CreateCardAsync(CardModel model)
        {
            _db.Cards.Add(model);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateCardAsync(CardModel model)
        {
            var entry = await _db.Cards.FindAsync(model.Id);
            
            if (entry is null)
                return;

            entry.Title = model.Title;
            entry.Description = model.Description;
            entry.DueDate = model.DueDate;
            entry.Priority = model.Priority;
            entry.Order = model.Order;
            entry.UpdatedAt = DateTime.Now;

            _db.Cards.Update(entry);
            await _db.SaveChangesAsync();
        }

        public async Task RemoveCardAsync(CardModel model)
        {
            var card = await _db.Cards.FindAsync(model.Id);

            if (card is null)
                return;

            _db.Cards.Remove(card);
            await _db.SaveChangesAsync();
        }
    }
}
