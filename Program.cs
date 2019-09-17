using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Skylinee
{
    class Program
    {
        static void Main(string[] args)
        {
            int amountOfBuildings = int.Parse(Console.ReadLine());
            double[] buildingDescriptionsXOne = new double[amountOfBuildings];
            double[] buildingDescriptionsXTwo = new double[amountOfBuildings];
            double[] buildingDescriptionsYOne = new double[amountOfBuildings];
            double[] buildingDescriptionsYTwo = new double[amountOfBuildings];
            double[] visable = new double[amountOfBuildings];

            for (int i = 0; i < amountOfBuildings; i++)
            {
                string[] tokens = Console.ReadLine().Split();
                buildingDescriptionsXOne[i] = double.Parse(tokens[0]);
                buildingDescriptionsYOne[i] = double.Parse(tokens[1]);
                buildingDescriptionsXTwo[i] = double.Parse(tokens[2]);
                buildingDescriptionsYTwo[i] = double.Parse(tokens[3]);
            }

            for(int i = 0; i < amountOfBuildings; i++)
            {
                visable[i] = AreaOfFunction(buildingDescriptionsXOne[i], buildingDescriptionsXTwo[i], buildingDescriptionsYOne[i], buildingDescriptionsYTwo[i]);
                for (int j = i + 1; j < amountOfBuildings; j++)
                {
                    visable[i] -= AreaOfFunction(buildingDescriptionsXOne[j], buildingDescriptionsXTwo[j], buildingDescriptionsYOne[j], buildingDescriptionsYTwo[j]);
                }
                double area = AreaOfFunction(buildingDescriptionsXOne[i], buildingDescriptionsXTwo[i], buildingDescriptionsYOne[i], buildingDescriptionsYTwo[i]);
                Console.WriteLine(visable[i]);
                visable[i] = (visable[i] / area);
                Console.WriteLine(area);
                Console.WriteLine(visable[i]);
            }

            Console.ReadLine();
        }

        static double AreaOfFunction(double xOne,double xTwo,double yOne,double yTwo)
        {
            double kx = ((yOne - yTwo) / (xOne - xTwo));
            double m = yOne - (kx * xOne);
            double primitivFunctionOne = (m * xOne) + ((kx * Math.Pow(xOne, 2)) / 2);
            double primitivFunctionTwo = (m * xTwo) + ((kx * Math.Pow(xTwo, 2)) / 2);
            double areaForBuildings = Math.Abs(primitivFunctionOne - primitivFunctionTwo);
            return areaForBuildings;
        }
    }
}
