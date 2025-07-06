using System;
class Persona
{
    public int agilidade;
    public int forca;
    public int vigor;
    public int vida;
    public int ca;
    public int dano;

    public void criaficha()
    {
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
        return rolagem.Next(1, faces);
    }

    public static void texto(string texto)
    {
        Console.WriteLine(texto);
    }

    public static void testecontra(int atribtestplayer, int atribtestenemy)
    {
        testeplayer = dice(20 + atribtestplayer);
        testeenemy = dice(20 + atribtestenemy);
    }
    public static void batalha(int playervida, int enemyvida, int playeragi, int enemyagi, int playerdano, int enemydano)
    {
        //Rolando iniciativa
        Console.WriteLine("\nUma batalha foi iniciada!\n role iniciativa para continuar");
        int minhaini = dice(20 + playeragi);
        int alemaoini = dice(20 + enemyagi);

        Console.WriteLine("Sua iniciativa: " + minhaini);
        Console.WriteLine("Iniciativa do oponente" + alemaoini);

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
                Console.WriteLine("O que você vai fazer? \n1. Atacar \n2. Bloquear \n3. Esquivar");
                int choose = Console.ReadLine();

                if (choose == 1)//atacar
                {
                    if (AcertouAtaque())
                    {
                        eneh = Damage(eneh, power);
                        Console.WriteLine("Você desferiu um golpe com sua espada e atingiu o oponente!");
                    }
                    else
                    {
                        Console.WriteLine("Você errou o ataque!");
                    }
                }
                else if (choose == 2)//bloquear
                {
                    Console.WriteLine("Você bloqueia o ataque do oponente!");
                }
                else if (choose == 3)//esquivar
                {

                }
                else
                {
                    Console.WriteLine("Comando inválido!");
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

        //Status do segurança babaca
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
        batalha(player.vida, segura.vida, player.agilidade, segura.agilidade, player.dano, segura.dano);
    }
}
