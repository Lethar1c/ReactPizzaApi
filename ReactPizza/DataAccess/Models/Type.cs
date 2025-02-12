namespace ReactPizza.DataAccess.Models
{
    public class Type
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public Type() { }
        public Type(int id, string name) { Id = id; Name = name; }
    }
}
