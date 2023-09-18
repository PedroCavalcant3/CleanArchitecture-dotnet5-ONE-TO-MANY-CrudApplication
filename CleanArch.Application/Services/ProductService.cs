using AutoMapper;
using CleanArch.Application.Interfaces;
using CleanArch.Application.ViewModels;
using CleanArch.Domain.Entities;
using CleanArch.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

public class ProductService : IProductService
{
    private IProductRepository _productRepository;
    private ISupplierRepository _supplierRepository;
    private readonly IMapper _mapper;

    public ProductService(
        IProductRepository productRepository,
        ISupplierRepository supplierRepository,
        IMapper mapper)
    {
        _productRepository = productRepository;
        _supplierRepository = supplierRepository;
        _mapper = mapper;
    }

    public void Add(ProductViewModel product)
    {
        var mapProduct = _mapper.Map<Product>(product);
        _productRepository.Add(mapProduct);
    }

    public async Task<ProductViewModel> GetById(int? id)
    {
        var result = await _productRepository.GetById(id);
        return _mapper.Map<ProductViewModel>(result);
    }

    public async Task<IEnumerable<ProductViewModel>> GetProducts()
    {
        var result = await _productRepository.GetProducts();
        return _mapper.Map<IEnumerable<ProductViewModel>>(result);
    }

    public void Remove(int? id)
    {
        var product = _productRepository.GetById(id).Result;
        _productRepository.Remove(product);
    }

    public void Update(ProductViewModel product)
    {
        var mapProduct = _mapper.Map<Product>(product);
        _productRepository.Update(mapProduct);
    }

    public async Task<IEnumerable<SupplierViewModel>> GetSuppliers()
    {
        var suppliers = await _supplierRepository.GetSuppliersAsync();
        return _mapper.Map<IEnumerable<SupplierViewModel>>(suppliers);
    }

    // Implemente outros métodos relacionados a fornecedores aqui
}
