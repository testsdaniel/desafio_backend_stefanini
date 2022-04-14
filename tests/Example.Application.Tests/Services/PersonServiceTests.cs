using Example.Application.PersonService.Models.Request;
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
    public class PersonServiceTests
    {
        private Infra.Data.ExampleContext _context;
        private PersonService.Service.PersonService _service;

        public PersonServiceTests()
        {
            _context = DbContextHelper.GetExampleContextInstance();

            var loggerMock = new Mock<ILogger<PersonService.Service.PersonService>>();
            _service = new PersonService.Service.PersonService(loggerMock.Object, _context);

            _context.City.Add(new City() { Name = "City Test", Uf = "SC" });
            _context.SaveChanges();
        }

        [Fact]
        public async Task GetAllAsync_Should_Return_Empty_List_Of_PersonDto()
        {
            await _context.ClearDbSetAsync<Person>();

            var response = await _service.GetAllAsync();

            response.List.Should().BeEmpty();
        }

        [Fact]
        public async Task GetAllAsync_Should_Return_Not_Empty_List_Of_PersonDto()
        {
            var person = new Person()
            {
                Name = "Person Test",
                Cpf = "76245519004",
                Age = 18,
                CityId = 1
            };
            await _context.Person.AddAsync(person);
            await _context.SaveChangesAsync();

            var response = await _service.GetAllAsync();

            response.List.Should().NotBeEmpty();
        }

        [Fact]
        public async Task GetByIdAsync_Should_Return_PersonDto()
        {
            var person = new Person()
            {
                Name = "Person Test",
                Cpf = "76245519004",
                Age = 18,
                CityId = 1
            };
            await _context.Person.AddAsync(person);
            await _context.SaveChangesAsync();

            var response = await _service.GetByIdAsync(person.Id);

            response.Data.Should().NotBeNull();
        }

        [Fact]
        public async Task GetByIdAsync_Should_Return_Null()
        {
            await _context.ClearDbSetAsync<Person>();

            var response = await _service.GetByIdAsync(int.MaxValue);

            response.Data.Should().BeNull();
        }

        [Fact]
        public async Task CreateAsync_Should_Return_PersonId()
        {
            var request = new CreatePersonRequest()
            {
                Name = "Test create person",
                Cpf = "76245519004",
                Age = 18,
                CityId = 1
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
        public async Task UpdateAsync_Should_Update_Person_Data()
        {
            var person = new Person()
            {
                Name = "Person Test",
                Cpf = "76245519004",
                Age = 18,
                CityId = 1
            };

            await _context.Person.AddAsync(person);
            await _context.SaveChangesAsync();

            var request = new UpdatePersonRequest()
            {
                Id = person.Id,
                Name = "Person test updated",
                Cpf = "76245519004",
                Age = 22,
                CityId = 1
            };
            await _service.UpdateAsync(request);

            var personAfterUpdate = await _context.Person.FindAsync(request.Id);

            personAfterUpdate.Name.Should().Be(request.Name);
            personAfterUpdate.Age.Should().Be(request.Age);
        }

        [Fact]
        public void UpdateAsync_Should_Throw_ArgumentException()
        {
            Action action = () => _service.UpdateAsync(null).GetAwaiter().GetResult();

            action.Should().Throw<ArgumentException>()
                .WithMessage("Request empty!");
        }

        [Fact]
        public async Task DeleteAsync_Should_Delete_Person()
        {
            var person = new Person()
            {
                Name = "Person test to delete",
                Cpf = "76245519004",
                Age = 18,
                CityId = 1
            };

            await _context.Person.AddAsync(person);
            await _context.SaveChangesAsync();

            await _service.DeleteAsync(new DeletePersonRequest() { Id = person.Id });

            var exists = await _context.City.AnyAsync(x => x.Id == person.Id);

            exists.Should().BeFalse();
        }
    }
}
