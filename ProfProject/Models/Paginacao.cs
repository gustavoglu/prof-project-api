namespace ProfProject.Models
{
    public class Paginacao<T>
    {
        public Paginacao(List<T> data, int pagina, long total, int limite)
        {
            Pagina = pagina;
            Total = total;
            Limite = limite;
            Data = data;
        }

        public int Pagina { get; set; }
        public long Total { get; set; }
        public int Limite { get; set; }
        public List<T> Data { get; set; }
    }
}
