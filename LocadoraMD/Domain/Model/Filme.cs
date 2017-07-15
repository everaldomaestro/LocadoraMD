namespace Domain.Model
{
    public partial class Filme
    {       
        int _ID;       
        string _Titulo;
        int _QTD;
        int _CategoriaID;
        decimal _ValorAluguel;

        public int ID { get => _ID; set => _ID = value; }
        public string Titulo { get => _Titulo; set => _Titulo = value; }
        public int QTD { get => _QTD; set => _QTD = value; }
        public int CategoriaID { get => _CategoriaID; set => _CategoriaID = value; }
        public decimal ValorAluguel { get => _ValorAluguel; set => _ValorAluguel = value; }
    }
}
