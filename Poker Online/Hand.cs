using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker_Online
{
    public class Card
    {
        private static readonly string[] RANKS = { "Ace", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Jack", "Queen", "King" };
        private static readonly string[] SUITS = { "Clubs", "Diamonds", "Hearts", "Spades" };

        private int rank;
        private int suit;

        public Card(int rank, int suit)
        {
            if (rank < 1 || rank > RANKS.Length || suit < 1 || suit > SUITS.Length)
            {
                throw new NonRealCardException(String.Format("The rank or suit for this card is out of bounds and cannot be made: rank {0}, suit {1}", rank, suit));
            }
            else
            {
                this.rank = rank++;
                this.suit = suit++;
            }
        }

        public string getSuitName()
        {
            return SUITS[suit - 1];
        }

        public string getRankName()
        {
            return RANKS[rank - 1];
        }

        public string getFullName()
        {
            return String.Format("{0} of {1}", getRankName(), getSuitName());
        }

        public int getSuit()
        {
            return suit;
        }

        public int getRank()
        {
            return rank;
        }
    }

    public class Hand
    {
        private List<Card> cards;
        private HandType type;

        public Hand(List<Card> cards)
        {
            this.cards = cards;
        }

        public Hand()
        {
            this.cards = new List<Card>();
        }

        public void addCard(Card card)
        {
            if (cards.Count == 7)
            {
                Console.WriteLine("Error, this hand is already full");
                return;
            }
            cards.Add(card);
        }

        public List<Card> getCards()
        {
            return cards;
        }

        public int getHighestRank()
        {
            int[] ranks = new int[7];
            int count = 0;
            foreach (Card card in cards)
            {
                ranks[count] = card.getRank();
                count++;
            }
            ranks = bubbleSort(ranks);
            return ranks[ranks.Count() - 1];
        }

        public int getHighestSuit()
        {
            int[] suits = new int[7];
            int count = 0;
            foreach (Card card in cards)
            {
                suits[count] = card.getSuit();
                count++;
            }
            suits = bubbleSort(suits);
            return suits[suits.Count() - 1];
        }

        public static int[] bubbleSort(int[] array)
        {
            int temp;
            bool swapped;
            for (int j = 0; j <= array.Length - 2; j++)
            {
                swapped = false;
                for (int i = 0; i <= array.Length - 2; i++)
                {
                    if (array[i] > array[i + 1])
                    {
                        temp = array[i + 1];
                        array[i + 1] = array[i];
                        array[i] = temp;
                        swapped = true;
                    }
                }
                if (swapped == false)
                {
                    break;
                }
            }
            return array;
        }

        public HandType getBestHand()
        {
            //go through hand of 7 cards, trying to find what 5 card hand you can make from best to worst
            if (containsFlush() != -1 && containsStraight() != -1)
            {
                return HandType.STRAIGHT_FLUSH;
            }
            if (containsFourOfKind() != -1)
            {
                return HandType.FOUR_OF_A_KIND;
            }
            if (containsThreeOfKind() != -1)
            {
                //if threeofkind.rank != pair.rank
                int tripledRank = containsThreeOfKind(); //maybe move this out of the if and just test this
                List<int> pairedCards = containsPair();
                if (pairedCards.Count > 0) //check if paired ranks arent equal to triple ranks
                {
                    return HandType.FULL_HOUSE;
                }
            }
            if (containsFlush() != -1)
            {
                return HandType.FLUSH;
            }
            if (containsStraight() != -1)
            {
                return HandType.STRAIGHT;
            }
            if (containsThreeOfKind() != -1)
            {
                return HandType.THREE_OF_A_KIND;
            }
            List<int> pairedRanks = containsPair();
            foreach (int item in pairedRanks)
            {
                Console.WriteLine(item);
            }
            switch (pairedRanks.Count)
            {
                case (3):
                    return HandType.TWO_PAIR; //3 pairs, check 3rd index for highest paired rank
                case (2):
                    return HandType.TWO_PAIR; //2 pairs, check 2nd index for highest paired rank
                case (1):
                    return HandType.ONE_PAIR;
                case (0):
                    return HandType.HIGH_CARD;
            }
            return HandType.HIGH_CARD;
        }


        /**
         * The following methods are used to identify whether a hand contains a certain type of hand
         * If the hand is present, the function will return the integer relating to the rank of the highest
         * card within this type of hand, that way we can use the output to compare two hands of equal types and
         * rank them. If the type of hand is not present, the functions will return -1.
         **/
        private int containsFlush()
        {
            Dictionary<int, int> suitCountDict = new Dictionary<int, int>();
            foreach (Card card in this.cards)
            {
                if (!(suitCountDict.ContainsKey(card.getSuit())))
                {
                    suitCountDict.Add(card.getSuit(), 1); //if suit hasnt been seen already add with count of 1
                }
                else
                {
                    suitCountDict[card.getSuit()]++; //otherwise add to count of that suit
                }
            }
            foreach (int suit in suitCountDict.Keys)
            {
                if (suitCountDict[suit] >= 5)
                {
                    return suit; //return the number corresponding to that suit
                }
            }
            return -1; //if no suits have 5 or more cards, return -1 
        }

        private int containsStraight() //this will only check for 7 consecutive cards, only need to check 5
        {
            int[] ranks = new int[7];
            int count = 0;
            foreach (Card card in cards)
            {
                ranks[count] = card.getRank();
                count++;
            }
            int[] sortedRanks = bubbleSort(ranks);
            int nextRank = sortedRanks[0];
            int consecRankCount = 1;
            int greatestRankPartOfStraight = -1;
            for (int i = 1; i < sortedRanks.Length; i++)
            {
                if (nextRank + 1 != sortedRanks[i]) //reset
                {
                    if (consecRankCount >= 5)
                    {
                        greatestRankPartOfStraight = nextRank;
                    }
                    nextRank = sortedRanks[i];
                    consecRankCount = 1;
                }
                else //otherwise keep up consecutive rank count and set next rank to be compared
                {
                    consecRankCount++;
                    nextRank = sortedRanks[i];
                }
            }
            if (consecRankCount >= 5) //incase last card is still part of consec
            {
                return sortedRanks[sortedRanks.Length - 1];
            }
            return (greatestRankPartOfStraight != -1) ? greatestRankPartOfStraight : -1;
        }

        private int containsThreeOfKind() //for full house, can only contain 1 pair 1 three of different ranks
        {
            Dictionary<int, int> rankCount = new Dictionary<int, int>();
            foreach (Card card in this.cards)
            {
                if (!(rankCount.ContainsKey(card.getRank())))
                {
                    rankCount.Add(card.getRank(), 1);
                }
                else
                {
                    rankCount[card.getRank()]++;
                }
            }
            foreach (int rank in rankCount.Keys)
            {
                if (rankCount[rank] == 3)
                {
                    return rank;
                }
            }
            return -1;
        }

        //returns a list of ranks that the hand has pairs
        private List<int> containsPair() //for 2 pair, can only contain 2
        {
            List<int> pairedRanks = new List<int>();
            Dictionary<int, int> rankCount = new Dictionary<int, int>();
            foreach (Card card in cards)
            {
                if (!(rankCount.ContainsKey(card.getRank())))
                {
                    rankCount.Add(card.getRank(), 1);
                }
                else
                {
                    rankCount[card.getRank()]++;
                }
            }
            foreach (int rank in rankCount.Keys)
            {
                if (rankCount[rank] == 2)
                {
                    pairedRanks.Add(rank);
                }
            }
            return pairedRanks; // TODO: Either organise the output of this or ensure you do when using it
        }

        private int containsFourOfKind()
        {
            Dictionary<int, int> rankCount = new Dictionary<int, int>();
            foreach (Card card in this.cards)
            {
                if (!(rankCount.ContainsKey(card.getRank())))
                {
                    rankCount.Add(card.getRank(), 1);
                }
                else
                {
                    rankCount[card.getRank()]++;
                }
            }
            foreach (int rank in rankCount.Keys)
            {
                if (rankCount[rank] == 4)
                {
                    return rank;
                }
            }
            return -1;
        }
    }

    public class Deck
    {

        private Queue<Card> deck = new Queue<Card>();

        /**
         * Creates a shuffled Queue of cards, this will be usefull as it makes drawing a card from the deck super easy and secure as only the top element can be accessed,
         * i.e: No rigging the deck!
         **/
        public Deck()
        {
            List<Card> unshuffledDeck = new List<Card>();
            List<Card> shuffledDeckList = new List<Card>();
            for(int i = 1; i <= 13; i++)
            {
                for(int j = 1; j <= 4; j++)
                {
                    unshuffledDeck.Add(new Card(i, j));
                }
            }
            shuffledDeckList = unshuffledDeck.OrderBy(x => Guid.NewGuid()).ToList();
            foreach(Card card in shuffledDeckList)
            {
                this.deck.Enqueue(card);
            }
        }

        public Card drawCard()
        {
            return deck.Dequeue();
        }
    }

    public enum HandType
    {
        HIGH_CARD = 1,
        ONE_PAIR = 2,
        TWO_PAIR = 3,
        THREE_OF_A_KIND = 4,
        STRAIGHT = 5,
        FLUSH = 6,
        FULL_HOUSE = 7,
        FOUR_OF_A_KIND = 8,
        STRAIGHT_FLUSH = 9
    }
}
