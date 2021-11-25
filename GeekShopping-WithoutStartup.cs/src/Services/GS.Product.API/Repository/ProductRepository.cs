using AutoMapper;
using GS.Product.API.Data.ValueObjects;
using GS.Product.API.Model.Context;
using Microsoft.EntityFrameworkCore;

namespace GS.Product.API.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly MySqlContext _context;
        private IMapper _mapper;

        public ProductRepository(MySqlContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ProductVO>> FindAll()
        {
            //List<Product.API.Model.Product> products = await _context.Products.ToListAsync();
            var products = await _context.Products.ToListAsync();

            var retorno = _mapper.Map<List<ProductVO>>(products);

            return retorno;
        }
        public async Task<ProductVO> FindById(long id)
        {
            Product.API.Model.Product product = await _context.Products.Where(p => p.Id == id).FirstOrDefaultAsync();

            var retorno = _mapper.Map<ProductVO>(product);

            return retorno;
        }
        public async Task<ProductVO> Create(ProductVO vo)
        {
            var product = _mapper.Map<Product.API.Model.Product>(vo);

            _context.Products.Add(product);

            await _context.SaveChangesAsync();

            var retorno = _mapper.Map<ProductVO>(product);

            return retorno;

        }
        public async Task<ProductVO> Update(ProductVO vo)
        {
            var product = _mapper.Map<Product.API.Model.Product>(vo);

            _context.Products.Update(product);

            await _context.SaveChangesAsync();

            var retorno = _mapper.Map<ProductVO>(product);

            return retorno;
        }
        public async Task<bool> Delete(long id)
        {
            try
            {
                var product = await _context.Products.Where(p => p.Id == id).FirstOrDefaultAsync();

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
