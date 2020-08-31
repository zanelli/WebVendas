using System.Collections.Generic;

namespace Dominio.Entidades.Interfaces
{
    public interface IServicoCrud<TEntidade>
        where TEntidade: class
    {
        IEnumerable<TEntidade> Listagem();
        void Cadastrar(TEntidade categoria);
        TEntidade CarregarRegistro(int id);
        void Excluir(int id);
    }
}