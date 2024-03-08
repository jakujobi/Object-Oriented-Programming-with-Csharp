//Program.cs
/*************************************************************************************
*** NAME: John Akujobi ***
*** CLASS: CSc 346 ***
*** ASSIGNMENT: Assignment 2 ***
*** DUE DATE: 02-26-2024 ***
*** INSTRUCTOR: GAMRADT ***
*** DESCRIPTION: ***
***  The program conducts automated tests on the Viking class.
***  It tests constructors and methods.
***  The class models a Viking with attributes like name and health,
***  and behaviors such as displaying these attributes using an interface.
***  JAkujobi's testing framework logs successes and failures,
***      rethrows exceptions for diagnostic purposes,
***      and concludes by reporting the test outcomes. 
*************************************************************************************/


global using System;
global using System.Collections.Generic;
global using System.Linq;
using static System.Console;
using static VikingNS.Global;
using VikingNS;

class TestAk3
{
    static short ExceptionCounter = 0;
    static short SuccessCounter = 0;
    static Random random = new Random();

    /********************************************************************************
    *** METHOD Main                                                            ***
    ********************************************************************************
    *** DESCRIPTION : Entry point for the program which runs a series of tests   ***
    *** on the Viking class constructors and reports the results.                ***
    *** INPUT ARGS  : string[] args                                              ***
    *** OUTPUT ARGS : None                                                       ***
    *** IN/OUT ARGS : None                                                       ***
    *** RETURN      : void                                                       ***
    ********************************************************************************/
    static void Main(string[] args)
    {
        Console.WriteLine("Running JAkujobi Viking Tests...");
        Console.WriteLine();
        TestJADefaultConstructor();
        TestJAParameterizedConstructor();
        TestJACopyConstructor();
        TestJAParameterWithSpecialCharacter();
        TestJANullName();
        TestJANegativeHealth();
        TestJALongName();
        TestJAEmptyName();
        TestJAStatusGreaterThanTwo();
        TestJAStatusLessThanZero();
        TestJAWeaponGreaterThanTwo();
        TestJAWeaponLessThanZero();
        TestJANameWithSpacesOnly();
        TestJANameWithTabCharacter();
        TestJANameWithNewlineCharacter();
        TestWithExtremelyHighHealthValue();
        TestWithNegativeWeaponValues();
        TestWithFloatingPointForHealth();
        StressTestWithRapidInstantiation();
        TestJAFuzzTesting();
    
        ReportJAkujobiTestResults();
    }

    /********************************************************************************
    *** METHOD PerformJATest                                                   ***
    ********************************************************************************
    *** DESCRIPTION : Executes a given test action and logs the result.            ***
    *** INPUT ARGS  : Action testAction, string testName                           ***
    *** OUTPUT ARGS : None                                                         ***
    *** IN/OUT ARGS : None                                                         ***
    *** RETURN      : void                                                         ***
    ********************************************************************************/
    static void PerformJATest(Action testAction, string testName){
        try
        {
            testAction();
            SuccessCounter++;
            Console.WriteLine($"{testName}: Success");
            Console.WriteLine();
        }
        catch (Exception ex)
        {
            ExceptionCounter++;
            Console.WriteLine($"{testName}: Failed");
            Console.WriteLine(ex.Message);
        }
        Console.WriteLine();
        Console.WriteLine("___________________________________________________________________");
        Console.WriteLine("___________________________________________________________________");
        Console.WriteLine();
        Console.WriteLine();
    }

