using System;

namespace GpaCalculator
{
    class Program
    {
        public double ReturnGpa(int marks)
        {
            double output = marks switch
            {
                _ when marks >= 0  && marks < 50 => 0.00,
                _ when marks >= 50 && marks < 55 => 1.00,
                _ when marks >= 55 && marks < 58 => 1.70,
                _ when marks >= 58 && marks < 61 => 2.00,
                _ when marks >= 61 && marks < 65 => 2.30,
                _ when marks >= 65 && marks < 70 => 2.70,
                _ when marks >= 70 && marks < 75 => 3.00,
                _ when marks >= 75 && marks < 80 => 3.30,
                _ when marks >= 80 && marks < 85 => 3.70,
                _ when marks >= 85 => 4.00
            };
            return output;
        }
        public void GpaCalculator()
        {
            Console.WriteLine("-------- Welcome to GPA Calculator --------");
            Console.Write("Enter the total number of subjects: ");
            int noOfSubjects = int.Parse(Console.ReadLine());

            int[] subjectMarks = new int[noOfSubjects];
            int[] subjectCreditHours = new int[noOfSubjects];
            double[] subjectGpa = new double[noOfSubjects];

            int sumOfCrHours = 0;
            double sumProductOfCrHourAndGp = 0;

            for(int i = 0; i < noOfSubjects; i++)
            {
                Console.WriteLine();

                Console.Write("Enter the obtained marks in subject # " + (i + 1) + " :");
                subjectMarks[i]= int.Parse(Console.ReadLine());

                Console.Write("Enter the credit hours of subject # " + (i + 1) + "   :");
                subjectCreditHours[i] = int.Parse(Console.ReadLine());                

                subjectGpa[i] = ReturnGpa(subjectMarks[i]);

                sumProductOfCrHourAndGp += (double)subjectCreditHours[i] * subjectGpa[i];
                sumOfCrHours += subjectCreditHours[i];
            }

            Console.WriteLine("\n--------------------------------------------");
            Console.WriteLine(
                format: "{0,-5}\t{1,-14}\t{2,-13}\tGPA",
                arg0: "Sr #",
                arg1: "Otained Marks",
                arg2: "Credit Hours");
            for (int i = 0; i < noOfSubjects; i++)
            {
                Console.WriteLine(
                format: "{0,-5}\t{1,-14}\t{2,-13}\t" + subjectGpa[i],
                arg0: i+1,
                arg1: subjectMarks[i],
                arg2: subjectCreditHours[i]);

            }

            Console.WriteLine("--------------------------------------------\n");

            Console.WriteLine("=============== Total GPA: {0:0.00}" , sumProductOfCrHourAndGp/(double)sumOfCrHours);

        }
        static void Main(string[] args)
        {
            Program n = new Program();
            n.GpaCalculator();
        }
    }
}