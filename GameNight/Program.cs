const string PLAYERS_FILE = "players.txt";
const string POINTS_FILE = "points.txt";
const string HISTORY_FILE = "history.txt";
const int MAX_POINTS = 20;

string projectFolder = Path.GetFullPath(
    Path.Combine(AppContext.BaseDirectory, "..", "..", ".."));
Directory.SetCurrentDirectory(projectFolder);

string[] players = File.ReadAllLines(PLAYERS_FILE);
string[] points = File.ReadAllLines(POINTS_FILE);

//PART 1: THE STANDINGS
System.Console.WriteLine("PLAYER".PadRight(11) + "POINTS");

for (int i = 0; i< players.Length; i++)
{
    System.Console.WriteLine(players[i].PadRight(11) + points[i]);
}

int leader = LeaderIndex(points);
int total = TotalPoints(points);

System.Console.WriteLine("Leader: " + players[leader] + " with " + points[leader]);
System.Console.WriteLine("Season total: " + total);

// METHODS
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

static int TotalPoints(string[] points)
{
    int total = 0;
    foreach (string point in points)
    {
        total += Convert.ToInt32(point);
    }
    return total;
}