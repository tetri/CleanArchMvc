using CleanArchMvc.Domain.Validation;

namespace CleanArchMvc.Domain.Entities
{
    public sealed class Pais : Entity
    {
        public string Name { get; private set; }
        public string Sigla { get; private set; }

        public Pais(string name, string sigla)
        {
            ValidateDomain(name, sigla);
        }

        public Pais(int id, string name, string sigla)
        {
            DomainExceptionValidation.When(id < 0, "Invalid Id value.");
            Id = id;
            ValidateDomain(name, sigla);
        }

        public void Update(string name, string sigla)
        {
            ValidateDomain(name, sigla);
        }

        //public ICollection<Estado> Estados { get; set; }

        private void ValidateDomain(string name, string sigla)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name),
                "Invalid name. Name is required.");

            DomainExceptionValidation.When(name.Length < 3,
                "Invalid name, too short, minimum 3 characters.");

            //TODO validar a sigla

            Name = name;
            Sigla = sigla;
        }
    }
}
