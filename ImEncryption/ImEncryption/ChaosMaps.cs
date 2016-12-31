using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ImEncryption
{
    class ChaosMaps
    {
        public double[][] superChaos2DSq(double xkey, double ykey, int L)
        {
            double[][] al = new double[][]
			{
				new double[L],
				new double[L]
			};
            double y = ykey;
            for (int i = 0; i < L; i++)
            {
                double x = 1.55 * y - 1.3 * y * y;//2维超混沌系统公式
                y = 0.1 * y - 1.1 * x;
                al[0][i] = x;
                al[1][i] = y;
            }
            return al;
        }
    }
}
