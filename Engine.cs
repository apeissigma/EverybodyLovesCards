using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Project1.Library;

namespace Project1
{
    public class Engine
    {
        public string Title = "Everybody Loves Cards!";
        private string logo = @" ___  _  _  ___  ___   _  _  ___   __  ___  _  _    __    __  _  _  ___  ___     __   __   ___   ___   ___  _ 
(  _)( )( )(  _)(  ,) ( \/ )(  ,) /  \(   \( \/ )  (  )  /  \( )( )(  _)/ __)   / _) (  ) (  ,) (   \ / __)/ \
 ) _) \\//  ) _) )  \  \  /  ) ,\( () )) ) )\  /    )(__( () )\\//  ) _)\__ \  ( (_  /__\  )  \  ) ) )\__ \\_/
(___) (__) (___)(_)\_)(__/  (___/ \__/(___/(__/    (____)\__/ (__) (___)(___/   \__)(_)(_)(_)\_)(___/ (___/(_)";
        private string graphic = $@"
                                        +---------+
                                        | J    +---------+
                                        |      | Q    +---------+
                                        |      |      | K       |
                                        |    {SpadeChar} |      |         |
                                        |      |    {HeartChar} |         |
                                        |      |      |    {DiamondChar}    |
                                        |      |      |         |
                                        +------|      |         |
                                               +------|       K |
                                                      +---------+
";
        Person Player = new Person("Player", 0);
        bool Playing = true;

        public void Run()
        {
            //Run
            DisplayIntro();
            GetPlayerName();
            Wait("continue");
            ClearConsole();
            while (Playing == true)
            {
                Print(DisplayHUD());
                DisplayMenu();
            }
        }

        private void DisplayIntro()
        {
            EnableUnicodeEncoding();
            Print(logo);
            Print(graphic);
            Print($"\t ---------- Welcome to {Title} Play card games and earn points! ---------- \n");
        }

        private void GetPlayerName()
        {
            PrintInline("Enter your name: ");
            Player.Name = GetInputString();
            Print($"\nWelcome, {Player.Name}!");
        }

        private void DisplayMenu()
        {
            Print("What would you like to play?\n");
            Print("  1) Same or Different");
            Print("  2) High or Low");
            Print("  3) Highest Match");
            Print("  4) Exit\n");

            var choice = GetInputInt();

            switch (choice)
            {
                case 1:
                    SameOrDiff sameOrDiff = new SameOrDiff();
                    Player.Points += sameOrDiff.Play();
                    break;
                case 2:
                    HighOrLow highOrLow = new HighOrLow();
                    Player.Points += highOrLow.Play();
                    break;
                case 3:
                    HighestMatch highestMatch = new HighestMatch();
                    Player.Points += highestMatch.Play();
                    break;
                case 4:
                    Wait("exit");
                    Playing = false;
                    break;
                default:
                    Print("Please enter a valid choice.");
                    Wait("continue");
                    ClearConsole();
                    Print(DisplayHUD());
                    DisplayMenu();
                    break;
            }
        }

        private string DisplayHUD()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("--------------------------------------------------------------------------------------------------------------\n");
            sb.Append($"          {Title}          |          Player: {Player.Name}          |          Points: {Player.Points}\n");
            sb.Append("--------------------------------------------------------------------------------------------------------------\n");

            return sb.ToString();
        }
    }
}
