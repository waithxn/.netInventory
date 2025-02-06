Console.WriteLine("====================");
Console.BackgroundColor = ConsoleColor.White;
Console.ForegroundColor = ConsoleColor.Black;
Console.WriteLine("Text-based Inventory");
Console.BackgroundColor = ConsoleColor.Black;
Console.ForegroundColor = ConsoleColor.White;
Console.WriteLine("====================");
Console.Write("Press ");
PrintInYellow("[ENTER] ");
Console.WriteLine("to begin.");
string[] inventory = { "gun", "note", "cell phone", "food" };
string activeItem = "nothing";
int hp = 1;
bool i = false;
bool h = false;
string playerName = "e";
ConsoleKeyInfo beginningGame = Console.ReadKey();
if (beginningGame.Key == ConsoleKey.Enter) {
  BeginGame();
}
void BeginGame() {
  Console.WriteLine("Enter your name:");
  playerName = Console.ReadLine();
  if (playerName.Contains("your name")) {
    Console.WriteLine("ha, ha, so funny.");
    Environment.Exit(123);
  }
  Console.WriteLine("Hello " + playerName + "!");
  Console.Write("\n Press ");
  PrintInYellow("[H] ");
  Console.Write("to open ");
  PrintInPurple("Help Menu\n");
}
void PrintInYellow(string message) {
  Console.ForegroundColor = ConsoleColor.Yellow;
  Console.Write(message);
  Console.ForegroundColor = ConsoleColor.White;
}
void PrintInPurple(string message) {
  Console.ForegroundColor = ConsoleColor.Magenta;
  Console.Write(message);
  Console.ForegroundColor = ConsoleColor.White;
}
void PrintInRed(string message) {
  Console.ForegroundColor = ConsoleColor.Red;
  Console.Write(message);
  Console.ForegroundColor = ConsoleColor.White;
}
void ReadInventory() {
  int ii = 1;
  Console.Write("\n === ");
  PrintInPurple("Inventory ");
  Console.Write("===\n");
  foreach (var item in inventory) {
    Console.Write(" " + " " + ii.ToString() + ". ");
    PrintInRed(item + "\n");
    ii++;
  }
  Console.WriteLine(" =================");
  ReadNumber();
  void ReadNumber() {
    Console.Write(" Press a number to select an item. \n");
    int itemNumber = int.Parse(Console.ReadKey().KeyChar.ToString());
    if (itemNumber <= inventory.Length) {
      SetActiveItem(inventory[itemNumber - 1].ToString());
    } else {
      Console.WriteLine(" Invalid item.");
      ReadNumber();
    }
    if (itemNumber == null)
      Console.WriteLine("err");
  }
}
void SetActiveItem(string item) {
  PrintInRed("\n " + item + " ");
  Console.Write("selected.\n");
  activeItem = item;
}
void OpenHelpMenu() {
  PrintInYellow("\n [H] ");
  Console.Write("- Open ");
  PrintInPurple("Help Menu");
  PrintInYellow("\n [I] ");
  Console.Write("- Open ");
  PrintInPurple("Inventory");
  PrintInYellow("\n [Y] ");
  Console.Write("- Inspect ");
  PrintInPurple("Active Item");
  PrintInYellow("\n [U] ");
  Console.Write("- Use ");
  PrintInPurple("Active Item\n");
}
void InspectItem(string item)

{
  if (item == "nothing") {
    PrintInRed("\n nothing");
    Console.Write(".\n");
  } else if (item == "gun") {
    if (inventory.Contains("ammo")) {
      Console.Write("\n A ");
      PrintInRed("gun");
      Console.Write(".\n");
    } else {
      Console.Write("\n An empty ");
      PrintInRed("gun");
      Console.Write(", useless without ");
      PrintInRed("ammo");
      Console.Write(".\n");
    }
  } else if (item == "note") {
    if (i) {
      Console.Write("\n A ");
      PrintInRed("note ");
      Console.Write("that has a hole in it.\n");
    } else {
      Console.Write("\n A ");
      PrintInRed("note ");
      Console.Write("that reads: " + playerName + ".");
    }
  } else if (item == "cell phone") {
    Console.Write("\n A ");
    PrintInRed("cell phone");
    Console.Write(", it's broken.\n");
  } else if (item == "food") {
    Console.Write("\n Some ");
    PrintInRed("food");
    Console.Write(", it looks like dinner.\n");
  } else if (item == "money") {
    Console.Write("\n $1 cash.");
  }
}
void UseItem(string item)

{
  if (item == "nothing") {
    Console.Write("\n You did nothing, good job.\n");
  } else if (item == "gun") {
    if (inventory.Contains("ammo")) {
      Console.Write("\n You shot the ");
      PrintInRed("note");
      Console.Write(".\n");
      RemoveFromInventory("ammo");
      i = true;
    } else if (h) {
      Console.Write("\n You sold the ");
      PrintInRed("gun ");
      Console.Write("and recieved ");
      PrintInRed("money");
      Console.Write(".\n");
      RemoveFromInventory("gun");
      AddToInventory("money");
    } else {
      Console.Write("\n You have no ");
      PrintInRed("ammo");
      Console.Write("!\n");
    }
  } else if (item == "note") {
    if (i) {
      Console.Write("\n You ate the ");
      PrintInRed("note");
      Console.Write(".\n");
      RemoveFromInventory("note");
      h = true;
    } else {
      Console.Write("\n You read the ");
      PrintInRed("note");
      Console.Write(".\n");
    }
  } else if (item == "cell phone") {
    Console.Write("\n You sold the ");
    PrintInRed("cell phone ");
    Console.Write("and purchased ");
    PrintInRed("ammo");
    Console.Write(".\n");
    AddToInventory("ammo");

    RemoveFromInventory("cell phone");
  } else if (item == "food") {
    if (h && i) {
      Console.Write("\n You ate the ");
      PrintInRed("food ");
      Console.Write("and choked.\n");
      RemoveFromInventory("food");
    } else {
      Console.Write("\n You ate the ");
      PrintInRed("food ");
      Console.Write("and gained 100 health points.\n");
      activeItem = "nothing";
      RemoveFromInventory("food");
      hp += 100;
    }
  } else if (item == "money") {
    Console.Write("\n You purchased ");
    PrintInRed("food");
    Console.Write(".\n");
    RemoveFromInventory("money");
    AddToInventory("food");
  }
}
void RemoveFromInventory(string item) {
  List<string> list = new List<string>(inventory);
  list.Remove(item);
  inventory = list.ToArray();
}
void AddToInventory(string item) {
  List<string> list = new List<string>(inventory);
  list.Add(item);
  inventory = list.ToArray();
}
for (;;) {
  ConsoleKeyInfo result = Console.ReadKey();
  if (result.Key == ConsoleKey.I)
    ReadInventory();
  else if (result.Key == ConsoleKey.H)
    OpenHelpMenu();
  else if (result.Key == ConsoleKey.Y)
    InspectItem(activeItem);
  else if (result.Key == ConsoleKey.U)
    UseItem(activeItem);
  if (hp > 100)
    hp = 100;
}
