using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlugueldeVeiculos
{
    [System.Serializable]
    internal class Carro : Veiculo, ControleVeiculos
    {
        List<Carro> carros = new List<Carro>();
        public Carro(string modelo, int velocidademax, double preco) : base(modelo, velocidademax, preco)
        {
            
        }

        public override void Exibir()
        {
            base.Exibir();
            Console.WriteLine("----------------------");
        }

        public void Disponivel()
        {
            int qtd = 0;
            foreach (Carro carro in carros)
            {
                for (int i = 0; i < carros.Count; i++)
                {
                    Console.WriteLine($"ID : [{i}]");
                    carro.Exibir();
                    qtd = i;
                }

            }
            Console.WriteLine($"Ainda temos {qtd + 1} carros disponíveis");
        }


    }
}
