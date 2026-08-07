using Quadro_de_pendencias.Models.Enums;

namespace Quadro_de_pendencias.Models
{
    public class CardModel
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid GroupId { get; set; }
        public string Title { get; set; } = "";
        public string? Description { get; set; }
        public DateTime? DueDate { get; set; }
        public bool Completed { get; set; }
        public CardPriority Priority { get; set; } = CardPriority.Normal;
        public CardStatus Status { get; set; } = CardStatus.Pending;
        public int Order { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }
    }
}
