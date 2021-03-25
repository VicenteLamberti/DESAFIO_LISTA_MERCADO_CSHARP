using System;
using System.Collections.Generic;
using System.Collections;

public class Item
{
    public string nItem { get; set; }
    public int qtItem { get; set; }
    public int vUnitario { get; set; }
    public int vTotal
    {
        get
        {
            return qtItem*vUnitario;
        }
    }

    public Item(string n, int qtd, int val)
    {
        nItem = n;
        qtItem = qtd;
        vUnitario = val;
    }
    
   
    
}

public class Email
{
    public string nomeEmail { get; set; }
    public Email(string email)
    {
        nomeEmail=email;
    }   

}



class desafio_1 
{
    static void Main ()
    {
        Console.Clear();
       
        List<Email>listaEmail = new List<Email>();
        
        //ADICIONAR EMAIL
        
        string verificacaoEmail = "s";
        while (verificacaoEmail == "s")
        {
            string email;
            Console.Clear();
            seEmailExistir:
            Console.WriteLine("Adicione o email que irá dividir a compra: ");
            email = Console.ReadLine().ToUpper();
            
            
             foreach (Email current in listaEmail)
             {
                 if(email == current.nomeEmail)
                 {
                    Console.WriteLine("Esse email já existe, digite outro");
                    goto seEmailExistir;
                 }
             }
            
            while(String.IsNullOrEmpty(email))
            {
                Console.WriteLine("Digite um email");
                email = Console.ReadLine().ToUpper();;
            }
         
                listaEmail.Add(new Email(email));


            Console.WriteLine("Deseja adicionar outro email? [s/n]" );
            verificacaoEmail = Console.ReadLine();
            while((verificacaoEmail != "s")&&(verificacaoEmail !="n"))
            {
                Console.WriteLine("Opção inválida");
                Console.WriteLine("Deseja adicionar outro email? [s/n]" );
                verificacaoEmail = Console.ReadLine();
            }
            Console.Clear();
        }

        
        Console.WriteLine("Emails Adicionados - Quantidade - {0}",listaEmail.Count);
        foreach (Email current in listaEmail)
        {
            Console.WriteLine(current.nomeEmail);
        }
        Console.WriteLine("\nAperte qualquer tecla para continuar.");
        Console.ReadKey();
        Console.Clear();
        
        
        //ADICIONAR ATRIBUTO NOME DO ITEM
        
        List<Item>lista = new List<Item>();
        
        string verificacao = "s";
        while (verificacao == "s")
        {
            string nome;
            string qtde,preco;
            int qtdeNum = 0, precoNum=0;
            bool ver ;
            int result;

            Console.WriteLine("Qual item deseja adicionar?");
            nome = Console.ReadLine();
            while(nome == "")
            {
               Console.WriteLine("\nItem vazio ou inválido");
               Console.WriteLine("\nQual item deseja adicionar?");
               nome = Console.ReadLine();
            
            }
            
            //ADICIONAR ATRIBUTO QUANTIDADE DO ITEM 

            seQuantidadeForString: 
            Console.WriteLine("\nQual a quantidade?");
            qtde = Console.ReadLine();
            ver = int.TryParse(qtde, out result);                           
            
            while(qtde == "")
            {
                Console.WriteLine("\nQuantidade vazia ou inválida");
                Console.WriteLine("\nQual a quantidade?");
                qtde = Console.ReadLine();
                ver = int.TryParse(qtde, out result);
            }
            
            if(ver)
            {
                qtdeNum = int.Parse(qtde);
            }
            else 
            {
                Console.WriteLine("\nQuantidade vazia ou inválida");
                goto seQuantidadeForString;
            }

            //ADICIONAR ATRIBUTO PREÇO DO ITEM
            
            Console.WriteLine("\nQual a preço?");
            try
            {
                preco = Console.ReadLine();
                precoNum = int.Parse(preco);
            }
            catch(Exception e)
            {
                preco="";
            }
            
            while(preco =="")
            {
                try
                {
                    Console.WriteLine("\nPreço vazio ou inválido");
                    Console.WriteLine("\nQual a preço?");
                    preco = Console.ReadLine();
                    precoNum = int.Parse(preco);
                }
                catch(Exception e)
                {
                    preco= "";
                }
            }
            
            //ADICIONAR OBJETO ITEM NA LISTA

            lista.Add(new Item(nome,qtdeNum,precoNum));

            Console.WriteLine("\nDeseja adicionar outro item? [s/n]" );
            verificacao = Console.ReadLine();
            while((verificacao != "s" )&&(verificacao!="n"))
            {
                Console.WriteLine("\nOpção inválida");
                Console.WriteLine("\nDeseja adicionar outro item? [s/n]" );
                verificacao = Console.ReadLine();
            }
            Console.Clear();
        }
        
        //RESULTADO DA LISTA DE ITEM
        int soma = 0;
        int resto = 0;
        int precoTotalDividido=0;
        int precoTotalDivididoMaisResto=0;

        foreach (Item current in lista)
        {
            Console.WriteLine("Item: " + current.nItem + " - Quantidade: " + current.qtItem + "  - Preço: R$ " + current.vUnitario + " centavos - Preço Total: R$ " + current.vTotal + " centavos.");
            
            soma = soma + current.vTotal; //VALOR TOTAL DA COMPRA
        }

        if((soma)%(listaEmail.Count)==0)
        {
            precoTotalDividido = soma/listaEmail.Count;
            //Console.WriteLine("Valor total da compra: R$ " + soma + " centavos. \nValor que cada um irá pagar: R$ " + precoTotalDividido + " centavos.");
        }
        else
        {
            resto = soma%listaEmail.Count;
            precoTotalDividido = soma/listaEmail.Count;
            precoTotalDivididoMaisResto = precoTotalDividido + resto;
            //Console.WriteLine("a compra deu " + soma +" o valor é " + precoTotalDividido + " para " + ((listaEmail.Count)-1) + " pessoa e " + precoTotalDivididoMaisResto + " para 1 pessoa");

        }
                  
        //CRIAÇÃO DICIONARIO COM A LISTA DE EMAIL E O VALOR QUE CADA UM IRÁ PAGAR
        
        string ultimo = "";
        Dictionary<string,int>dicionario = new Dictionary<string, int>();
        
        if((soma)%(listaEmail.Count)==0)
        {
            foreach(Email current in listaEmail)
            {
                dicionario.Add(current.nomeEmail,precoTotalDividido);
            }

            foreach (KeyValuePair<string,int> current in dicionario)
            {
                Console.WriteLine("Email: " + current.Key + " - " + " R$ " + current.Value + " centavos");
            }
        }
        
        else
        {
            foreach (Email current in listaEmail)
            {
                dicionario.Add(current.nomeEmail, precoTotalDividido);
                ultimo = current.nomeEmail;
            }
            
            dicionario[ultimo] = precoTotalDivididoMaisResto;
            foreach (KeyValuePair<string,int> current in dicionario)
            {
                Console.WriteLine("Email: " + current.Key + " - " + " R$ " + current.Value + " centavos");
            }
        }
    }
}