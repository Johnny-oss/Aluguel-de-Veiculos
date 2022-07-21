using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlugueldeVeiculos
{
    [System.Serializable]
    internal class Moto : Veiculo, ControleVeiculos
    {
        private int cilindradas;
        List<Moto> motos = new List<Moto>();
        public Moto(string modelo, int velocidademax, double preco, int cilindradas) : base(modelo, velocidademax, preco)
        {
            this.Cilindradas = cilindradas;
        }


        // Como estou adicionando valores no meu arquivo Program em uma lista, não estou chamando esse atributo diretamente, então ok
        // Porém, se eu fosse a chamá-lo diretamente, poderia chamar essa Propriedade Cilindradas
        public int Cilindradas 
        { 
            get { return this.cilindradas; } 
            set { this.cilindradas = value; }
        
        }

        public override void Exibir()
        {
            base.Exibir();
            Console.WriteLine("Cilindradas: " + this.Cilindradas);
            Console.WriteLine("----------------------");
        }

        public void Disponivel()
        {
            int qtd = 0;
            foreach (Moto moto in motos)
            {
                for (int i = 0; i < motos.Count; i++)
                {
                    Console.WriteLine($"ID : [{i}]");
                    moto.Exibir();
                    qtd = i;
                }

            }
            Console.WriteLine($"Ainda temos {qtd + 1} motos disponíveis");
        }

       
    }
}
