/*
 * Contrataram você como o novo desenvolvedor da equipe da Esther, 
 * e você ficou responsável de iniciar a codificação do módulo de estatística da aplicação, 
 * iniciando o desenvolvimento da função que irá calcular a média de uma amostra. 
 * Essa amostra será um vetor de doubles que será o parâmetro de entrada do seu método.
 * Te desafiamos a criar um método que receba como parâmetro um array de double 
 * e retorne a média simples calculada.
*/

void Media()
{
    double[] arrayDeDoubles = new double[5];
    Console.WriteLine("Vamos digitar 5 números para encontrar-mos a média deles");

    double acumulador = 0;
    for (int i = 0; i < 5; i++)
    {
        Console.Write($"Digite o {i + 1}º número: ");        
        arrayDeDoubles[i] = double.Parse(Console.ReadLine());
        acumulador += arrayDeDoubles[i];
    }
    Console.WriteLine();
    Console.WriteLine($"{acumulador / arrayDeDoubles.Length} foi a média encontrada.");

}
Media();
