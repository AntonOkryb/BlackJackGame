using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Anton Byrko
namespace BlackJack
{
    class Program
    {
        enum CardRank
        {
            Six = 6, Seven = 7, Eight = 8, Nine = 9, Ten = 10, Jack = 2, Queen = 3, King = 4, Ase = 11
        }

        enum Suit
        {
            Diamonds, Hearts, Spades, Clubs
        }

        struct Card
        {
            public CardRank Rank;
            public Suit S;
        }

        static void Main(string[] args)
        {
            Card[] cardDeck = new Card[36];
            for (int i = 0; i < 36; i++)
            {
                switch (i / 4)
                {
                    case 0: cardDeck[i].Rank = CardRank.Six; break;
                    case 1: cardDeck[i].Rank = CardRank.Seven; break;
                    case 2: cardDeck[i].Rank = CardRank.Eight; break;
                    case 3: cardDeck[i].Rank = CardRank.Nine; break;
                    case 4: cardDeck[i].Rank = CardRank.Ten; break;
                    case 5: cardDeck[i].Rank = CardRank.Jack; break;
                    case 6: cardDeck[i].Rank = CardRank.Queen; break;
                    case 7: cardDeck[i].Rank = CardRank.King; break;
                    case 8: cardDeck[i].Rank = CardRank.Ase; break;
                }
                switch (i % 4)
                {
                    case 0: cardDeck[i].S = Suit.Diamonds; break;
                    case 1: cardDeck[i].S = Suit.Hearts; break;
                    case 2: cardDeck[i].S = Suit.Spades; break;
                    case 3: cardDeck[i].S = Suit.Clubs; break;
                }
            }

            Random rnd = new Random();

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 36; j++)
                {
                    int poz = rnd.Next(36);
                    Card cardTmp = cardDeck[poz];
                    cardDeck[poz] = cardDeck[j];
                    cardDeck[j] = cardTmp;
                }
            }

            int deckTop = 35;

            Card[] cpuDeck = new Card[9];
            int cpuDeckEmptyPoz = 0;
            int cpuScors = 0;

            Card[] playerDeck = new Card[9];
            int playerDeckEmptyPoz = 0;
            int playerScors = 0;

            bool cpuTern = false;
            int firstTern = rnd.Next(2);

            if (firstTern == 1) cpuTern = false;


            if (cpuTern)
            {
                cpuDeck[cpuDeckEmptyPoz++] = cardDeck[deckTop];
                cpuScors += (int)cardDeck[deckTop--].Rank; ;

                playerDeck[playerDeckEmptyPoz++] = cardDeck[deckTop];
                playerScors += (int)cardDeck[deckTop--].Rank;

                Console.WriteLine("players Deck");
                for (int i = 0; i < playerDeckEmptyPoz; i++)
                {
                    Console.WriteLine($"\t{playerDeck[i].Rank} - {playerDeck[i].S} = {(int)playerDeck[i].Rank}");
                }

                cpuDeck[cpuDeckEmptyPoz++] = cardDeck[deckTop];
                cpuScors += (int)cardDeck[deckTop--].Rank;

                playerDeck[playerDeckEmptyPoz++] = cardDeck[deckTop];
                playerScors += (int)cardDeck[deckTop--].Rank; ;

                Console.WriteLine("players Deck");
                for (int i = 0; i < playerDeckEmptyPoz; i++)
                {
                    Console.WriteLine($"\t{playerDeck[i].Rank} - {playerDeck[i].S} = {(int)playerDeck[i].Rank}");
                }
            }

            else
            {
                playerDeck[playerDeckEmptyPoz++] = cardDeck[deckTop];
                playerScors += (int)cardDeck[deckTop--].Rank; ;
                Console.WriteLine("players Deck");
                for (int i = 0; i < playerDeckEmptyPoz; i++)
                {
                    Console.WriteLine($"\t{playerDeck[i].Rank} - {playerDeck[i].S} = {(int)playerDeck[i].Rank}");
                }

                cpuDeck[cpuDeckEmptyPoz++] = cardDeck[deckTop];
                cpuScors += (int)cardDeck[deckTop--].Rank;

                playerDeck[playerDeckEmptyPoz++] = cardDeck[deckTop];
                playerScors += (int)cardDeck[deckTop--].Rank;
                Console.WriteLine("players Deck");
                for (int i = 0; i < playerDeckEmptyPoz; i++)
                {
                    Console.WriteLine($"\t{playerDeck[i].Rank} - {playerDeck[i].S} = {(int)playerDeck[i].Rank}");
                }

                cpuDeck[cpuDeckEmptyPoz++] = cardDeck[deckTop];
                cpuScors += (int)cardDeck[deckTop--].Rank;
            }

