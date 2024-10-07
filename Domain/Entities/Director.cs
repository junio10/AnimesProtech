using System.Text.Json.Serialization;

namespace Domain.Entities;

public class Director
{
    public int Id { get; set; }

    public required string Name { get; set; }
    [JsonIgnore]
    public List<Anime>? Animes { get; set; }
}
