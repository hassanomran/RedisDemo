using RedisDemo.Data.Models.Car;

namespace RedisDemo.Repo.CarRepo.CarRepo
{
    public interface ICarRepo
    {
        Task<IEnumerable<Car>> GetAllCarsAsync();
        Task<Car?> GetCarByIdAsync(int id);
        Task AddCarAsync(Car car);
        Task<bool> UpdateCarAsync(int id, Car car);
        Task<bool> DeleteCarAsync(int id);
    }
}
