using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlugueldeVeiculos
{
    [System.Serializable]
    internal class Veiculo
    {
        private string modelo;
        private int velocidademax;
        public double preco;

        public Veiculo(string modelo, int velocidademax, double preco)
        {
            this.modelo = modelo;
            this.velocidademax = velocidademax;
            this.preco = preco;
        }

        public virtual void Exibir()
        {
            Console.WriteLine("");
            Console.WriteLine("Modelo: " + this.modelo);
            Console.WriteLine("Velocidade Maxima: " + this.velocidademax);
            Console.WriteLine("Preço por hora: " + this.preco);
           

        }
    }
}