    /********************************************************************************
    *** METHOD TestJADefaultConstructor                                        ***
    ********************************************************************************
    *** DESCRIPTION : Tests the default constructor of the Viking class.           ***
    *** INPUT ARGS  : None                                                         ***
    *** OUTPUT ARGS : None                                                         ***
    *** IN/OUT ARGS : None                                                         ***
    *** RETURN      : void                                                         ***
    ********************************************************************************/
    static void TestJADefaultConstructor()
    {
        PerformJATest(() =>
        {
            Console.WriteLine("Testing default constructor...");
            Viking viking = new Viking();
            if (viking.Name != "Bjorn" || viking.Status != VikingNS.Global.Status.KARL || viking.Health != 100 || viking.Weapon != VikingNS.Global.Weapon.AXE)
            {
                throw new Exception("Default constructor failed to initialize Viking instance with default values.");
            }

            viking.ViewH();
            viking.ViewV();
        }, "TestJADefaultConstructor");
    }

    /********************************************************************************
    *** METHOD TestJAParameterizedConstructor                                  ***
    ********************************************************************************
    *** DESCRIPTION : Tests the parameterized constructor of the Viking class      ***
    *** with specified name, status, health, and weapon parameters.                ***
    *** INPUT ARGS  : None                                                         ***
    *** OUTPUT ARGS : None                                                         ***
    *** IN/OUT ARGS : None                                                         ***
    *** RETURN      : void                                                         ***
    ********************************************************************************/
    static void TestJAParameterizedConstructor()
    {
        PerformJATest(() =>
        {
            Console.WriteLine("Testing parameterized constructor...");
            Viking viking = new Viking("Ulrik", Status.JARL, 150, Weapon.SWORD);
            if (viking.Name != "Ulrik" || viking.Status != Status.JARL || viking.Health != 150 || viking.Weapon != Weapon.SWORD)
            {
                throw new Exception("Parameterized constructor failed to initialize Viking instance with provided values.");
            }

            viking.ViewH();
            viking.ViewV();
        }, "TestJAParameterizedConstructor");
    }

    /********************************************************************************
    *** METHOD TestJACopyConstructor                                           ***
    ********************************************************************************
    *** DESCRIPTION : Tests the copy constructor of the Viking class by creating   ***
    *** a new Viking instance as a copy of an existing one.                        ***
    *** INPUT ARGS  : None                                                         ***
    *** OUTPUT ARGS : None                                                         ***
    *** IN/OUT ARGS : None                                                         ***
    *** RETURN      : void                                                         ***
    ********************************************************************************/
    static void TestJACopyConstructor()
    {
        PerformJATest(() =>
        {
            Console.WriteLine("Testing copy constructor...");
            Viking viking = new Viking("Ragnar", VikingNS.Global.Status.JARL, 150, VikingNS.Global.Weapon.SWORD);
            Viking vikingCopy = new Viking(viking);
            if (vikingCopy.Name != "Ragnar" || vikingCopy.Status != VikingNS.Global.Status.JARL || vikingCopy.Health != 150 || vikingCopy.Weapon != VikingNS.Global.Weapon.SWORD)
            {
                throw new Exception("Copy constructor failed to initialize Viking instance with provided values.");
            }

            vikingCopy.ViewH();
            vikingCopy.ViewV();
        }, "TestJACopyConstructor");
    }

    /********************************************************************************
    *** METHOD TestJAParameterWithSpecialCharacter                             ***
    ********************************************************************************
    *** DESCRIPTION : Tests the parameterized constructor with a name containing ***
    *** special characters to ensure proper handling and initialization.         ***
    *** INPUT ARGS  : None                                                       ***
    *** OUTPUT ARGS : None                                                       ***
    *** IN/OUT ARGS : None                                                       ***
    *** RETURN      : void                                                       ***
    ********************************************************************************/
    static void TestJAParameterWithSpecialCharacter()
    {
        PerformJATest(() =>
        {
            Console.WriteLine("Testing parameterized constructor with special characters...");
            Viking viking = new Viking("Ragn@r", VikingNS.Global.Status.JARL, 150, VikingNS.Global.Weapon.SWORD);
            if (viking.Name != "Ragn@r" || viking.Status != VikingNS.Global.Status.JARL || viking.Health != 150 || viking.Weapon != VikingNS.Global.Weapon.SWORD)
            {
                throw new Exception("Parameterized constructor failed to initialize Viking instance with provided values.");
            }

            viking.ViewH();
            viking.ViewV();
        }, "TestJAParameterWithSpecialCharacter");
    }

