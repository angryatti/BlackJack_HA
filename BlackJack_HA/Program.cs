using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Security.Cryptography.X509Certificates;

namespace BlackJack_HA
{
    internal static class Program
    {

        struct Deck
        {


            public string DeckAndType;



        }
        static Random rng = new Random();
        public static void Shuffle<T>(this IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }

        }






        static void Main(string[] args)
        {
            const string highcards = "JKQA";
            List<Deck> decks = new List<Deck>();

            for (int j = 0; j < 4; j++)
            {
                for (int i = 2; i <= 10; i++)
                {
                    Deck deck = new Deck();
                    switch (j)
                    {
                        case 0: deck.DeckAndType = Convert.ToString(i) + " h"; break;
                        case 1: deck.DeckAndType = Convert.ToString(i) + " c"; break;
                        case 2: deck.DeckAndType = Convert.ToString(i) + " d"; break;
                        case 3: deck.DeckAndType = Convert.ToString(i) + " s"; break;
                        default: throw new Exception();
                    }
                    decks.Add(deck);



                }
            }
            for (int i = 0; i < highcards.Length; i++)
            {
                for (int j = 0; j < highcards.Length; j++)
                {

                    Deck deck = new Deck();

                    switch (j)
                    {
                        case 0: deck.DeckAndType = highcards[i] + " h"; break;
                        case 1: deck.DeckAndType = highcards[i] + " c"; break;
                        case 2: deck.DeckAndType = highcards[i] + " d"; break;
                        case 3: deck.DeckAndType = highcards[i] + " s"; break;
                        default: throw new Exception();
                    }

                    decks.Add(deck);

                }




            }
            Random rnd = new Random();
            decks.Shuffle();

            List<Deck> selectedCards = new List<Deck>();
            int index = 0;
            index = rnd.Next(0, decks.Count);
            selectedCards.Add(decks[index]);
            decks.RemoveAt(index);
            index = rnd.Next(0, decks.Count);

            selectedCards.Add(decks[index]);
            decks.RemoveAt(index);
            List<Deck> selectedPlayerCards = new List<Deck>();
            int index2 = 0;
            index2 = rnd.Next(0, decks.Count);
            selectedPlayerCards.Add(decks[index2]);
            decks.RemoveAt(index2);

            index2 = rnd.Next(0, decks.Count);

            selectedPlayerCards.Add(decks[index2]);
            decks.RemoveAt(index2);

            int valueP = 0;
            int valueD = 0;

            switch (selectedPlayerCards[0].DeckAndType.Split(" ").FirstOrDefault())
            {

                case "A": valueP += 11; break;
                case "K": valueP += 10; break;
                case "Q": valueP += 10; break;
                case "J": valueP += 10; break;
                default: valueP += Convert.ToInt32(selectedPlayerCards[0].DeckAndType.Split(" ").FirstOrDefault()); break;

            }

            switch (selectedPlayerCards[1].DeckAndType.Split(" ").FirstOrDefault())
            {

                case "A": valueP += 11; break;
                case "K": valueP += 10; break;
                case "Q": valueP += 10; break;
                case "J": valueP += 10; break;
                default: valueP += Convert.ToInt32(selectedPlayerCards[1].DeckAndType.Split(" ").FirstOrDefault()); break;

            }

            switch (selectedCards[0].DeckAndType.Split(" ").FirstOrDefault())
            {

                case "A": valueD += 11; break;
                case "K": valueD += 10; break;
                case "Q": valueD += 10; break;
                case "J": valueD += 10; break;
                default: valueD += Convert.ToInt32(selectedCards[0].DeckAndType.Split(" ").FirstOrDefault()); break;

            }

            switch (selectedCards[1].DeckAndType.Split(" ").FirstOrDefault())
            {

                case "A": valueD += 11; break;
                case "K": valueD += 10; break;
                case "Q": valueD += 10; break;
                case "J": valueD += 10; break;
                default: valueD += Convert.ToInt32(selectedCards[1].DeckAndType.Split(" ").FirstOrDefault()); break;

            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("You have: " + valueP);
            Console.ForegroundColor = ConsoleColor.Blue;
            foreach (Deck deck in selectedPlayerCards)
            {

                Console.WriteLine(deck.DeckAndType);


            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Dealer has:  " + selectedCards[0].DeckAndType + " ?");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Press C(Call), S(Stay)");
            string value2 = Console.ReadLine();
            int x = 2;
            if (value2 == "C" || value2 == "c")

            {



                while (true)
                {



                    index = rnd.Next(0, decks.Count);
                    selectedPlayerCards.Add(decks[index]);
                    decks.RemoveAt(index);
                    switch (selectedPlayerCards[x].DeckAndType.Split(" ").FirstOrDefault())
                    {

                        case "A": valueP += 11; break;
                        case "K": valueP += 10; break;
                        case "Q": valueP += 10; break;
                        case "J": valueP += 10; break;
                        default: valueP += Convert.ToInt32(selectedPlayerCards[x].DeckAndType.Split(" ").FirstOrDefault()); break;

                    }
                    if (valueP > 21)
                    {
                        Console.WriteLine("Player draws: " + selectedPlayerCards[x].DeckAndType);
                        Console.ForegroundColor = ConsoleColor.Red;

                        Console.WriteLine("Too much! Dealer wins! Player has: " + valueP);
                        Console.ForegroundColor = ConsoleColor.Blue;
                        break;

                    }

                    if (valueP == 21)
                    {

                        Console.WriteLine("Player has 21");
                        value2 = "S";
                        break;
                    }

                    Console.WriteLine("Player draws: " + selectedPlayerCards[x].DeckAndType);
                    Console.WriteLine("Player has: " + valueP);
                    x++;

                    if (Console.ReadLine() == "S")
                    {

                        value2 = "S";
                        break;
                    }


                }

            }
            if (value2 == "S" || value2 == "S")
            {
                Console.WriteLine("Dealer has:  " + selectedCards[0].DeckAndType + " " + selectedCards[1].DeckAndType);
                Console.WriteLine("Dealer Has: " + valueD);
                int z = 2;
                while (valueD < 17)
                {

                    index = rnd.Next(0, decks.Count);
                    selectedCards.Add(decks[index]);
                    decks.RemoveAt(index);
                    switch (selectedCards[z].DeckAndType.Split(" ").FirstOrDefault())
                    {

                        case "A": valueD += 11; break;
                        case "K": valueD += 10; break;
                        case "Q": valueD += 10; break;
                        case "J": valueD += 10; break;
                        default: valueD += Convert.ToInt32(selectedCards[z].DeckAndType.Split(" ").FirstOrDefault()); break;

                    }
                    Console.WriteLine("Dealer draws: " + selectedCards[z].DeckAndType);
                    z++;




                }
                Console.WriteLine("Dealer has: " + valueD);

                if ((valueD > valueP) && valueD <= 21)
                {

                    Console.WriteLine("Dealer Wins");


                }
                else if ((valueD < valueP) && valueP <= 21)
                {

                    Console.WriteLine("Player Wins");


                }
                else if ((valueD > 21) && valueP <= 21)
                {

                    Console.WriteLine("Player Wins");

                }
                else
                {

                    Console.WriteLine("Draw!");


                }


            }


            Console.WriteLine("______________");
            Console.WriteLine("Used card number: " + (52 - decks.Count));

        }
    }
}
