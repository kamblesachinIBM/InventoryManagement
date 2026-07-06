namespace Product.Application.Responses
{
    public record ProductResponse
    {
        public int Id { get; init; }
        public string Code { get; init; }
        public string Name { get; init; }
        public string Description { get; init; }
        public decimal Price { get; init; }
    }
}