    /********************************************************************************
    *** METHOD TestJANullName                                                   ***
    ********************************************************************************
    *** DESCRIPTION : Tests the parameterized constructor with a null name to     ***
    *** ensure the Viking instance is initialized with a null name.               ***
    *** INPUT ARGS  : None                                                       ***
    *** OUTPUT ARGS : None                                                       ***
    *** IN/OUT ARGS : None                                                       ***
    *** RETURN      : void                                                       ***
    ********************************************************************************/
    static void TestJANullName()
    {
        PerformJATest(() =>{
            Console.WriteLine("Testing parameterized constructor with null name...");
            Viking viking = new Viking(null, VikingNS.Global.Status.JARL, 150, VikingNS.Global.Weapon.SWORD);
            if (viking.Name != null)
            {
                throw new Exception("Parameterized constructor failed to handle null name.");
            }

            viking.ViewH();
            viking.ViewV();
        }, "TestJANullName");
    }

    /********************************************************************************
    *** METHOD TestJANegativeHealth                                             ***
    ********************************************************************************
    *** DESCRIPTION : Tests the parameterized constructor with a negative health  ***
    *** value to ensure the Viking instance handles invalid health input.         ***
    *** INPUT ARGS  : None                                                       ***
    *** OUTPUT ARGS : None                                                       ***
    *** IN/OUT ARGS : None                                                       ***
    *** RETURN      : void                                                       ***
    ********************************************************************************/
    static void TestJANegativeHealth()
    {
        PerformJATest(() =>{
            Console.WriteLine("Testing parameterized constructor with negative health...");
            Viking viking = new Viking("Thor", VikingNS.Global.Status.JARL, -150, VikingNS.Global.Weapon.SWORD);
            if (viking.Health >= 0)
            {
                throw new Exception("Parameterized constructor failed to handle negative health.");
            }

            viking.ViewH();
            viking.ViewV();
        }, "TestJANegativeHealth");
    }

    /********************************************************************************
    *** METHOD TestJALongName                                                   ***
    ********************************************************************************
    *** DESCRIPTION : Tests the parameterized constructor with a long name to     ***
    *** ensure the Viking instance is initialized correctly.                      ***
    *** INPUT ARGS  : None                                                       ***
    *** OUTPUT ARGS : None                                                       ***
    *** IN/OUT ARGS : None                                                       ***
    *** RETURN      : void                                                       ***
    ********************************************************************************/
    static void TestJALongName()
    {
        PerformJATest(() =>
        {
            Console.WriteLine("Testing parameterized constructor with long name...");
            Viking viking = new Viking("12345678910111213141516", VikingNS.Global.Status.JARL, 200, VikingNS.Global.Weapon.SWORD, true);
            if (viking.Name != "12345678910111213141516" || viking.Status != VikingNS.Global.Status.JARL || viking.Health != 200 || viking.Weapon != VikingNS.Global.Weapon.SWORD || viking.Shield != true)
            {
                throw new Exception("Parameterized constructor failed to initialize Viking instance with provided values.");
            }

            viking.ViewH();
            viking.ViewV();
        }, "TestJALongName");
    }

    /********************************************************************************
    *** METHOD TestJAEmptyName                                                  ***
    ********************************************************************************
    *** DESCRIPTION : Tests the parameterized constructor with an empty string as ***
    *** name to ensure the Viking instance is initialized with an empty name.     ***
    *** INPUT ARGS  : None                                                       ***
    *** OUTPUT ARGS : None                                                       ***
    *** IN/OUT ARGS : None                                                       ***
    *** RETURN      : void                                                       ***
    ********************************************************************************/
    static void TestJAEmptyName()
    {
        PerformJATest(() =>
        {
            Console.WriteLine("Testing parameterized constructor with empty name...");
            Viking viking = new Viking("", VikingNS.Global.Status.JARL, 200, VikingNS.Global.Weapon.SWORD, true);
            if (viking.Name != "" || viking.Status != VikingNS.Global.Status.JARL || viking.Health != 200 || viking.Weapon != VikingNS.Global.Weapon.SWORD || viking.Shield != true)
            {
                throw new Exception("Parameterized constructor failed to initialize Viking instance with provided values.");
            }

            viking.ViewH();
            viking.ViewV();
        }, "TestJAEmptyName");
    }