            if (cpuScors >= 21 && playerScors >= 21)
            {
                Console.WriteLine("DRAW");
                if (cpuScors == 22) cpuScors--;
                Console.WriteLine("cpuDeck");

                for (int i = 0; i < cpuDeckEmptyPoz; i++)
                {
                    Console.WriteLine($"\t{cpuDeck[i].Rank} - {cpuDeck[i].S} = {(int)cpuDeck[i].Rank}");
                }

                Console.WriteLine("players Deck");
                if (playerScors == 22) playerScors--;
                for (int i = 0; i < playerDeckEmptyPoz; i++)
                {
                    Console.WriteLine($"\t{playerDeck[i].Rank} - {playerDeck[i].S} = {(int)cpuDeck[i].Rank}");
                }
            }

            else if (cpuScors >= 21)
            {
                Console.WriteLine("CPU WIN!");
                if (cpuScors == 22) cpuScors--;
                Console.WriteLine("cpuDeck");
                for (int i = 0; i < cpuDeckEmptyPoz; i++)
                {
                    Console.WriteLine($"\t{cpuDeck[i].Rank} - {cpuDeck[i].S} = {(int)cpuDeck[i].Rank}");
                }

                Console.WriteLine("players Deck");
                for (int i = 0; i < playerDeckEmptyPoz; i++)
                {
                    Console.WriteLine($"\t{playerDeck[i].Rank} - {playerDeck[i].S} = {(int)playerDeck[i].Rank}");
                }
                Environment.Exit(0);
            }

            else if (playerScors >= 21)
            {
                Console.WriteLine("PLAYER WIN!");
                if (playerScors == 22) cpuScors--;
                Console.WriteLine("cpuDeck");
                for (int i = 0; i < cpuDeckEmptyPoz; i++)
                {
                    Console.WriteLine($"\t{cpuDeck[i].Rank} - {cpuDeck[i].S} = {(int)cpuDeck[i].Rank}");
                }

                Console.WriteLine("players Deck");
                for (int i = 0; i < playerDeckEmptyPoz; i++)
                {
                    Console.WriteLine($"\t{playerDeck[i].Rank} - {playerDeck[i].S} = {(int)playerDeck[i].Rank}");
                }
                Environment.Exit(0);
            }

