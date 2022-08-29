﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSPSolver
{
    public static class Samples
    {
        public static List<List<double>> Sample1()
        {
            string[] s = new string[] { "Y7", "Y8", "Y9", "Y10", "Y11", "Y12", "Y13", "Y14" };
            double[] x = new double[] { -106214.427, -106283.146, -106299.959, -106372.579, -106382.308, -106387.508, -106449.139, -106456.964 };
            double[] y = new double[] { -24611.454, -24638.786, -24645.051, -24665.214, -24662.276, -24668.275, -24692.245, -24691.847 };
            return MakeList(x, y);
        }
        public static List<List<double>> Sample2()
        {
            string[] s = new string[] { "1-A", "1-B", "1-C", "1-D", "1-E", "1-F", "1-P", "1-Q1", "1-Q2",
            "1-R", "1-S", "1-21", "7-A1", "7-A2", "7-B1", "7-B2", "7-C1", "7-C2", "7-D", "7-E",
            "7-F", "7-G1", "7-G2", "7-H", "7-2", "7-3", "7-4", "7-5", "K-54", "K-55", "K-56", "K0015"};
            double[] x = new double[] { -106210.456, -106208.973, -106208.893, -106209.696, -106211.524, -106238.663, -106320.163, -106410.689,
                -106412.745, -106370.593, -106214.436, -106323.094, -106384.257, -106382.249, -106420.262, -106424.834, -106506.778, -106508.621,
                -106477.734, -106469.634, -106462.926, -106456.693, -106451.816, -106410.014, -106450.962, -106440.053, -106415.804, -106445.536,
                -106352.412, -106307.33, -106241.047, -106373.514 };
            double[] y = new double[] { -24606.158, -24590.559, -24582.495, -24572.049, -24563.06, -24487.58, -24525, -24558.322, -24562.896, -24670.274, 
                -24611.466, -24517.555, -24667.011, -24662.426, -24565.566, -24563.535, -24593.711, -24598.369, -24659.482, -24672.99, -24685.29, 
                -24692.145, -24693.286, -24591.718, -24573.157, -24602.78, -24576.943, -24587.891, -24663.206, -24647.798, -24623.098, -24662.833 };
            return MakeList(x, y);
        }
        public static List<List<double>> Sample3()
        {
            string[] s = new string[] { "LNO75", "LNO76", "LNO76+11.40", "LNO77", "LNO77+11.60", "LNO78",
            "LNO79", "LNO80", "LNO81", "LNO81+10.60", "LNO82", "LNO82+1.19", "LNO82+9.90", "LNO82+16.10", "LNO83",
            "LNO84+1.10", "LNO84+1.60", "LNO84+1.80", "LNO84+11.60", "LNO85", "LNO86", "LNO87", "LNO88", "LNO89",
            "LNO90", "LNO90+0.05", "LNO91", "LNO92", "LNO93", "LNO94", "LNO94+3.30", "LNO94+11.30", "LNO94+19.00",
            "LNO95", "LNO95+5.56", "LNO96", "LNO97", "LNO98", "LNO98+2.70", "LNO98+10.00", "LNO98+14.70", "LNO99",
            "LNO99+9.10", "LNO99+19.31", "LNO100", "LNO101", "LNO102", "LNO102+9.60", "LNO103"};
            double[] x = new double[] { -106012.701, -106030.939, -106041.316, -106049.389, -106060.249, -106067.928, -106086.216, -106104.635, 
                -106123.181, -106133.684, -106143.853, -106145.162, -106154.955, -106164.002, -106172.109, -106192.309, -106188.893, -106186.652, 
                -106191.554, -106199.374, -106217.643, -106236.356, -106254.84, -106272.963, -106291.194, -106291.241, -106310.543, -106330.019,
                -106349.443, -106368.746, -106372.637, -106382.314, -106388.194, -106389.15, -106394.461, -106408.229, -106427.218, -106446.182,
                -106448.737, -106456.958, -106458.785, -106463.621, -106472.134, -106481.472, -106482.116, -106500.374, -106518.372, -106527.777, 
                -106537.044 };
            double[] y = new double[] { -24539.877, -24547.579, -24552.01, -24554.77, -24558.55, -24561.725, -24569.278, -24576.503, -24583.4, -24585.277,
                -24584.631, -24584.482, -24582.803, -24575.916, -24564.941, -24569.608, -24580.599, -24587.445, -24602.455, -24605.206, -24612.789,
                -24619.095, -24626.114, -24634.327, -24642.31, -24642.325, -24648.361, -24654.035, -24659.906, -24666.161, -24665.2, -24662.274,
                -24669.068, -24669.414, -24671.35, -24676.447, -24683.78, -24691.242, -24692.267, -24691.818, -24700.02, -24702.448, -24706.115,
                -24710.739, -24711.016, -24720.101, -24729.696, -24732.642, -24737.808 };
            return MakeList(x, y);
        }
        public static List<List<double>> Sample4()
        {
            string[] s = new string[] { "H28-304", "H28-305", "4016", "4017", "4018", "4019", "4020", "4023",
            "4024", "4025", "4026", "4027", "4028", "4020-1", "4023-1", "T5032", "T5033", "T5034", "T5035",
            "T5036", "T5037", "T5038", "T5039", "T5040", "T5041", "T5042", "T5043", "T5044", "T5045", "T5045-2" };
            double[] x = new double[] {-106197.413, -106381.463, -106205.819, -106257.26, -106308.86, -106359.82, -106413.108, -106163.857,
                -106212.014, -106261.623, -106311.807, -106368.907, -106462.105, -106446.832, -106216.939, -106187.628, -106193.946,
                -106206.658, -106286.842, -106359.277, -106374.247, -106454.162, -106467.609, -106486.054, -106514.742, -106450.648,
                -106412.648, -106321.674, -106222.866, -106220.059};
            double[] y = new double[] { -24544.752, -24643.597, -24638.431, -24656.843, -24674.861, -24692.402, -24707.412, -24604.968, 
                -24629.879, -24648.375, -24666.515, -24685.796, -24730.602, -24716.027, -24495.364, -24574.826, -24596.73, -24610.413,
                -24640.731, -24666.238, -24663.329, -24701.776, -24712.054, -24659.432, -24587.671, -24572.34, -24560.875, -24524.93,
                -24477.736, -24489.592 };
            return MakeList(x, y);
        }
        public static List<List<double>> Sample5()
        {
            string[] s = new string[] { "NO.82", "SP4", "NO.83", "NO.84", "NO.85", "NO.86", "NO.87", "NO.88",
            "NO.89", "NO.90", "NO.91", "NO.92", "NO.93", "NO.94", "NO.95", "KAE5-1", "NO.96", "NO.97",
            "NO.98", "NO.99", "KEE5-1", "NO.100", "NO.101", "NO.102", "NO.103", "NO.104", "KE5-1", "NO.105"};
            double[] x = new double[] { -106131.746, -106132.859, -106150.493, -106169.293, -106188.145, -106207.048, -106226.001,
                -106245.002, -106264.051, -106283.146, -106302.234, -106321.262, -106340.227, -106359.128, -106377.962, -106383.188,
                -106396.728, -106415.42, -106434.031, -106452.553, -106470.346, -106470.979, -106489.299, -106507.512, -106525.612,
                -106543.598, -106550.939, -106561.465 };
            double[] y = new double[] {-24616.83, -24617.248, -24623.797, -24630.62, -24637.298, -24643.83, -24650.218, -24656.459,
                -24662.553, -24668.502, -24674.471, -24680.631, -24686.98, -24693.52, -24700.247, -24702.152, -24707.164, -24714.278,
                -24721.6, -24729.145, -24736.652, -24736.923, -24744.944, -24753.209, -24761.716, -24770.463, -24774.12, -24779.449};
            return MakeList(x, y);
        }

        public static List<List<double>> Sample6()
        {
            double[] x = new double[] { 6734, 2233, 5530, 401, 3082, 7608, 7573, 7265, 6898, 1112, 5468, 5989, 4706, 4612, 6347, 6107,
                7611, 7462, 7732, 5900, 4483, 6101, 5199, 1633, 4307, 675, 7555, 7541, 3177, 7352, 7545, 3245, 6426, 4608, 23, 7248,
                7762, 7392, 3484, 6271, 4985, 1916, 7280, 7509, 10, 6807, 5185, 3023 };
            double[] y = new double[] { 1453, 10, 1424, 841, 1644, 4458, 3716, 1268, 1885, 2049, 2606, 2873, 2674, 2035, 2683, 669,
                5184, 3590, 4723, 3561, 3369, 1110, 2182, 2809, 2322, 1006, 4819, 3981, 756, 4506, 2801, 3305, 3173, 1198, 2216,
                3779, 4595, 2244, 2829, 2135, 140, 1569, 4899, 3239, 2676, 2993, 3258, 1942 };
            return MakeList(x, y);
        }

        private static List<List<double>> MakeList(double[] x, double[] y)
        {
            List<List<double>> list = new List<List<double>>();
            for (int i = 0; i < x.Length; i++)
            {
                List<double> point = new List<double> { x[i], y[i] };
                list.Add(point);
            }
            return list;
        }
    }
}
