﻿using bytebank.Modelos.Conta;
using bytebank_ATENDIMENTO.bytebank.Exceptions;
using bytebank_ATENDIMENTO.bytebank.Util;
using System;
using System.Collections;

Console.WriteLine("Boas Vindas ao ByteBank, Atendimento.");

#region Exemplos Arrays em C#
//TestaArrayInt();
//TestaBuscarPalavra();

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
    for (int i = 0; i < idades.Length; i++)
    {
        int idade = idades[i];
        Console.WriteLine($"indice[{i}] = {idades[i]}");
        acumulador += idade;
    }

    int media = acumulador / idades.Length;
    Console.WriteLine($"A média de idades é: {media}");

}

void TestaBuscarPalavra()
{
    string[] arrayDePalavras = new string[5];

    for (int i = 0; i < arrayDePalavras.Length; i++)
    {
        Console.Write($"Digite {i + 1}ª Palavra: ");
        arrayDePalavras[i] = Console.ReadLine();
    }
    Console.Write($"Digite a palavra a ser encontrada: ");
    var busca = Console.ReadLine();

    foreach (string palavra in arrayDePalavras)
    {
        if (palavra.Equals(busca))
        {
            Console.WriteLine($"Palavra encontrada = {busca}.");
            break;
        }

    }
}

Array amostra = Array.CreateInstance(typeof(double), 5);
amostra.SetValue(5.9, 0);
amostra.SetValue(1.8, 1);
amostra.SetValue(7.1, 2);
amostra.SetValue(10, 3);
amostra.SetValue(6.9, 4);

//TestaMediana(amostra);
void TestaMediana(Array array)
{
    if ((array == null) || (array.Length == 0))
    {
        Console.WriteLine("Array para cálculo da mediana estpa vazio ou nulo");
    }
    else
    {
        double[] numerosOrdenados = (double[])array.Clone();
        Array.Sort(numerosOrdenados);

        int tamanho = numerosOrdenados.Length;
        int meio = tamanho / 2;
        double mediana = (tamanho % 2 != 0) ? numerosOrdenados[meio] :
            (numerosOrdenados[meio] + numerosOrdenados[meio - 1]) / 2;

        Console.WriteLine($"Com base na amostra na amostra a mediana = {mediana}.");
    }
}

//int[] valores = { 10, 58, 36, 47 };

//for(int i = 0; i  < valores.Length; i++)
//{
//    Console.WriteLine(valores[i]);
//}

void TestaArrayDeContasCorrentes()
{
    ListaDeContasCorrentes listaDeContas = new ListaDeContasCorrentes();
    listaDeContas.Adicionar(new ContaCorrente(874, "5679787-A"));
    listaDeContas.Adicionar(new ContaCorrente(874, "5679787-A"));
    listaDeContas.Adicionar(new ContaCorrente(874, "7781438-C"));
    listaDeContas.Adicionar(new ContaCorrente(874, "7781438-C"));
    listaDeContas.Adicionar(new ContaCorrente(874, "7781438-C"));
    listaDeContas.Adicionar(new ContaCorrente(874, "7781438-C"));
    var contaDoAndre = new ContaCorrente(963, "123456-x");
    listaDeContas.Adicionar(contaDoAndre);
    //listaDeContas.ExibirLista();
    //listaDeContas.Remover(contaDoAndre);
    //listaDeContas.ExibirLista();

    for (int i = 0; i < listaDeContas.Tamanho; i++)
    {
        ContaCorrente conta = listaDeContas[i];
        Console.WriteLine($"Índice [{i}] = {conta.Conta} / {conta.Numero_agencia}");
    }
}


//TestaArrayDeContasCorrentes();
#endregion 
# region Exemplos de uso do List

//List<ContaCorrente> _listaContas2 = new List<ContaCorrente>()
//{
//    new ContaCorrente(874, "5679787-A"),
//    new ContaCorrente(874, "445668-B"),
//    new ContaCorrente(874, "7781438-C")
//};

//List<ContaCorrente> _listaContas3 = new List<ContaCorrente>()
//{
//    new ContaCorrente(951, "5679787-E"),
//    new ContaCorrente(321, "445668-F"),
//    new ContaCorrente(719, "7781438-G")
//};

