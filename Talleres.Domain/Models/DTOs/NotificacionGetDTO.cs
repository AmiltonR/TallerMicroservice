using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talleres.Domain.Models.DTOs
{
    public class NotificacionGetDTO
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public string Notification { get; set; }
    }
}
