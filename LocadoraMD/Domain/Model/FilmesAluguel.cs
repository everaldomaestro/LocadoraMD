namespace Domain.Model
{
    public partial class FilmesAluguel
    {
        int ID { get; set; }
        int FilmeID { get; set; }
        decimal ValorFilme { get; set; }
        int QTD { get; set; }
        int AluguelID { get; set; }
    }
}
