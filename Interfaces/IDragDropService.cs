using Quadro_de_pendencias.ViewModels;

namespace Quadro_de_pendencias.Interfaces
{
    public interface IDragDropService
    {
        CardViewModel? DraggedCard { get; set; }
        GroupViewModel? SourceGroup { get; set; }
        void Reset();
    }
}
