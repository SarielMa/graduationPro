using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ImEncryption
{
    class HaarBlockScr
    {
        HaarWT haar;
        Common comm;
        GeneralScrm gscr;
        public HaarBlockScr()
        {
            haar = new HaarWT();
            comm = new Common();
            gscr = new GeneralScrm();

        }
        public int[,] superChaosScr(int[,] P, int M, int pm,double xkey,double ykey)
        {
            double[][] sL = (new ChaosMaps()).superChaos2DSq(xkey, ykey, M);//2维超混沌系统当中两个数是密钥
            int[] xi = comm.sort2index(sL[0], M);//通过排序产生原下标序列
            int[] yi = comm.sort2index(sL[1], M);
            int[,] S = gscr.rcScramble(P, M, xi, yi, pm);
            return S;
        }
        public int[,] SuperChaosED(int[,] P,int N,int ED)
        {
            int[,] E=new int[N,N];
            HaarKey hk = new HaarKey();
            haarLevelDialog haarLev = new haarLevelDialog();
            if (haarLev.ShowDialog() == DialogResult.OK) 
            {
                int Level;
                int Lev;
                if (haarLev.getLev != "")
                {
                    Level = Convert.ToInt32(haarLev.getLev);
                }
                else
                    Level = 1;
                Lev = Level + 1;
                int[,] H1 = haar.liftwavedec2(P,N,Level);
                int[,][,] s = comm.setLevelBk(Lev,N);
                int[,][,] h = comm.divideLevels(H1,Lev,N);
                int M = N;
                if (hk.ShowDialog() == DialogResult.OK)
                {
                    double x;
                    double y;
                    if (hk.getX != "")
                    {
                        x= Convert.ToDouble(hk.getX);
                    }
                    else
                        x = 1;
                    if (hk.getY != "")
                    {
                        y = Convert.ToDouble(hk.getY);
                    }
                    else
                        y = 1;
                    for (int k = 1; k < Lev; k++)
                    {
                        M = M / 2;
                        //ENCRPTION
                        if (ED == 1)
                        {
                            for (int l = 1; l < 4; l++)
                                s[k, l] = superChaosScr(h[k, l], M, 1, x, y);
                            if (k == Level)
                                s[k, 0] = superChaosScr(h[k, 0], M, 1, x, y);
                        }
                        else
                        {
                            for (int l = 1; l < 4; l++)
                            {
                                s[k, l] = superChaosScr(h[k, l], M, -1, x, y);

                            }
                            if (k == Level)
                                s[k, 0] = superChaosScr(h[k, 0], M, -1, x, y);
                        }
                    }
                }
                s = comm.mergeLevels(s,Level,M);
                E = haar.liftwaverec2(s[0,0],N,Level);
            }
            return E;
        }
    
    }
}