//_listaContas2.AddRange(_listaContas3);
//_listaContas2.Reverse();

//for(int i = 0; i < _listaContas2.Count; i++)
//{
//    Console.WriteLine($"Indice[{i}] = Conta [{_listaContas2[i].Conta}]");
//}

//Console.WriteLine("\n\n");

//var range = _listaContas3.GetRange(0,1);

//for (int i = 0; i < range.Count; i++)
//{
//    Console.WriteLine($"Indice[{i}] = Conta [{range[i].Conta}]");
//}

//Console.WriteLine("\n\n");

//_listaContas3.Clear();

//for (int i = 0; i < _listaContas3.Count; i++)
//{
//    Console.WriteLine($"Indice[{i}] = Conta [{range[i].Conta}]");
//}

#endregion

List<ContaCorrente> _listaContas = new List<ContaCorrente>()
{
    new ContaCorrente(95,"123456-X"){Saldo = 100, Titular = new Cliente{Cpf = "11111", Nome = "Bruno"} },
    new ContaCorrente(95,"951258-X"){Saldo = 200, Titular = new Cliente{Cpf = "222", Nome = "Bruna"} },
    new ContaCorrente(94, "987321-W"){Saldo = 60, Titular = new Cliente{Cpf = "3333", Nome = "Claudia"} }
};

AtendimentoCliente();
void AtendimentoCliente()
{
    try
    {
        char opcao = '0';
        while (opcao != '6')
        {
            Console.Clear();
            Console.WriteLine("================================");
            Console.WriteLine("===        Atendimento       ===");
            Console.WriteLine("===1 -   Cadastrar Conta     ===");
            Console.WriteLine("===2 -   Listar Contas       ===");
            Console.WriteLine("===3 -   Remover Contas      ===");
            Console.WriteLine("===4 -   Ordenar Contas      ===");
            Console.WriteLine("===5 -   Pesquisar Contas    ===");
            Console.WriteLine("===6 -   Sair do Sistema     ===");
            Console.WriteLine("================================");
            Console.WriteLine("\n\n");
            Console.WriteLine("Digite a opção desejada");
            try
            {
                opcao = Console.ReadLine()[0];

            }
            catch (Exception excecao)
            {

                throw new ByteBankException(excecao.Message);
            }
            switch (opcao)
            {
                case '1':
                    CadastraConta();
                    break;
                case '2':
                    ListarContas();
                    break;
                case '3':
                    RemoverContas();
                    break;
                case '4':
                    OrdenarContas();
                    break;
                case '5':
                    PesquisarContas();
                    break;
                default:
                    Console.WriteLine("Opção não implementada.");
                    break;
            }

        }

    }
    catch (ByteBankException excecao)
    {

        Console.WriteLine($"{excecao.Message}");
    }
}

void PesquisarContas()
{
    Console.Clear();
    Console.WriteLine("================================");
    Console.WriteLine("===    Pesquisar Contas    ===");
    Console.WriteLine("================================");
    Console.WriteLine("\n");
    Console.WriteLine("Deseja pesquisa por (1) NÚMERO DA CONTA, (2) CPF TITULAR ou (3) NÚMERO DA AGÊNCIA");
    switch (int.Parse(Console.ReadLine()))
    {
        case 1:
            {
                Console.WriteLine("Informe o número da conta: ");
                string numeroConta = Console.ReadLine();
                ContaCorrente consultaConta = ConsultaPorNumeroConta(numeroConta);
                Console.WriteLine(consultaConta.ToString());
                Console.ReadKey();
                break;
            }
        case 2:
            {
                Console.WriteLine("Informe o CPF do Titular: ");
                string cpf = Console.ReadLine();
                ContaCorrente consultaConta = ConsultaPorCPFTitular(cpf);
                Console.WriteLine(consultaConta.ToString());
                Console.ReadKey();
                break;
            }
        case 3:
            {
                Console.WriteLine("Informe o Nº da Agência: ");
                int numeroAgencia = int.Parse(Console.ReadLine());
                var contasPorAgencia = ConsultaPorAgencia(numeroAgencia);
                ExibeContaPorAgencia(contasPorAgencia);
                Console.ReadKey();
                break;
            }
        default:
            Console.WriteLine("Opção inválida");
            Console.ReadKey();
            break;
    }

}

