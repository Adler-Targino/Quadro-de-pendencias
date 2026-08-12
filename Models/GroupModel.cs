namespace Quadro_de_pendencias.Models
{
    public class GroupModel
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid BoardId { get; set; }
        public string Name { get; set; } = "";
        public string Color { get; set; } = "#6C63FF";
        public int Order { get; set; }

        public List<CardModel> Cards { get; set; } = [];
    }
}
