using CadastroDePetsApi.Persistencia.Entidades;

namespace CadastroDePetsApi.Apresentacao.Servico.Interfaces
{
    public interface IProprietarioServico
    {
        bool CadastrarProprietario(Proprietario proprietario);
    }
}