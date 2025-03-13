//variables
using System.ComponentModel;
using System.ComponentModel.Design;

int balance = 200; //money
int currentBet = 0; // the bet
string chosenGame = ""; //indicates what game was chosen
string bigChoice = ""; // works with decideIfRetry
bool cashOut = false; // if false game is running if true game is not
bool gameChosen = false; // indicates if a game was chosen
bool decideIfRetry = false; //makes sure that the player decides to play again
//funktions

static int bet(int capital) // betting function
{

    //inner variables
    bool acceptedBet = false; //is the bet valid a valid number
    bool betIsNumber = false; // is the bet a number
    string chosenBet = ""; // collects input for bet
    int bet = 0; // the bet

    //getting an accepted bet
    Console.WriteLine($"how much are you betting? you have {capital} money");
    while (acceptedBet == false) //while the bet is invalid
    {
        chosenBet = Console.ReadLine(); //collecting input for bet
        betIsNumber = int.TryParse(chosenBet, out bet); // turning bet into int
        if (betIsNumber == true && bet <= capital && bet > 0) acceptedBet = true; // is bet accepted
        else Console.WriteLine($"your bet has to be a number larger than zero and smaller than {capital}");
    }
    return bet; // makes function return the bet
}

static int dicegame(int bet, int money) // the dice game function
{
    Random rnd = new Random();
    int dieOne = rnd.Next(1, 6);
    int dieTwo = rnd.Next(1, 6);
    int dieSum = dieOne + dieTwo; // gives outcome of dice

    if (dieSum == 2 || dieSum == 12) //big win
    {

        money += bet * 5;
        Console.WriteLine("you won the big price");

    }
    else if (dieSum == 7) // small win
    {
        money += bet * 2;
        Console.WriteLine("you won the small price");
    }
    else // loss
    {
        money -= bet;
        Console.WriteLine("you lost your bet");
    }
    return money;
}

static int roulettegame(int bet, int money) // roulette
{
    Random rnd = new Random();
    bool placedBetIsNumber = false; //has player placed bet on number
    bool betIsOnTable = false; // is the bet available
    string placedBet = "100"; // checks bet
    int betInNumber = 100; // in case bet is a number
    int rouletteResult = rnd.Next(1, 50); //spinns roulette thingy
    List<int> red = [];
    List<int> black = [];
    List<int> green = [1, 50]; //color lists
    for (int i = 0; i < 24; i++) //fills red
    {
        red.Add(i * 2 + 2);

    }
    for (int i = 0; i < 24; i++) // fills black
    {
        black.Add(i * 2 + 3);

    }
    while (betIsOnTable == false)// collects bet
    {
        Console.WriteLine("were do you place your bet? red, black, green or 1-50");
        placedBet = Console.ReadLine();
        placedBetIsNumber = int.TryParse(placedBet, out betInNumber);
        if (betInNumber > 50 || betInNumber < 1) placedBetIsNumber = false;
        if (placedBetIsNumber == true || placedBet == "red" || placedBet == "black" || placedBet == "green") betIsOnTable = true;
    }

    Console.Write(rouletteResult); // gives result to player
    if (red.Contains(rouletteResult)) Console.WriteLine("red");
    if (black.Contains(rouletteResult)) Console.WriteLine("black");
    if (green.Contains(rouletteResult)) Console.WriteLine("green");
    Console.ReadLine();
    if (placedBetIsNumber == true) // did the player bet on a number
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

    if (placedBetIsNumber == false) // did the player bet on a color
    {
        if (placedBet == "red") //did the player bet red
        {
            if (red.Contains(rouletteResult)) //did the player win
            {
                Console.WriteLine($"you win {bet * 2}");
                money += bet * 2;
            }
            else Console.WriteLine("you lose");

        }
        if (placedBet == "black") //did the player bet black
        {
            if (black.Contains(rouletteResult))
            {
                Console.WriteLine($"you win {bet * 2}"); //did the player win
                money += bet * 2;
            }
            else Console.WriteLine("you lose");
        }
        if (placedBet == "green") //did the player bet green
        {
            if (green.Contains(rouletteResult))
            {
                Console.WriteLine($"you win {bet * 10}"); //did the player win
                money += bet * 10;
            }
            else Console.WriteLine("you lose");
        }
    }
    return money;
}

