namespace CadastroDePetsApi.Apresentacao.DTOs;

public class AnimalDto
{
    public int AnimalId { get; set; }
    public string? Nome { get; set; }
    public int Idade { get; set; }
    public string? Genero { get; set; }
    public string? Raca { get; set; }
    public ProprietarioDto? Proprietario { get; set; }
}
