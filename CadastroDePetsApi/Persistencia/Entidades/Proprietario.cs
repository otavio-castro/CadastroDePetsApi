﻿using System.ComponentModel.DataAnnotations.Schema;

namespace CadastroDePetsApi.Persistencia.Entidades;

[Table("Proprietarios")]
public class Proprietario
{
    public int ProprietarioId { get; set; }
    public string? Nome { get; set; }
    public string? Endereco { get; set; }
    public string? Telefone { get; set; }
}