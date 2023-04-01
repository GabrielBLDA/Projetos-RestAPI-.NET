namespace Dotnet_API.Metods
{
   public static class ProductRepository
    {
        public static List<Products> produtos {get; set;}

        public static void Add(Products products) {
            if (produtos == null)
                produtos = new List<Products>();
            
            produtos.Add(products); 
        }

        public static Products GetBy(string code)
        {
            return produtos.FirstOrDefault(p => p.Code == code);
        }
    }
}
