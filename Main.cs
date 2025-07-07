using System;
class Persona
{
    public string nome;
    public int agilidade;
    public int forca;
    public int vigor;
    public int vida;
    public int ca;
    public int dano;

    public void criaficha()
    {
        Console.WriteLine("\nQual e o seu nome?");
        this.nome = Console.ReadLine();

        Console.WriteLine("\nQuantos pontos voce quer colocar em AGILIDADE?");
        this.agilidade = int.Parse(Console.ReadLine());

        Console.WriteLine("\nQuantos pontos voce quer colocar em FORCA?");
        this.forca = int.Parse(Console.ReadLine());

        Console.WriteLine("\nQuantos pontos voce quer colocar em VIGOR?");
        this.vigor = int.Parse(Console.ReadLine());

        int totalpontos = this.vigor + this.agilidade + this.forca;
        if (totalpontos > 4)
        {
            Console.WriteLine("\nMaldito homem que confia no homem!\nEu te disse que era para agir de " +
                "maneira JUSTA e voce traiu minha confianca...\nComo punicao, agora voce tem apenas 3 " +
                "pontos para distribuir entre seus Atributos.\n");

            this.agilidade = 0;
            this.forca = 0;
            this.vigor = 0;

            Console.WriteLine("\nDistribua seus 3 pontos restantes.");

            Console.WriteLine("\nQuantos pontos voce quer colocar em AGILIDADE?");
            this.agilidade = int.Parse(Console.ReadLine());

            Console.WriteLine("\nQuantos pontos voce quer colocar em FORCA?");
            this.forca = int.Parse(Console.ReadLine());

            Console.WriteLine("\nQuantos pontos voce quer colocar em VIGOR?");
            this.vigor = int.Parse(Console.ReadLine());

            totalpontos = this.vigor + this.agilidade + this.forca;

            if (totalpontos > 3)
            {
                Console.WriteLine("\nVoce traiu minha confianca pela segunda vez...\n" +
                    "Como punicao definitiva, seus pontos serao automaticamente distribuidos.");

                this.agilidade = 1;
                this.forca = 1;
                this.vigor = 1;
            }
        }
        else
        {
            Console.WriteLine("\nPerfeito.");
        }

        ca = this.agilidade + 10;
        vida = this.vigor + 12;
        dano = this.forca + 2;
    }

    public void verficha()
    {
        Console.WriteLine("\n========= FICHA DO PERSONAGEM =========");
        Console.WriteLine("Nome:" + nome);
        Console.WriteLine("Forca: " + forca);
        Console.WriteLine("Dano: " + dano);
        Console.WriteLine("-=-=-=-=-");
        Console.WriteLine("Agilidade: " + agilidade);
        Console.WriteLine("CA (Defesa): " + ca);
        Console.WriteLine("-=-=-=-=-");
        Console.WriteLine("Vigor: " + vigor);
        Console.WriteLine("Vida: " + vida + "/" + vida);
        Console.WriteLine("========================================");
    }
}

public class HelloWorld
{
    public static int dice(int faces)
    {
        Random rolagem = new Random();
        return rolagem.Next(1, faces + 1);
    }

    public static void texto(string texto)
    {
        Console.WriteLine(texto);
    }

    public static bool testecontra(int atribtestum, int atribtestdois)
    {
        int testeperum = dice(20) + atribtestum;
        Console.WriteLine("Seu teste:" + testeperum);

        int testeperdois = dice(20) + atribtestdois;
        Console.WriteLine("Teste do oponente:" + testeperdois);

        bool acerto = (testeperum > testeperdois);
        return acerto;
    }

    public static void batalha(int playervida, int enemyvida, int playeragi, int enemyagi, int playerdano, int enemydano, string enemynome, int enemyca, int playerforca)
    {
        //Rolando iniciativa
        Console.WriteLine("\nUma batalha foi iniciada!\nRole iniciativa para continuar");
        int minhaini = dice(20) + playeragi;
        int alemaoini = dice(20) + enemyagi;

        Console.WriteLine("Sua iniciativa: " + minhaini);
        Console.WriteLine("Iniciativa do oponente: " + alemaoini);

        //Caso minha iniciativa for maior
        if (minhaini > alemaoini)
        {
            Console.WriteLine("Voce comeca atacando!");

            while (playervida > 0 && enemyvida > 0)
            {
                Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-");
                Console.WriteLine("SUA VIDA/PODER: " + playervida + "/" + playerdano);
                Console.WriteLine("VIDA INIMIGO: " + enemyvida);
                Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-");
                Console.WriteLine("O que voce vai fazer? \n1. Atacar \n2. Bloquear \n3. Esquivar");
                string choose = Console.ReadLine();

                switch (choose)
                {
                    case "1":
                        Console.WriteLine("Voce tentou atacar o inimigo!");
                        int resulteste = dice(20) + playeragi;
                        Console.WriteLine($"Seu teste (1d20+AGILIDADE) deu {resulteste}. O inimigo tem Defesa {enemyca}.");

                        if (resulteste > enemyca)
                        {

                            enemyvida -= playerdano;
                            Console.WriteLine($"Voce acertou o ataque e causou {playerdano} de dano no oponente!! A vida de {enemynome} cai para {enemyvida}");
                        }
                        else
                        {
                            Console.WriteLine("O inimigo defendeu!");
                        }

                        break;

                    case "2":
                        Console.WriteLine("Voce bloqueou o inimigo! O dano foi reduzido pela metade.");
                        break;

                    case "3":
                        Console.WriteLine("Voce esquivou do inimigo! Nao sofreu nenhum dano.");
                        break;

                    default:
                        Console.WriteLine("Opcao invalida.");
                        break;
                }
            }

        }

        //Caso iniciativa do inimigo for maior
        else
        {
            while (playervida > 0 && enemyvida > 0)
            {
                Console.WriteLine("O oponente comeca atacando!");
                Console.Read();
            }
        }
    }

    public static void Main(string[] args)
    {
        //Textos
        string inicio = "-=-=-=-=-= THE SENAI SESI CHRONICLES =-=-=-=-=-\nCrie seu personagem para comecar.\n";
        string fichaexplica = "A ficha sera feita da seguinte maneira...\n-> Voce tem 4 pontos " +
            "para distribuir entre seus atributos:\n- Forca (o quanto voce bate)\n- Agilidade " +
            "(o quao rapido voce e)\n- Vigor (o quanto voce e resistente).\nNo final, a soma da " +
            "quantidade de pontos em cada atributo nao pode ser maior do que 4. Seja justo!\n";

        ////Criando objetos 
        Persona player = new Persona();
        Persona segura = new Persona();

        //Buildando o segurança babaca
        segura.nome = "Segurança Babaca";
        segura.agilidade = 0;
        segura.forca = 3;
        segura.vigor = 3;
        segura.ca = 10;
        segura.vida = 15;
        segura.dano = 5;

        //Main
        texto(inicio);
        texto(fichaexplica);
        player.criaficha();
        player.verficha();
        batalha(player.vida, segura.vida, player.agilidade, segura.agilidade, player.dano, segura.dano, segura.nome, segura.ca, player.forca);
    }
}               
