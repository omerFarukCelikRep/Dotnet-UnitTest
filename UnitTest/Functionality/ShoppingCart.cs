namespace UnitTest.Functionality
{
    public record Product(int id, string name, double Price);

    public interface IDbService
    {
        bool SaveItemToShoppingCart(Product? product);
        bool RemoveItemFromShoppingCart(int? productId);
    }

    public class ShoppingCart
    {
        private readonly IDbService _dbService;

        public ShoppingCart(IDbService dbService)
        {
            _dbService = dbService;
        }

        public bool AddProduct(Product? product)
        {
            if (product == null)
            {
                return false;
            }

            if (product.id == 0)
            {
                return false;
            }

            _dbService.SaveItemToShoppingCart(product);

            return true;
        }

        public bool DeleteProduct(int? id)
        {
            if (id == null)
            {
                return false;
            }

            if (id == 0)
            {
                return false;
            }

            _dbService.RemoveItemFromShoppingCart(id);

            return true;
        }
    }
}