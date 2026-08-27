using System;
using System.Collections.Generic;
using System.Text;

namespace Quadro_de_pendencias.Interfaces
{
    public interface IDialogService
    {
        Task<bool> ConfirmAsync(string title, string message, string accept = "Confirmar", string cancel = "Cancelar");
    }
}
