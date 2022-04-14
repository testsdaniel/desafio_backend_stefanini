using Example.Application.CityService.Models.Request;
using Example.Application.Tests.Helpers;
using Example.Domain;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Example.Application.Tests.Services
{
    public class CityServiceTests
    {
        private Infra.Data.ExampleContext _context;
        private CityService.Service.CityService _service;

        public CityServiceTests()
        {
            _context = DbContextHelper.GetExampleContextInstance();

            var loggerMock = new Mock<ILogger<CityService.Service.CityService>>();
            _service = new CityService.Service.CityService(loggerMock.Object, _context);
        }

        [Fact]
        public async Task GetAllAsync_Should_Return_Empty_List_Of_CityDto()
        {
            await _context.ClearDbSetAsync<City>();

            var response = await _service.GetAllAsync();

            response.List.Should().BeEmpty();
        }

        [Fact]
        public async Task GetAllAsync_Should_Return_Not_Empty_List_Of_CityDto()
        {
            await _context.City.AddAsync(new City() { Name = "City Test", Uf = "SC" });
            await _context.SaveChangesAsync();

            var response = await _service.GetAllAsync();

            response.List.Should().NotBeEmpty();
        }

        [Fact]
        public async Task GetByIdAsync_Should_Return_CityDto()
        {
            var city = new City() { Name = "City Test 2", Uf = "SP" };
            await _context.City.AddAsync(city);
            await _context.SaveChangesAsync();

            var response = await _service.GetByIdAsync(city.Id);

            response.Data.Should().NotBeNull();
        }

        [Fact]
        public async Task GetByIdAsync_Should_Return_Null()
        {
            await _context.ClearDbSetAsync<City>();

            var response = await _service.GetByIdAsync(int.MaxValue);

            response.Data.Should().BeNull();
        }

        [Fact]
        public async Task CreateAsync_Should_Return_CityId()
        {
            var request = new CreateCityRequest()
            {
                Name = "Teste create city",
                Uf = "RJ"
            };

            var response = await _service.CreateAsync(request);

            response.Id.Should().BeGreaterThan(0);
        }

        [Fact]
        public void CreateAsync_Should_Throw_ArgumentException()
        {
            Action action = () => _service.CreateAsync(null).GetAwaiter().GetResult();

            action.Should().Throw<ArgumentException>()
                .WithMessage("Request empty!");
        }

        [Fact]
        public async Task UpdateAsync_Should_Update_City_Data()
        {
            var city = new City() { Name = "City to update", Uf = "MG" };

            await _context.City.AddAsync(city);
            await _context.SaveChangesAsync();

            var request = new UpdateCityRequest() { Id = city.Id, Name = "City updated", Uf = "CE" };
            await _service.UpdateAsync(request);

            var cityAfterUpdate = await _context.City.FindAsync(request.Id);

            cityAfterUpdate.Name.Should().Be(request.Name);
            cityAfterUpdate.Uf.Should().Be(request.Uf);
        }

        [Fact]
        public void UpdateAsync_Should_Throw_ArgumentException()
        {
            Action action = () => _service.UpdateAsync(null).GetAwaiter().GetResult();

            action.Should().Throw<ArgumentException>()
                .WithMessage("Request empty!");
        }

        [Fact]
        public async Task DeleteAsync_Should_Delete_City()
        {
            var city = new City() { Name = "City to delete", Uf = "MS" };

            await _context.City.AddAsync(city);
            await _context.SaveChangesAsync();

            await _service.DeleteAsync(new DeleteCityRequest() { Id = city.Id });

            var exists = await _context.City.AnyAsync(x => x.Id == city.Id);

            exists.Should().BeFalse();
        }
    }
}
