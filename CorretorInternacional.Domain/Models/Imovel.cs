using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace CorretorInternacional.Domain.Models
{
    public class Imovel : Entity
    {
        [DisplayName("Nome")]
        public string Name { get; set; }

        [DisplayName("Preço")]
        public double Price { get; set; }

        public string AdressId { get; set; }
        [ForeignKey("AndressId")]
        public Adress Adress { get; set; }
    }
}
