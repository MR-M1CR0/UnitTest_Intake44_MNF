using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;
using Moq;
using CarFactoryMVC.Entities;
using CarFactoryMVC.Models;
using CarFactoryMVC.Payment;
using CarFactoryMVC.Repositories_DAL;
using CarFactoryMVC.Services_BLL;
using CarFactoryMVC_Test.Stups;
using Microsoft.EntityFrameworkCore;
using Moq.EntityFrameworkCore;

namespace CarFactoryMVC_Test
{
    
    public class CarServiceTests : IDisposable
    {
        private readonly ITestOutputHelper outputHelper;
        Mock<ICarsRepository> carRepoMock;
        CarsService carsService;

        public CarServiceTests(ITestOutputHelper outputHelper)
        {
            this.outputHelper = outputHelper;
            outputHelper.WriteLine("test setup");


            // create mock for dependencies
            carRepoMock = new Mock<ICarsRepository>();
            carsService = new(carRepoMock.Object);

        }

        public void Dispose()
        {
            outputHelper.WriteLine("test cleanup");
        }

        [Fact]
        public void GetAllCars_returnCarList()
        {
            // Arrange
            outputHelper.WriteLine("GetAllCars_returnCarList");
            List<Car> cars = new List<Car>()
            {
                new Car(){Id = 10},
                new Car(){Id = 20},
                new Car(){Id = 30},
            };

            carRepoMock.Setup(cr => cr.GetAllCars()).Returns(cars);

            // Act
            List<Car> result = carsService.GetAll();

            // Assert
            Assert.Equal(3, result.Count);
        }

        [Fact]
        public void GetCarById_returnCar()
        {
            // Arrange
            outputHelper.WriteLine("GetCarById_returnCar");
            Car car = new Car() { Id = 10};
            carRepoMock.Setup(cr => cr.GetCarById(10)).Returns(car);

            // Act
            Car result = carsService.GetCarById(10);

            // Assert
            Assert.Equal(car, result);
        }

        [Fact]
        public void GetCarById_returnNull()
        {
            // Arrange
            outputHelper.WriteLine("GetCarById_returnNull");
            carRepoMock.Setup(cr => cr.GetCarById(10)).Returns((Car)null);

            // Act
            Car result = carsService.GetCarById(10);

            // Assert
            Assert.Null(result);
        }
        
    }
}
