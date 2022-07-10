using AutoMapper;
using GeekShopping.ProductAPI.Data.DTOs;
using GeekShopping.ProductAPI.Model;
using GeekShopping.ProductAPI.Model.Context;
using Microsoft.EntityFrameworkCore;

namespace GeekShopping.ProductAPI.Repository
{
    public class ProductRespository : IProductRespository
    {
        private readonly MySqlContext _context;
        private IMapper _mapper;

        public ProductRespository(MySqlContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductDTO>> FindAll()
        {
            List<Product> products = await _context.Products.ToListAsync();
            return _mapper.Map<List<ProductDTO>>(products);
        }

        public async Task<ProductDTO> FindById(long id)
        {
            Product product = await _context.Products.Where(p => p.Id == id).FirstOrDefaultAsync();
            return _mapper.Map<ProductDTO>(product);
        }

        public async Task<ProductDTO> Create(ProductDTO productDTO)
        {
            Product product = _mapper.Map<Product>(productDTO);
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return _mapper.Map<ProductDTO>(product);
        }

        public async Task<ProductDTO> Update(ProductDTO productDTO)
        {
            Product product = _mapper.Map<Product>(productDTO);
            _context.Products.Update(product);
            await _context.SaveChangesAsync();

            return _mapper.Map<ProductDTO>(product);
        }

        public async Task<bool> Delete(long id)
        {
            try
            {
                Product product = await _context.Products.Where(p => p.Id == id).FirstOrDefaultAsync();
                if (product == null)
                    return false;

                _context.Products.Remove(product);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }      
        
    }
}
