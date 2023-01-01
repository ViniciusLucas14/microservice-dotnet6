using GeekShopping.ProductAPI.Domain.VM;

namespace GeekShopping.ProductAPI.Domain.IRepository
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductVM>> FindAll();
        Task<ProductVM> FindById(int id);
        Task<ProductVM> Create(ProductVM vm);
        Task<ProductVM> Update(ProductVM vm);
        Task<bool> Delete(int id);

    }
}
