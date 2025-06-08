using System.ComponentModel.DataAnnotations.Schema;

namespace CadastroDePetsApi.Persistencia.Entidades;

[Table("Animais")]
public class Animal
{
    public int AnimalId { get; set; }
    public string? Nome { get; set; }
    public int Idade { get; set; }
    public string? Genero { get; set; }
    public string? Raca { get; set; }

    [ForeignKey("Proprietario")]
    public int ProprietarioId { get; set; }
}