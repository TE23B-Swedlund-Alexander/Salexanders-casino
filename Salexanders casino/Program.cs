//variables
using System.ComponentModel.Design;

int balance = 200;
int currentBet = 0;
string chosenGame = ""; //indicates what game was chosen
string bigChoice = ""; // works with decideIfRetry
bool cashOut = false; // if false game is running if true game is not
bool gameChosen = false; // indicates if a game was chosen
bool decideIfRetry = false; //makes sure that the player decides to play again
//funktions

static int bet(int capital)
{

    //inner variables
    bool acceptedBet = false;
    bool betIsNumber = false;
    string chosenBet = "";
    int bet = 0;

    //getting an accepted bet
    Console.WriteLine($"how much are you betting? you have {capital} money");
    while (acceptedBet == false)
    {
        chosenBet = Console.ReadLine();
        betIsNumber = int.TryParse(chosenBet, out bet);
        if (betIsNumber == true && bet <= capital && bet > 0) acceptedBet = true;
        else Console.WriteLine($"your bet has to be a number larger than zero and smaller than {capital}");
    }
    return bet;
}

static int dicegame(int bet, int money)
{
    Random rnd = new Random();
    int dieOne = rnd.Next(1, 6);
    int dieTwo = rnd.Next(1, 6);
    int dieSum = dieOne + dieTwo;

    if (dieSum == 2 || dieSum == 12)
    {

        money += bet * 5;
        Console.WriteLine("you won the big price");

    }
    else if (dieSum == 7)
    {
        money += bet * 2;
        Console.WriteLine("you won the small price");
    }
    else
    {
        money -= bet;
        Console.WriteLine("you lost your bet");
    }
    return money;
}

static int roulettegame(int bet, int money)
{
    Random rnd = new Random();
    bool placedBetIsNumber = false;
    bool betIsOnTable = false;
    string placedBet = "100";
    int betInNumber = 100;
    int rouletteResult = rnd.Next(1, 50);
    List<int> red = [];
    List<int> black = [];
    List<int> green = [1, 50];
    for (int i = 0; i < 24; i++)
    {
        red.Add(i * 2 + 2);

    }
    for (int i = 0; i < 24; i++)
    {
        black.Add(i * 2 + 3);

    }
    while (betIsOnTable == false)
    {
        Console.WriteLine("were do you place your bet? red, black, green or 1-50");
        placedBet = Console.ReadLine();
        placedBetIsNumber = int.TryParse(placedBet, out betInNumber);
        if (betInNumber > 50 || betInNumber < 1) placedBetIsNumber = false;
        if (placedBetIsNumber == true || placedBet == "red" || placedBet == "black" || placedBet == "green") betIsOnTable = true;
    }


    if (placedBetIsNumber == true)
    {
        if (rouletteResult == betInNumber)
        {
            money += bet * 20;
            Console.WriteLine($"you won {bet * 20} monies");
        }
        else
        {
            Console.WriteLine("you lose");
        }

    }

    if (placedBetIsNumber == false)
    {
        if (placedBet == "red")
        {
            if (red.Contains(rouletteResult))
            {
                Console.WriteLine($"you win {bet * 2}");
                money += bet * 2;
            }
            else Console.WriteLine("you lose");

        }
        if (placedBet == "black")
        {
            if (black.Contains(rouletteResult))
            {
                Console.WriteLine($"you win {bet * 2}");
                money += bet * 2;
            }
            else Console.WriteLine("you lose");
        }
        if (placedBet == "green")
        {
            if (green.Contains(rouletteResult))
            {
                Console.WriteLine($"you win {bet * 10}");
                money += bet * 10;
            }
            else Console.WriteLine("you lose");
        }
    }
    return money;
}

