using EcommerceBreno.ProductApi.DTOs;
using EcommerceBreno.ProductApi.Repositories;
using EcommerceBreno.ProductApi.Models;
using AutoMapper;

namespace EcommerceBreno.ProductApi.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public ProductService(IMapper mapper, IProductRepository productRepository)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public async Task AddProduct(ProductDTO productDto)
        {
            var productEntity = _mapper.Map<Product>(productDto);
            await _productRepository.Create(productEntity);
            productDto.Id = productEntity.Id;
        }

        public async Task<ProductDTO> GetProductById(int id)
        {
            var productEntity = await _productRepository.GetById(id);
            return _mapper.Map<ProductDTO>(productEntity);
        }

        public async Task<IEnumerable<ProductDTO>> GetProducts()
        {
            var productsEntity = await _productRepository.GetAll();
            return _mapper.Map<IEnumerable<ProductDTO>>(productsEntity);
        }

        public async Task RemoveProduct(int id)
        {
            var productEntity = await _productRepository.GetById(id);
            await _productRepository.Delete(productEntity.Id);
        }

        public async Task UpdateProduct(ProductDTO productDto)
        {
            var categoryEntity = _mapper.Map<Product>(productDto);
            await _productRepository.Update(categoryEntity);
        }
    }
}
