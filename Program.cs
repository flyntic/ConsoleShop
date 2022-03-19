// See https://aka.ms/new-console-template for more information

Console.WriteLine("Инициализация списка товаров: ");

Console.Write("Введенные типы : ");
foreach (var value in Enum.GetValues(typeof(ConsoleShop.ArticleType)))
{
    Console.Write((int)value + " - " + ConsoleShop.Article.getType((ConsoleShop.ArticleType)value)+", ");
}
Console.WriteLine();

Console.WriteLine("Введите артикул, название, тип (1-" + Enum.GetValues(typeof(ConsoleShop.ArticleType)).Length +
                  "), стоимость товара (конец 0, через ' ')");
ConsoleShop.Article[] articles = new ConsoleShop.Article[0];

string string_in;
string[] strings_in;
double new_article;
string new_name;
int new_type;
float new_price;

while (true)
{
    string_in = Console.ReadLine();
    if (string_in.Equals("0")) break;
    strings_in = string_in.Split();
    if (!double.TryParse(strings_in[0], out new_article)) break;
    new_name = strings_in[1];
    if (!int.TryParse(strings_in[2], out new_type)) break;
    if (!float.TryParse(strings_in[3], out new_price)) break;
    int nextArticle = articles.Length;
    ConsoleShop.Article article =
        new ConsoleShop.Article(new_article, new_name, (ConsoleShop.ArticleType) new_type, new_price);
    Array.Resize(ref articles, (int) nextArticle + 1);
    articles[nextArticle] = article;
}

Console.WriteLine("Товары в магазине: ");

foreach (var item in articles)
    item.print();


Console.WriteLine("Инициализация списка клиентов: ");

Console.WriteLine("Введите имя,отчество,фамилию, телефон, адрес клиента   (конец 0, через ' ')");
ConsoleShop.Client[] clients = new ConsoleShop.Client[0];

string new_nname;
string new_mname;
string new_sname;
string new_telephone;
string new_adres;

while (true)
{
    string_in = Console.ReadLine();
    if (string_in.Equals("0")) break;
    strings_in = string_in.Split();
    new_nname = strings_in[0];
    new_mname = strings_in[1];
    new_sname = strings_in[2];
    new_telephone = strings_in[3];
    new_adres = strings_in[4];
    int nextClient = clients.Length;
    ConsoleShop.Client client =
        new ConsoleShop.Client(nextClient,new_nname, new_mname,new_sname,new_telephone,new_adres);
    Array.Resize(ref clients, (int) nextClient + 1);
    clients[nextClient] = client;
}

Console.WriteLine("Клиенты: ");

foreach (var item in clients)
    item.print();

//Ввод чеков 

