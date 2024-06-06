var random = new Random();
var dice = new Dice(random);
var guessingGame = new GuessingGame(dice);

GameResult gameResult = guessingGame.Play();
if(gameResult == GameResult.Victory)
{
    Console.WriteLine("你贏了!");
}
else
{
    Console.WriteLine("你輸了 :(");
}

Console.ReadKey();

class GuessingGame
{
    private readonly Dice _dice;
    private const int InitialTries = 3;

    public GuessingGame(Dice dice)
    {
        _dice = dice;
    }

    public GameResult Play()
    {
        var diceRollResult = _dice.Roll();
        Console.WriteLine(
            $"骰子以擲出，你有 {InitialTries} 次機會猜猜是哪一個數字被擲出");

        var triesLeft = InitialTries;
        while(triesLeft > 0)
        {
            var guess = ConsoleReader.ReadInteger("輸入一個數字");
            if(guess == diceRollResult)
            {
                return GameResult.Victory;
            }
            Console.WriteLine("答錯");
            --triesLeft;
        }
        return GameResult.Loss;
    }
}

public enum GameResult
{
    Victory,
    Loss
}

public static class ConsoleReader
{
    public static int ReadInteger(string message)
    {
        int result;
        do
        {
            Console.WriteLine(message);
        }
        while (!int.TryParse(Console.ReadLine(), out result));
        return result;
    }
}
public class Dice
{
    private readonly Random _random;
    private const int SidesCount = 6;

    public Dice(Random random)
    {
        _random = random;
    }

    public int Roll() =>  _random.Next(1, SidesCount + 1);
   
    public void Describe() => 
        Console.WriteLine($"This is a dice with {SidesCount} sides.");
}