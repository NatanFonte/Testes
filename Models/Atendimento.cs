namespace MIGHTVR_VS.Models
{
    public class Atendimento
    {
        public int Id { get; set; }

        public DateOnly DtHoraAgendamento { get; set; }

        public DateOnly DataAtendimento { get; set; }

        public TimeOnly Horario { get; set; }
    }
}
