namespace Product.Application.DTOs
{
    public record class ProductDto(
        int Id, 
        string? Code, 
        string? Name,
        string? Description, 
        decimal Price);


    public record class CreateProductDto(
        string? Code,
        string? Name,
        string? Description,
        decimal Price);

}
