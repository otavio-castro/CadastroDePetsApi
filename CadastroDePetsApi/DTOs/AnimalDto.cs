namespace CadastroDePetsApi.DTOs;

public class AnimalDto
{
    public int AnimalId { get; set; }
    public string? Nome { get; set; }
    public int Idade { get; set; }
    public char Genero { get; set; }
    public string? Raca { get; set; }
    public ProprietarioDto? Proprietario { get; set; }
}