void ExibeContaPorAgencia(List<ContaCorrente> contasPorAgencia)
{
    if (contasPorAgencia == null)
    {
        Console.WriteLine("Não há dados para a agência informada.");
    }
    else
    {

        foreach (var Con in contasPorAgencia)
            Console.WriteLine(Con.ToString());
    }
}

List<ContaCorrente> ConsultaPorAgencia(int numeroAgencia)
{
    var consulta =
        (
        from conta in _listaContas
        where conta.Numero_agencia == numeroAgencia
        select conta

        ).ToList();
    return consulta;
}

ContaCorrente ConsultaPorCPFTitular(string? cpf)
{
    //ContaCorrente conta = null;
    //for (int i = 0; i < _listaContas.Count; i++)
    //{
    //    if (_listaContas[i].Titular.Cpf.Equals(cpf))
    //    {
    //        conta = _listaContas[i];
    //    }
    //}
    //return conta;

    return _listaContas.Where(conta => conta.Titular.Cpf == cpf).FirstOrDefault();
}

ContaCorrente ConsultaPorNumeroConta(string? numeroConta)
{
    //ContaCorrente conta = null;
    //for(int i = 0; i<_listaContas.Count; i++)
    //{
    //    if (_listaContas[i].Conta.Equals(numeroConta))
    //    {
    //        conta = _listaContas[i];
    //    }
    //}
    //return conta;

    return _listaContas.Where(conta => conta.Conta == numeroConta).FirstOrDefault();
}

void OrdenarContas()
{
    _listaContas.Sort();
    Console.WriteLine("lista de contas ordenada");
    Console.ReadKey();
}

void RemoverContas()
{
    Console.Clear();
    Console.WriteLine("================================");
    Console.WriteLine("===    Remover Contas    ===");
    Console.WriteLine("================================");
    Console.WriteLine("\n");
    Console.WriteLine("Informe o número da conta");
    string numeroConta = Console.ReadLine();
    ContaCorrente conta = null;
    foreach (var item in _listaContas)
    {
        if (item.Conta.Equals(numeroConta))
        {
            conta = item;
        }
    }
    if (conta != null)
    {
        _listaContas.Remove(conta);
        Console.WriteLine("... Conta removida com sucesso! ...");
    }
    else
    {
        Console.WriteLine("... Conta não localizada para remoção! ...");
    }
    Console.ReadKey();

}

void CadastraConta()
{
    Console.Clear();
    Console.WriteLine("================================");
    Console.WriteLine("===    Cadastro de Contas    ===");
    Console.WriteLine("================================");
    Console.WriteLine("\n");
    Console.WriteLine("===  Informe dados da conta  ===");

    Console.Write("Número da conta: ");
    string numeroConta = Console.ReadLine();

    Console.Write("Número da Agência: ");
    int numeroAgencia = int.Parse(Console.ReadLine());

    ContaCorrente conta = new ContaCorrente(numeroAgencia, numeroConta);

    Console.Write("Informe o saldo inicial: ");
    conta.Saldo = double.Parse(Console.ReadLine());

    Console.Write("Informe o nome do titular: ");
    conta.Titular.Nome = Console.ReadLine();

    Console.Write("Informe CPF do Titular: ");
    conta.Titular.Cpf = Console.ReadLine();

    Console.Write("Informe a Profissão do Titular: ");
    conta.Titular.Profissao = Console.ReadLine();

    _listaContas.Add(conta);
    Console.WriteLine("... Conta cadastrada com sucesso! ...");
    Console.ReadKey();

}

void ListarContas()
{
    Console.Clear();
    Console.WriteLine("================================");
    Console.WriteLine("===     Listar de Contas     ===");
    Console.WriteLine("================================");
    Console.WriteLine("\n");

    if (_listaContas.Count <= 0)
    {
        Console.WriteLine("... Não há contas cadastradas! ...");
        Console.ReadKey();
        return;
    }

    foreach (ContaCorrente itens in _listaContas)
    {
        Console.WriteLine(itens.ToString());
        Console.ReadKey();
    }
}
