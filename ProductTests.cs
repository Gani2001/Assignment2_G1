using Assignment2_G1;

namespace Assignment2_G1Test
{
    [TestFixture]
    public class ProductTests
    {
        // Constructor Tests
        [Test]
        public void Constructor_Should_Throw_When_ProductID_Is_Less_Than_1()
        {
            // Arrange & Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => new Product(0, "Test Product", 10.0m, 5));
        }

        [Test]
        public void Constructor_Should_Throw_When_ProductID_Is_Greater_Than_1000()
        {
            // Arrange & Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => new Product(1001, "Test Product", 10.0m, 5));
        }

        [Test]
        public void Constructor_Should_Throw_When_Price_Is_Less_Than_1()
        {
            // Arrange & Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => new Product(1, "Test Product", 0.99m, 5));
        }

        [Test]
        public void Constructor_Should_Throw_When_Price_Is_Greater_Than_5000()
        {
            // Arrange & Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => new Product(1, "Test Product", 5001.0m, 5));
        }

        [Test]
        public void Constructor_Should_Throw_When_Stock_Is_Less_Than_1()
        {
            // Arrange & Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => new Product(1, "Test Product", 10.0m, 0));
        }

        [Test]
        public void Constructor_Should_Throw_When_Stock_Is_Greater_Than_1000()
        {
            // Arrange & Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => new Product(1, "Test Product", 10.0m, 1001));
        }

        // Attribute Tests
        [Test]
        public void Attributes_Should_Be_Assigned_Correctly()
        {
            // Arrange
            var product = new Product(1, "Test Product", 10.0m, 5);

            // Act & Assert
            Assert.That(product.ProductID, Is.EqualTo(1));
            Assert.That(product.ProductName, Is.EqualTo("Test Product"));
            Assert.That(product.Price, Is.EqualTo(10.0m));
            Assert.That(product.Stock, Is.EqualTo(5));
        }

        // Stock Increase Tests
        [Test]
        public void IncreaseStock_Should_Increase_Stock_By_Specified_Amount()
        {
            // Arrange
            var product = new Product(1, "Test Product", 10.0m, 5);

            // Act
            product.IncreaseStock(5);

            // Assert
            Assert.That(product.Stock, Is.EqualTo(10));
        }

        [Test]
        public void IncreaseStock_Should_Throw_When_Amount_Is_Negative()
        {
            // Arrange
            var product = new Product(1, "Test Product", 10.0m, 5);

            // Act & Assert
            Assert.Throws<ArgumentException>(() => product.IncreaseStock(-1));
        }

        [Test]
        public void IncreaseStock_With_Zero_Should_Not_Change_Stock()
        {
            // Arrange
            var product = new Product(1, "Test Product", 10.0m, 5);

            // Act
            product.IncreaseStock(0);

            // Assert
            Assert.That(product.Stock, Is.EqualTo(5));
        }

        [Test]
        public void IncreaseStock_Should_Handle_Maximum_Boundary_Value()
        {
            // Arrange
            var product = new Product(1, "Test Product", 10.0m, 1);

            // Act
            product.IncreaseStock(999);

            // Assert
            Assert.That(product.Stock, Is.EqualTo(1000));
        }

        // Stock Decrease Tests
        [Test]
        public void DecreaseStock_Should_Decrease_Stock_By_Specified_Amount()
        {
            // Arrange
            var product = new Product(1, "Test Product", 10.0m, 5);

            // Act
            product.DecreaseStock(3);

            // Assert
            Assert.That(product.Stock, Is.EqualTo(2));
        }

        [Test]
        public void DecreaseStock_Should_Throw_When_Amount_Exceeds_Stock()
        {
            // Arrange
            var product = new Product(1, "Test Product", 10.0m, 5);

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => product.DecreaseStock(6));
        }

        [Test]
        public void DecreaseStock_Should_Throw_When_Amount_Is_Negative()
        {
            // Arrange
            var product = new Product(1, "Test Product", 10.0m, 5);

            // Act & Assert
            Assert.Throws<ArgumentException>(() => product.DecreaseStock(-1));
        }

        [Test]
        public void DecreaseStock_With_Zero_Should_Not_Change_Stock()
        {
            // Arrange
            var product = new Product(1, "Test Product", 10.0m, 5);

            // Act
            product.DecreaseStock(0);

            // Assert
            Assert.That(product.Stock, Is.EqualTo(5));
        }

        [Test]
        public void DecreaseStock_Should_Handle_Boundary_Value()
        {
            // Arrange
            var product = new Product(1, "Test Product", 10.0m, 1000);

            // Act
            product.DecreaseStock(1000);

            // Assert
            Assert.That(product.Stock, Is.EqualTo(0));
        }

        [Test]
        public void Constructor_Should_Assign_Correct_Values_At_Lower_Boundaries()
        {
            // Arrange
            var product = new Product(1, "Test Product", 1.0m, 1);

            // Act & Assert
            Assert.That(product.ProductID, Is.EqualTo(1));
            Assert.That(product.ProductName, Is.EqualTo("Test Product"));
            Assert.That(product.Price, Is.EqualTo(1.0m));
            Assert.That(product.Stock, Is.EqualTo(1));
        }

        [Test]
        public void Constructor_Should_Assign_Correct_Values_At_Upper_Boundaries()
        {
            // Arrange
            var product = new Product(1000, "Test Product", 5000.0m, 1000);

            // Act & Assert
            Assert.That(product.ProductID, Is.EqualTo(1000));
            Assert.That(product.ProductName, Is.EqualTo("Test Product"));
            Assert.That(product.Price, Is.EqualTo(5000.0m));
            Assert.That(product.Stock, Is.EqualTo(1000));
        }
    }

}