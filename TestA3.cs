using VikingNS;
using System;
using static System.Console;

public class TestA3
{
    public short case_num = 0;
    public short failed_case = 0;
    public short success_case = 0;

    public void RunTests()
    {
        Viking viking = new("Viking", 100, Global.Weapon.AXE, true);

        // All your test cases go here...
        //case 1 - default constructor
        try
        {   case_num++;
            Karl karl1 = new();
            WriteLine(karl1.ToString());

            success_case++;
        }
        catch(Exception e){
            WriteLine(e.Message);
            WriteLine($"case: {case_num}");
            failed_case++;
        }

        // case 2 - parameterized constructor
        try
        {   case_num++;
            Karl karl2 = new("Karl1", 100, Global.Weapon.AXE, true, Global.Duty.CRAFTSMAN);
            WriteLine(karl2.ToString());
            success_case++;
        }
        catch(Exception e){
            WriteLine(e.Message);
            WriteLine($"case: {case_num}");
            failed_case++;
        }

        //case 3 - copy constructor
        try
        {   case_num++;
            Karl karl3 = new("Karl2", 100, Global.Weapon.AXE, true, Global.Duty.WARRIOR);
            Karl karl_copy = new(karl3);
            WriteLine("This is copy instance: \n" + karl_copy.ToString());
            success_case++;
        }
        catch(Exception e){
            WriteLine(e.Message);
            WriteLine($"case: {case_num}");
            failed_case++;
        }

        //! false cases
        //case 4
        try
        {   case_num++;
            Karl karl4 = new("\t", 100, Global.Weapon.AXE, true, Global.Duty.FARMER); //!Invalid value for name
            WriteLine(karl4.ToString());
            success_case++;
        }
        catch(Exception e){
            WriteLine(e.Message);
            WriteLine($"case: {case_num}");
            failed_case++;
        }

        // case 5
        try
        {   case_num++;
            Karl karl5 = new("Meow", -100, Global.Weapon.AXE, true, Global.Duty.FARMER); //! Invalid value for health
            WriteLine(karl5.ToString());
            success_case++;
        }
        catch(Exception e){
            WriteLine(e.Message);
            WriteLine($"case: {case_num}");
            failed_case++;
        }

        //case 6
        try
        {   case_num++;
            Karl karl6 = new("Karl6", 100, (Global.Weapon)5, true, Global.Duty.FARMER); //! Invalid value for weapon
            WriteLine(karl6.ToString());
            success_case++;
        }
        catch(Exception e){
            WriteLine(e.Message);
            WriteLine($"case: {case_num}");
            failed_case++;
        }

        //case 7
        try
        {   case_num++;
            Karl karl7 = new("Karl7", 100, Global.Weapon.AXE, true, (Global.Duty)5); //! Invalid value for duty
            WriteLine(karl7.ToString());
            success_case++;
        }
        catch(Exception e){
            WriteLine(e.Message);
            WriteLine($"case: {case_num}");
            failed_case++;
        }


        //!This one is okay
        //case 8
        try
        {   case_num++;
            Karl karl7 = new("Karl8", 0, Global.Weapon.AXE, false, Global.Duty.FARMER);
            WriteLine(karl7.ToString());
            success_case++;
        }
        catch(Exception e){
            WriteLine(e.Message);
            WriteLine($"case: {case_num}");
            failed_case++;
        }
        // Test case end - Report
        ForegroundColor = ConsoleColor.Yellow;
        WriteLine();
        WriteLine("End of test!");
        WriteLine("Total test cases: " + (case_num));
        WriteLine("True test cases: 4");
        WriteLine("True fail cases: 4");
        WriteLine();

        ForegroundColor = ConsoleColor.Green;
        WriteLine("True Success count: " + success_case);
        ForegroundColor = ConsoleColor.Red;
        WriteLine("True Exception count: " + failed_case);
        ResetColor();
    }
}