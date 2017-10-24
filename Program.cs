using System;
using System.IO;

namespace Programar
{class Program

    {static void Main(string[] args)
        {string opcao1 = "";

            do
            {
                Console.WriteLine("Digite a opção");
                Console.WriteLine("1 - Cadastrar Cliente");
                Console.WriteLine("2 - Cadastrar Produto");
                Console.WriteLine("3 - Realizar Venda");
                Console.WriteLine("4 - Extrato Cliente");
                Console.WriteLine("9 - Sair");

                opcao1 = Console.ReadLine();
            
                switch(opcao1)
                {
                    case "1": CadastrarCliente();
                    break;
                    case "2": CadastrarProduto();
                    break;
                    case "3": RealizarVenda();
                    break;
                    case "4": ExtratoCliente();
                    break;
                    case "9":
                                {Console.WriteLine("Deseja realmente sair(s ou n)");
                                string sair = Console.ReadLine();
                                if(sair.ToLower().Contains("s"))
                                    Environment.Exit(0);
                                else if(!sair.ToLower().Contains("n"))
                                
                                    {opcao1 = "0";
                                    Console.WriteLine("Opção Inválida");
                                    }
                                else
                                    {opcao1 = "0";
                                    }
                            }
                    

                             
                    break;
                }
            }
   
            while (opcao1 != "9");
        }
        static void CadastrarCliente()
            {
            Console.WriteLine("Cadastro");
            Console.WriteLine("Qual é seu nome?");
            string nome = Console.ReadLine();
            Console.WriteLine("Qual é seu e-mail?");
            string email = Console.ReadLine();
            Console.WriteLine("Pessoa física (digite 1), pessoa jurídica (digite 2)");
            string opcao2 = Console.ReadLine();
            switch(opcao2)
            {
                case "1":
                        bool cpfvalido = false; 
                        Console.WriteLine("Qual é seu CPF?");
                        string cpf = Console.ReadLine();
                        cpfvalido = checagemcpf(cpf,nome,email);
                        
                break;
                case "2":
                        bool cnpjvalido = false; 
                        Console.WriteLine("Qual é seu CNPJ?");
                        string cnpj = Console.ReadLine(); 
                        cnpjvalido = checagemcnpj(cnpj,nome,email);

                break;
                default: 
                        CadastrarCliente();
                break;
                }
            }
        
    static bool checagemcpf(string cpf, string nome, string email)
       
       {bool cpfvalido = false;
        if(cpf.Length != 11)
        {
            Console.WriteLine("CPF Inválido"); 
            return cpfvalido;         
        }
        else
        {
            int[] multiplicador1 = new int[]{10,9,8,7,6,5,4,3,2};
            int[] multiplicador2 = new int[]{11,10,9,8,7,6,5,4,3,2};
            string cpf9, cpf10, cpfult2, digito, digito1, digito2;
            int soma1=0, resto1=0, soma2=0, resto2=0;
            cpf9 = cpf.Substring(0,9);
            cpfult2 = cpf.Substring(9,2);

            for(int i = 0; i < 9; i++)
            {
                soma1 += Convert.ToInt16(cpf9[i].ToString()) * multiplicador1[i];                     
            }

            resto1 = soma1%11;

            if(resto1 < 2)
            {
                resto1 = 0;
            }
            else
            {
                resto1 = 11 - resto1;
            }
                
            digito1 = resto1.ToString();
            cpf10 = cpf9 + digito1;
                              
                
            for(int i=0;i<10;i++)
            {
                soma2 += Convert.ToInt32(cpf10[i].ToString()) * multiplicador2[i]; 
            }
                
            resto2 = soma2%11;

            if(resto2 < 2)
            {
                resto2 = 0;
            }
            else
            {
                resto2 = 11 - resto2;
            }

            digito2 = resto2.ToString();
            digito = digito1 + digito2;

            if(digito==cpfult2.ToString())
            {
                Console.WriteLine("CPF Válido");
                StreamWriter cadastro = new StreamWriter ("Cadastro.txt", true);
                FileInfo cabecalho = new FileInfo("Cadastro.txt");
                if(cabecalho.Length == 0)
                {
                    cadastro.WriteLine ("NOME; E-MAIL; CPF/CNPJ; DATA");
                }
                    cadastro.WriteLine(nome + ";" + email + ";" + cpf + ";" + DateTime.Now);
                    cadastro.Close();
                    cpfvalido = true;
            }
            else
            {
                 Console.WriteLine("CPF Inválido");      
            }
            return cpfvalido;
        }
        
        }
    static bool checagemcnpj(string cnpj, string nome, string email)
        {bool cnpjvalido = false;
            
        if(cnpj.Length != 14)
        {
            Console.WriteLine("CNPJ Inválido");
            return cnpjvalido;
        }
        else
        {
            int[] multiplicador1 = new int[]{5,4,3,2,9,8,7,6,5,4,3,2};
            int[] multiplicador2 = new int[]{6,5,4,3,2,9,8,7,6,5,4,3,2};
            string cnpj12, cnpj13, cnpjult2, digito, digito1, digito2;
            int soma1=0, resto1=0, soma2=0, resto2=0;
            cnpj12 = cnpj.Substring(0,12);
            cnpjult2 = cnpj.Substring(12,2);

            for(int i = 0; i < 12; i++)
            {
                soma1 += Convert.ToInt16(cnpj12[i].ToString()) * multiplicador1[i];                     
            }

            resto1 = soma1%11;

            if(resto1 < 2)
            {
                resto1 = 0;
            }
            else
            {
                resto1 = 11 - resto1;
            }
                
            digito1 = resto1.ToString();
            cnpj13 = cnpj12 + digito1;
                              
                
            for(int i=0;i<13;i++)
            {
                soma2 += Convert.ToInt16(cnpj13[i].ToString()) * multiplicador2[i]; 
            }
                
            resto2 = soma2%11;

            if(resto2 < 2)
            {
                resto2 = 0;
            }
            else
            {
                resto2 = 11 - resto2;
            }

            digito2 = resto2.ToString();
            digito = digito1 + digito2;

            if(digito==cnpjult2.ToString())
            {
                Console.WriteLine("CNPJ Válido");
                StreamWriter cadastro = new StreamWriter ("Cadastro.txt", true);
                FileInfo cabecalho = new FileInfo("Cadastro.txt");
                if(cabecalho.Length == 0)
                {
                    cadastro.WriteLine ("NOME; E-MAIL; CPF/CNPJ; DATA");
                }
                cadastro.WriteLine(nome + ";" + email + ";" + cnpj + ";" + DateTime.Now + ";");
                cadastro.Close();
                cnpjvalido = true;
                }
                else
                {
                     Console.WriteLine("CNPJ Inválido");
                }
                return cnpjvalido;
            }
        
        }
    


    static void CadastrarProduto()
    
        {Console.WriteLine("Qual o nome do produto?");
        string nomeproduto = Console.ReadLine();
        Console.WriteLine("Qual o código do produto?");
        string codigoproduto = Console.ReadLine();
        Console.WriteLine("Descrição do produto:");
        string descricaoproduto = Console.ReadLine();
        Console.WriteLine("Qual o preço do produto?");
        string precoproduto = Console.ReadLine();

        StreamWriter cadastroproduto = new StreamWriter ("Cadastroproduto.txt", true);
        cadastroproduto.WriteLine(nomeproduto + ";" + codigoproduto + ";" + descricaoproduto + ";" + precoproduto + ";");
        cadastroproduto.Close();
        FileInfo cabecalho = new FileInfo("Cadastroproduto.txt");
        if(cabecalho.Length == 0)
        {
            cadastroproduto.WriteLine ("NOME DO PRODUTO; CÓDIGO DO PRODUO; DESCRIÇÃO DO PRODUTO; PREÇO;");
        }
        }
    static void RealizarVenda()
    
        {Console.WriteLine("Digite seu CPF");
        string cpfvenda = Console.ReadLine();     
        string[] linhas = File.ReadAllLines("Cadastro.txt");
        bool cpfencontrado = false;
        string linhacliente = "";
        foreach(string linha in linhas)
        {
            if(linha.Contains(cpfvenda) == true)
            {
               cpfencontrado = true;
                linhacliente = linha;
                break;
            }
            else
            {
            cpfencontrado = false;
            }            
        }
    
        if(cpfencontrado == true)
        {
            Console.WriteLine("CPF Válido");
            string[] produtos = File.ReadAllLines("Cadastroproduto.txt");
            foreach(string produtovenda in produtos)
            {
                Console.WriteLine(produtovenda);
            }

            Console.WriteLine("Digite o código do produto");
            string codigoproduto = Console.ReadLine();
                    
            StreamWriter cadastrovendas = new StreamWriter ("Cadastrovendas.txt", true);
            FileInfo cabecalho = new FileInfo("Cadastrovendas.txt");
            if(cabecalho.Length == 0)
            {
                cadastrovendas.WriteLine ("NOME DO CLIENTE; E-MAIL; CPF DO CLIENTE; DATA DO CADASTRO; NOME DO PRODUTO; CÓDIGO DO PRODUTO; DESCRIÇÃO DO PRODUTO; PREÇO; DATA DA COMPRA;");
            }
                   
            foreach(string linhaproduto in produtos)
            {
                if(linhaproduto.Contains(codigoproduto) == true)
                {
                cadastrovendas.WriteLine(linhacliente + ";" + linhaproduto + ";" + DateTime.Now + ";");
                cadastrovendas.Close();
                }
                        
            }
        }
        else
        {
            Console.WriteLine("CPF Inválido");
            CadastrarCliente();
        }
        } 
    static void ExtratoCliente()
        
        {Console.WriteLine("Pessoa física (digite 1), pessoa jurídica (digite 2)");
        string opcao2 = Console.ReadLine();
        string nome = "";
        string email = "";
        switch(opcao2)
        {
            case "1":
                bool cpfvalido = false; 
                Console.WriteLine("Qual é seu CPF?");
                string cpf = Console.ReadLine();
                cpfvalido = checagemcpf(cpf,nome,email);
                if(cpfvalido == true)
                {
                    string[] compras = File.ReadAllLines("Cadastrovendas.txt");
                    foreach( string compra in compras)
                    {
                        if(compra.Contains(cpf))
                        {
                            Console.WriteLine(compra);
                        }
                    }
                }
                    break;
                    
            case "2":
                bool cnpjvalido = false; 
                Console.WriteLine("Qual é seu CNPJ?");
                string cnpj = Console.ReadLine(); 
                cnpjvalido = checagemcnpj(cnpj,nome,email);
                if(cnpjvalido == true)
                {
                    string[] compras = File.ReadAllLines("Cadastrovendas.txt");
                    foreach( string compra in compras)
                    {
                        if(compra.Contains(cnpj))
                        {
                            Console.WriteLine(compra);
                        }
                    }
                }
                    break;
                
            default: 
                    ExtratoCliente();
                    break;           
                
        }
        }
    } 
}       