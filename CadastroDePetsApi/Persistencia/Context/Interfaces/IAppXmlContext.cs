namespace CadastroDePetsApi.Persistencia.Context.Interfaces
{
    public interface IAppXmlContext
    {
        void SalvarDados<T>(string filePath, List<T> data);
        List<T> CarregarDados<T>(string filePath);
        bool LimparDados<T>(string filePath);
    }
}
