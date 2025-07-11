using System;

// Classe base do personagem
class Persona
{
    public string Nome { get; private set; }
    public string Classe { get; private set; }
    public int Agi { get; private set; }
    public int Forca { get; private set; }
    public int Vigor { get; private set; }
    public int Nivel { get; private set; } = 1;
    public int Experiencia { get; private set; } = 0;

    public int Vida;
    public int Dano;
    public int CA;

    //Função pro inimigo setar os atributos
    protected void DefinirAtributosBase(string nome, int agi, int forca, int vigor)
    {
        this.Nome = nome;
        this.Agi = agi;
        this.Forca = forca;
        this.Vigor = vigor;
    }

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
>>Você é incrívelmente bom nos esportes. Corre rápido, tem um fôlego invejável e sempre está treinando para melhorar sua performance.
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
                Vigor += 1;
                break;
            }
            else if (escolha == "3")
            {
                Classe = "Atleta";
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
        Vida = (10 + Vigor);
        CA = (10 + Agi);
        Dano = (3 + Forca);
        Console.Clear();
    }

    public void VerFicha()
    {
        AtualizarStatusDeCombate();
        Console.WriteLine($"-=-=-=-=-=FICHA DE PERSONAGEM=-=-=-=-=-\nNome: {Nome}\nClasse: {Classe}\n" +
         $"Nível: {Nivel}\nXP: {Experiencia}/{Nivel * 10}\nVida: {Vida}\nVigor: {Vigor}\nForça: {Forca}\nDano: {Dano}\nAgilidade: {Agi}\nDefesa: {CA}");
    }

    //Sobe de nível
    public void LevelUp()
    {
        Nivel += 1;
        Experiencia = 0;

        while (true)
        {
            Console.WriteLine($@"-=-=-=-=-=PARABÉNS=-=-=-=-=-
Você subiu para o nível {Nivel}!
Como recompensa, escolha 1 atributo para ganhar mais um ponto.

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

    //Ganha xp
    public void GanharExperiencia(int xpGanho)
    {
        Experiencia += xpGanho;
        Console.WriteLine($"Você ganhou {xpGanho} XP!");
        int xpNecessario = Nivel * 10;

        if (Experiencia >= xpNecessario)
        {
            Console.WriteLine($"\nVocê acumulou {Experiencia}/{xpNecessario} XP e subiu de nível!");
            LevelUp();
        }
        else
        {
            Console.WriteLine($"XP atual: {Experiencia}/{xpNecessario}");
        }

        Console.WriteLine("\nAperte ENTER para continuar...");
        Console.ReadLine();
        Console.Clear();
    }

    //Atualiza Vida, Dano e CA toda vez q precisa (tipo qnd sobe de nível)
    public void AtualizarStatusDeCombate()
    {
        Vida = 10 + Vigor;
        Dano = 3 + Forca;
        CA = 10 + Agi;
    }
}

//Classe do inimigo (filha da Classe Persona)
class Enemy : Persona
{
    public void SetarAtributos(int agi, int forca, int vigor, string nome)
    {
        DefinirAtributosBase(nome, agi, forca, vigor);
        AtualizarStatusDeCombate();
    }
}

class Program
{
    static Random dado = new Random();
    public static int Dado(int faces)
    {
        return dado.Next(1, faces + 1);
    }

    //Função batalha
    public static void Batalha(Persona jogador, Enemy inimigo)
    {
        jogador.AtualizarStatusDeCombate();
        inimigo.AtualizarStatusDeCombate();

        Console.Clear();
        Console.WriteLine("-=-=-=-=-=BATALHA INICIADA=-=-=-=-=-");

        while (jogador.Vida > 0 && inimigo.Vida > 0)
        {
            Console.WriteLine(@$"=-=-=-=-=-=-=-=-=-=-=-=- 
SUA VIDA: {jogador.Vida} 
VIDA {inimigo.Nome}: {inimigo.Vida} 
=-=-=-=-=-=-=-=-=-=-=-=- 
O que você vai fazer? 
1. Atacar 
2. Esquivar");

            string acaoJogador = Console.ReadLine();
            string acaoInimigo = Dado(2).ToString(); //1 ele ataca, 2 ele esquiva

            Console.Clear();
            Console.WriteLine($"{jogador.Nome} escolheu {(acaoJogador == "1" ? "Atacar" : acaoJogador == "2" ? "Esquivar" : "Nada")}");
            Console.WriteLine($"{inimigo.Nome} escolheu {(acaoInimigo == "1" ? "Atacar" : "Esquivar")}\n");

            // Jogador ataca
            if (acaoJogador == "1")
            {
                int dadoAtaque = Dado(20);
                int testeAtaque = dadoAtaque + jogador.Agi;

                if (acaoInimigo == "2")
                {
                    int testeEsquiva = Dado(20) + inimigo.Agi;
                    Console.WriteLine($"Seu teste de ATAQUE (1d20+AGI): {testeAtaque} x Teste de ESQUIVA do inimigo (1d20+AGI): {testeEsquiva}");

                    if (testeEsquiva > testeAtaque)
                    {
                        Console.WriteLine($"{inimigo.Nome} esquivou do seu ataque!");
                    }
                    else
                    {
                        inimigo.Vida -= jogador.Dano;
                        Console.WriteLine($"Você acertou! {inimigo.Nome} perdeu {jogador.Dano} de vida.");
                    }
                }
                else
                {
                    Console.WriteLine($"Seu teste de ATAQUE (1d20+AGI): {testeAtaque} x DEFESA do inimigo: {inimigo.CA}");

                    if (testeAtaque > inimigo.CA)
                    {
                        inimigo.Vida -= jogador.Dano;
                        Console.WriteLine($"{inimigo.Nome} foi atingido e perdeu {jogador.Dano} de vida.");
                    }
                    else
                    {
                        Console.WriteLine("Você errou o ataque!");
                    }
                }
            }

            //Turno do inimigo
            if (acaoInimigo == "1" && inimigo.Vida > 0)
            {
                int dadoAtaque = Dado(20);
                int testeAtaque = dadoAtaque + inimigo.Agi;

                if (acaoJogador == "2")
                {
                    int testeEsquiva = Dado(20) + jogador.Agi;
                    Console.WriteLine($"Teste de ataque de {inimigo.Nome} (1d20+AGI):ca: {testeAtaque} vs seu teste de ESQUIVA (1d20+AGI): {testeEsquiva}");

                    if (testeEsquiva > testeAtaque)
                    {
                        Console.WriteLine("Você esquivou do ataque!");
                    }
                    else
                    {
                        jogador.Vida -= inimigo.Dano;
                        Console.WriteLine($"{inimigo.Nome} acertou o golpe! Você perdeu {inimigo.Dano} de vida.");
                    }
                }
                else
                {
                    Console.WriteLine($"Teste de ataque de {inimigo.Nome} (1d20+AGI): {testeAtaque} x sua DEFESA: {jogador.CA}");

                    if (testeAtaque > jogador.CA)
                    {
                        jogador.Vida -= inimigo.Dano;
                        Console.WriteLine($"Você foi atingido! Perdeu {inimigo.Dano} de vida.");
                    }
                    else
                    {
                        Console.WriteLine($"{inimigo.Nome} errou o ataque.");
                    }
                }
            }

            Console.WriteLine("\nAperte ENTER para próxima rodada...");
            Console.ReadLine();
            Console.Clear();
        }

        //Resultado da batalha
        if (jogador.Vida <= 0)
        {
            Console.WriteLine("Você foi derrotado!");
        }
        else if (inimigo.Vida <= 0)
        {
            Console.WriteLine($"Você venceu {inimigo.Nome}!");
            jogador.GanharExperiencia(10);
        }
    }

    //Mostrar texto na tela
    public static void Texto(string texto)
    {
        Console.WriteLine(texto);
    }

    //Mostra o menu após cada cena
    public static void PosCena(Persona jogador)
    {
        while (true)
        {
            Console.WriteLine(@"O que você quer fazer?
1. Ver ficha
2. Continuar");

            string opcao = Console.ReadLine();
            if (opcao == "1")
            {
                Console.Clear();
                jogador.VerFicha();
                Console.WriteLine("\nAperte ENTER para voltar...");
                Console.ReadLine();
                Console.Clear();
            }
            else if (opcao == "2")
            {
                Console.Clear();
                break;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Opção inválida.");
            }
        }
    }


    public static void Main()
    {
        //Textos
        string titulo = "-=-=-=-=-=THE SENAI SESI CHRONICLES=-=-=-=-=-\nAperte ENTER para começar.";
        string cenaum = "-=-=-=-=-=BOM DIA!=-=-=-=-=-\nVocê acorda na sua casa, como sempre. São 07:45 da manhã e você percebe que " +
            "está atrasado pro SENAI. Rápidamente você\nlevanta da cama e em surpreendentes 20 minutos" +
            "você escovou os dentes, tomou café, arrumou o cabelo e pôs a roupa (não\nnecessáriamente nessa ordem)." +
            " Agora pronto, você sai de casa rumo ao ponto de ônibus." +
            "\n=-=-=-=-=-=-=-=-=-=-\n";
        string cenadoisptum = "-=-=-=-=-=O PONTO DE ÔNIBUS=-=-=-=-=-\nVocê está caminhando rumo ao ponto de ônibus mais perto da sua " +
            "casa, na sua linda e formosa patría NEVES. Inocente e despreocupado, você \ncaminha pela calçada com uma enorme paz em seu coração; quando derrepente é atacado por " +
            "um ser... Raquítico?\n" +
            "Magro, desnutrido e todo sujo, você começa a ser perseguido por um cracudo!" +
            "\n=-=-=-=-=-=-=-=-=-=-\n";
        string cenadoisptdois = "-=-=-=-=-=O PONTO DE ÔNIBUS=-=-=-=-=-\nAssim que você acaba esse embate ÉPICO, o 408 chega e você pega ele pra " +
            "chegar logo na escola." +
            "\n=-=-=-=-=-=-=-=-=-=-\n";
        string cenatres = "-=-=-=-=-=O ÔNIBUS=-=-=-=-=-\n" +
            "Você entra no 408 que está quse lotado e senta em um dos únicos lugares vagos lá no fundo.\nO tempo passa e " +
            "Você está ouvindo música enquanto observa a vista exuberante da cidade de São Gonçalo, até que um moleque de " +
            "cabelo azul \ne uniforme da sua escola atrapalha sua paz vendendo bala. Com um sotaque sulista, ele te oferece balas " +
            "por um preço MUITO FEITO de 16 centavos ( tipo, qual a dificuldade de colocar um valor exato \ntipo 15 centavos cara?)" +
            ". Você se irrita com isso e não compra as balas. Quando ele acaba " +
            "de vender ele senta de volta no lugar dele e deixa você e os oturos passageiros seguirem viagem em paz" +
            "\n=-=-=-=-=-=-=-=-=-=-\n"; ;
        string cenaquatro = "-=-=-=-=-=A CHEGADA=-=-=-=-=-\n" +
            "Você passa pelo Rodo Shoppinge e lembra que se você der sinal ali na frente você para pertinho da escola. " +
            "Então você\npuxa a cordinha e começa a se preparar para descer. Mas antes de levantar você põe a mão" +
            "nos seus bolsos procurando o seu crachá de acesso e... Nada. O desespero começa a tomar conta do sue coração." +
            "\nRapidamente, você abre a mochila, verifica minuciosamente cada compartimento dela e chega a terrivel " +
            "conclusão de que você esqueceu seu crachá em casa." +
            "\n=-=-=-=-=-=-=-=-=-=-\n";
        string cenacincoptum = "-=-=-=-=-=A CHEGADA=-=-=-=-=-\n" +
                "Você desce do ônibus sentindo a pressão do destino inevitável.\n\nAo chega na escola, só de passar no portão" +
                "dá pra sentir o pavor que é ser encarado por ele... \n\nSó de ver o seu rosto e sentir seu cheiro, ele identifica " +
                "a sua situação... \n\nCom 1.87 de altura e PURO ÓDIO por estudantes, uma FEIA E ASSUSTADORA cara de maluco e muita " +
                "raiva de quem esquece o crachá;\n\nO >>SEGURANÇA BABACA<< CORRE PRA CIMA DE VOCÊ, COMO SE FOSSE UMA CRIATURA BESTIAL; " +
                "COM VORACIDADE, ENQUANTO ELE GRITA NA SUA DIREÇÃO 'VOCE NAO VAI PASSAR " +
                "NAO EIN SEU COMEDIA!'\n";

        //Objetos
        Persona player = new Persona();
        Enemy segura = new Enemy();
        Enemy cracudo = new Enemy();

        //Inimigos
        segura.SetarAtributos(0, 2, 2, "Segurança babaca");
        segura.AtualizarStatusDeCombate();

        cracudo.SetarAtributos(0, 0, 0, "Cracudo");
        cracudo.AtualizarStatusDeCombate();


        ////Main
        //Tela Inicial
        Texto(titulo);
        Console.ReadLine();
        Console.Clear();

        //Criação de ficha
        player.CriarFicha();
        player.VerFicha();
        Console.Clear();

        //Cena 1 - Em casa
        Texto(cenaum);
        PosCena(player);
        Console.Clear();

        //Cena 2 - Ponto de ônibus.
        Texto(cenadoisptum);
        Console.WriteLine("Aperte ENTER para continuar...");
        Console.ReadLine();
        Console.Clear();
        Batalha(player, cracudo);
        Texto(cenadoisptdois);
        PosCena(player);
        Console.Clear();

        //Cena 3 - O ônibus
        Texto(cenatres);
        PosCena(player); ;
        Console.Clear();

        //Cena 4 - Descida do ônibus
        Texto(cenaquatro);
        PosCena(player);
        Console.Clear();

        //Cena 5 - 
        Texto(cenacincoptum);
        Console.WriteLine("Aperte ENTER para continuar...");
        Console.ReadLine();
        Console.Clear();
        Batalha(player, segura);
    }
}
