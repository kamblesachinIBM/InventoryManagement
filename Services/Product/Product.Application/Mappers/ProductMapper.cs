using Product.Application.Commands;
using Product.Application.DTOs;
using Product.Application.Responses;
using Product.Core.Entities;

namespace Product.Application.Mappers
{
    public static class ProductMapper
    {
        public static CreateProductCommand ToCreateProductCommand(this CreateProductDto createProductDto)
        {
            return new CreateProductCommand
            {
                Code = createProductDto.Code,
                Name = createProductDto.Name,
                Description = createProductDto.Description,
                Price = createProductDto.Price
            };
        }

        public static ProductEntity ToEntity(this CreateProductCommand createProductCommand)
        {
            return new ProductEntity
            {
                Code = createProductCommand.Code,
                Name = createProductCommand.Name,
                Description = createProductCommand.Description,
                Price = createProductCommand.Price
            };
        }

        public static ProductResponse ToResponse(this ProductEntity productEntity)
        {
            return new ProductResponse
            {
                Id = productEntity.Id,
                Code = productEntity.Code,
                Name = productEntity.Name,
                Description = productEntity.Description,
                Price = productEntity.Price
            };
        }
    }
}
