using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace AlugueldeVeiculos
{
    internal class Program
    {
        static List<Veiculo> veiculos = new List<Veiculo>();
        static void Main(string[] args)
        {
            Carregar();
            bool sair = false;
            while (!sair)
            {
                try
                {
                    Console.WriteLine("Aluguel de veiculos!");
                    Console.WriteLine("1-Deseja alugar um veiculo:\n2-Cadastrar novo veículo:\n3-Sair");
                    int opcao = int.Parse(Console.ReadLine());

                    switch (opcao)
                    {
                        case 1:
                            Alugar();
                            break;
                        case 2:
                            Cadastrar();
                            break;
                        case 3:
                            sair = true;
                            break;
                        default:
                            Console.WriteLine("Opção inválida!!");
                            Console.ReadLine();
                            break;
                    }
                }catch (Exception ex)
                {
                    Console.WriteLine("Somente numeros");
                    Console.ReadLine();
                }
               
                Console.Clear();

            }
            
        }

        static void Alugar()
        {
            Listar();
            Console.WriteLine("Escolha o ID do veículo que deseja alugar");
            int id = int.Parse(Console.ReadLine());

            if (id >= 0 && id < veiculos.Count)// O COUNT EXIBE O TAMANHO DA LISTA, MAS LEMBRE-SE QUE COMECA A CONTAR DO 0
            {


                Console.WriteLine("Informe quantas horas você irá passar com veículo:");
                int horas = int.Parse(Console.ReadLine());

                Console.WriteLine("Você escolheu o veiculo ");
                veiculos[id].Exibir();

                double valorTotal = veiculos[id].Preco * horas;
                Console.WriteLine("O valor por hora será:" + valorTotal);

                Console.ReadLine();
                Remover(id);
            }
            else
            {
                Console.WriteLine("ID INVÁLIDO");
            }
        }

        static void Remover(int id)
        {       
            
            if (id >= 0 && id < veiculos.Count)
            {
                veiculos.RemoveAt(id);
                Salvar();
            }
            
        }


        static public void Listar()
        {
            int i = 0;
            foreach(Veiculo veiculo in veiculos)
            {
                Console.WriteLine($"ID : [{i}]");
                veiculo.Exibir();
                i++;
                
            }
            

            Console.ReadLine();
        }

        static public void CadastrarMoto()
        {
            Console.WriteLine("Insira o modelo da moto");
            string modelo = Console.ReadLine();
            Console.WriteLine("Insira o velocidade maxima da moto");
            int velocidademax = int.Parse(Console.ReadLine());
            Console.WriteLine("Insira o preço por hora pela moto");
            double precohora = double.Parse(Console.ReadLine());
            Console.WriteLine("Insira as cilindradas da moto");
            int cilindradas = int.Parse(Console.ReadLine());

            Moto moto = new Moto(modelo,velocidademax,precohora,cilindradas);
            veiculos.Add(moto);
            Salvar();


        }
        static public void CadastrarCarro()
        {
            Console.WriteLine("Insira o modelo do carro");
            string modelo = Console.ReadLine();
            Console.WriteLine("Insira o velocidade maxima do carro");
            int velocidademax = int.Parse(Console.ReadLine());
            Console.WriteLine("Insira o preço por hora pelo carro");
            double precohora = double.Parse(Console.ReadLine());
            

            Carro carro = new Carro(modelo, velocidademax, precohora);
            veiculos.Add(carro);
            Salvar();

        }

        static public void CadastrarCaminhao()
        {
           
            Console.WriteLine("Insira o modelo do caminhao");
            string modelo = Console.ReadLine();
            Console.WriteLine("Insira o velocidade maxima do caminhao");
            int velocidademax = int.Parse(Console.ReadLine());
            Console.WriteLine("Insira o preço por hora pelo caminhao");
            double precohora = double.Parse(Console.ReadLine());
            Console.WriteLine("Insira a carga suportada pelo caminhao");
            int carga = int.Parse(Console.ReadLine());


            Caminhão caminhao = new Caminhão(modelo, velocidademax, precohora, carga);
            veiculos.Add(caminhao);

            //DESSA FORMA CONSIGO ACESSAR O QUE TEM DENTRO DO ATRIBUTO cargasuportada
            //Console.WriteLine(caminhao.Cargasuportada);
            //Console.ReadLine();
            Salvar();

        }

        static public void Cadastrar()
        {
            try
            {
                Console.WriteLine("O que voce deseja cadastrar:");
                Console.WriteLine("1-Moto\n2-Carro\n3-Caminhao");
                int op = int.Parse(Console.ReadLine());

                switch (op)
                {
                    case 1:
                        CadastrarMoto();
                        break;
                    case 2:
                        CadastrarCarro();
                        break;
                    case 3:
                        CadastrarCaminhao();
                        break;
                    default:
                        Console.WriteLine("Opção inválida");
                        break;

                }
            }catch (Exception ex)
            {
                Console.WriteLine("Somente numeros!");
                Console.ReadLine();
            }
           
        }



        static void Salvar()
        {
            FileStream stream = new FileStream("AluguelVeiculos.txt", FileMode.OpenOrCreate);
            BinaryFormatter encoder = new BinaryFormatter();

            encoder.Serialize(stream, veiculos);

            stream.Close();

        }

        static void Carregar()
        {
            FileStream stream = new FileStream("AluguelVeiculos.txt", FileMode.OpenOrCreate);
            BinaryFormatter encoder = new BinaryFormatter();
            try
            {
                veiculos = (List<Veiculo>)encoder.Deserialize(stream);

                if (veiculos == null)
                {
                    veiculos = new List<Veiculo>();
                }
            }
            catch (Exception ex)
            {
                veiculos = new List<Veiculo>();
            }

            stream.Close();

        }



    }
}
