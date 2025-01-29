//variables
Random rnd = new Random ();
int balance = 200;
int currentBet=0;
string chosenGame=""; //indicates what game was chosen
bool gameChosen=false; // indicates if a game was chosen
//funktions
static int bet(int capital){

    //inner variables
bool acceptedBet=false;
bool betIsNumber=false;
string chosenBet="";
int bet=0;

    //getting an accepted bet
Console.WriteLine ($"how much are you betting? you have {capital} money");
while (acceptedBet==false){
chosenBet=Console.ReadLine();
betIsNumber=int.TryParse(chosenBet, out bet);
if (betIsNumber==true && bet<=capital && bet>0) acceptedBet=true; 
else Console.WriteLine($"your bet has to be a number larger than zero and smaller than {capital}");
}
   return bet; 
}

//currentBet=bet(balance); use to acctivate bet

Console.WriteLine("welcome to Salexanders casino the best casino in the world, we hace amazing games like: dice, roulette and higher lower");
Console.WriteLine("wich game are you going to play?");
while (gameChosen==false)





















Console.ReadLine();