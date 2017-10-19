﻿using System;
using System.IO;

namespace s2d2t1
{
    class Program
    {
        static void Main(string[] args)
        {
            string opcao1 = "";

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
                case "1": 
                    CadastrarCliente();
                    break;
                // case "2": CadastrarProduto();
                // break;
                // case "3": RealizarVenda();
                // break;
                // case "4": ExtratoCliente("Extrato Cliente");
                // break;
                }
            }
            
            while (opcao1 != "9");
        }
            static void CadastrarCliente()
            {
            Console.WriteLine("Qual é seu nome?");
            string nome = Console.ReadLine();
            Console.WriteLine("Qual é seu e-mail?");
            string email = Console.ReadLine();
            Console.WriteLine("Pessoa físia (digite 1), pessoa jurídica (digite 2");
            string opcao2 = Console.ReadLine();
                switch(opcao2)
                {
                    case "1": 
                        Console.WriteLine("Qual é seu CPF?");
                        string cpf = Console.ReadLine();
                        bool cpfvalido = checagemcpf(cpf);
                        
                        break;
                    case "2":
                        Console.WriteLine("Qual é seu CNPJ?");
                        string cnpj = Console.ReadLine(); 
                        bool cnpjvalido = checagemcnpj(cnpj);
                        break;
                    default: 
                        CadastrarCliente();
                        break;
                }
            }
        
    static bool checagemcpf(string cpf)
        {
            if(cpf.Length != 11)
            {
                Console.WriteLine("CPF Inválido");
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
                }
                 else
                {
                     Console.WriteLine("CPF Inválido");      
                }

            }
        
        }
    static bool checagemcnpj(string cnpj)
        {
            
            if(cnpj.Length != 14)
            {
                Console.WriteLine("CNPJ Inválido");
            }
            else
            {
                int[] multiplicador1 = new int[]{5,4,3,2,9,8,7,6,5,4,3,2};
                int[] multiplicador2 = new int[]{6,5,4,3,2,9,8,7,6,5,4,3,2};
                string cnpj12, cnpj13, cnpjult2, digito, digito1, digito2;
                int soma1=0, resto1=0, soma2=0, resto2=0;
                cnpj12 = cnpj.Substring(0,12);
                cnpjult2 = cnpj12.Substring(10,2);

                for(int i = 0; i < 9; i++)
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
                              
                
                for(int i=0;i<10;i++)
                {
                    soma2 += Convert.ToInt32(cnpj13[i].ToString()) * multiplicador2[i]; 
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
                }
                 else
                {
                     Console.WriteLine("CNPJ Inválido");
                }

            }
        
        }
    }

}        