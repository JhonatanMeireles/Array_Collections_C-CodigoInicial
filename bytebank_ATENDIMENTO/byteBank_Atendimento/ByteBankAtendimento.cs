using bytebank.Modelos.Conta;
using bytebank_ATENDIMENTO.bytebank.Exceptions;
using Newtonsoft.Json;
using System.Data;


namespace bytebank_ATENDIMENTO.byteBank_Atendimento
{
    internal class ByteBankAtendimento
    {
        private List<ContaCorrente> _listaContas = new List<ContaCorrente>()
{
    new ContaCorrente(95,"123456-X"){Saldo = 100, Titular = new Cliente{Cpf = "11111", Nome = "Bruno"} },
    new ContaCorrente(95,"951258-X"){Saldo = 200, Titular = new Cliente{Cpf = "222", Nome = "Bruna"} },
    new ContaCorrente(94, "987321-W"){Saldo = 60, Titular = new Cliente{Cpf = "3333", Nome = "Claudia"} }
};

        public void AtendimentoCliente()
        {
            try
            {
                char opcao = '0';
                while (opcao != '7')
                {
                    Console.Clear();
                    Console.WriteLine("================================");
                    Console.WriteLine("===        Atendimento       ===");
                    Console.WriteLine("===1 -   Cadastrar Conta     ===");
                    Console.WriteLine("===2 -   Listar Contas       ===");
                    Console.WriteLine("===3 -   Remover Contas      ===");
                    Console.WriteLine("===4 -   Ordenar Contas      ===");
                    Console.WriteLine("===5 -   Pesquisar Contas    ===");
                    Console.WriteLine("===6 -   Exportar Contas    ===");
                    Console.WriteLine("===7 -   Sair do Sistema     ===");
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
                        case '6':
                            ExportarContas();
                            break;
                        case '7':
                            EncerrarAplicacao();
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

        private void ExportarContas()
        {
            Console.Clear();
            Console.WriteLine("================================");
            Console.WriteLine("===    Exportar Contas    ===");
            Console.WriteLine("================================");
            Console.WriteLine("\n");

            if(_listaContas.Count <= 0) 
            {
                Console.WriteLine("Não existe dados para exportação!");
                Console.ReadKey();
            }
            else
            {
                string json = JsonConvert.SerializeObject(_listaContas, Formatting.Indented);
                try
                {
                    FileStream fs = new FileStream("contas.json", FileMode.Create);
                    using(StreamWriter sw = new StreamWriter(fs)) 
                    {  
                        sw.WriteLine(json); 
                    }
                    Console.WriteLine("Arquivo criado.");

                }
                catch (Exception ex)
                {
                    throw new ByteBankException(ex.Message);
                    Console.ReadKey();
                }
            }
        }

        private void EncerrarAplicacao()
        {
            Console.WriteLine("Encerrando a aplicação!");
            Console.ReadKey();
        }

        private void PesquisarContas()
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

        private void ExibeContaPorAgencia(List<ContaCorrente> contasPorAgencia)
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

        private void OrdenarContas()
        {
            _listaContas.Sort();
            Console.WriteLine("lista de contas ordenada");
            Console.ReadKey();
        }

        private void RemoverContas()
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

        private void CadastraConta()
        {
            Console.Clear();
            Console.WriteLine("================================");
            Console.WriteLine("===    Cadastro de Contas    ===");
            Console.WriteLine("================================");
            Console.WriteLine("\n");
            Console.WriteLine("===  Informe dados da conta  ===");

            //Console.Write("Número da conta: ");
            //string numeroConta = Console.ReadLine();

            Console.Write("Número da Agência: ");
            int numeroAgencia = int.Parse(Console.ReadLine());
            ContaCorrente conta = new ContaCorrente(numeroAgencia);
            Console.WriteLine($"Número da conta [NOVA] : {conta.Conta}");

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

        private void ListarContas()
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

    }
}
