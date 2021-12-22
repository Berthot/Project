using System.Collections.Generic;
using System.Linq;
using CEP.Domain.Entities;
using CEP.Domain.IRepository;
using CEP.Infra.Data;

namespace CEP.Infra.Repositories
{
    public class CepRepository : ICepRepository
    {
        private readonly Context _context;

        public CepRepository(Context context)
        {
            _context = context;
        }
        public List<Cep> GetAllCep()
        {
            return _context.Ceps.ToList();
        }

        public List<Cep> GetAllCepByUf(string uf)
        {
            return _context.Ceps.Where(x=>x.Uf == uf.ToUpper()).ToList();
        }

        public Cep GetCepByStreet(string street)
        {
            return _context.Ceps.FirstOrDefault(x => x.Logradouro.ToLower() == street.ToLower());

        }

        public void AddNewCep(Cep cepEntity)
        {
            _context.Add(cepEntity);
            _context.SaveChanges();
        }

        public Cep GetCepByCode(string cep)
        {
            return _context.Ceps.FirstOrDefault(x => x.Code == cep);

        }
    }
}