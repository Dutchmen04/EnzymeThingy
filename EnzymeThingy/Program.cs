using EnzymeThingy;

class Program
{
    public static void Main()
    {
        bool allInputCorrect = false;
        float plasticDigestionRate = 0.0f;
        while (!allInputCorrect)
        {
            try
            {
                Console.Write("Enter the plastic digestion rate: ");
                plasticDigestionRate = float.Parse(Console.ReadLine());
                allInputCorrect = true;
            }catch(Exception e){ Console.WriteLine("Fill in a float dumbass");}
        }
        allInputCorrect = false;
        float lifeRatio = 0.0f;
        while (!allInputCorrect)
        {
            try
            {
                Console.Write("Enter the life conversion rate: ");
                lifeRatio = float.Parse(Console.ReadLine());
                allInputCorrect = true;
            }catch(Exception e){ Console.WriteLine("Fill in a float dumbass");}
        }
        allInputCorrect = false;
        float transferChance = 0.0f;
        while (!allInputCorrect)
        {
            try
            {
                Console.Write("Enter the transfer chance: ");
                transferChance = float.Parse(Console.ReadLine());
                allInputCorrect = true;
            }catch(Exception e){ Console.WriteLine("Fill in a float dumbass");}
        }
        allInputCorrect = false;
        float transferAmount = 0.0f;
        while (!allInputCorrect)
        {
            try
            {
                Console.Write("Enter the transfer amount: ");
                transferAmount = float.Parse(Console.ReadLine());
                allInputCorrect = true;
            }catch(Exception e){ Console.WriteLine("Fill in a float dumbass");}
        }
        
        allInputCorrect = false;
        int iterationCount = 0;
        while (!allInputCorrect)
        {
            try
            {
                Console.Write("Enter the amount of iterations: ");
                iterationCount = Int32.Parse(Console.ReadLine());
                allInputCorrect = true;
            }catch(Exception e){ Console.WriteLine("Fill in an integer dumbass");}
        }
        
        Bacteria bak = new Bacteria(plasticDigestionRate, lifeRatio);
        (float, float)[][] ray = new (float, float)[2][];
        InitArray(ray);
        SimulationBoard bord = new SimulationBoard(ray, bak, transferAmount, transferChance);
        bord.InitBoard(10, 3000);
        double totalBefore = bord.GetPlasticConcentration();
        bord.Run(iterationCount);
        double totalAfter = bord.GetPlasticConcentration();
        Console.WriteLine($"Total rate of plastic digested: { (1- totalAfter / totalBefore) * 100}%");
    }

    public static void InitArray((float, float)[][] ray)
    {
        for (int i = 0; i < ray.Length; i++)
        {
            ray[i] = new (float, float)[ray.Length];
        }
    }
}