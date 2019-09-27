using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocomoProject
{
    //public enum ProjectType
    //{
    //    Organic = 0, Semi_detached = 1, Embedded = 2
    //}

    public static class Calculation
    {
        //Таблиця коефіцієнтів
        static double[][] coefArr = new double[3][];
        static Calculation()
        {
            coefArr[0] = new[] { 2.4, 1.05, 2.5, 0.38 }; // для проекта типа Organic
            coefArr[1] = new[] { 3.0, 1.12, 2.5, 0.35 }; // Semi-Detached
            coefArr[2] = new[] { 3.6, 1.20, 2.5, 0.32 }; // Embedded
        }

        //Трудоємність
        public static double GetEfforts(int codeSize, int type)
        {
            return coefArr[type][0] * (Math.Pow(codeSize, coefArr[type][1]));
        }

        // Термін розробки
        public static double GetTimeToDevelop(int codeSize, int type)
        {
            return coefArr[type][2] * (Math.Pow(GetEfforts(codeSize, type), coefArr[type][3]));
        }

        //Число необхідних розробників
        public static double GetPersonsToDevelop(int codeSize, int type)
        {
            return Math.Round(GetEfforts(codeSize, type) / GetTimeToDevelop(codeSize, type));
        }
    }



}