            bool cpuGetCards = false;
            if (cpuTern)
            {
                cpuGetCards = true;
                int chois = rnd.Next(10);

                while (true)
                {
                    if (cpuScors < 16)
                    {
                        cpuDeck[cpuDeckEmptyPoz++] = cardDeck[deckTop];
                        cpuScors += (int)cardDeck[deckTop--].Rank;
                    }

                    else if (cpuScors > 15 && cpuScors < 18 && chois < 5)
                    {
                        cpuDeck[cpuDeckEmptyPoz++] = cardDeck[deckTop];
                        cpuScors += (int)cardDeck[deckTop--].Rank;
                    }

                    else if (cpuScors == 18 && chois >= 0 && chois > 3)
                    {
                        cpuDeck[cpuDeckEmptyPoz++] = cardDeck[deckTop];
                        cpuScors += (int)cardDeck[deckTop--].Rank;
                    }

                    else if (cpuScors < 18 && chois == 7)
                    {
                        cpuDeck[cpuDeckEmptyPoz++] = cardDeck[deckTop];
                        cpuScors += (int)cardDeck[deckTop--].Rank;
                    }
                    else break;
                }

                if (cpuScors == 21)
                {
                    Console.WriteLine("CPU WIN!");

                    Console.WriteLine("cpuDeck");
                    for (int i = 0; i < cpuDeckEmptyPoz; i++)
                    {
                        Console.WriteLine($"\t{cpuDeck[i].Rank} - {cpuDeck[i].S} = {(int)cpuDeck[i].Rank}");
                    }

                    Console.WriteLine("players Deck");
                    for (int i = 0; i < playerDeckEmptyPoz; i++)
                    {
                        Console.WriteLine($"\t{playerDeck[i].Rank} - {playerDeck[i].S} = {(int)playerDeck[i].Rank}");
                    }
                    Environment.Exit(0);

                }

                else if (cpuScors > 21)
                {
                    Console.WriteLine("PLAYER WIN");

                    Console.WriteLine("cpuDeck");
                    for (int i = 0; i < cpuDeckEmptyPoz; i++)
                    {
                        Console.WriteLine($"\t{cpuDeck[i].Rank} - {cpuDeck[i].S} = {(int)cpuDeck[i].Rank}");
                    }

                    Console.WriteLine("players Deck");
                    for (int i = 0; i < playerDeckEmptyPoz; i++)
                    {
                        Console.WriteLine($"\t{playerDeck[i].Rank} - {playerDeck[i].S} = {(int)playerDeck[i].Rank}");
                    }
                    Environment.Exit(0);
                }

                Console.WriteLine($"CPU has {cpuDeckEmptyPoz} cards");
            }

            Console.WriteLine("Get one more card? Yes(y)\\No(n)");
            char getCard = char.Parse(Console.ReadLine());

            while (getCard == 'y' && playerScors < 21)
            {
                playerDeck[playerDeckEmptyPoz++] = cardDeck[deckTop];
                playerScors += (int)cardDeck[deckTop--].Rank;
                Console.WriteLine("players Deck");
                for (int i = 0; i < playerDeckEmptyPoz; i++)
                {
                    Console.WriteLine($"\t{playerDeck[i].Rank} - {playerDeck[i].S} = {(int)playerDeck[i].Rank}");
                }

                if (playerScors < 21)
                {
                    Console.WriteLine("Get one more card? Yes(y)\\No(n)");
                    getCard = char.Parse(Console.ReadLine());
                }
            }

