using System;
using CEP.CLI.Extensions;
using CEP.Domain.IService;
using CEP.Service.Helpers;
using Microsoft.Extensions.DependencyInjection;

namespace CEP.CLI
{
    static class Program
    {
        private static ICepService _cepService;

        static void Main(string[] args)
        {
            DependencyInjection();

            var option = "";
            while (option != "0")
            {
                MenuHelper.PrintMainMenu();
                Console.Write("Opção: ");
                option = Console.ReadLine();
                switch (option)
                {
                    case "1":
                        ConsultStreet();
                        break;
                    case "2":
                        ConsultByCep();
                        break;
                    case "3":
                        SearchByUf();
                        break;
                    case "4":
                        ShowAllCep();
                        break;
                    default:
                        continue;
                }
            }
        }

        private static void ConsultStreet()
        {
            Console.Write("Insira o logradouro: ");
            var street = Console.ReadLine();
            if (string.IsNullOrEmpty(street))
            {
                Console.WriteLine("O campo de logradouro nao pode ser vazio");
                MenuHelper.PressToBackToMenu();
                return;
            }

            var cep = _cepService.SearchByStreet(street);
            if (cep == default)
            {
                Console.WriteLine("Logradouro não encontrado na base");
                MenuHelper.PressToBackToMenu();
                return;
            }

            Console.WriteLine($"{cep}");
            MenuHelper.PressToBackToMenu();
        }

        private static void ConsultByCep()
        {
            var acc = 0;
            while (acc != 3)
            {
                Console.Write("Insira o CEP: ");
                var cepString = Console.ReadLine();
                if (string.IsNullOrEmpty(cepString))
                {
                    Console.Write($"CEP [ {cepString} ]invalido");
                    acc++;
                    continue;
                }

                var cep = _cepService.SearchByCep(cepString);
                if (cep != default)
                {
                    MenuHelper.PrintLine();
                    Console.WriteLine($"{cep}");
                    MenuHelper.PrintLine();
                    MenuHelper.PressToBackToMenu();
                    return;
                }

                acc++;
            }
        }

        private static void SearchByUf()
        {
            Console.Write("Insira o UF: ");
            var ufString = Console.ReadLine();
            if (string.IsNullOrEmpty(ufString))
            {
                Console.WriteLine("O campo de UF nao pode ser vazio");
                MenuHelper.PressToBackToMenu();
                return;
            }

            var cepLists = _cepService.GetAllCepByUf(ufString);

            if (cepLists == default) MenuHelper.PressToBackToMenu();

            MenuHelper.PrintLine();
            foreach (var cep in cepLists!)
                Console.WriteLine(cep);
            MenuHelper.PrintLine();

            MenuHelper.PressToBackToMenu();
        }

        private static void ShowAllCep()
        {
            var cepLists = _cepService.GetAllCep();

            if (cepLists == default)
            {
                Console.WriteLine("Nenhum CEP cadastrado no sistema");
                MenuHelper.PressToBackToMenu();
            }

            MenuHelper.PrintLine();
            foreach (var cep in cepLists!)
                Console.WriteLine(cep);
            MenuHelper.PrintLine();

            MenuHelper.PressToBackToMenu();
        }

        private static void DependencyInjection()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.ConfigureServices();
            var serviceProvider = serviceCollection.BuildServiceProvider();

            _cepService = serviceProvider.GetService<ICepService>();
        }

        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddServices();
            services.AddRepositories();
            services.AddDbConnection("DB");
        }
    }
}