static int higherlowergame(int bet, int money) // higher lower game
{
    Random rnd = new Random();
    bool streakIsGoing = true; // is the streak going
    bool guessIsHigherLower = false; // is the guess valid
    bool chosenIfKeepGoing = false; // is the player cashing out
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
        for (int u = 0; u < 4; u++) // makes deck with numbers
        {
            cards.Add(i + 1);

        }
    }
    for (int i = 1; i < 14; i++) //makes suits for the deck
    {

        suits.Add("spades");
        suits.Add("clubs");
        suits.Add("diamonds");
        suits.Add("hearts");

    }

    suitsdrawn.Add(suits[0]); //makes starting value for the game
    suits.Remove(suits[0]);
    cardsDrawn.Add(cards[0]);
    cards.Remove(cards[0]);

    while (streakIsGoing == true && cards.Count > 0) //game is running
    {
        newNumber = rnd.Next(0, cards.Count); // chooses new card

        if (cardsDrawn[score] == 14) Console.WriteLine($"the card is the ace of {suitsdrawn[score]}"); // writes the card that is in place
        else if (cardsDrawn[score] == 11) Console.WriteLine($"the card is the jack of {suitsdrawn[score]}");
        else if (cardsDrawn[score] == 12) Console.WriteLine($"the card is the queen of {suitsdrawn[score]}");
        else if (cardsDrawn[score] == 13) Console.WriteLine($"the card is the king of {suitsdrawn[score]}");
        else Console.WriteLine($"the card is the {cardsDrawn[score]} of {suitsdrawn[score]}");

        Console.WriteLine("higher or lower");
        while (guessIsHigherLower == false) //is guess a valid option
        {
            playerGuess = Console.ReadLine();
            if (playerGuess == "higher" || playerGuess == "lower") guessIsHigherLower = true; else Console.WriteLine("you have to answer with higher or lower in lowercase letters");
        }
        guessIsHigherLower = false;

        if (cards[newNumber] == 14) Console.WriteLine($"the new card is the ace of {suits[newNumber]}"); //writes new card 
        else if (cards[newNumber] == 11) Console.WriteLine($"the new card is the jack of {suits[newNumber]}");
        else if (cards[newNumber] == 12) Console.WriteLine($"the new card is the queen of {suits[newNumber]}");
        else if (cards[newNumber] == 13) Console.WriteLine($"the new card is the king of {suits[newNumber]}");
        else Console.WriteLine($"the new card is the {cards[newNumber]} of {suits[newNumber]}");
        if (cards[newNumber] < cardsDrawn[score] && playerGuess == "lower") // makes text say the right thing later and checks if guess is correct
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
        if (cardsDrawn[score] == 14) Console.WriteLine($"which is {higherOrLower} the ace of {suitsdrawn[score]}"); //tells player if card is higher or lower
        else if (cardsDrawn[score] == 11) Console.WriteLine($"which is {higherOrLower} the jack of {suitsdrawn[score]}");
        else if (cardsDrawn[score] == 12) Console.WriteLine($"which is {higherOrLower} the queen of {suitsdrawn[score]}");
        else if (cardsDrawn[score] == 13) Console.WriteLine($"which is {higherOrLower} the king of {suitsdrawn[score]}");
        else if (cardsDrawn[score] < 11 && cardsDrawn[score] > 1) Console.WriteLine($"which is {higherOrLower} the {cardsDrawn[score]} of {suitsdrawn[score]}");

        if (streakIsGoing == false) //if guess was wrong
        {
            money -= bet;
            Console.WriteLine("you loose");
        }
        if (streakIsGoing == true) // if guess was right
        {
            Console.WriteLine("do you want to keep giong yes/no"); //kepp going or cash out
            while (chosenIfKeepGoing == false)
            {

                keepGoing = Console.ReadLine();
                if (keepGoing == "yes" || keepGoing == "no") chosenIfKeepGoing = true; 
            }
            chosenIfKeepGoing = false; // cashes out
            if (keepGoing == "no")
            {
                money += score * bet; //gives money
                Console.WriteLine($"you made {score * bet} money");
                streakIsGoing = false; // ends loop
            }

        }
        suitsdrawn.Add(suits[newNumber]); //moves card from deck to "discard pile"
        suits.Remove(suits[newNumber]);
        cardsDrawn.Add(cards[newNumber]);
        cards.Remove(cards[newNumber]);
        score++; //multiplier for reward

    }






    return money;
}

while (cashOut == false && balance > 0)
{
    Console.WriteLine("welcome to Salexanders casino the best casino in the world, we hace amazing games like: dice, roulette and higher lower");
    Console.WriteLine("which game are you going to play?");

    while (gameChosen == false) //choose game
    {
        chosenGame = Console.ReadLine();
        if (chosenGame.ToLower() == "dice" || chosenGame.ToLower() == "roulette" || chosenGame.ToLower() == "higher lower")
        {
            gameChosen = true;
        }
    }
    while (gameChosen == true) // runs bet and chosen game
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
        Console.WriteLine("play again, choose new game or cashout?"); // text explains itself
        Console.WriteLine("to play same game again type [again]");
        Console.WriteLine("to choose new game type [new]");
        Console.WriteLine("to cashout type [cashout]");
        decideIfRetry = false;
        bigChoice = "";
        while (decideIfRetry == false)
        {
            bigChoice = Console.ReadLine(); // decice if try again
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
        decideIfRetry = false;
    }
}


if (cashOut == true)
{
    Console.WriteLine($"you made it out with {balance} mony");
}
if (balance == 0) Console.WriteLine("ha broke");
Console.ReadLine();

















