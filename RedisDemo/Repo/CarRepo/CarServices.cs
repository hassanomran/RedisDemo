using RedisDemo.Data.Models.Car;
using RedisDemo.Repo.CarRepo.CarRepo;
using RedisDemo.Repo.RedisRepo;

namespace RedisDemo.Repo.CarRepo
{
    public class CarServices : ICarRepo
    {
        private readonly IRedisCacheService _cacheService;
        private const string CacheKey = "cars";

        public CarServices(IRedisCacheService cacheService)
        {
            _cacheService = cacheService;
        }
        public async Task<IEnumerable<Car>> GetAllCarsAsync()
        {
            return await _cacheService.GetCacheAsync<IEnumerable<Car>>(CacheKey) ?? new List<Car>();
        }

        public async Task<Car?> GetCarByIdAsync(int id)
        {
            var cars = await GetAllCarsAsync();
            return cars.FirstOrDefault(c => c.Id == id);
        }

        public async Task AddCarAsync(Car car)
        {
            var cars = (await GetAllCarsAsync()).ToList();
            cars.Add(car);
            await _cacheService.SetCacheAsync(CacheKey, cars, TimeSpan.FromMinutes(10));
        }

        public async Task<bool> UpdateCarAsync(int id, Car car)
        {
            var cars = (await GetAllCarsAsync()).ToList();
            var index = cars.FindIndex(c => c.Id == id);
            if (index == -1) return false;
            cars[index] = car;
            await _cacheService.SetCacheAsync(CacheKey, cars, TimeSpan.FromMinutes(10));
            return true;
        }

        public async Task<bool> DeleteCarAsync(int id)
        {
            var cars = (await GetAllCarsAsync()).ToList();
            var car = cars.FirstOrDefault(c => c.Id == id);
            if (car == null) return false;
            cars.Remove(car);
            await _cacheService.SetCacheAsync(CacheKey, cars, TimeSpan.FromMinutes(10));
            return true;
        }
    }
}
