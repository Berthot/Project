using CEP.Domain.Entities;

namespace CEP.Domain.IRepository
{
    public interface ICepApiRepository
    {
        Cep GetCep(string cep);
    }
}