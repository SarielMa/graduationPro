using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ImEncryption
{
    class Matrix
    {
        //自可逆矩阵求法
        public int[,] keyMatrix(int M, int k, int N)
        {
            int i = M / 2;
            int[,] A = new int[M, M];
            int[,] A2 = new int[i, i];
            int[,] A3 = new int[i, i];
            int[,] A4 = new int[i, i];
            int[,] A5 = new int[i, i];
            Random rnd = new Random(100);
            for (int j = 0; j < i; j++)
            {
                for (int l = 0; l < i; l++)
                {
                    A5[l, j] = rnd.Next(N);
                }
            }
            for (int m = 0; m < i; m++)
            {
                for (int n = 0; n < i; n++)
                {
                    A2[n, m] = N - A5[n, m];
                }
            }
            for (int j2 = 0; j2 < i; j2++)
            {
                for (int i2 = 0; i2 < i; i2++)
                {
                    A3[i2, j2] = k * A5[i2, j2] % N;
                }
            }
            for (int i3 = 0; i3 < i; i3++)
            {
                A3[i3, i3] = k * (N + 1 - A2[i3, i3]) % N;
            }
            for (int j3 = 0; j3 < i; j3++)
            {
                for (int i4 = 0; i4 < i; i4++)
                {
                    int tem = A2[i4, j3];
                    while (tem % k != 0)
                    {
                        tem += N;
                    }
                    A4[i4, j3] = tem / k;
                }
            }
            for (int i5 = 0; i5 < i; i5++)
            {
                int tem = 1 + A2[i5, i5];
                while (tem % k != 0)
                {
                    tem += N;
                }
                A4[i5, i5] = tem / k;
            }
            return new Common().merge(A2, A3, A4, A5, M);
        }
       //矩阵转置
        public int[][,] mtrTrans(int[][,] mtr, int K, int L)
        {
            int[][,] tem = new int[K][,];
            for (int i = 0; i < K; i++)
            {
                tem[i] = new int[L, L];
            }
            for (int j = 0; j < K; j++)
            {
                for (int k = 0; k < L; k++)
                {
                    for (int l = 0; l < L; l++)
                    {
                        tem[j][l, k] = mtr[j][k, l];
                    }
                }
            }
            return tem;
        }
        
    }
}
