namespace Domain.Model
{
    public partial class Cliente
    {       
        int _ID;
        string _Nome;
        string _Sobrenome;

        public int ID { get => _ID; set => _ID = value; }
        public string Nome { get => _Nome; set => _Nome = value; }
        public string Sobrenome { get => _Sobrenome; set => _Sobrenome = value; }
    }
}
