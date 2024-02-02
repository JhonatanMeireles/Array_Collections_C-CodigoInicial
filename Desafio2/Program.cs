List<string> nomesDosEscolhidos = new List<string>()
{
    "Bruce Wayne",
    "Carlos Vilagran",
    "Richard Grayson",
    "Bob Kane",
    "Will Farrel",
    "Lois Lane",
    "General Welling",
    "Perla Letícia",
    "Uxas",
    "Diana Prince",
    "Elisabeth Romanova",
    "Anakin Wayne"
};


void ExisteONome(List<string> receba)
{
    if(receba.Contains("Anakin Wayne"))
        Console.Write("Localizado");
    Console.WriteLine("\n\n");
}

ExisteONome(nomesDosEscolhidos);