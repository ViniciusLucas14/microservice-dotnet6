using AutoMapper;
using GeekShopping.ProductAPI.Domain.VM;
using GeekShopping.ProductAPI.Implementation.Model.Class;
using GeekShopping.ProductAPI.Implementation.Model.Context;
using Microsoft.EntityFrameworkCore;

namespace GeekShopping.ProductAPI.Domain.IRepository
{
    public class ProductRepository : IProductRepository
    {
        private readonly SqlContext _context;
        private IMapper _mapper;

        public ProductRepository(SqlContext context, 
                                 IMapper mapper)
        {
            _context= context;
            _mapper = mapper;
        }

        public async Task<ProductVM> FindById(int id)
        {
           Product? product = await _context.Products.Where(p => p.Id == id).FirstOrDefaultAsync();
           return _mapper.Map<ProductVM>(product);  
        }

        public async Task<IEnumerable<ProductVM>> FindAll()
        {
            List<Product> products = await _context.Products.ToListAsync();
            return _mapper.Map<List<ProductVM>>(products);
        }

        public async Task<ProductVM> Create(ProductVM vm)
        {
            Product product = _mapper.Map<Product>(vm);
             _context.Add(product);
            await _context.SaveChangesAsync();
            return _mapper.Map<ProductVM>(vm);
        }
        public async Task<ProductVM> Update(ProductVM vm)
        {
            Product product = _mapper.Map<Product>(vm);
            _context.Update(product);
            await _context.SaveChangesAsync();
            return _mapper.Map<ProductVM>(vm);
        }
        public async Task<bool> Delete(int id)
        {
            try
            {
                 Product? product = await _context.Products.Where(p => p.Id == id).FirstOrDefaultAsync();
                if (product == null) return false;

                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
     
    }
}
