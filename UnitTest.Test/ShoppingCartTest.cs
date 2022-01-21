using Moq;
using UnitTest.Functionality;
using Xunit;

namespace UnitTest.Test
{
    // public class DbServiceMock : IDbService
    // {
    //     public bool ProcessResult { get; set; }
    //     public Product ProductBeingProcessed { get; set; }
    //     public int ProductIdBeingProcessed { get; set; }
    //     public bool RemoveItemFromShoppingCart(int? productId)
    //     {
    //         if (productId == null)
    //         {
    //             return false;
    //         }

    //         ProductIdBeingProcessed = productId.Value;
    //         return ProcessResult;
    //     }

    //     public bool SaveItemToShoppingCart(Product? product)
    //     {
    //         if (product == null)
    //         {
    //             return false;
    //         }

    //         ProductBeingProcessed = product;
    //         return ProcessResult;
    //     }
    // }
    public class ShoppingCartTest
    {
        public readonly Mock<IDbService> _dbServiceMock = new();

        [Fact]
        public void AddProduct_Success()
        {
            // Given
            // var dbMock = new DbServiceMock();

            // dbMock.ProcessResult = true;
            // var shoppingCart = new ShoppingCart(dbMock);

            var shoppingCart = new ShoppingCart(_dbServiceMock.Object);
            
            // When
            var product = new Product(1, "Shoes", 150);
            var result = shoppingCart.AddProduct(product);

            // Then
            Assert.True(result);
            _dbServiceMock.Verify(x => x.SaveItemToShoppingCart(It.IsAny<Product>()), Times.Once);
        }

        [Fact]
        public void AddProduct_Failure_DueToInvalidPayload()
        {
            // Given
            // var dbMock = new DbServiceMock();
            // dbMock.ProcessResult = false;

            // var shoppingCart = new ShoppingCart(dbMock);
            var shoppingCart = new ShoppingCart(_dbServiceMock.Object);
        
            // When
            var result = shoppingCart.AddProduct(null);
        
            // Then
            Assert.False(result);
            _dbServiceMock.Verify(x => x.SaveItemToShoppingCart(It.IsAny<Product>()), Times.Never);
        }

        [Fact]
        public void RemoveProduct_Success()
        {
            // Given
            // var dbMock = new DbServiceMock();
            // dbMock.ProcessResult = true;

            // var shoppingCart = new ShoppingCart(dbMock);

            var shoppingCart = new ShoppingCart(_dbServiceMock.Object);
        
            // When
            var product = new Product(1, "Shoes", 150);
            var result = shoppingCart.AddProduct(product);

            var deleteResult = shoppingCart.DeleteProduct(product.id);
        
            // Then
            Assert.True(deleteResult);
            _dbServiceMock.Verify(x => x.SaveItemToShoppingCart(It.IsAny<Product>()), Times.Once);
        }
    }
}