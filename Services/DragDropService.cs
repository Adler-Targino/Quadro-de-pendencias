using Quadro_de_pendencias.Interfaces;
using Quadro_de_pendencias.ViewModels;

namespace Quadro_de_pendencias.Services
{
    public class DragDropService : IDragDropService
    {
        public CardViewModel? DraggedCard { get; set; }
        public GroupViewModel? SourceGroup { get; set; }

        public void Reset()
        {
            DraggedCard = null;
            SourceGroup = null;
        }
    }
}
