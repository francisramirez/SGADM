using SGA.Application.Repositories.Confguration;
using SGA.Domain.Base;
using SGA.Domain.Entitines.Configuration;
using SGA.Persistence.Repositories.Configuration;
using Microsoft.EntityFrameworkCore;
using SGA.Persistence.Context;
namespace SGA.Persistence.Test
{
    public class BusRepositoryTest
    {
        private readonly IBusRepository _busRepository;
        private readonly SGAContext _context;
        public BusRepositoryTest()
        {
            var options = new DbContextOptionsBuilder<SGAContext>()
                .UseInMemoryDatabase("SGA")
                .Options;

            _context = new SGAContext(options);
            _busRepository = new BusRepository(_context);
        }
        [Fact]
        public async Task SaveBus_When_BusEntity_IsNull()
        {
            //Arrange
            Bus bus = null;

            //Act
            var result = await _busRepository.Save(bus);
            string message = "El objeto bus no puede ser nulo";

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.Equal(message, result.Message);
            Assert.False(result.Success);
        }
        [Fact]
        public async Task SaveBus_When_NumeroPlaca_IsNullOrEmpty()
        {
            //Arrange
            Bus bus = new Bus() { NumeroPlaca = string.Empty };

            //Act
            var result = await _busRepository.Save(bus);
            string message = "El número de placa no puede ser nulo o vacío.";

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.Equal(message, result.Message);
            Assert.False(result.Success);
        }
        [Fact]
        public async Task SaveBus_When_NumeroPlaca_IsMoreThan50_Characters()
        {
            //Arrange
            Bus bus = new Bus() { NumeroPlaca = "asdfadsfasdfdasfdasffasdfasdfasdfasdfasdfasdfasfafasfasdfasdfasdfasdfasdfdsfdfsdfsasdsdfsdfsdfsdfsdfsdfsdfsdfsdfsdfsdfsdfsdasasdasfdfsdfsdfsdsfdfsdfsdfsdfsdfsdfsdfs" };

            //Act
            var result = await _busRepository.Save(bus);
            string message = "La longitud del número de placa es inválida.";

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.Equal(message, result.Message);
            Assert.False(result.Success);
        }
        [Fact]
        public async Task SaveBus_When_Is_Ok()
        {
            //Arrange
            Bus bus = new Bus()
            {
                Nombre = "Bus 1",
                CapacidadPiso1 = 100,
                CapacidadPiso2 = 200,
                Disponible = true,
                Estatus = true,
                FechaCreacion = DateTime.Now,
                FechaModificacion = DateTime.Now,
                NumeroPlaca = "123456",
                UsuarioModificacion = 1
            };

            //Act
            var result = await _busRepository.Save(bus);
            string message = "El bus fue creado correctamente.";
            var added = await _busRepository.GetAll(cd => cd.Nombre == bus.Nombre);
            List<Bus> buses = (List<Bus>)added.Data;

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.Equal(message, result.Message);
            Assert.True(result.Success);
            Assert.True(buses.Count > 0);
            Assert.Equal(bus.CapacidadPiso1, buses[0].CapacidadPiso1);
          
        }
    }
}