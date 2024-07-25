using backend.ViewModels;

namespace backend.Service;

public interface IPessoaService
{ 
        IEnumerable<PessoaViewModel> GetAll();

        IEnumerable<PessoaViewModel> GetById(Guid id);

        void Add(PessoaViewModel pessoa);
        void Update(PessoaViewModel pessoa);


}
