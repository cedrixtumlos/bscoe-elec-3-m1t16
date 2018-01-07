using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour {
	int i=0;
	string[] level1Passwords = { "mazda", "jeep", "honda", "mini", "audi" };
	string[] level1hint = { "damza", "peje", "dahon", "iimn", "udia" };
	string[] level2Passwords = { "huawei", "alcatel", "samsung", "verizon", "lenovo" };
	string[] level2hint = { "ahuiwe", "clatale", "gunsams", "iverzon", "noovle" };
	string[] level3Passwords = { "pineapple", "watermelon", "mangosteen", "avocado", "raspberry" };
	string[] level3hint = { "nippleape", "realwetmon", "neetmasgon", "doocava", "serbarryp" };

	int level;

	string password;

	string guess;


	enum Screen { MainMenu, Password, Win };

	Screen currentScreen;

	void Start()
	{
		ShowMainMenu("M1T16");
	}

	void ShowMainMenu(string greeting)
	{
		currentScreen = Screen.MainMenu;
		Terminal.ClearScreen();
		Terminal.WriteLine(greeting+"\r\n");
		Terminal.WriteLine("What would you like to hack?");
		Terminal.WriteLine("Press 1 for Cars");
		Terminal.WriteLine("Press 2 for Cellphone");
		Terminal.WriteLine("Press 3 for Fruits\r\n");
		Terminal.WriteLine("Enter your selection:");
		i = 0;
	}

	void OnUserInput(string input)
	{

		if (input == "menu")
		{
			ShowMainMenu("M1T16");
		}
		else if (currentScreen == Screen.MainMenu)
		{
			RunMainMenu(input);
		}
		else if (currentScreen == Screen.Password)
		{
			CheckPassword(input);
		}
		else if (currentScreen == Screen.Win)
		{
			DisplayWinScreen();
		}
	}



	void RunMainMenu(string input)
	{

		bool isValidLevelNumber = (input == "1" || input == "2" || input == "3");
		if (isValidLevelNumber)
		{
			level = int.Parse(input);
			AskForPassword();
		}
		else if (input == "007")
		{
			Terminal.WriteLine("What would you like to do? HACKER?"); // Easter egg
		}
		else
		{
			Terminal.WriteLine("Please choose a valid option!");
		}
	}

	void AskForPassword()
	{
		currentScreen = Screen.Password;
		Terminal.ClearScreen();
		SetRandomPassword();
	}

	void SetRandomPassword()
	{
		switch (level)
		{
		case 1:
			Terminal.ClearScreen();
			Terminal.WriteLine("Guess the Car");
			password = level1Passwords[i]; // Password is a random item in the array
			Level1();
			break;
		case 2:
			Terminal.ClearScreen();
			Terminal.WriteLine("Guess the Cellphone");
			password = level2Passwords[i];
			Level2();
			break;
		case 3:
			Terminal.ClearScreen();
			Terminal.WriteLine("Guess the Fruits");
			password = level3Passwords[i];
			Level3();
			break;
		default:
			Debug.Log("Invalid level number");
			break;
		}
	}

	void CheckPassword(string input)
	{
		if (level == 1)
		{
			if (input == password)
			{
				DisplayWinScreen();
			}
			else
			{
				Terminal.WriteLine("Wrong password, try again!");
				if (i < 4) {
					i++;
				} else {
					i = 0;
				}
				SetRandomPassword();

			}
		}
		else if (level == 2)
		{
			if (input == password)
			{
				DisplayWinScreen();
			}
			else
			{
				Terminal.WriteLine("Wrong password, try again!");
				if (i < 4) {
					i++;
				} else {
					i = 0;
				}
				SetRandomPassword();
			}
		}
		else if (level == 3)
		{
			if (input == password)
			{
				DisplayWinScreen();
			}
			else
			{
				Terminal.WriteLine("Wrong password, try again!");
				if (i < 4) {
					i++;
				} else {
					i = 0;
				}
				SetRandomPassword();

			}
		}
	}

	void DisplayWinScreen()
	{
		Terminal.ClearScreen (); 
		Terminal.WriteLine("Congratulations! You Succesfully Hacked the code ;)");
		i = 0;
		currentScreen = Screen.Win;
	}

	void Level1()
	{
		
		Terminal.WriteLine("Enter your password, hint: " +level1hint[i]);


	}

	void Level2()
	{
		
		Terminal.WriteLine("Enter your password, hint: " +level2hint[i] );

	}

	void Level3()
	{
		Terminal.WriteLine("Enter your password, hint: "+level3hint[i]);

	}
}

