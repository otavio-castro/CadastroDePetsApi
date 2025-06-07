using System.Xml.Serialization;

namespace CadastroDePetsApi.Context
{
    public class AppXmlContext
    {
        public void SalvarDados<T>(string filePath, List<T> data)
        {
            XmlSerializer serializer = new(typeof(List<T>));
            using var stream = new FileStream(filePath, FileMode.Create);

            serializer.Serialize(stream, data);
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
