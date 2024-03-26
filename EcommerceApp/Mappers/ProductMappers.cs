using EcommerceApp.DTOs.Product;
using EcommerceApp.Models;

namespace EcommerceApp.Mappers;

public static class ProductMappers
{
    public static Product ToProductFromCreateDto(this RequestToProduct requestToProduct)
    {
        return new Product()
        {
            Name = requestToProduct.Name,
            Price = requestToProduct.Price,
            Description = requestToProduct.Description,
            imgPath = requestToProduct.imgPath,
        };
    }
    
    public static ProductDto ToProductDto(this Product product)
    {
        return new ProductDto()
        {
            ProductId = product.ProductId,
            Name = product.Name,
            Price = product.Price,
            Description = product.Description,
            imgPath = product.imgPath
        };
    }
    
    
}