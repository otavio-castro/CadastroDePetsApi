using System.Xml.Serialization;
using CadastroDePetsApi.Context.Interfaces;

namespace CadastroDePetsApi.Context
{
    public class AppXmlContext : IAppXmlContext
    {
        public void SalvarDados<T>(string filePath, List<T> data)
        {
            XmlSerializer serializer = new(typeof(List<T>));
            using var stream = new FileStream(filePath, FileMode.Create);

            serializer.Serialize(stream, data);

            //TODO, se o arquivo ja existir deve usar o já existente
        }

        public List<T> CarregarDados<T>(string filePath)
        {
            if (!File.Exists(filePath))
                return new List<T>();

            XmlSerializer serializer = new(typeof(List<T>));
            using var stream = new FileStream(filePath, FileMode.Open);

            return serializer.Deserialize(stream) as List<T> ?? new List<T>();
        }
    }
}
