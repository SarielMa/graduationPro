using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ImEncryption
{
    class GeneralScrm
    {
        public int[,] rcScramble(int[,] pix, int L, int[] xind, int[] yind, int pm)
        {
            int[,] rpix = new int[L, L];
            for (int i = 0; i < L; i++)
            {
                int v = yind[i];
                for (int j = 0; j < L; j++)
                {
                    int u = xind[j];
                    if (pm == 1)
                    {
                        rpix[u, v] = pix[j, i];
                    }
                    else
                    {
                        if (pm == -1)
                        {
                            rpix[j, i] = pix[u, v];
                        }
                    }
                }
            }
            return rpix;
        }
    }
}
