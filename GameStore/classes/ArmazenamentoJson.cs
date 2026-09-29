using System.IO;
using System.Web.Script.Serialization;

namespace GameStore.Classes
{
    public static class ArmazenamentoJson
    {
        private static JavaScriptSerializer serializador =
            new JavaScriptSerializer();

        public static void Salvar<T>(string caminho, T dados)
        {
            string json = serializador.Serialize(dados);
            File.WriteAllText(caminho, json);
        }

        public static T Carregar<T>(string caminho)
        {
            string json = File.ReadAllText(caminho);
            return serializador.Deserialize<T>(json);
        }
    }
}