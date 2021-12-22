using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using CEP.Domain.Entities;
using CEP.Domain.IRepository;
using CEP.Domain.IService;

namespace CEP.Service.Services
{
    public class CepService : ICepService
    {
        private readonly ICepApiRepository _cepApiRepository;
        private readonly ICepRepository _cepRepository;
        private readonly Regex _cepRegex;

        public CepService(ICepRepository cepRepository, ICepApiRepository cepApiRepository)
        {
            _cepApiRepository = cepApiRepository;
            _cepRepository = cepRepository;
            _cepRegex = new Regex(@"^\d{8}$");
        }

        public Cep SearchByStreet(string street)
        {
            var data = street.Trim().ToLower();
            return _cepRepository.GetCepByStreet(data);
            // return "";
        }

        public Cep SearchByCep(string cep)
        {
            cep = CleanUpCep(cep);

            if (ValidateCep(cep) == false) return default;

            var cepInDb = _cepRepository.GetCepByCode(cep);
            if (cepInDb != default) return cepInDb;
            
            var cepEntity = _cepApiRepository.GetCep(cep);

            if (cepEntity == default)
            {
                Console.WriteLine($"CEP: [ {cep} ] não encontrado");
                return default;
            }

            cepEntity.Code = cepEntity.Code?.Replace("-", "");
            _cepRepository.AddNewCep(cepEntity);

            return cepEntity;
        }

        private static string CleanUpCep(string cep)
        {
            cep = cep.Replace(".", "");
            cep = cep.Replace("-", "");
            cep = cep.Replace(" ", "");
            return cep;
        }

        public bool ValidateCep(string cep)
        {
            if (_cepRegex.IsMatch(cep))
                return true;
            Console.WriteLine($"CEP: [ {cep} ] invalido insira novamente");
            return false;
        }

        public bool UfIsValid(string uf)
        {
            if (string.IsNullOrEmpty(uf)) return false;
            return new List<string>()
            {
                "AC", "AL", "AP", "AM", "BA",
                "CE", "DF", "ES", "GO", "MA",
                "MT", "MS", "MG", "PA", "PB",
                "PR", "PE", "PI", "RJ", "RN",
                "RS", "RO", "RR", "SC", "SP",
                "SE", "TO"
            }.Contains(uf.ToUpper());
        }

        public List<Cep> GetAllCep()
        {
            var cep = _cepRepository.GetAllCep();
            if (cep == default || cep.Count == 0)
                return default;
            return cep;
        }

        public List<Cep> GetAllCepByUf(string uf)
        {
            uf = uf.ToUpper();
            if (UfIsValid(uf) == false)
            {
                Console.WriteLine($"UF: {uf} não existe");
                return default;
            }

            var ceps = _cepRepository.GetAllCepByUf(uf);

            if (ceps != default && ceps.Count != 0) return ceps;
            
            Console.WriteLine($"Nenhum cep foi encontrado para o uf [ {uf} ]");
            return default;


        }
    }
}