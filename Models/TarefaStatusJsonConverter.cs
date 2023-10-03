using System.Text.Json;
using System.Text.Json.Serialization;

namespace TarefasBackEnd.Models
{
    public class TarefaStatusJsonConverter : JsonConverter<TarefaStatus>
    {

        public override TarefaStatus Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            
            throw new NotImplementedException();
        }

        public override void Write(Utf8JsonWriter writer, TarefaStatus value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString()); // Serializa o enum como uma string
        }


    }
}
