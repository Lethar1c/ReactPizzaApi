namespace ReactPizza.WebApi.Pizzas.Dtos
{
    public class TypeDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public TypeDto(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
