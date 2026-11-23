/*
* Name: Bryce Clement
* Course: CSCI 1250, Section 002
* Assignment: Lab 08, Game Night
* Date: November 18, 2026
* Description: Keeps a game night leaderboard in three text files. Shows the
* season so far, records tonight's points, saves the new totals,
* and adds tonight's result to a history that grows every week.
*/

//The constants give a name to access the files and says what the max amount of points a night the person can get
const string PLAYERS_FILE = "players.txt";
const string POINTS_FILE = "points.txt";
const string HISTORY_FILE = "history.txt";
const int MAX_POINTS = 20;

string projectFolder = Path.GetFullPath(
    Path.Combine(AppContext.BaseDirectory, "..", "..", ".."));
Directory.SetCurrentDirectory(projectFolder);

string[] players = File.ReadAllLines(PLAYERS_FILE);
string[] points = File.ReadAllLines(POINTS_FILE);
string[] history = File.ReadAllLines(HISTORY_FILE);

//PART 3 TOP: THE HISTORY
System.Console.WriteLine("=== GAME NIGHT LEADERBOARD ===");
if (history.Length == 0)
{
    System.Console.WriteLine("No nights played yet.");
}
else
{
    System.Console.WriteLine("Nights played: " + history.Length);

    //foreach because it has to look at each night in history
    foreach (string night in history)
    {
        System.Console.WriteLine(night);
    }
}

int tonightNumber = history.Length + 1;
System.Console.WriteLine("Tonight is Night " + tonightNumber);
System.Console.WriteLine();


//PART 1: THE STANDINGS
System.Console.WriteLine("PLAYER".PadRight(11) + "POINTS");

//it has to go through the index of players to count them 
for (int i = 0; i< players.Length; i++)
{
    System.Console.WriteLine(players[i].PadRight(11) + points[i]);
}

int leader = LeaderIndex(points);
int total = TotalPoints(points);

System.Console.WriteLine("Leader: " + players[leader] + " with " + points[leader]);
System.Console.WriteLine("Season total: " + total);

//PART 2: GAME NIGHT
System.Console.WriteLine();

int bestTonight = -1;
string winnerTonight = "";

//need the index to get all the players names
for (int i = 0; i < players.Length; i++)
{
    int tonight = -1;

//use while because a bad score can be input many times so it loops until a good score in input
    while (tonight < 0 || tonight > MAX_POINTS)
    {
        System.Console.WriteLine("Points tonight for " + players[i] + ": ");
        tonight = Convert.ToInt32(Console.ReadLine());

        if (tonight < 0 || tonight > MAX_POINTS)
        {
            System.Console.WriteLine("Points must be from 0 to " + MAX_POINTS);
        }
    }

    int season = Convert.ToInt32(points[i]) + tonight;
    points[i] = season.ToString();

    if (tonight > bestTonight)
    {
        bestTonight = tonight;
        winnerTonight = players[i];
    }
}

System.Console.WriteLine("Tonight's winner: " + winnerTonight + " with " + bestTonight);

System.Console.WriteLine();

File.WriteAllLines(POINTS_FILE, points);
System.Console.WriteLine("Saved points.txt");

//PART 3 BOTTOM: THE HISTORY
string newHistoryLine = HistoryEntry(tonightNumber, winnerTonight, bestTonight);
string[] entry = { newHistoryLine };
File.AppendAllLines(HISTORY_FILE, entry);

System.Console.WriteLine("Added to history.txt: " + newHistoryLine);

// METHODS
//gives back the index position of the person with the highest score
static int LeaderIndex(string[] points)
{
    int highestIndex = 0;
    int highestScore = Convert.ToInt32(points[0]);

    for (int i = 1; i < points.Length; i++)
    {
        int currentScore = Convert.ToInt32(points[i]);
        if (currentScore > highestScore)
        {
            highestScore = currentScore;
            highestIndex = i;
        }
    }
    return highestIndex;
} 

//gives back the total points
static int TotalPoints(string[] points)
{
    int total = 0;
    foreach (string point in points)
    {
        total += Convert.ToInt32(point);
    }
    return total;
}

//gives one night of scores to be saved to history
static string HistoryEntry(int night, string winner, int points)
{
    return "Night " + night + ": " + winner + " won with " + points + " points";
}