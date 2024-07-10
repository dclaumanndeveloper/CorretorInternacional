using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CorretorInternacional.Domain.Models
{
    public class Entity
    {
        [Key]
        [DisplayName("Código")]
        public string Id { get; set; }

        [DisplayName("Criado em")]
        public DateOnly CreatedAt { get; set; }
        [DisplayName("Atualizado em")]

        public DateOnly UpdatedAt { get; set; }

        [DisplayName("Status")]
        public bool Active { get; set; }


    }
}
