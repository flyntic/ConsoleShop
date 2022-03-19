namespace ConsoleShop;

public enum PayType
{
    cash,
    creditcard
}

public struct Request
{
    public double idOrder;
    private double idClient;
    private DateTime dateOrder;
    private RequestItem[] products;
    private PayType payType;

    public Request(double idOrder, double idClient)
    {
        this.idOrder = idOrder;
        this.idClient = idClient;
        this.dateOrder = DateTime.Now;
        this.products = new RequestItem[0];
        this.payType = PayType.cash;
    }

    public bool addProduct(RequestItem item)
    {
        int length = products.Length;
        Array.Resize(ref this.products, length + 1);
        this.products[length] = item;
        return true;
    }

    public bool addPayType(PayType payType)
    {
        this.payType = payType;
        return true;
    }

    public float costOrder(Article[] articles)
    {
        float cost = 0;
        foreach (var product in products)
        {
            Article ar = Array.Find(articles, article => article.idProduct == product.idProduct);
            cost += ar.getPrice() * (float) product.countProduct;
        }

        return cost;
    }

    public void print(Article[] articles, Client[] clients)
    {
        double id = this.idClient;
        Client cl = Array.Find(clients, client => client.idClient == id);
        Console.WriteLine("Заказ N" + this.idOrder + " Клиент: " + cl.getName() + "Дата " + this.dateOrder.Date +
                          " Время " + this.dateOrder.TimeOfDay);

        foreach (var product in this.products)
        {
            Article ar = Array.Find(articles, article => article.idProduct == product.idProduct);
            Console.WriteLine(ar.getPrice() + " " + product.countProduct);
        }

        Console.WriteLine("Общая сумма заказа " + this.costOrder(articles));
        Console.WriteLine(this.payType == PayType.cash ? "Оплата наличными" : "Безналичная оплата");
    }
}