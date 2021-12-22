using System;
using System.Collections.Generic;

namespace CEP.Service.Helpers
{
    public static class MenuHelper
    {


        public static void PrintMainMenu()
        {
            var menus = new List<string>()
            {
                "( 0 ) Sair",
                "( 1 ) Gostaria de consultar um logradouro da base de dados?",
                "( 2 ) Gostaria de consultar por CEP?",
                "( 3 ) Gostaria de consultar todos os CEP de determinado UF?",
                "( 4 ) Gostaria da listagem de Cep e Logradouros cadastrados no sistema?",
            };

            Console.WriteLine("\n \n");
            foreach (var text in menus)
                Console.WriteLine($"{text}");
        }
        
        public static void PressToBackToMenu()
        {
            Console.WriteLine("Pressione enter para voltar ao menu!");
            Console.ReadLine();

        }

        public static void PrintLine()
        {
            Console.WriteLine("-------------------------------------------------------");
        }
    }
}

// 1. Perguntar se o usuário quer consultar se logradouro existe na base
// 2. Consultar por um cep novo
// 3. Validar CEP existente
// 4. Retornar os dados do CEP informado no início para o usuário
// 5. Listar todos os CEPs por UF da base
// 6. Deseja visualizar todos os CEPs alguma UF? Se sim, informar UF, se não, informar sair.
