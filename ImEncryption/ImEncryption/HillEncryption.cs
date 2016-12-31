using System;
using System.Collections.Generic;
using System.Text;


namespace ImEncryption
{
    class HillEncryption
    {
        Common comm;
        Matrix mtrx;
        public HillEncryption()
        {
            comm = new Common();
            mtrx = new Matrix();
        }
        //hill encryption
        private int[][,] hillCipher(int[][,] tem, int[,] A, int M, int N)
        {
            int[][,] ctem=new int[N][,];
            for (int i = 0; i < N; i++)
            {
                ctem[i]=new int[M,M];
            }
            for (int l = 0; l < N; l++)
            {
                for (int j = 0; j < M; j++)
                {
                    for (int i = 0; i < M; i++)
                    {
                        ctem[l][i, j] = 0;
                        for (int p = 0; p < M; p++)
                        {
                            ctem[l][i,j] += (A[p, i] * tem[l][j, p]) % N;
                        }
                        ctem[l][i,j] = ctem[l][i, j] % N;
                    }
                }
            }
            return ctem;
        }
        //decryption
        public int[,] HillDec(int[,] P, int N)
        {
            int M = 16;
            int k = 127;
            int[,] bim=new int[M,M];
            int[,] A = mtrx.keyMatrix(M,k,N);
            int[][,] tem = comm.divBlocks(P,M,N);
            int[][,] ctem = hillCipher(tem,A,M,N);
            //转置矩阵
            tem = mtrx.mtrTrans(ctem,N,M);
            ctem = hillCipher(tem, A, M, N);
            int[,] cP = comm.combBlocks(ctem,M,N);
            return cP;
        }
        //encrption
        public int[,] HillEnc(int[,] oP,int N)
        {
            int M = 16;
            int k = 127;
            int[,] cP=new int[N,N];
            //生成自可逆
            int[,] A = mtrx.keyMatrix(M,k,N);
            int[][,] tem = comm.dividBlocks(oP,M,N);
            int[][,] ctem = hillCipher(tem,A,M,N);
            tem = mtrx.mtrTrans(ctem,N,M);
            ctem = hillCipher(tem,A,M,N);
            return comm.combinBlocks(ctem,M,N);
        }
    
    }
    
}
