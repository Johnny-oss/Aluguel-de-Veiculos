using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlugueldeVeiculos
{
    [System.Serializable]
    internal class Caminhão : Veiculo, ControleVeiculos
    {
        List<Caminhão> caminhaoes = new List<Caminhão>();
        private int cargasuportada;
        public Caminhão(string modelo, int velocidademax, double preco, int cargasuportada) : base(modelo, velocidademax, preco)
        {
            this.Cargasuportada = cargasuportada;
        }

        // Como estou adicionando valores no meu arquivo Program em uma lista, não estou chamando esse atributo diretamente, então ok
        // Porém, se eu fosse a chamá-lo diretamente, poderia chamar essa Propriedade Cargasuportada
        public int Cargasuportada 
        {
            get { return this.cargasuportada; }
            set { this.cargasuportada = value; }
        }
        
        public override void Exibir()
        {
            base.Exibir();
            Console.WriteLine("Carga suportada: "+ this.Cargasuportada);
            Console.WriteLine("----------------------");
        }

        public void Disponivel()
        {
            int qtd = 0;
            foreach (Caminhão caminhao in caminhaoes)
            {
                for (int i = 0; i < caminhaoes.Count; i++)
                {
                    Console.WriteLine($"ID : [{i}]");
                    caminhao.Exibir();
                    qtd = i;
                }

            }
            Console.WriteLine($"Ainda temos {qtd + 1} caminhoes disponíveis");
        }

       
    }
}
