using BlazorApp4.Models;
using Microsoft.AspNetCore.Components;

namespace BlazorApp4.Components.Pages
{
    public partial class ProductCard
    {
        [Parameter]
        public Product Product { get; set; } = new Product();
    }
}
