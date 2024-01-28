Console.WriteLine("Boas Vindas ao ByteBank, Atendimento.");

int idade = 30;

int[] idades = new int[5];
idades[0] = 30;
idades[1] = 40;
idades[2] = 17;
idades[3] = 21;
idades[4] = 18;

void TestaArrayInt()
{
    int[] idades = new int[5];
    idades[0] = 30;
    idades[1] = 40;
    idades[2] = 17;
    idades[3] = 21;
    idades[4] = 18;

    Console.WriteLine($"Tamanho do Array: {idades.Length}");
    int acumulador = 0;
    for( int i = 0; i < idades.Length; i++)
    {
        int idade = idades[i];
        Console.WriteLine($"indice[{i}] = {idades[i]}");
        acumulador += idade;
    }

    int media =  acumulador/idades.Length;
    Console.WriteLine($"A média de idades é: {media}");

}

void TestaBuscarPalavra()
{
    string[] arrayDePalavras= new string[5];

    for( int i = 0;i < arrayDePalavras.Length; i++)
    {
        Console.Write($"Digite {i + 1}ª Palavra: ");
        arrayDePalavras[i]= Console.ReadLine();
    }
    Console.Write($"Digite a palavra a ser encontrada: ");
    var busca = Console.ReadLine();

    foreach( string palavra in arrayDePalavras )
    { 
        if (palavra.Equals(busca)) 
        {
            Console.WriteLine($"Palavra encontrada = {busca}.");
            break;
        } 
        
    }
}

//TestaArrayInt();
TestaBuscarPalavra();