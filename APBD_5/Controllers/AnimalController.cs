using APBD_5.Model;
using APBD_5.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace APBD_5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalController : ControllerBase
    {
        private IAnimalService _animalService;

        public AnimalController(IAnimalService animalService)
        {
            _animalService = animalService;
        }

        [HttpGet]
        public IActionResult GetAnimalsList(string? orderBy)
        {
            var animals = _animalService.GetAnimals(orderBy);
            return Ok(animals);
        }

        [HttpGet("{id}")]
        public IActionResult GetAnimal(int id)
        {
            var animal = _animalService.GetAnimal(id);
            if (animal == null)
            {
                return NotFound();
            }
            return Ok(animal);
        }

        [HttpPost]
        public IActionResult CreateAnimal(Animal animal)
        {
            try
            {
                var createdAnimalId = _animalService.CreateAnimal(animal);
                return CreatedAtAction(nameof(GetAnimal), new { id = createdAnimalId }, animal);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateAnimal(int id, Animal animal)
        {
            if (id != animal.Id)
            {
                return BadRequest("ID in URL does not match ID in animal object.");
            }

            try
            {
                _animalService.UpdateAnimal(animal);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAnimal(int id)
        {
            try
            {
                _animalService.DeleteAnimal(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
