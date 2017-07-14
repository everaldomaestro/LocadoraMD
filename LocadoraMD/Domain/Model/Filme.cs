namespace Domain.Model
{
    public partial class Filme
    {       
        int ID { get; set; }       
        string Titulo { get; set; }
        int QTD { get; set; }
        int CategoriaID { get; set; }
        decimal ValorAluguel { get; set; }       
    }
}
