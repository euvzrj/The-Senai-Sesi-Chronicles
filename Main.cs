using System;

class Persona
{
    public string Nome {get; private set;}
    public string Classe { get; private set; }
    public int Agi {get; private set;}
    public int Forca {get; private set;}
    public int Vigor {get; private set;}
    public int Nivel { get; private set; }


    public void CriarFicha()
    {
        Console.WriteLine("-=-=-=-=-=CRIAÇÃO DE PERSONAGEM=-=-=-=-=-");
        Console.WriteLine("Qual é o nome do seu personagem?");
        Nome = Console.ReadLine();
        Console.Clear();

        while (string.IsNullOrWhiteSpace(Nome))
        {
            Console.Clear();
            Console.WriteLine("-=-=-=-=-=CRIAÇÃO DE PERSONAGEM=-=-=-=-=-");
            Console.WriteLine("!!ERRO!! Digite um nome válido.");
            Nome = Console.ReadLine()?.Trim();
            Console.Clear();

        }


        string escolha = "";
        while (true)
        {
            Console.WriteLine("-=-=-=-=-=ESCOLHA SUA CLASSE=-=-=-=-=-");
            Console.WriteLine(@"Qual classe você escolhe pro seu personagem?
1. O cara legal
>>Você é o clássico cara legal da escola. Não tem nada demais, nem de menos.
>>+1 em força, agilidade e vigor.

2. O Marombeiro
>>Você é aquele cara da escola que faz academia. Vive pelos seus treinos, com dietas regradas sempre em busca do shape inexplicável e da estética perfeita.
>>+2 em força, +1 em vigor

3. O Atleta
>>Você é incrívelmente bom nos esportes. Corre rápido, tem um fôlego invejável e sempre chama está treinando para melhorar sua performance.
>>+2 em agilidade, +1 em vigor");


            escolha = Console.ReadLine();

            if (escolha == "1")
            {
                Classe = "O cara legal";
                Forca += 1;
                Agi += 1;
                Vigor += 1;
                break;
            }
            else if (escolha == "2")
            {
                Classe = "Marombeiro";
                Forca += 2;
                Agi += 0;
                Vigor += 1;
                break;
            }
            else if (escolha == "3")
            {
                Classe = "Atleta";
                Forca += 0;
                Agi += 2;
                Vigor += 1;
                break;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Digite uma opção válida!");
            }
        }

        Console.Clear();
    }

    public void VerFicha()
    {
        Console.WriteLine("-=-=-=-=-=JOGADOR REGISTRADO=-=-=-=-=-");
        Console.WriteLine($"Ficha criada!\nNome: {this.Nome}\nClasse: {this.Classe}\n" +
         $"Força: {this.Forca}\nAgilidade: {this.Agi}\nVigor: {this.Vigor}");
    }

    public void LevelUp()
    {
        while (true)
        {
            Console.WriteLine(@"-=-=-=-=-=PARABÉNS=-=-=-=-=-
você subiu de nível. Como recompensa, escolha 1 atributo para ganhar mais um ponto.

Qual você escolhe? 
1. AGILIDADE
2. FORÇA
3. VIGOR");
            string escolha = Console.ReadLine();
            if (escolha == "1")
            {
                Console.WriteLine("Você ganhou +1 ponto em AGILIDADE!");
                Agi += 1;
                break;
            }
            else if (escolha == "2")
            {
                Console.WriteLine("Você ganhou +1 ponto em FORÇA!");
                Forca += 1;
                break;
            }
            else if (escolha == "3")
            {
                Console.WriteLine("Você ganhou +1 ponto em VIGOR!");
                Vigor += 1;
                break;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Digite uma opção válida!");
            }
        }
        Console.Clear();
        VerFicha();
        Console.WriteLine("\nAperte ENTER para continuar...");
        Console.ReadLine();
        Console.Clear();
    }
}

class Program
{

    //Função dado
    static Random dado = new Random();
    public static int Dado(int faces)
    {
        return dado.Next(1, faces + 1);
    }


    public static void Main()
    {
        //Textos
        string titulo = "-=-=-=-=-=THE SENAI SESI CHRONICLES=-=-=-=-=-\nAperte ENTER para começar.";

        //criando objetos
        Persona player = new Persona();

        //Main
        Console.WriteLine(titulo);
        Console.ReadLine();
        Console.Clear();

        player.CriarFicha();
        player.VerFicha();
        Console.Clear();

        player.LevelUp();

        Console.WriteLine($"Teste com D20: {Dado(20)}");
    }
}
