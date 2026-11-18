const string PLAYERS_FILE = "players.txt";
const string POINTS_FILE = "points.txt";
const string HISTORY_FILE = "history.txt";
const int MAX_POINTS = 20;
// Look for data files next to Program.cs, however the program is started.
string projectFolder = Path.GetFullPath(
    Path.Combine(AppContext.BaseDirectory, "..", "..", ".."));
Directory.SetCurrentDirectory(projectFolder);

//PART 1: THE STANDINGS

string[] people = File.ReadAllLines(PLAYERS_FILE);
string[] numbers = File.ReadAllLines(POINTS_FILE);

double total = 0;
double leader = 0;
int location = 0;

System.Console.WriteLine("PLAYER".PadRight(11) + "POINTS");
for (int i = 0; i < people.Length; i++)
{
    string players = Convert.ToString(people[i]);
    double points = Convert.ToDouble(numbers[i]);

    if (points > leader)
    {
        leader = points;
        location = i + 1;
    }

total += points;
    
    System.Console.WriteLine(players.PadRight(11) + points);
}
System.Console.WriteLine("Leader: " + people[location - 1] + " with " + leader);
System.Console.WriteLine("Season total: " + total);