    /********************************************************************************
    *** METHOD TestJAZeroHealth                                                ***
    ********************************************************************************
    *** DESCRIPTION : Tests the parameterized constructor with zero health to     ***
    *** ensure the Viking instance handles zero health input.                     ***
    *** INPUT ARGS  : None                                                       ***
    *** OUTPUT ARGS : None                                                       ***
    *** IN/OUT ARGS : None                                                       ***
    *** RETURN      : void                                                       ***
    ********************************************************************************/
    static void TestJAZeroHealth()
    {
        PerformJATest(() =>
        {
            Console.WriteLine("Testing parameterized constructor with zero health...");
            Viking viking = new Viking("Brynhild", VikingNS.Global.Status.JARL, 0, VikingNS.Global.Weapon.SWORD, true);
            if (viking.Name != "Brynhild" || viking.Status != VikingNS.Global.Status.JARL || viking.Health != 0 || viking.Weapon != VikingNS.Global.Weapon.SWORD || viking.Shield != true)
            {
                throw new Exception("Parameterized constructor failed to handle zero health.");
            }

            viking.ViewH();
            viking.ViewV();
        }, "TestJAZeroHealth");
    }

    /********************************************************************************
    *** METHOD TestJAStatusGreaterThanTwo                                       ***
    ********************************************************************************
    *** DESCRIPTION : Tests the parameterized constructor with a status value     ***
    *** greater than the defined range to ensure proper handling of invalid       ***
    *** status values.                                                           ***
    *** INPUT ARGS  : None                                                       ***
    *** OUTPUT ARGS : None                                                       ***
    *** IN/OUT ARGS : None                                                       ***
    *** RETURN      : void                                                       ***
    ********************************************************************************/
    static void TestJAStatusGreaterThanTwo()
    {
        PerformJATest(() =>
        {
            Console.WriteLine("Testing parameterized constructor with status > 2...");
            Viking viking = new Viking("Viking status >2", (VikingNS.Global.Status)3);
            if (viking.Status != (VikingNS.Global.Status)3)
            {
                throw new Exception("Parameterized constructor failed to handle status > 2.");
            }

            viking.ViewV();
        }, "TestJAStatusGreaterThanTwo");
    }

    /********************************************************************************
    *** METHOD TestJAStatusLessThanZero                                         ***
    ********************************************************************************
    *** DESCRIPTION : Tests the parameterized constructor with a negative status  ***
    *** value to ensure the Viking instance handles invalid status input.         ***
    *** INPUT ARGS  : None                                                       ***
    *** OUTPUT ARGS : None                                                       ***
    *** IN/OUT ARGS : None                                                       ***
    *** RETURN      : void                                                       ***
    ********************************************************************************/
    static void TestJAStatusLessThanZero()
    {
        PerformJATest(() =>
        {
            Console.WriteLine("Testing parameterized constructor with status < 0...");
            Viking viking = new Viking("Status <0", (VikingNS.Global.Status)(-1));
            if (viking.Status != (VikingNS.Global.Status)(-1))
            {
                throw new Exception("Parameterized constructor failed to handle status < 0.");
            }

            viking.ViewV();
        }, "TestJAStatusLessThanZero");
    }

