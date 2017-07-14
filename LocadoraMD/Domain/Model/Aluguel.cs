namespace Domain.Model
{
    using System;
   
    public partial class Aluguel
    {
        int ID { get; set; }
        int AluguelID { get; set; }
        DateTime DataAluguel { get; set; }
        DateTime? DataDevolucao { get; set; }
        decimal ValorAluguel { get; set; }
        int ClienteID { get; set; }
    }
}
