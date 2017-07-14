namespace Domain.Model
{     
    public partial class Categoria
    {
        int _ID;
        string _Descricao;

        public int ID { get => _ID; set => _ID = value; }
        public string Descricao { get => _Descricao; set => _Descricao = value; }
    }
}
