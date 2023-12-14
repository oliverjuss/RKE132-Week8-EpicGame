string folter = @"E:\\Dropbox\\Codeing\\Week8EpicGame";
string heroFile = "heros.txt";
string villansFile = "villans.txt";
string weponsFile = "wepons.txt";

string[] heros = File.ReadAllLines(Path.Combine(folter,heroFile));
string[] villans = File.ReadAllLines(Path.Combine(folter, villansFile));
string[] wepons = File.ReadAllLines(Path.Combine(folter, weponsFile));



string hero = GetRandomValueFromArray(heros);
string weapon = GetRandomValueFromArray(wepons);
int heroHp = GetCharaterHp(hero,weapon);
int heroStrikeStrengh = heroHp;
Console.WriteLine($"{hero} {heroHp} HP uses {weapon} to saves the day!");


string villan = GetRandomValueFromArray(villans);
string villanweapon = GetRandomValueFromArray(wepons);
int villanHp = GetCharaterHp(villan,villanweapon);
int villanStrikeStrengh = villanHp;
Console.WriteLine($"{villan} {villanHp} HP uses {villanweapon} to to ruin the day");

while(heroHp > 0 && villanHp > 0)
{
    heroHp = heroHp - Hit(villan, villanStrikeStrengh);
    villanHp = villanHp - Hit(hero, heroStrikeStrengh);
}

Console.WriteLine($"Hero {hero} HP: {heroHp}");
Console.WriteLine($"Villlan {villan} HP: {villanHp}");

if (heroHp > 0)
{
    Console.WriteLine($"{hero} saves the day");
}
else if (villanHp > 0)
{
    Console.WriteLine($"{villan} ruins the day and takes over the world");
}
else
{
    Console.WriteLine("draw");
}

static string GetRandomValueFromArray(string[] somearray)
{
    Random rnd = new Random();
    int randomindex = rnd.Next(0, somearray.Length);
    string randomStringArray = somearray[randomindex];
    return randomStringArray;
}


static int GetCharaterHp(string chacterName, string weponsName)
{
    int hp = chacterName.Length + weponsName.Length;
    
    if (chacterName.Length < 10)
    {
        hp+= 5;
    }
    return hp;
}


static int Hit(string characterName, int characterHP)
{

    Random rnd = new Random();
    int strike = rnd.Next(0, characterHP);

    if (strike == 0)
    {
        Console.WriteLine($"{characterName} missed the target!");
    }
    else if (strike == characterHP - 1)
    {
        Console.WriteLine($"{characterName} made a critical hit!");
    }
    else
    {
        Console.WriteLine($"{characterName} hit {strike}!");
    }
    return strike;
}