            if (!cpuGetCards)
            {
                int chois = rnd.Next(10);

                while (true)
                {
                    if (cpuScors < 16)
                    {
                        cpuDeck[cpuDeckEmptyPoz++] = cardDeck[deckTop];
                        cpuScors += (int)cardDeck[deckTop--].Rank;
                    }

                    else if (cpuScors > 15 && cpuScors < 18 && chois < 5)
                    {
                        cpuDeck[cpuDeckEmptyPoz++] = cardDeck[deckTop];
                        cpuScors += (int)cardDeck[deckTop--].Rank;
                    }

                    else if (cpuScors == 18 && chois >= 0 && chois > 3)
                    {
                        cpuDeck[cpuDeckEmptyPoz++] = cardDeck[deckTop];
                        cpuScors += (int)cardDeck[deckTop--].Rank;
                    }

                    else if (cpuScors < 18 && chois == 7)
                    {
                        cpuDeck[cpuDeckEmptyPoz++] = cardDeck[deckTop];
                        cpuScors += (int)cardDeck[deckTop--].Rank;
                    }
                    else break;
                }

                if (cpuScors == 21)
                {
                    Console.WriteLine("CPU WIN!");

                    Console.WriteLine("cpuDeck");
                    for (int i = 0; i < cpuDeckEmptyPoz; i++)
                    {
                        Console.WriteLine($"\t{cpuDeck[i].Rank} - {cpuDeck[i].S} = {(int)cpuDeck[i].Rank}");
                    }

                    Console.WriteLine("players Deck");
                    for (int i = 0; i < playerDeckEmptyPoz; i++)
                    {
                        Console.WriteLine($"\t{playerDeck[i].Rank} - {playerDeck[i].S} = {(int)playerDeck[i].Rank}");
                    }
                    Environment.Exit(0);
                }

                else if (cpuScors > 21)
                {
                    Console.WriteLine("PLAYER WIN");

                    Console.WriteLine("cpuDeck");
                    for (int i = 0; i < cpuDeckEmptyPoz; i++)
                    {
                        Console.WriteLine($"\t{cpuDeck[i].Rank} - {cpuDeck[i].S} = {(int)cpuDeck[i].Rank}");
                    }

                    Console.WriteLine("players Deck");
                    for (int i = 0; i < playerDeckEmptyPoz; i++)
                    {
                        Console.WriteLine($"\t{playerDeck[i].Rank} - {playerDeck[i].S} = {(int)playerDeck[i].Rank}");
                    }
                    Environment.Exit(0);
                }
                else if (playerScors == 21)
                {
                    Console.WriteLine("PLAYER WIN");
                    Console.WriteLine("players Deck");
                    for (int i = 0; i < playerDeckEmptyPoz; i++)
                    {
                        Console.WriteLine($"\t{playerDeck[i].Rank} - {playerDeck[i].S} = {(int)playerDeck[i].Rank}");
                    }

                    Console.WriteLine("cpuDeck");
                    for (int i = 0; i < cpuDeckEmptyPoz; i++)
                    {
                        Console.WriteLine($"\t{cpuDeck[i].Rank} - {cpuDeck[i].S} = {(int)cpuDeck[i].Rank}");
                    }
                    Environment.Exit(0);
                }

                else if (playerScors > 21)
                {
                    Console.WriteLine("CPU WIN");
                    Console.WriteLine("players Deck");
                    for (int i = 0; i < playerDeckEmptyPoz; i++)
                    {
                        Console.WriteLine($"\t{playerDeck[i].Rank} - {playerDeck[i].S} = {(int)playerDeck[i].Rank}");
                    }

                    Console.WriteLine("cpuDeck");
                    for (int i = 0; i < cpuDeckEmptyPoz; i++)
                    {
                        Console.WriteLine($"\t{cpuDeck[i].Rank} - {cpuDeck[i].S} = {(int)cpuDeck[i].Rank}");
                    }
                    Environment.Exit(0);
                }

                else if (playerScors < cpuScors)
                {
                    Console.WriteLine("CPU WIN");
                    Console.WriteLine("players Deck");
                    for (int i = 0; i < playerDeckEmptyPoz; i++)
                    {
                        Console.WriteLine($"\t{playerDeck[i].Rank} - {playerDeck[i].S} = {(int)playerDeck[i].Rank}");
                    }

                    Console.WriteLine("cpuDeck");
                    for (int i = 0; i < cpuDeckEmptyPoz; i++)
                    {
                        Console.WriteLine($"\t{cpuDeck[i].Rank} - {cpuDeck[i].S} = {(int)cpuDeck[i].Rank}");
                    }
                    Environment.Exit(0);
                }

                else if (playerScors > cpuScors)
                {
                    Console.WriteLine("PLAYER WIN");
                    Console.WriteLine("players Deck");
                    for (int i = 0; i < playerDeckEmptyPoz; i++)
                    {
                        Console.WriteLine($"\t{playerDeck[i].Rank} - {playerDeck[i].S} = {(int)playerDeck[i].Rank}");
                    }

                    Console.WriteLine("cpuDeck");
                    for (int i = 0; i < cpuDeckEmptyPoz; i++)
                    {
                        Console.WriteLine($"\t{cpuDeck[i].Rank} - {cpuDeck[i].S} = {(int)cpuDeck[i].Rank}");
                    }
                    Environment.Exit(0);
                }

                else if (playerScors == cpuScors)
                {
                    Console.WriteLine("DRAW");
                    Console.WriteLine("players Deck");
                    for (int i = 0; i < playerDeckEmptyPoz; i++)
                    {
                        Console.WriteLine($"\t{playerDeck[i].Rank} - {playerDeck[i].S} = {(int)playerDeck[i].Rank}");
                    }

                    Console.WriteLine("cpuDeck");
                    for (int i = 0; i < cpuDeckEmptyPoz; i++)
                    {
                        Console.WriteLine($"\t{cpuDeck[i].Rank} - {cpuDeck[i].S} = {(int)cpuDeck[i].Rank}");
                    }
                }
            }
        }
    }
}
