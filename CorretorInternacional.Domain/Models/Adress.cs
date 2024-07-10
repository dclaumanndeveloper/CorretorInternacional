using System.ComponentModel;

using static CorretorInternacional.Domain.Enumeradores.State;

namespace CorretorInternacional.Domain.Models
{
    public class Adress : Entity
    {
        [DisplayName("CEP")]
        public string PostalCode { get; set; }

        [DisplayName("Logradouro")]
        public string AdressName { get; set; }

        [DisplayName("Número")]
        public int Number { get; set; }

        [DisplayName("Complemento")]
        public string Complement { get; set; }

        [DisplayName("Estado")]
        public States State { get; set; }

        [DisplayName("Cidade")]
        public string City { get; set; }

    }
}
