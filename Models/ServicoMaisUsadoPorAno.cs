namespace MIGHTVR_VS.Models
{
    public class ServicoMaisUsadoPorAno
    {
        public int Ano { get; set; } 
        public int ServicoId { get; set; }
        public int TotalUsos { get; set; }
        public string? TipoServico { get; set; }
    }
}