static int higherlowergame(int bet, int money)
{
    Random rnd = new Random();
    bool streakIsGoing = true;
    bool guessIsHigherLower = false;
    bool chosenIfKeepGoing = false;
    string playerGuess = "";
    string higherOrLower = "";
    string keepGoing = "";

    int newNumber;
    int score = 0;
    List<int> cards = [];
    List<int> cardsDrawn = [];
    List<string> suits = [];
    List<string> suitsdrawn = [];
    for (int i = 1; i < 14; i++)
    {
        for (int u = 0; u < 4; u++)
        {
            cards.Add(i);

        }
    }
    for (int i = 1; i < 14; i++)
    {

        suits.Add("spades");
        suits.Add("clubs");
        suits.Add("diamonds");
        suits.Add("hearts");

    }

    suitsdrawn.Add(suits[0]);
    suits.Remove(suits[0]);
    cardsDrawn.Add(cards[0]);
    cards.Remove(cards[0]);

    while (streakIsGoing == true)
    {
        newNumber = rnd.Next(0, cards.Count);


        Console.WriteLine($"the card is the {cardsDrawn[score]} of {suitsdrawn[score]}");
        Console.WriteLine("higher or lower");
        while (guessIsHigherLower == false)
        {
            playerGuess = Console.ReadLine();
            if (playerGuess == "higher" || playerGuess == "lower") guessIsHigherLower = true; else Console.WriteLine("you have to answer with higher or lower in lowercase letters");
        }
        guessIsHigherLower=false;
        Console.WriteLine($"the new card is the {cards[newNumber]} of {suits[newNumber]}");
        if (cards[newNumber] < cardsDrawn[score] && playerGuess == "lower")
        {
            higherOrLower = "lower than";
        }
        else if (cards[newNumber] > cardsDrawn[score] && playerGuess == "higher")
        {
            higherOrLower = "higher than";

        }
        if (cards[newNumber] < cardsDrawn[score] && playerGuess == "higher")
        {
            higherOrLower = "lower than";
            streakIsGoing = false;
        }
        else if (cards[newNumber] > cardsDrawn[score] && playerGuess == "lower")
        {
            higherOrLower = "higher than";
            streakIsGoing = false;
        }
        else if (cards[newNumber] == cardsDrawn[score])
        {
            higherOrLower = "eaqual to";
        }

        Console.WriteLine($"wich is {higherOrLower} the {cardsDrawn[score]} of {suitsdrawn[score]}");
        if (streakIsGoing == false)
        {
            money -= bet;
            Console.WriteLine("you loose");
        }
        if (streakIsGoing == true)
        {
            Console.WriteLine("do you want to keep giong yes/no");
            while (chosenIfKeepGoing == false)
            {

                keepGoing = Console.ReadLine();
                if (keepGoing == "yes" || keepGoing == "no") chosenIfKeepGoing = true;
            }
            chosenIfKeepGoing=false;
            if (keepGoing == "no")
            {
                money += score * bet;
                Console.WriteLine($"you made {score * bet} money");
                streakIsGoing = false;
            }

        }
        suitsdrawn.Add(suits[newNumber]);
        suits.Remove(suits[newNumber]);
        cardsDrawn.Add(cards[newNumber]);
        cards.Remove(cards[newNumber]);
        score++;

    }






    return money;
}
while (cashOut == false)
{
    Console.WriteLine("welcome to Salexanders casino the best casino in the world, we hace amazing games like: dice, roulette and higher lower");
    Console.WriteLine("which game are you going to play?");

    while (gameChosen == false)
    {
        chosenGame = Console.ReadLine();
        if (chosenGame.ToLower() == "dice" || chosenGame.ToLower() == "roulette" || chosenGame.ToLower() == "higher lower")
        {
            gameChosen = true;
        }
    }
    while (gameChosen == true)
    {
        currentBet = bet(balance);
        if (chosenGame.ToLower() == "dice")
        {
            balance = dicegame(currentBet, balance);
        }
        if (chosenGame.ToLower() == "roulette")
        {
            balance = roulettegame(currentBet, balance);
        }
        if (chosenGame.ToLower() == "higher lower")
        {
            balance = higherlowergame(currentBet, balance);
        }
        Console.WriteLine("play again, choose new game or cashout?");
        Console.WriteLine("to play same game again type [again]");
        Console.WriteLine("to choose new game type [new]");
        Console.WriteLine("to cashout type [cashout]");
        decideIfRetry = false;
        bigChoice = "";
        while (decideIfRetry == false)
        {
            bigChoice = Console.ReadLine();
            if (bigChoice == "again") decideIfRetry = true;
            if (bigChoice == "new")
            {
                decideIfRetry = true;
                gameChosen = false;
            }
            if (bigChoice == "cashout")
            {
                decideIfRetry = true;
                gameChosen = false;
                cashOut = true;
            }
        }
    }
}




















