using System.Threading;

namespace ApiCadastroCliente.Models
{
    public class Cliente
    {
        public int Id { get; private set; }
        public string Nome { get; set; }
        public char Genero { get; set; }
        public string Telefone { get; set; }
        public string Endereço { get; set; }

        readonly int count = 0;
        public Cliente(string nome, char genero, string telefone, string endereço)
        {
            Id = count++;
            Nome = nome;
            Genero = genero;
            Telefone = telefone;
            Endereço = endereço;
        }
    }
}
