using System.Collections.Generic;
using CEP.Domain.Entities;

namespace CEP.Domain.IRepository
{
    public interface ICepRepository
    {
        List<Cep> GetAllCep();
        List<Cep> GetAllCepByUf(string uf);
        Cep GetCepByStreet(string street);
        void AddNewCep(Cep cepEntity);
        Cep GetCepByCode(string cep);
    }
}