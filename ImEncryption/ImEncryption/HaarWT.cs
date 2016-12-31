using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ImEncryption
{
    class HaarWT
    {
        public int[,] liftwavedec2(int[,] image, int m, int lev)
        {
            int[,] img = new int[m, m];
            for (int i = 0; i < m; i++)//矩阵复制
            {
                for (int j = 0; j < m; j++)
                {
                    img[i, j] = image[i, j];
                }
            }
            int M = m;
            for (int k = 0; k < lev; k++)
            {
                int[,] omg = new int[M, M];
                for (int l = 0; l < M; l++)
                {
                    for (int n = 0; n < M; n++)
                    {
                        omg[l, n] = img[l, n];
                    }
                }
                int[,] hmg = this.lwavedec2(omg, M);
                for (int i2 = 0; i2 < M; i2++)
                {
                    for (int j2 = 0; j2 < M; j2++)
                    {
                        img[i2, j2] = hmg[i2, j2];
                    }
                }
                M /= 2;
            }
            return img;
        }
        public int[,] liftwaverec2(int[,] image, int m, int lev)
        {
            int[,] img = new int[m, m];
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    img[i, j] = image[i, j];
                }
            }
            int M = (int)((double)m / Math.Pow(2.0, (double)lev));//多层分解后的大小
            for (int k = 0; k < lev; k++)
            {
                M *= 2;
                int[,] omg = new int[M, M];
                for (int l = 0; l < M; l++)
                {
                    for (int n = 0; n < M; n++)
                    {
                        omg[l, n] = img[l, n];
                    }
                }
                int[,] hmg = this.lwaverec2(omg, M);
                for (int i2 = 0; i2 < M; i2++)
                {
                    for (int j2 = 0; j2 < M; j2++)
                    {
                        img[i2, j2] = hmg[i2, j2];
                    }
                }
            }
            return img;
        }
        public int[,] lwavedec2(int[,] image, int N)//一次小波提升分解
        {
            int T = N / 2;
            int[,] f = new int[N, T];
            int[,] f2 = new int[N, T];
            int[,] g = new int[T, N];
            int[,] g2 = new int[T, N];
            int[,] hcol = new int[N, T];
            int[,] lcol = new int[N, T];
            int[,] hrow = new int[T, N];
            int[,] lrow = new int[T, N];
            int[,] hwdec = new int[N, N];
            for (int i = 0; i < T; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    f[j, i] = image[j, 2 * i];
                    f2[j, i] = image[j, 2 * i + 1];
                }
            }
            for (int k = 0; k < T; k++)
            {
                for (int l = 0; l < N; l++)
                {
                    hcol[l, k] = f[l, k] - f2[l, k];
                }
            }
            for (int m = 0; m < T; m++)
            {
                for (int n = 0; n < N; n++)
                {
                    lcol[n, m] = f2[n, m] + (int)Math.Floor(0.5 * (double)hcol[n, m] + 0.5);
                }
            }
            for (int j2 = 0; j2 < T; j2++)
            {
                for (int i2 = 0; i2 < N; i2++)
                {
                    hwdec[i2, j2] = lcol[i2, j2];
                    hwdec[i2, T + j2] = hcol[i2, j2];
                }
            }
            for (int j3 = 0; j3 < N; j3++)
            {
                for (int i3 = 0; i3 < T; i3++)
                {
                    g[i3, j3] = hwdec[2 * i3, j3];
                    g2[i3, j3] = hwdec[2 * i3 + 1, j3];
                }
            }
            for (int j4 = 0; j4 < N; j4++)
            {
                for (int i4 = 0; i4 < T; i4++)
                {
                    hrow[i4, j4] = g[i4, j4] - g2[i4, j4];
                }
            }
            for (int j5 = 0; j5 < N; j5++)
            {
                for (int i5 = 0; i5 < T; i5++)
                {
                    lrow[i5, j5] = g2[i5, j5] + (int)Math.Floor(0.5 * (double)hrow[i5, j5] + 0.5);
                }
            }
            for (int j6 = 0; j6 < N; j6++)
            {
                for (int i6 = 0; i6 < T; i6++)
                {
                    hwdec[i6, j6] = lrow[i6, j6];
                    hwdec[T + i6, j6] = hrow[i6, j6];
                }
            }
            return hwdec;
        }
        public int[,] lwaverec2(int[,] image, int N)
        {
            int T = N / 2;
            int[,] f = new int[N, T];
            int[,] f2 = new int[N, T];
            int[,] hcol = new int[N, T];
            int[,] lcol = new int[N, T];
            int[,] hrow = new int[T, N];
            int[,] lrow = new int[T, N];
            int[,] hwrec = new int[N, N];
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < T; j++)
                {
                    hrow[j, i] = image[T + j, i];
                    lrow[j, i] = image[j, i];
                }
            }
            for (int k = 0; k < N; k++)
            {
                for (int l = 0; l < T; l++)
                {
                    lrow[l, k] -= (int)Math.Floor(0.5 * (double)hrow[l, k] + 0.5);
                }
            }
            for (int m = 0; m < N; m++)
            {
                for (int n = 0; n < T; n++)
                {
                    hrow[n, m] += lrow[n, m];
                }
            }
            for (int j2 = 0; j2 < N; j2++)
            {
                for (int i2 = 0; i2 < T; i2++)
                {
                    hwrec[2 * i2, j2] = hrow[i2, j2];
                    hwrec[2 * i2 + 1, j2] = lrow[i2, j2];
                }
            }
            for (int j3 = 0; j3 < T; j3++)
            {
                for (int i3 = 0; i3 < N; i3++)
                {
                    f2[i3, j3] = hwrec[i3, j3];
                    f[i3, j3] = hwrec[i3, T + j3];
                }
            }
            for (int j4 = 0; j4 < T; j4++)
            {
                for (int i4 = 0; i4 < N; i4++)
                {
                    lcol[i4, j4] = f2[i4, j4] - (int)Math.Floor(0.5 * (double)f[i4, j4] + 0.5);
                }
            }
            for (int j5 = 0; j5 < T; j5++)
            {
                for (int i5 = 0; i5 < N; i5++)
                {
                    hcol[i5, j5] = f[i5, j5] + lcol[i5, j5];
                }
            }
            for (int j6 = 0; j6 < T; j6++)
            {
                for (int i6 = 0; i6 < N; i6++)
                {
                    hwrec[i6, 2 * j6 + 1] = lcol[i6, j6];
                    hwrec[i6, 2 * j6] = hcol[i6, j6];
                }
            }
            return hwrec;
        }
    }
}
