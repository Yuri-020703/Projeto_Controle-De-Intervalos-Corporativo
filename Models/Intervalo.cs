using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;


namespace Controle_de_Intervalos_Corporativo.Models
{
    public class Intervalo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public DateTime HoraIntervalo { get; set; }
        public DateTime Retorno { get; set; }

        public Intervalo() { }  

        public Intervalo(DateTime horaPausa)
        {
            HoraIntervalo = horaPausa;
        }

        public void PausaAlmoço()
        {
            Retorno = HoraIntervalo.AddHours(1).AddMinutes(30);
        }

        public void PausaCafeDaManha()
        {
            Retorno = HoraIntervalo.AddMinutes(30);
        }

        public void PausaCafeDaTarde()
        {
            Retorno = HoraIntervalo.AddMinutes(15);
        }
    }
}
