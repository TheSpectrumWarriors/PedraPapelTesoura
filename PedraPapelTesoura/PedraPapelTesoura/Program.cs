using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**
4 Fases Principais:

1. Perguntar ao utilizador qual das 3 opções ele escolhe
2. Verificar que o utilizador respondeu com uma das três opções
3. Escolher uma das três opções ao acaso
4. Dizer ao utilizador qual é que o PC escolheu e, de acordo com as reras do jogo, verificar quem ganhou, ou se houve empate. 
*/

namespace PedraPapelTesoura {
    class Program {
        static void Main(string[] args)
        {
            #region Variáveis
            // Array com as 3 opções (necessário para o random)
            string[] opções = new string[6] { "PEDRA", "PAPEL", "TESOURA", "1", "2", "3" };
            String escolhaDoUtilizador;
            String escolhaDoComputador;
            int resultado = 0;
            int userPoints = 0;
            int computerPoints = 0;
            bool playing = true;
            bool secondTime = false;
            String nome;
            String highscore;
            #endregion

            do
            {
                #region mostrarHighscore
                // chamar lerFicheiro() com argumento 1 devolve o nome
                nome = lerFicheiro(1);
                // chamar lerFicheiro() com argumento 2 devolve a pontuação no formato pontosUtil-pontosPC. Exemplo: 21-8
                highscore = lerFicheiro(2);

                // Lógica: por baixo desta linha
                #endregion

                #region Questão
                escolhaDoUtilizador = fazerPergunta(opções, userPoints, computerPoints, secondTime);
                secondTime = true;
                #endregion

                #region Random
                //usar string escolhaDoComputador
                int x = new Random().Next(1, 101);
                if (x < 34)
                {
                    escolhaDoComputador = "Pedra";
                }
                else if (x < 67)
                {
                    escolhaDoComputador = "Papel";
                }
                else
                {
                    escolhaDoComputador = "Tesoura";
                }
                Console.WriteLine("O Computador escolheu: " + escolhaDoComputador);
                #endregion

                #region Verficação
                // Vou fazer isto de uma maneira muito feia porque ainda não tenho a confiança necessária para andar a usar arrays multi-dimensionais em c#

                // Para o caso de ser preciso mais tarde:
                // resultado: 0 - Empate, 1 - Utilizador Ganha, 2 - Computador Ganha

                if (escolhaDoUtilizador == "1") { escolhaDoUtilizador = "Pedra".ToUpper(); }
                if (escolhaDoUtilizador == "2") { escolhaDoUtilizador = "Papel".ToUpper(); }
                if (escolhaDoUtilizador == "3") { escolhaDoUtilizador = "Tesoura".ToUpper(); }

                if (escolhaDoComputador.ToUpper() == escolhaDoUtilizador)
                {
                    resultado = 0;
                    Console.WriteLine();
                    Console.WriteLine("Empate! Ninguém ganha.");
                }
                else if (escolhaDoComputador == "Pedra")
                {
                    Console.WriteLine();
                    if (escolhaDoUtilizador == "Tesoura".ToUpper())
                    {
                        resultado = 2;
                        Console.WriteLine("O Computador Ganha! A Pedra esmaga a Tesoura.");
                    }
                    else if (escolhaDoUtilizador == "Papel".ToUpper())
                    {
                        resultado = 1;
                        Console.WriteLine("O Utilizador Ganha! O Papel embrulha a Pedra.");
                    }
                }
                else if (escolhaDoComputador == "Papel")
                {
                    Console.WriteLine();
                    if (escolhaDoUtilizador == "Pedra".ToUpper())
                    {
                        resultado = 2;
                        Console.WriteLine("O Computador Ganha! O Papel embrulha a Pedra");
                    }
                    else if (escolhaDoUtilizador == "Tesoura".ToUpper())
                    {
                        resultado = 1;
                        Console.WriteLine("O Utilizador Ganha! A Tesoura corta o Papel");
                    }
                }
                else if (escolhaDoComputador == "Tesoura")
                {
                    Console.WriteLine();
                    if (escolhaDoUtilizador == "Papel".ToUpper())
                    {
                        resultado = 2;
                        Console.WriteLine("O Computador Ganha! A Tesoura corta o Papel");
                    }
                    else if (escolhaDoUtilizador == "Pedra".ToUpper())
                    {
                        resultado = 1;
                        Console.WriteLine("O Utilizador Ganha! A Pedra esmaga a Tesoura");
                    }
                }

                if (resultado == 1)
                {
                    userPoints = userPoints + 1;
                }

                else if (resultado == 2)
                {
                    computerPoints = computerPoints + 1;
                }

                bool validKey = false;

                do
                {
                    Console.WriteLine();
                    Console.WriteLine("Clica Enter para continuar a jogar!");
                    Console.WriteLine("Ou X para sair do jogo.");
                    ConsoleKeyInfo pressedKey = Console.ReadKey();
                    if (pressedKey.Key == ConsoleKey.X)
                    {
                        // Esta parte do código é executada se o utilizador quiser sair do jogo, antes de ele sair vamos, SE a pontuação dele for novo recorde, peruntar-lhe o nome e gravar o nome e pontuação no ficheiro
                        #region gravarHighscore
                        // PRIMEIRO:
                        // Vefificar se é highscore
                        // Se sim, perguntar nome, etc...

                        //Como verificar se é highscore?
                        // chamar lerFicheiro() com argumento 1 devolve o nome
                        // String nome = lerFicheiro(1);
                        // chamar lerFicheiro() com argumento 2 devolve a pontuação no formato pontosUtil-pontosPC. Exemplo: 21-8
                        // String highscore = lerFicheiro(2);
                        // Comparar pontuação com a atual é o que tens q fazer
                        // A pontuação atual é dada pelas variáveis userPoints e computerPoints, ambas integers

                        // A string pontuação é, por exemplo: "21-8". Como separar os pontos do user dos do PC na string tradução?
                        // A seguinte linha de código separa a string pontuação entre: "parte que vem antes do traço"  e "parte que vem depois do traço" e guarda ambas as partes como strings num array
                        // String[] subStrings = pontuação.Split('-');
                        // Para aceder à primeira parte (no exemplo: 21) fazemos String blabla = subStrings[0] porque essa parte é guardada como a primeira string do array, ou seja, o elemento de índice 0
                        // Para aceder à segunda parte (no exemplo: 8) fazemos String bleble = subStrings[1]

                        // Para comparar o recorde em vigor (vindo do ficheiro) e a pontuação atual (vinda das variáveis):
                        // Como o recorde está guardado em duas STRINGS e a pontuação atual em dois INTEGERS vais ter de pesquisar na net como converter String para Integer para transformar as strings do recorde em números para os puderes comparar com os Integers de pontuação atual

                        // PS: Não sei se a nossa definição de recorde vai ser:
                        // 1 - Maior número de pontos do utilizador (nesse caso n precisas das strings/ints que têm a pontuação do PC)
                        // ou 2 - Maior diferença de pontos entre o utilizador e o PC se o utilizador ganhou (precisas de tudo)
                        // Escolhe

                        // Qualquer dúvida estou no messenger para tentar ajudar.
                        // Boa Sorte!


                        String Nome = "x"; // aqui deve estar o input do utilizador
                        String pontuação = "t"; // Tem que ser String! Procura como converter int para String se for necessário.
                        // Para gravar no ficheiro:
                        gravarFicheiro(Nome, pontuação);
                        // Se tiveres a ideia de gravar mais do que só o nome e pontuação avisa que eu terei que mudar os métodos lerFicheiro() e gravarFicheiro()
                        #endregion

                        playing = false;
                        validKey = true;
                    }
                    else if (pressedKey.Key == ConsoleKey.Enter)
                    {
                        //TODO: Verificar se é highscore novo e avisar o utilizador.
                        validKey = true;
                    }
                    else
                    {
                        //Repeats until validKey = true
                    }

                } while (validKey == false);

                Console.Clear();
                Console.WriteLine("User: " + userPoints + "  vs  PC: " + computerPoints);
                Console.WriteLine("");
                #endregion
            } while (playing == true);

            Console.ReadKey();
        }