    /********************************************************************************
    *** METHOD TestJAWeaponGreaterThanTwo                                       ***
    ********************************************************************************
    *** DESCRIPTION : Tests the parameterized constructor with a weapon value      ***
    *** greater than the defined range to ensure proper handling of invalid       ***
    *** weapon values.                                                           ***
    *** INPUT ARGS  : None                                                       ***
    *** OUTPUT ARGS : None                                                       ***
    *** IN/OUT ARGS : None                                                       ***
    *** RETURN      : void                                                       ***
    ********************************************************************************/
    static void TestJAWeaponGreaterThanTwo()
    {
        PerformJATest(() =>
        {
            Console.WriteLine("Testing parameterized constructor with weapon > 2...");
            Viking viking = new Viking(weapon: (VikingNS.Global.Weapon)3);
            if (viking.Weapon != (VikingNS.Global.Weapon)3)
            {
                throw new Exception("Parameterized constructor failed to handle weapon > 2.");
            }

            viking.ViewV();
        }, "TestJAWeaponGreaterThanTwo");
    }

    /********************************************************************************
    *** METHOD TestJAWeaponLessThanZero                                         ***
    ********************************************************************************
    *** DESCRIPTION : Tests the parameterized constructor with a negative weapon  ***
    *** value to ensure the Viking instance handles invalid weapon input.         ***
    *** INPUT ARGS  : None                                                       ***
    *** OUTPUT ARGS : None                                                       ***
    *** IN/OUT ARGS : None                                                       ***
    *** RETURN      : void                                                       ***
    ********************************************************************************/
    static void TestJAWeaponLessThanZero()
    {
        PerformJATest(() =>
        {
            Console.WriteLine("Testing parameterized constructor with weapon < 0...");
            Viking viking = new Viking(weapon: (VikingNS.Global.Weapon)(-1));
            if (viking.Weapon != (VikingNS.Global.Weapon)(-1))
            {
                throw new Exception("Parameterized constructor failed to handle weapon < 0.");
            }

            viking.ViewV();
        }, "TestJAWeaponLessThanZero");
    }

    /********************************************************************************
    *** METHOD TestJANameWithSpacesOnly                                        ***
    ********************************************************************************
    *** DESCRIPTION : Tests the parameterized constructor with a name consisting  ***
    *** only of spaces to ensure the Viking instance handles invalid names.       ***
    *** INPUT ARGS  : None                                                       ***
    *** OUTPUT ARGS : None                                                       ***
    *** IN/OUT ARGS : None                                                       ***
    *** RETURN      : void                                                       ***
    ********************************************************************************/
    static void TestJANameWithSpacesOnly()
    {
        PerformJATest(() =>
        {
            Console.WriteLine("Testing parameterized constructor with name containing spaces only...");
            Viking viking = new Viking("     ");
            if (viking.Name != "     ")
            {
                throw new Exception("Parameterized constructor failed to handle name with spaces only.");
            }

            viking.ViewV();
        }, "TestJANameWithSpacesOnly");
    }

    /********************************************************************************
    *** METHOD TestWithExtremelyHighHealthValue                                  ***
    ********************************************************************************
    *** DESCRIPTION : Tests the parameterized constructor with an extremely high ***
    *** health value to see how the class handles large integers.                 ***
    *** INPUT ARGS  : None                                                       ***
    *** OUTPUT ARGS : None                                                       ***
    *** IN/OUT ARGS : None                                                       ***
    *** RETURN      : void                                                       ***
    ********************************************************************************/
    static void TestWithExtremelyHighHealthValue()
    {
        PerformJATest(() =>{
            Console.WriteLine("Testing parameterized constructor with extremely high health...");
            Viking viking = new Viking("Thor", VikingNS.Global.Status.JARL, short.MaxValue, VikingNS.Global.Weapon.SWORD);
            // Add your assertions here
            viking.ViewH();
            viking.ViewV();
        }, "TestWithExtremelyHighHealthValue");
    }

