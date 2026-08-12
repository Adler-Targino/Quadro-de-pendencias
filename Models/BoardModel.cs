namespace Quadro_de_pendencias.Models
{
    public class BoardModel
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Title { get; set; } = "Meu quadro de pendências";
        public string Description { get; set; } = "Descrição do quadro";

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public List<GroupModel> Groups { get; set; } = [];
    }
}
