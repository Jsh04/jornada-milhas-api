

using JornadaMilhas.Core.Indices;

namespace JornadaMilhas.Core.Interfaces;

public interface IUnitOfWork
{
    IRepository<DestinosIndex> DestinoRepository { get; }
    IRepository<DepoimentosIndex> DepoimentoRepository { get; }
    IRepository<UsuarioIndex> UsuarioRepository { get; }

}