    /********************************************************************************
    *** METHOD TestWithNegativeWeaponValues                                      ***
    ********************************************************************************
    *** DESCRIPTION : Tests the parameterized constructor with negative weapon   ***
    *** values to see how the class handles invalid weapon input.                ***
    *** INPUT ARGS  : None                                                       ***
    *** OUTPUT ARGS : None                                                       ***
    *** IN/OUT ARGS : None                                                       ***
    *** RETURN      : void                                                       ***
    ********************************************************************************/
    static void TestWithNegativeWeaponValues()
    {
        PerformJATest(() =>{
            Console.WriteLine("Testing parameterized constructor with negative weapon values...");
            Viking viking = new Viking("Thor", VikingNS.Global.Status.JARL, 100, (VikingNS.Global.Weapon)(-100));
            // Add your assertions here
            viking.ViewH();
            viking.ViewV();
        }, "TestWithNegativeWeaponValues");
    }

    /********************************************************************************
    *** METHOD TestWithFloatingPointForHealth                                    ***
    ********************************************************************************
    *** DESCRIPTION : Tests the parameterized constructor with floating point    ***
    *** health values to see how the class handles type mismatches.              ***
    *** INPUT ARGS  : None                                                       ***
    *** OUTPUT ARGS : None                                                       ***
    *** IN/OUT ARGS : None                                                       ***
    *** RETURN      : void                                                       ***
    ********************************************************************************/
    static void TestWithFloatingPointForHealth()
    {
        PerformJATest(() =>{
            Console.WriteLine("Testing parameterized constructor with floating point for health...");
            Viking viking = new Viking("Thor", VikingNS.Global.Status.JARL, (int)100.5, VikingNS.Global.Weapon.SWORD);
            // Add your assertions here
            viking.ViewH();
            viking.ViewV();
        }, "TestWithFloatingPointForHealth");
    }

    /********************************************************************************
    *** METHOD TestJANameWithTabCharacter                                      ***
    ********************************************************************************
    *** DESCRIPTION : Tests the parameterized constructor with a name containing  ***
    *** a tab character to ensure the Viking instance handles special characters  ***
    *** in names correctly.                                                      ***
    *** INPUT ARGS  : None                                                       ***
    *** OUTPUT ARGS : None                                                       ***
    *** IN/OUT ARGS : None                                                       ***
    *** RETURN      : void                                                       ***
    ********************************************************************************/
    static void TestJANameWithTabCharacter()
    {
        PerformJATest(() =>
        {
            Console.WriteLine("Testing parameterized constructor with name containing tab character...");
            Viking viking = new Viking("\t");
            if (viking.Name != "\t")
            {
                throw new Exception("Parameterized constructor failed to handle name with tab character.");
            }

            viking.ViewV();
        }, "TestJANameWithTabCharacter");
    }

    /********************************************************************************
    *** METHOD TestJANameWithNewlineCharacter                                  ***
    ********************************************************************************
    *** DESCRIPTION : Tests the parameterized constructor with a name containing  ***
    *** a newline character to ensure the Viking instance handles special         ***
    *** characters in names correctly.                                           ***
    *** INPUT ARGS  : None                                                       ***
    *** OUTPUT ARGS : None                                                       ***
    *** IN/OUT ARGS : None                                                       ***
    *** RETURN      : void                                                       ***
    ********************************************************************************/
    static void TestJANameWithNewlineCharacter()
    {
        PerformJATest(() =>
        {
            Console.WriteLine("Testing parameterized constructor with name containing newline character...");
            Viking viking = new Viking("\n");
            if (viking.Name != "\n")
            {
                throw new Exception("Parameterized constructor failed to handle name with newline character.");
            }

            viking.ViewV();
        }, "TestJANameWithNewlineCharacter");
    }


