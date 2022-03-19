namespace ConsoleShop;

public enum ArticleType
{
    Products = 1,
    Alcogol,
    ZooProducts
};

public struct Article
{
    public double idProduct;
    private string nameProduct;
    private ArticleType typeProduct;
    private float priceProduct;

    public static string getType(ArticleType a)
    {
        switch (a)
        {
            case ArticleType.Products: return "Продукты";
            case ArticleType.Alcogol: return "Алкоголь";
            case ArticleType.ZooProducts: return "Зоотовары";
        }

        return null;
    }
    public Article(double idProduct, string nameProduct, ArticleType typeProduct, float priceProduct)
    {
        this.idProduct = idProduct;
        this.nameProduct = nameProduct;
        this.typeProduct = typeProduct;
        this.priceProduct = priceProduct;
    }

    public void print()
    {
        Console.WriteLine(this.idProduct + "\t" + this.nameProduct + "\t" + this.typeProduct + "\t" +
                          this.priceProduct + " руб.");
    }

    public float getPrice()
    {
        return this.priceProduct;
    }

    public string getName()
    {
        return nameProduct;
    }
}