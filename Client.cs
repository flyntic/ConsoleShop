namespace ConsoleShop;

public enum ClientType
{
    blockedClient,
    newClient,
    constClient,
    loveClient,
    privelegyClient,
};

public struct Client
{
    public double idClient;
    private string name;
    private string middlename;
    private string surname;
    private string address;
    private string telephone;
    private ClientType typeClient;
    private double numbersAllOrders;
    private float costAllOrders;

    private static float[] costClients = new float[5] {-1.0F, 0.0F, 1000.0F, 3000.0F, 5000.0F};

    private static string[] defClients = new string[5]
        {"заблокирован", "новый", "постоянный", "любимый", "привелигированный"};


    public Client(double idClient, string name, string middlename, string surname, string address, string telephone)
    {
        this.idClient = idClient;
        this.name = name;
        this.middlename = middlename;
        this.surname = surname;
        this.address = address;
        this.telephone = telephone;
        this.typeClient = ClientType.newClient;
        this.numbersAllOrders = 0;
        this.costAllOrders = 0;
    }

    public bool addOrder(float costOrder)
    {
        if (costOrder < 0)
        {
            this.typeClient = ClientType.blockedClient;
            return true;
        }

        if (this.typeClient == ClientType.blockedClient) return false;

        this.numbersAllOrders++;
        this.costAllOrders += costOrder;
        foreach (int i in Enum.GetValues(typeof(ClientType))) //.Cast<typeClient>().ToList())
            if (this.costAllOrders >= costClients[i])
                this.typeClient = (ClientType) i;
        return true;
    }

    public void print()
    {
        Console.WriteLine(this.idClient + "\t" + this.name + "\t" + this.middlename + "\t" + this.surname
                          + "\t" + defClients[(int) this.typeClient]);
    }

    public string getName()
    {
        return (this.name + " " + this.middlename + " " + this.surname);
    }
}