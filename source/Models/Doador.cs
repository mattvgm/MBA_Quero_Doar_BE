using MongoDB.Bson;
using source.Service.Interfaces;
using System;

namespace source.Models
{
    public class Doador : IModelBase
    {
        public Doador()
        {
            _id = ObjectId.GenerateNewId();
        }

        public ObjectId _id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Telefone { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}