        static String fazerPergunta(string[] opções, int userPoints, int computerPoints, bool secondTime)
        {
            //usar string escolhaDoUtilizador
            Console.Write("Escolhe Pedra/Papel/Tesoura: ");
            String escolhaDoUtilizador = Console.ReadLine();

            if (!(opções.Contains(escolhaDoUtilizador.ToUpper()))) {
                Console.WriteLine();
                Console.Clear();
                if (secondTime == true) {
                    Console.WriteLine("User: " + userPoints + "  vs  PC: " + computerPoints);
                    Console.WriteLine("");
                }
                Console.WriteLine("Erro! Não escreveu nenhuma das opções!");
                escolhaDoUtilizador = fazerPergunta(opções, userPoints, computerPoints, secondTime);
            }

            secondTime = true;
            return escolhaDoUtilizador.ToUpper();
        }

        static void gravarFicheiro(String nome, String pontuação){
            var path = Path.Combine(Directory.GetCurrentDirectory(), "\\Spectrum\\resultado.txt");
            // Exemplo de string a gravar no ficheiro: Tiago#21-8
            string createText = nome + "#" + pontuação + Environment.NewLine;
            File.WriteAllText(path, createText);
        }

        static String lerFicheiro(int mode) {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "\\Spectrum\\resultado.txt");
            string text = File.ReadAllText(path, Encoding.UTF8);
            // Exemplo de string a ler do ficheiro: Tiago#21-8

            String[] subStrings = text.Split('#');

            if (mode == 1) {
                //devolver nome
                return subStrings[0];
            }
            // Se mode for igual a 2:
            else {
                //devolver pontuação - Formato: "PontuaçãoUtiizador"-"PontuaçãoPC" - exemplo: 21-8
                return subStrings[1];
            }
        }
    }
}