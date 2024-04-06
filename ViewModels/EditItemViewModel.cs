namespace FoodCorner.ViewModels
{
    public class EditItemViewModel : BaseItemViewModel
    {
        public int Id { get; set; }
        public string? CurrentImage { get; set; }
        public IFormFile? Image { get; set; } = default!;
    }
}
