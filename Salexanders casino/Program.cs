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
List<int>red=[];
List<int>black=[];
List<int>green=[1,50];
for (int i=0; i<24; i++){
    red.Add (i*2+2);

}
for (int i=0; i<24; i--){
    black.Add (i*2+3);

}

    return money;
}
static int higherlowergame(int bet, int money)
{


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
balance= roulettegame(currentBet,balance);
        }
        if (chosenGame.ToLower() == "higher lower")
        {

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




















