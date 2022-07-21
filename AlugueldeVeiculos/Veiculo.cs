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
        private double preco;

        public Veiculo(string modelo, int velocidademax, double preco)
        {
            this.Modelo = modelo;
            this.Velocidademax = velocidademax;
            this.Preco = preco;
        }

        public string Modelo
        {
            get { return this.modelo; }
            set { this.modelo = value; }
        }

        public int Velocidademax
        {
            get { return this.velocidademax; }
            set { this.velocidademax = value; }
        }

        public double Preco
        {
            get { return this.preco; }
            set { this.preco = value; }
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
