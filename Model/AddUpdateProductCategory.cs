namespace WebAPI.Model
{
    public class AddUpdateProductCategory
    {
        public required string Name { get; set; }
        public string Description { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
    }
}
