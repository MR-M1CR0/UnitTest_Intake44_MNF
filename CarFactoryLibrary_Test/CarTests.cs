using CarFactoryLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFactoryLibrary_Test
{
    public class CarTests
    {
        [Fact]
        public void IsStopped_CarVelocity20_False()
        {
            // Arrange
            Car car = new Toyota() { velocity = 20, drivingMode = DrivingMode.Forward };

            // Act
            var result = car.IsStopped();

            // Boolean Assert
            Assert.False(result);
        }
        [Fact]
        public void IsStopped_CarVelocity0_True()
        {
            // Arrange
            Car car = new Toyota();

            // Act
            var result = car.IsStopped();

            // Boolean Assert
            Assert.True(result);
        }
        [Fact]
        public void GetDirection_CarModeForward_Forward()
        {
            // Arrange
            Car car = new Toyota() { velocity = 15, drivingMode = DrivingMode.Forward };

            // Act
            var result = car.GetDirection();

            // Equality Assert
            //Assert.Equal("Forward", result);


            // String Assert
            Assert.StartsWith("F", result);
            Assert.EndsWith("d", result);
            Assert.Contains("wa", result);
            Assert.DoesNotContain("x", result);

            // Assert.Matches("regex", result);
            // Assert.DoesNotMatch("regex", result);
        }

        [Fact]
        public void IncreaseVelocity_CarVelocity10IncreseBy5_Velocity15()
        {
            // Arrange
            Car car = new Toyota() { velocity = 10 };

            // Act
            car.IncreaseVelocity(5);

            // Assert
            Assert.Equal(15, car.velocity);
        }

        [Fact]
        public void Accelerate_CarVelocity20_VelocityIncrease()
        {
            // Arrage
            //Car car = new Toyota { velocity = 20 };
            Car car = new BMW { velocity = 20 };

            // Act
            car.Accelerate();   // range 5 to 15

            // Numeric Assert
            Assert.InRange(car.velocity, 25, 35);
            // Assert.NotInRange()
        }

        [Fact]
        public void GetMyCar_car_same()
        {
            // Arrange
            Car car = new Toyota();
            Car car1 = new Toyota();

            // Act
            Car car2 = car.GetMyCar();

            // Assert
            // Reference Equality
            Assert.Same(car, car2);
            Assert.NotSame(car, car1);

            // Value Equality
            Assert.Equal<Car>(car, car1);
        }

        // -------------------------------------------------------------------------------

        // 1
        [Fact]
        public void Stop_CarVelocity20_Velocity0()
        {
            Car car = new Toyota() { velocity = 20 };

            car.Stop();

            Assert.Equal(0, car.velocity);
            Assert.Equal(DrivingMode.Stopped, car.drivingMode);
        }

        // 2
        [Fact]
        public void TimeToCoverDistance_CarVelocity10Distance50_5()
        {
            Car car = new Toyota() { velocity = 10 };

            var result = car.TimeToCoverDistance(50);

            Assert.Equal(5, result);
        }

        // 3
        [Fact]
        public void Equals_TwoEqualCars_True()
        {
            Car car1 = new Toyota() { velocity = 40, drivingMode = DrivingMode.Forward };
            Car car2 = new Toyota() { velocity = 40, drivingMode = DrivingMode.Forward };

            var result = car1.Equals(car2);

            Assert.True(result);
        }

        // 4
        [Fact]
        public void Equals_TwoDifferentCars_False()
        {
            Car car1 = new Toyota() { velocity = 30, drivingMode = DrivingMode.Forward };
            Car car2 = new BMW() { velocity = 20, drivingMode = DrivingMode.Backward };

            var result = car1.Equals(car2);

            Assert.False(result);
        }

        // 5
        [Fact]
        public void GetHashCode_EqualCars_SameHashCode()
        {
            Car car1 = new Toyota() { velocity = 20, drivingMode = DrivingMode.Forward };
            Car car2 = new Toyota() { velocity = 20, drivingMode = DrivingMode.Forward };

            var hash1 = car1.GetHashCode();
            var hash2 = car2.GetHashCode();

            Assert.Equal(hash1, hash2);
        }

        // 6
        [Fact]
        public void TimeToCoverDistance_CarVelocity0()
        {
            Car car = new Toyota();

            var result = car.TimeToCoverDistance(50);

            Assert.Equal(double.PositiveInfinity, result);
        }

    }
}
