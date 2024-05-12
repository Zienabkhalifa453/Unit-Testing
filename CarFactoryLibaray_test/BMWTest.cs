using CarFactoryLibrary;

namespace CarFactoryLibaray_test
{
    public class BMWTest
    {
        [Fact]
        public void IsStopped_velocity0_true()
        {
            // Arrange
            BMW BMW = new BMW();
            BMW.velocity = 0;

            // Act
            bool result = BMW.IsStopped();

            // Boolean Asserts
            Assert.True(result);
        }
        [Fact]
        public void IsStopped_velocity20_false()
        {
            // Arrange
            BMW bMW = new BMW();
            bMW.velocity = 20;


            // Act
            bool result = bMW.IsStopped();

            // Boolean Asserts
            Assert.False(result);
        }
        [Fact]
        public void IncreaseVelocity_valocity20Add30_50()
        {
            // Arrange
            BMW bMW = new BMW();
            bMW.velocity = 20;
            double AddedVelocitoy = 30;

            // Act
            bMW.IncreaseVelocity(AddedVelocitoy);



            // Numeric Asserts
            Assert.False(bMW.velocity < 10);
            Assert.True(bMW.velocity > 10);

            Assert.InRange(bMW.velocity, 20, 60);
            Assert.NotInRange(bMW.velocity, 10, 20);
        }

        [Fact]
        public void GetDirection_DirectionForward_Forward()
        {
            // Arrange
            BMW bMW = new BMW();
            bMW.drivingMode = DrivingMode.Forward;

            // Act
            string result = bMW.GetDirection();

            // string Asserts
            Assert.Equal(DrivingMode.Forward.ToString(), result);

            Assert.StartsWith("F", result);
            Assert.EndsWith("rd", result);

            Assert.Contains("rw", result);
            Assert.Contains("wa", result);
            Assert.Contains("Fo", result);
            Assert.DoesNotContain("ld", result);


        }


        [Fact]
        public void GetMyCar_callFunction_SameCar()
        {
            // Arrange
            BMW bMW = new BMW();

            // Act
            Car car = bMW.GetMyCar();

            // Refrence Assert
            Assert.Same(bMW, car);

        }

        [Fact]
        public void NewCar_CarTypeT_ToYota()
        {
            // Arrange

            // Act
            Car? car = CarFactory.NewCar(CarTypes.Toyota);

            // Reference Asserts
            Assert.NotNull(car);

            // Type Asserts
            Assert.IsType<Toyota>(car);
            Assert.IsNotType<BMW>(car);

            Assert.IsAssignableFrom<Car>(car);

            Assert.IsAssignableFrom<Car>(new Toyota());
        }
        [Fact]
        public void NewCar_CarType_Exception()
        {
            // Arrange



            // Assert
            Assert.Throws<NotImplementedException>(() =>
            {
                // Act
                Car? result = CarFactory.NewCar(CarTypes.Honda);
            });
        }
    }
}
