using BlazorApp4.Models;

namespace BlazorApp4.Components.Pages
{
    public partial class Home
    {
        public List<Product> products = new List<Product>();

        protected override async Task OnInitializedAsync()
        {
            GetProducts();
        }

        private void GetProducts()
        {
            products = productService.GetAll();
        }
    }
}
