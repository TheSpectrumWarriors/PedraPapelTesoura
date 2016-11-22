using System;
using System.Collections.Generic;
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
        static void Main(string[] args) {
            #region Variáveis
            // Array com as 3 opções (necessário para o random)
            string[] opções = new string[3] {"Pedra", "Papel", "Tesoura"};
            String escolhaDoUtilizador;
            String escolhaDoComputador;
            int resultado;
            #endregion

            #region Questão
            //usar string escolhaDoUtilizador
            Console.Write("Escolhe Pedra/Papel/Tesoura: ");
            escolhaDoUtilizador = Console.ReadLine();

            if escolhaDoUtilizador = "Pedra"

            #endregion

            #region Random
            //usar string escolhaDoComputador
            int x = new Random().Next(1 , 101);
            if (x < 34) {
                escolhaDoComputador = opções[0];
            } else if(x < 67){
                escolhaDoComputador = opções[1];
            } else {
                escolhaDoComputador = opções[2];
            }
            Console.WriteLine("O Computador escolheu: " + escolhaDoComputador);
            #endregion

            #region Verficação
            //Usar ambas as stringss de escolha e verificar quem ganha ou se há empate. Dizer primeiro ao utilizador qual foi a escolha do PC
            // Vou fazer isto de uma maneira muito feia porque ainda não tenho a confiança necessária para andar a usar arrays multi-dimensionais em c#

            // Para o caso de ser preciso mais tarde:
            // resultado: 0 - Empate, 1 - Utilizador Ganha, 2 - Computador Ganha

            if (escolhaDoComputador == escolhaDoUtilizador) {
                resultado = 0;
                Console.WriteLine();
                Console.WriteLine("Empate! Ninguém ganha.");
            }

            else if (escolhaDoComputador == "Pedra") {
                Console.WriteLine();
                if (escolhaDoUtilizador == "Tesoura"){
                    resultado = 2;
                    Console.WriteLine("O Computador Ganha! A Pedra esmaga a Tesoura.");
                }
                else if (escolhaDoUtilizador == "Papel"){
                    resultado = 1;
                    Console.WriteLine("O Utilizador Ganha! O Papel embrulha a Pedra.");
                }
            }

            else if (escolhaDoComputador == "Papel") {
                Console.WriteLine();
                if (escolhaDoUtilizador == "Pedra"){
                    resultado = 2;
                    Console.WriteLine("O Computador Ganha! O Papel embrulha a Pedra");
                }
                else if (escolhaDoUtilizador == "Tesoura"){
                    resultado = 1;
                    Console.WriteLine("O Utilizador Ganha! A Tesoura corta o Papel");
                }
            }

            else if (escolhaDoComputador == "Tesoura") {
                Console.WriteLine();
                if (escolhaDoUtilizador == "Papel"){
                    resultado = 2;
                    Console.WriteLine("O Computador Ganha! A Tesoura corta o Papel");
                }
                else if (escolhaDoUtilizador == "Pedra"){
                    resultado = 1;
                    Console.WriteLine("O Utilizador Ganha! A Pedra esmaga a Tesoura");
                }
            }

            #endregion
        }
    }
}