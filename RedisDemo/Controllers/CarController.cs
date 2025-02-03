using Microsoft.AspNetCore.Mvc;
using RedisDemo.Data.Models.Car;
using RedisDemo.Repo.CarRepo.CarRepo;

namespace RedisDemo.Controllers
{
    // Car Controller
    [ApiController]
    [Route("api/cars")]
    public class CarController : ControllerBase
    {
        private readonly ICarRepo _carService;

        public CarController(ICarRepo carService)
        {
            _carService = carService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCars()
        {
            return Ok(await _carService.GetAllCarsAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCarById(int id)
        {
            var car = await _carService.GetCarByIdAsync(id);
            return car is not null ? Ok(car) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> AddCar([FromBody] Car car)
        {
            await _carService.AddCarAsync(car);
            return CreatedAtAction(nameof(GetCarById), new { id = car.Id }, car);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCar(int id, [FromBody] Car car)
        {
            var updated = await _carService.UpdateCarAsync(id, car);
            return updated ? NoContent() : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCar(int id)
        {
            var deleted = await _carService.DeleteCarAsync(id);
            return deleted ? NoContent() : NotFound();
        }
    }

}
