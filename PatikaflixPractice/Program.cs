using PatikaflixPractice;
using System.Runtime.CompilerServices;

List<TVSeries> tVSeriesList = new List<TVSeries>();

while (true)
{
    TVSeries tVSeries = new TVSeries()
    {
        SeriesName = GetStringInput("lütfen dizi adını girin --->"),

        MadeYear = GetIntInput("Lütfen yapım yılını giriniz --->"),

        PublicationYear = GetIntInput("Dizinin başlama yılını giriniz"),


        Type = GetStringInput("Dizinin türünü giriniz --->"),

        Directors = GetStringInput("Lütfen yönetmenin adını giriniz --->"),

        Platform = GetStringInput("Dizi hangi platfomrda yayınlanıyordu --->"),
    };
    tVSeriesList.Add(tVSeries);

    Console.WriteLine("Listeye başka bir dizi eklemek istiyor musunuz?(E/H)");

    string choose = Console.ReadLine().ToLower();

    if (choose == "h")
    break;

}

List<Comedy> comedylist = tVSeriesList
                          .Where(c => c.Type.ToLower() == "komedi")
                          .Select(c => new Comedy
                          {
                              SeriesName = c.SeriesName,
                              Type = c.Type,
                              Director = c.Directors,

                          }).ToList();

var sorted = comedylist.OrderBy(c => c.SeriesName)
                       .ThenBy(c => c.Director)
                       .ToList();

Console.WriteLine("----YENİ OLUŞTURULAN DİZİNİN ÖZELLİKLERİ----");

foreach (var comedy in sorted) 
{
    Console.WriteLine($"Dizinin adı: {comedy.SeriesName}\nDizinin türü: {comedy.Type}\nDizinin yönetmeni: {comedy.Director}");
}

string GetStringInput(string text)
{
    Console.WriteLine(text);
    return Console.ReadLine();
}

int GetIntInput(string text)
{
    bool isValidInput = false;
    int value = 0;
    while (!isValidInput)
    {
        Console.WriteLine(text);

        string userInput = Console.ReadLine();
        if (int.TryParse(userInput, out value))
        {
            isValidInput = true;
        }
        else 
        {
            Console.WriteLine("Geçersiz işlem yaptınız lütfen sayı değeri giriniz");

        }

    }  return value;
}








