using System.Collections.Generic;
using CEP.Domain.Entities;

namespace CEP.Domain.IService
{
    public interface ICepService
    {
        Cep SearchByStreet(string street);

        Cep SearchByCep(string cep);

        bool ValidateCep(string cep);
        
        bool UfIsValid(string uf);

        List<Cep> GetAllCep();
        
        List<Cep> GetAllCepByUf(string uf);
        
        
    }
}