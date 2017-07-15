namespace Domain.Model
{
    public partial class FilmeAluguel
    {
        int _ID;
        int _FilmeID;
        decimal _ValorFilme;
        int _QTD;
        int _AluguelID;

        public int ID { get => _ID; set => _ID = value; }
        public int FilmeID { get => _FilmeID; set => _FilmeID = value; }
        public decimal ValorFilme { get => _ValorFilme; set => _ValorFilme = value; }
        public int QTD { get => _QTD; set => _QTD = value; }
        public int AluguelID { get => _AluguelID; set => _AluguelID = value; }
    }
}
