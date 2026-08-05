using System;
using System.Collections.Generic;
using System.Text;

namespace Quadro_de_pendencias.Models
{
    public class CardAttachmentModel
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string FileName { get; set; } = "";
        public string Path { get; set; } = "";
    }
}
