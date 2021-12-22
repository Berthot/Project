using System.Text.Json.Serialization;
using CEP.Domain.Entities.Base;

namespace CEP.Domain.Entities
{
    public class Cep : EntityBase
    {
        [JsonPropertyName("cep")]
        public string Code { get; set; }
        public string Logradouro { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Localidade { get; set; }
        public string Uf { get; set; }
        public string Ibge { get; set; }
        public string Gia { get; set; }
        public string Ddd { get; set; }
        public string Siafi { get; set; }

        public override string ToString()
        {
            return $"CEP: {Code} | Localidade: {Localidade}/{Uf} | Logradouro: {Logradouro} | Bairro: {Bairro}";
        }
    }

    //     [Id]          INT            IDENTITY (1, 1) NOT NULL,
    //     [cep]         CHAR (9)       NULL,
    //     [logradouro]  NVARCHAR (500) NULL,
    //     [complemento] NVARCHAR (500) NULL,
    //     [bairro]      NVARCHAR (500) NULL,
    //     [localidade]  NVARCHAR (500) NULL,
    //     [uf]          CHAR (2)       NULL,
    //     [unidade]     BIGINT         NULL,
    //     [ibge]        INT            NULL,
    //     [gia]         NVARCHAR (500) NULL
    // );


}