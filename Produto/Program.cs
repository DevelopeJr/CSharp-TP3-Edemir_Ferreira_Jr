using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Infrastructure;
using Domain;


namespace Produto
{
    class Program
    {
        static void Main(string[] args)
        {
            ///REFATORAR MÉTODO MAIN EM MÉTODOS MENORES

            CultureInfo.DefaultThreadCurrentCulture = CultureInfo.CreateSpecificCulture("pt-BR");
            const string pressioneQualquerTecla = "Pressione qualquer tecla para exibir o menu principal ...";
            var produtos = new ProdutoRepository();

            string opcao;
            do
            {
                Console.Clear();
                Console.WriteLine("*** Gerenciador de produtos *** ");
                Console.WriteLine("1 - Pesquisar produto:");
                Console.WriteLine("2 - Adicionar produto:");
                Console.WriteLine("3 - Sair:");
                Console.WriteLine("\nEscolha uma das opções acima: ");

                opcao = Console.ReadLine();
                if (opcao == "1")
                {
                    Console.WriteLine("Informe nome do produto ou parte do nome do produto que deseja pesquisar:");
                    var termoDePesquisa = Console.ReadLine();
                    var entidadesEncontradas = produtos.Pesquisar(termoDePesquisa);

                    if (entidadesEncontradas.Count > 0)
                    {
                        Console.WriteLine("Selecione uma das opções abaixo para visualizar os dados do produto encontrados:");
                        for (var index = 0; index < entidadesEncontradas.Count; index++)
                            Console.WriteLine($"{index} - {entidadesEncontradas[index]._NomeProduto}");

                        if (!ushort.TryParse(Console.ReadLine(), out var indexAExibir) || indexAExibir >= entidadesEncontradas.Count)
                        {
                            Console.WriteLine($"Opção inválida! {pressioneQualquerTecla}");
                            Console.ReadKey();
                            continue;
                        }

                        if (indexAExibir < entidadesEncontradas.Count)
                        {
                            var entidade = entidadesEncontradas[indexAExibir];

                            Console.WriteLine("Dados do produto");
                            Console.WriteLine($"Nome do produto: {entidade._NomeProduto}");
                            Console.WriteLine($"Data de fabricação: {entidade._Fabricacao:dd/MM/yyyy}");
                            Console.WriteLine($"Características do produto: {entidade._Caracteristicas}");
                            Console.WriteLine($"Armazenamento do produto: {entidade._Armazenamento}");
                            Console.WriteLine($"Quanditdade de produtos: {entidade._Quantidade}");
                            Console.WriteLine($"Garantia do produtos: {produtos.Garantia(entidade._Fabricacao)}");

                            
                            Console.Write(pressioneQualquerTecla);
                            Console.ReadKey();
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Não foi encontrado nenhuma produto! {pressioneQualquerTecla}");
                        Console.ReadKey();
                    }
                }
                else if (opcao == "2")
                {
                    var cadastroProduto = new ProdutoModel();
                    
                    Console.WriteLine("Informe nome do produto que deseja adicionar:"); 
                    cadastroProduto._NomeProduto = Console.ReadLine();

                    //Console.WriteLine("Informe data de fabricação do produto que deseja adicionar:");
                    //cadastroProduto._Fabricacao = Console.ReadLine();

                    Console.WriteLine("Informe caracteríticas do produto que deseja adicionar:");
                    cadastroProduto._Caracteristicas = Console.ReadLine();

                    Console.WriteLine("Informe capacidade de armazenamento do produto que deseja adicionar:");

                    if (!int.TryParse(Console.ReadLine(), out cadastroProduto._Armazenamento))
                    {
                        Console.WriteLine($"Informação inválida! Dados descartados! {pressioneQualquerTecla}");
                        Console.ReadKey();
                        continue;
                    }

                                       
                    Console.WriteLine("Informe quantidade de produto que deseja adicionar:");
                    
                    if (!int.TryParse(Console.ReadLine(), out cadastroProduto._Quantidade))
                    {
                        Console.WriteLine($"Quantidade inválida! Dados descartados! {pressioneQualquerTecla}");
                        Console.ReadKey();
                        continue;
                    }


                    Console.WriteLine("Informe a data de fabricação (formato dd/MM/yyyy):"); 
                    if (!DateTime.TryParse(Console.ReadLine(), out cadastroProduto._Fabricacao))
                    {
                        Console.WriteLine($"Data inválida! Dados descartados! {pressioneQualquerTecla}");
                        Console.ReadKey();
                        continue;
                    }

                    Console.WriteLine("Os dados estão corretos?");
                    Console.WriteLine($"Nome do produto: {cadastroProduto._NomeProduto}");
                    Console.WriteLine($"Data de fabricação: {cadastroProduto._Fabricacao:dd/MM/yyyy}");
                    Console.WriteLine("1 - Sim \n2 - Não");

                    var opcaoParaAdicionar = Console.ReadLine();
                    if (opcaoParaAdicionar == "1")
                    {
                        produtos.Adicionar(cadastroProduto);

                        Console.WriteLine($"Dados adicionados com sucesso! {pressioneQualquerTecla}");
                        Console.ReadKey();
                    }
                    else if (opcaoParaAdicionar == "2")
                    {
                        Console.WriteLine($"Dados descartados! {pressioneQualquerTecla}");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine($"Opção inválida! {pressioneQualquerTecla}");
                        Console.ReadKey();
                    }
                }
                else if (opcao == "3")
                {
                    Console.Write("Saindo do programa... ");
                }
                else if (opcao != "3")
                {
                    Console.Write($"Opcao inválida! Escolha uma opção válida. {pressioneQualquerTecla}");
                    Console.ReadKey();
                }

            } while (opcao != "3");
        }
    }
}
