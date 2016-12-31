using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ImEncryption
{
    class TEST
    {
        private Common comm;
        public TEST()
        {
            this.comm = new Common();
        }
        public double cor(int[] data1, double aver1, int[] data2, double aver2, int num)
        {
            double cov = 0.0;
            for (int i = 0; i < num; i++)
            {
                cov += ((double)data1[i] - aver1) * ((double)data2[i] - aver2);
            }
            return cov / (double)num;
        }
        public double getCorr(int[] data1, int[] data2, int num)
        {
            double aver = this.comm.dataAver(data1, num);
            double aver2 = this.comm.dataAver(data2, num);
            double sqerr = this.comm.meanSqErr(data1, aver, num);
            double sqerr2 = this.comm.meanSqErr(data2, aver2, num);
            double crr = this.cor(data1, aver, data2, aver2, num);
            return crr / (Math.Sqrt(sqerr) * Math.Sqrt(sqerr2));//得出两个点之间的相关性系数
        }
        public double[,] getCorr(int[,] R, int[,] G, int[,] B, int N, int num)//h代表横，V代表竖，h代表斜
        {
            int M = N * (N - 1);
            int[] xh_r = new int[num];
            int[] yh_r = new int[num];
            int[] xv_r = new int[num];
            int[] yv_r = new int[num];
            int[] xd_r = new int[num];
            int[] yd_r = new int[num];
            int[] xh_g = new int[num];
            int[] yh_g = new int[num];
            int[] xv_g = new int[num];
            int[] yv_g = new int[num];
            int[] xd_g = new int[num];
            int[] yd_g = new int[num];
            int[] xh_b = new int[num];
            int[] yh_b = new int[num];
            int[] xv_b = new int[num];
            int[] yv_b = new int[num];
            int[] xd_b = new int[num];
            int[] yd_b = new int[num];
            double[,] corr = new double[3, 3];
            int seed = 100;
            Random rnd = new Random(seed);
            for (int i = 0; i < num; i++)
            {
                int rand = rnd.Next(M);
                int u = rand % (N - 1);
                int v = rand / N;
                xh_r[i] = R[u, v];
                yh_r[i] = R[u + 1, v];
                xv_r[i] = R[u, v];
                yv_r[i] = R[u, v + 1];
                xd_r[i] = R[u, v];
                yd_r[i] = R[u + 1, v + 1];
                xh_g[i] = G[u, v];
                yh_g[i] = G[u + 1, v];
                xv_g[i] = G[u, v];
                yv_g[i] = G[u, v + 1];
                xd_g[i] = G[u, v];
                yd_g[i] = G[u + 1, v + 1];
                xh_b[i] = B[u, v];
                yh_b[i] = B[u + 1, v];
                xv_b[i] = B[u, v];
                yv_b[i] = B[u, v + 1];
                xd_b[i] = B[u, v];
                yd_b[i] = B[u + 1, v + 1];
            }
            corr[0, 0] = this.getCorr(xh_r, yh_r, num);
            corr[1, 0] = this.getCorr(xv_r, yv_r, num);
            corr[2, 0] = this.getCorr(xd_r, yd_r, num);
            corr[0, 1] = this.getCorr(xh_g, yh_g, num);
            corr[1, 1] = this.getCorr(xv_g, yv_g, num);
            corr[2, 1] = this.getCorr(xd_g, yd_g, num);
            corr[0, 2] = this.getCorr(xh_b, yh_b, num);
            corr[1, 2] = this.getCorr(xv_b, yv_b, num);
            corr[2, 2] = this.getCorr(xd_b, yd_b, num);
            return corr;
        }
        public double getEntropy(int[,] P, int N)
        {
            int[] pix = new int[N];
            double H = 0.0;
            for (int i = 0; i < N; i++)
            {
                pix[i] = 0;
            }
            for (int j = 0; j < N; j++)
            {
                for (int k = 0; k < N; k++)
                {
                    int g = P[j, k];
                    pix[g]++;
                }
            }
            for (int l = 0; l < N; l++)
            {
                if (pix[l] > 0)
                {
                    H += (double)pix[l] * Math.Log10((double)pix[l]);
                }
            }
            return Math.Log10((double)(N * N)) / Math.Log10(2.0) - H / ((double)(N * N) * Math.Log10(2.0));
        }
        public int[] getHist(int[,] P, int iw, int ih)//统计各个灰度的像素的个数
        {
            int[] h = new int[256];
            for (int i = 0; i < ih; i++)
            {
                for (int j = 0; j < iw; j++)
                {
                    int grey = P[j, i];
                    h[grey]++;
                }
            }
            return h;
        }
        public float getMSD(int[] v, int L)
        {
            double sum = 0.0;
            for (int i = 0; i < L; i++)
            {
                sum += (double)v[i];
            }
            double aver = sum / (double)L;
            double sqsum = 0.0;
            for (int j = 0; j < L; j++)
            {
                sqsum += ((double)v[j] - aver) * ((double)v[j] - aver);
            }
            return (float)(sqsum / (double)L);
        }
        public double getNPCR(int[,] E, int[,] E1, int N)
        {
            int num = 0;
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    if (E[j, i] != E1[j, i])
                    {
                        num++;
                    }
                }
            }
            return 100.0 * (double)num / (double)(N * N);//乘100是为了算出那个百分数~~~~~
        }
       
        public double getUACI(int[,] E, int[,] E1, int N)
        {
            int psum = 0;
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    int p;
                    if (E[j, i] > E1[j, i])
                    {
                        p = E[j, i] - E1[j, i];
                    }
                    else
                    {
                        p = E1[j, i] - E[j, i];
                    }
                    psum += p;
                }
            }
            return 100.0 * (double)psum / (255.0 * (double)N * (double)N);
        }
        
    }
}