    /********************************************************************************
    *** METHOD StressTestWithRapidInstantiation                                 ***
    ********************************************************************************
    *** DESCRIPTION : Creates a loop that rapidly instantiates and discards      ***
    *** Viking objects to test the class's performance and memory handling under ***
    *** stress.                                                                 ***
    *** INPUT ARGS  : None                                                       ***
    *** OUTPUT ARGS : None                                                       ***
    *** IN/OUT ARGS : None                                                       ***
    *** RETURN      : void                                                       ***
    ********************************************************************************/
    static void StressTestWithRapidInstantiation()
    {
        PerformJATest(() =>{
            Console.WriteLine("Stress testing with rapid instantiation...");
            for (int i = 0; i < 1000000; i++)
            {
                Viking viking = new Viking("Thor", VikingNS.Global.Status.JARL, 100, VikingNS.Global.Weapon.SWORD);
                // No assertions needed for this test
            }
        }, "StressTestWithRapidInstantiation");
    }

    /********************************************************************************
    *** METHOD TestJAFuzzTesting                                                ***
    ********************************************************************************
    *** DESCRIPTION : Conducts fuzz testing on the Viking class by generating     ***
    *** random input values for the constructor and methods to uncover unexpected ***
    *** behaviors or crashes.                                                     ***
    *** INPUT ARGS  : None                                                        ***
    *** OUTPUT ARGS : None                                                        ***
    *** IN/OUT ARGS : None                                                        ***
    *** RETURN      : void                                                        ***
    ********************************************************************************/
    static void TestJAFuzzTesting()
    {
        PerformJATest(() => {
            Console.WriteLine("Starting fuzz testing...");
            for (short i = 0; i < 15; i++) // Running 100 fuzz tests
            {
                try{
                    string name = GenerateRandomString((short)random.Next(1, 20));
                    Status status = (Status)(short)random.Next(0, Enum.GetNames(typeof(Status)).Length);
                    short health = (short)random.Next(-100, 500);
                    Weapon weapon = (Weapon)(short)random.Next(0, Enum.GetNames(typeof(Weapon)).Length);
                    bool shield = random.Next(0, 2) == 1;

                    Viking viking = new Viking(name, status, health, weapon, shield);
                    Console.WriteLine($"Fuzz Test #{i + 1}: Created Viking - {name}, {status}, {health}, {weapon}, {shield}");

                    viking.ViewV();
                    viking.ViewH();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred during fuzz test #{i + 1}: {ex.Message}");
                    ExceptionCounter++;
                }
                SuccessCounter++;
                Console.WriteLine($"Fuzz Test #{i + 1} completed.");
            }
        }, "TestJAFuzzTesting");
    }

    /********************************************************************************
    *** METHOD GenerateRandomString                                             ***
    ********************************************************************************
    *** DESCRIPTION : Helper function to generate random strings for Fuzz testing ***
    *** INPUT ARGS  : int length                                                 ***
    *** OUTPUT ARGS : None                                                       ***
    *** IN/OUT ARGS : None                                                       ***
    *** RETURN      : string stringChars                                         ***
    ********************************************************************************/
    static string GenerateRandomString(int length)
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        char[] stringChars = new char[length];
        for (int i = 0; i < length; i++)
        {
            stringChars[i] = chars[random.Next(chars.Length)];
        }
        return new string(stringChars);
    }


    /********************************************************************************
    *** METHOD ReportJAkujobiTestResults                                       ***
    ********************************************************************************
    *** DESCRIPTION : Outputs the test results summary including the total number ***
    *** of tests, how many passed, and how many failed.                          ***
    *** INPUT ARGS  : None                                                       ***
    *** OUTPUT ARGS : None                                                       ***
    *** IN/OUT ARGS : None                                                       ***
    *** RETURN      : void                                                       ***
    ********************************************************************************/
    static void ReportJAkujobiTestResults()
    {
        Console.WriteLine();
        Console.WriteLine("JAkujobi Viking Test Results");
        Console.WriteLine($"Total Tests: {ExceptionCounter + SuccessCounter}");
        Console.WriteLine($"Success: {SuccessCounter}");
        Console.WriteLine($"Failed: {ExceptionCounter}");
    }


}