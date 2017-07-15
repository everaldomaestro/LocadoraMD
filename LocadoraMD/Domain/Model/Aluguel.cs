namespace Domain.Model
{
    using System;
   
    public partial class Aluguel
    {
        int _ID;
        int _AluguelID;
        DateTime _DataAluguel;
        DateTime? _DataDevolucao;
        decimal _ValorAluguel;
        int _ClienteID;

        public int ID { get => _ID; set => _ID = value; }
        public int AluguelID { get => _AluguelID; set => _AluguelID = value; }
        public DateTime DataAluguel { get => _DataAluguel; set => _DataAluguel = value; }
        public DateTime? DataDevolucao { get => _DataDevolucao; set => _DataDevolucao = value; }
        public decimal ValorAluguel { get => _ValorAluguel; set => _ValorAluguel = value; }
        public int ClienteID { get => _ClienteID; set => _ClienteID = value; }
    }
}
