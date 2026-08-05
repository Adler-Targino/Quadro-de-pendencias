using CommunityToolkit.Mvvm.ComponentModel;
using Quadro_de_pendencias.Models.Enums;

namespace Quadro_de_pendencias.Models
{
    public partial class CardModel : ObservableObject
    {
        [ObservableProperty]
        public partial Guid Id { get; set; } = Guid.NewGuid();
        [ObservableProperty]
        public partial Guid GroupId { get; set; }

        [ObservableProperty]
        public partial string Title { get; set; } = "";

        [ObservableProperty]
        public partial string? Description { get; set; }

        [ObservableProperty]
        public partial DateTime? DueDate { get; set; }

        [ObservableProperty]
        public partial bool Completed { get; set; }

        [ObservableProperty]
        public partial CardPriority Priority { get; set; } = CardPriority.Normal;

        [ObservableProperty]
        public partial CardStatus Status { get; set; } = CardStatus.Pending;

        // Ordem dentro da coluna
        [ObservableProperty]
        public partial int Order { get; set; }

        [ObservableProperty]
        public partial DateTime CreatedAt { get; set; } = DateTime.Now;

        [ObservableProperty]
        public partial DateTime? UpdatedAt { get; set; }
    }
}
