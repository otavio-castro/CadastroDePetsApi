﻿using CadastroDePetsApi.Apresentacao.DTOs;
using CadastroDePetsApi.Persistencia.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace CadastroDePetsApi.Apresentacao.Servico.Interfaces;

public interface IAnimalServico
{
    bool CadastrarAnimal(Animal animal);

    ActionResult<IEnumerable<AnimalDto>> BuscarAnimais();

    ActionResult<IEnumerable<AnimalDto>> OrdenarAlfabetico();

    ActionResult<AnimalDto> BuscarAnimalPorId(int id);

    bool DeletarPetPorId(int id);

    bool AlterarInformacoesPet(Animal animalAtualizado);
}