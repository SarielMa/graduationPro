using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace ImEncryption
{
    class Common
    {
        

        ////NXN矩阵拷贝函数
        public int[,] matrixCopy(int[,] A, int N)
        {
            int[,] B = new int[N, N];
            for (int j = 0; j < N; j++)
                for (int i = 0; i < N; i++)
                    B[i, j] = A[i, j];
            return B;
        }

       
        ////矩阵转置
        public double[,] matrixTrans(double[,] P, int L, int M)
        {
            double[,] Pt = new double[M, L];
            for (int j = 0; j < M; j++)
                for (int i = 0; i < L; i++)
                    Pt[j, i] = P[i, j];
            return Pt;
        }

       

        //图像矩阵操作(合并,分块,取块)--------------------------------------
        //将MXM的块合并成图像矩阵cP函数
        public int[,] combinBlocks(int[][,] ctem, int M, int N)
        {
            int[,] cP = new int[N, N];           //加密图像矩阵
            for (int v = 0; v < M; v++)
            {
                for (int u = 0; u < M; u++)
                {
                    for (int j = 0; j < M; j++)
                        for (int i = 0; i < M; i++)
                            cP[u * M + i, v * M + j] = ctem[v * M + u][i, j];
                }
            }
            return cP;
        }

        //将256个矩阵ctem[256][,]的256个分量分别赋于bim,将图像块bim[,]合并为加密图
        public int[,] combBlocks(int[][,] ctem, int M, int N)
        {
            int[,] oP = new int[N, N];           //图像矩阵
            for (int j = 0; j < M; j++)
            {
                for (int i = 0; i < M; i++)
                {
                    //将256个矩阵ctem[256][,]的256个分量分别赋于bim,将图像块bim[,]合并为加密图
                    for (int v = 0; v < M; v++)
                        for (int u = 0; u < M; u++)
                            oP[i * M + u, j * M + v] = ctem[v * M + u][i, j];
                }
            }
            return oP;
        }

        //将图像矩阵oP分成MXM的块函数
        public int[][,] dividBlocks(int[,] oP, int M, int N)
        {
            int[][,] tem = new int[N][,];        //算法中的temporary matrix
            for (int i = 0; i < N; i++)
                tem[i] = new int[M, M];

            for (int j = 0; j < M; j++)
            {
                for (int i = 0; i < M; i++)
                {
                    //取 MXM图像块bim[,],and 将bim的256个分量分别赋于256个矩阵tem[256][,]
                    for (int v = 0; v < M; v++)
                        for (int u = 0; u < M; u++)
                            tem[v * M + u][i, j] = oP[i * M + u, j * M + v];
                }
            }
            return tem;
        }

        //将图像矩阵cP分成MXM的块函数
        public int[][,] divBlocks(int[,] cP, int M, int N)
        {
            int[][,] tem = new int[N][,];        //算法中的temporary matrix
            for (int i = 0; i < N; i++)
                tem[i] = new int[M, M];

            for (int v = 0; v < M; v++)
            {
                for (int u = 0; u < M; u++)
                {
                    //将bim[,]放置为加密图的第[v * M + u]块,取第[v * M + u]个矩阵的256个分量分别赋于bim
                    for (int j = 0; j < M; j++)
                        for (int i = 0; i < M; i++)
                            tem[v * M + u][i, j] = cP[u * M + i, v * M + j];
                }
            }
            return tem;
        }

       

        //将H[L,no]的L=0,1,...,Lev-1层分成4块,用no=0,1,2,3表示左上,右上,左下,右下块        
        public int[,][,] divideLevels(int[,] H, int Lev, int N)
        {
            int M = N;

            //分配内存
            //H的分层和分块;h[k,l][i,j]:第k层;l=0,LL;l=1,LH;l=2,HL;l=3,HH 
            int[,][,] h = setLevelBk(Lev, N);

            //用H初始化h[0,0]
            for (int j = 0; j < N; j++)
                for (int i = 0; i < N; i++)
                    h[0, 0][i, j] = H[i, j];

            M = N;
            for (int k = 1; k < Lev; k++)
            {
                M = M / 2;
                for (int j = 0; j < M; j++)
                {
                    for (int i = 0; i < M; i++)
                    {
                        h[k, 0][i, j] = h[k - 1, 0][i, j];          //LL   
                        h[k, 1][i, j] = h[k - 1, 0][i, j + M];      //LH
                        h[k, 2][i, j] = h[k - 1, 0][i + M, j];      //HL
                        h[k, 3][i, j] = h[k - 1, 0][i + M, j + M];  //HH
                    }
                }
            }
            return h;
        }

       
        //获取R[,],G[,],B[,], rgb=0:R; rgb=1:G;rgb=2:B
        //win--窗口1-pictureBox1;2-pictureBox2
        public int[,] getPixel(int rgb, PictureBox box, int N)
        {
            Bitmap bm = new Bitmap(box.Image);
            int[,] P = new int[N, N];
            if (rgb == 0)
                for (int j = 0; j < N; j++)
                    for (int i = 0; i < N; i++)
                        P[i, j] = bm.GetPixel(i, j).R;
            else if (rgb == 1)
                for (int j = 0; j < N; j++)
                    for (int i = 0; i < N; i++)
                        P[i, j] = bm.GetPixel(i, j).G;
            else if (rgb == 2)
                for (int j = 0; j < N; j++)
                    for (int i = 0; i < N; i++)
                        P[i, j] = bm.GetPixel(i, j).B;
            return P;
        }

        //获取RGB三色矩阵[0][,]为红色; [1][,]为绿色; [2][,]为蓝色
        public int[][,] getPixel(PictureBox box, int N)
        {
            Bitmap bm = new Bitmap(box.Image);
            int[][,] P = new int[3][,];
            for (int i = 0; i < 3; i++)
                P[i] = new int[N, N];

            for (int j = 0; j < N; j++)
                for (int i = 0; i < N; i++)
                {
                    P[0][i, j] = bm.GetPixel(i, j).R;
                    P[1][i, j] = bm.GetPixel(i, j).G;
                    P[2][i, j] = bm.GetPixel(i, j).B;
                }
            return P;
        }

        

        ////将P0,P1,P2,P3合并成一个矩阵
        public int[,] merge(int[,] P0, int[,] P1, int[,] P2, int[,] P3, int n)
        {
            int[,] P = new int[n, n];
            int hN = n / 2;
            for (int j = 0; j < hN; j++)
            {
                for (int i = 0; i < hN; i++)
                {
                    P[i, j] = P0[i, j];
                    P[i + hN, j] = P1[i, j];
                    P[i, j + hN] = P2[i, j];
                    P[i + hN, j + hN] = P3[i, j];
                }
            }
            return P;
        }

        //合并各层各块,see divideLevels();
        public int[,][,] mergeLevels(int[,][,] s, int Lev, int N)
        {
            int M = N;
            for (int k = Lev; k > 0; k--)
            {
                for (int j = 0; j < M; j++)
                {
                    for (int i = 0; i < M; i++)
                    {
                        s[k - 1, 0][i, j] = s[k, 0][i, j];        //第k层LL块   
                        s[k - 1, 0][i, j + M] = s[k, 1][i, j];    //第k层LH块
                        s[k - 1, 0][i + M, j] = s[k, 2][i, j];    //第k层HL块
                        s[k - 1, 0][i + M, j + M] = s[k, 3][i, j];//第k层HH块
                    }
                }
                M = 2 * M;
            }
            return s;
        }

        //为每层分4块设置内存函数
        public int[,][,] setLevelBk(int Lev, int N)
        {
            int[,][,] s = new int[Lev, 4][,];//与h[k,l]相应的置乱块             

            int M = N;
            for (int k = 0; k < Lev; k++)
            {
                for (int l = 0; l < 4; l++)
                    s[k, l] = new int[M, M];
                M = M / 2;
            }
            return s;
        }

      

        //比较图1与图2像素差异函数
        public void imgDiff(string str1, string str2, int[,] img1, int[,] img2, int n)
        {
            int q = 0;                           //像素差异数量            
            for (int j = 0; j < n; j++)
                for (int i = 0; i < n; i++)
                    if (img1[i, j] != img2[i, j]) q++;
            MessageBox.Show(str1 + "与" + str2 + "的像素差异数 m = " + q, "信息提示");
        }

        //比较图1与图2像素差异函数
        public void imgDiff(string str1, string str2, int[,] img1, int[] img2, int n)
        {
            int q = 0;                           //像素差异数量            
            for (int j = 0; j < n; j++)
                for (int i = 0; i < n; i++)
                    if (img1[i, j] != img2[j * n + i]) q++;
            MessageBox.Show(str1 + "与" + str2 + "的像素差异数 m = " + q, "信息提示");
        }

        //比较图1与图2的RGB像素差异函数
        public void imgDiff(string str1, string str2, int[][,] img1, int[][,] img2, int n)
        {
            int[] q = new int[3];
            for (int k = 0; k < 3; k++)
                for (int j = 0; j < n; j++)
                    for (int i = 0; i < n; i++)
                        if (img1[k][i, j] != img2[k][i, j]) q[k]++;
            MessageBox.Show(str1 + "与" + str2 + "的像素差异数:\n" +
                            "红色 m0 = " + q[0] + "; 绿色 m1 = " + q[1] + "; 蓝色 m2 = " + q[2], "信息提示");
        }

        //显示数据和图像------------------------------------------------------------------------------
        //画直方图函数
        public void drawHist(string str, int[] h, PictureBox box, Label lab)
        {
            //画直方图
            Graphics g = box.CreateGraphics();
            Pen pen1 = new Pen(Color.Blue);
            g.Clear(Color.White);
            g.FillRectangle(new SolidBrush(Color.White), 0, 0, 255, 255);
            pen1.Color = Color.Green;

            //找出最大的数,进行标准化.
            int maxh = h[0];
            for (int i = 1; i < 256; i++)
                if (maxh < h[i])
                    maxh = h[i];

            for (int i = 0; i < 256; i++)
                h[i] = h[i] * 250 / maxh;

            for (int i = 0; i < 256; i++)
                g.DrawLine(pen1, i, 255, i, 255 - h[i]);

            g.DrawString("峰值：" + maxh, new Font("", 8), new SolidBrush(Color.Blue), 0, 0);
            lab.Location = new Point(387, 60);
            lab.Text = str;
        }

       

        //显示相关性函数
        public void showCorr(PictureBox box, double[,] crr)
        {
            Graphics g = box.CreateGraphics();
            Pen pen1 = new Pen(Color.Blue);
            Font font = new Font("", 8, FontStyle.Bold);
            g.FillRectangle(new SolidBrush(Color.White), 0, 0, 255, 255);
            g.DrawString("相关性系数", font, new SolidBrush(Color.Blue), 90, 30);
            g.DrawString("水平", font, new SolidBrush(Color.Blue), 40, 60);
            g.DrawString("垂直", font, new SolidBrush(Color.Blue), 110, 60);
            g.DrawString("对角", font, new SolidBrush(Color.Blue), 180, 60);
            float fcrr;
            for (int j = 0; j < 3; j++)
            {
                if (j == 0) g.DrawString("R:", font, new SolidBrush(Color.Blue), 20, j * 20 + 80);
                else if (j == 1) g.DrawString("G:", font, new SolidBrush(Color.Blue), 20, j * 20 + 80);
                else if (j == 2) g.DrawString("B:", font, new SolidBrush(Color.Blue), 20, j * 20 + 80);

                for (int i = 0; i < 3; i++)
                {
                    fcrr = (float)(crr[i, j] - (crr[i, j] % 0.000001));　　　//删除小数点6位以后的数字
                    g.DrawString("" + fcrr, font, new SolidBrush(Color.Blue), i * 70 + 40, j * 20 + 80);
                }
            }
        }

        //相关性图示函数
        public void showCorrImage(PictureBox box1, PictureBox box2, Label lab1, Label lab2, int N)
        {
            Bitmap bm = new Bitmap(box1.Image);
            Bitmap bo = new Bitmap(N, N);
            int[,] R = new int[N, N];
            int x, y;

            for (int j = 0; j < N; j++)
                for (int i = 0; i < N; i++)
                    R[i, j] = bm.GetPixel(i, j).R;

            Color c = new Color();
            for (int j = 0; j < N; j++)
            {
                for (int i = 0; i < N - 1; i++)
                {
                    x = R[i, j];
                    y = R[i + 1, j];
                    c = Color.FromArgb(0, 225, 0);//暂定为绿色
                    bo.SetPixel(x, 255 - y, c);
                }
            }
            box2.Refresh();
            Graphics g = box2.CreateGraphics();
            g.Clear(Color.White);
            g.DrawImage(bo, 0, 0);
            lab2.Location = new Point(367, 60);
            lab2.Size = new Size(220, 15);
            lab2.Text = "水平相邻点(x,y)与(x+1,y)相关性图示";

            //画刻度线
            Pen pen = new Pen(Color.Red);
            g.DrawLine(pen, 0, 255, 255, 255);  //x轴
            g.DrawLine(pen, 128, 255, 128, 252);
            g.DrawLine(pen, 255, 255, 255, 252);
            g.DrawLine(pen, 0, 0, 0, 255);      //y轴
            g.DrawLine(pen, 0, 127, 3, 127);
            g.DrawLine(pen, 0, 0, 3, 0);
            g.DrawString("X", new Font("", 8), new SolidBrush(Color.Red), 220, 240);
            g.DrawString("0", new Font("", 8), new SolidBrush(Color.Red), 2, 240);
            g.DrawString("128", new Font("", 8), new SolidBrush(Color.Red), 115, 240);
            g.DrawString("255", new Font("", 8), new SolidBrush(Color.Red), 235, 240);
            g.DrawString("Y", new Font("", 8), new SolidBrush(Color.Red), 2, 22);
            g.DrawString("128", new Font("", 8), new SolidBrush(Color.Red), 2, 122);
            g.DrawString("255", new Font("", 8), new SolidBrush(Color.Red), 2, 2);
        }
        public void showCorrImage2(PictureBox box1, PictureBox box2, Label lab1, Label lab2, int N)
        {
            Bitmap bm = new Bitmap(box1.Image);
            Bitmap bo = new Bitmap(N, N);
            int[,] R = new int[N, N];
            int x, y;

            for (int j = 0; j < N; j++)
                for (int i = 0; i < N; i++)
                    R[i, j] = bm.GetPixel(i, j).R;

            Color c = new Color();
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N - 1; j++)
                {
                    x = R[i, j];
                    y = R[i ,j+1];
                    c = Color.FromArgb(0, 0, 255);//暂定为蓝色
                    bo.SetPixel(x, 255 - y, c);
                }
            }
            box2.Refresh();
            Graphics g = box2.CreateGraphics();
            g.Clear(Color.White);
            g.DrawImage(bo, 0, 0);
            lab2.Location = new Point(367, 60);
            lab2.Size = new Size(220, 15);
            lab2.Text = "垂直相邻点(x,y)与(x,y+1)相关性图示";

            //画刻度线
            Pen pen = new Pen(Color.Red);
            g.DrawLine(pen, 0, 255, 255, 255);  //x轴
            g.DrawLine(pen, 128, 255, 128, 252);
            g.DrawLine(pen, 255, 255, 255, 252);
            g.DrawLine(pen, 0, 0, 0, 255);      //y轴
            g.DrawLine(pen, 0, 127, 3, 127);
            g.DrawLine(pen, 0, 0, 3, 0);
            g.DrawString("X", new Font("", 8), new SolidBrush(Color.Red), 220, 240);
            g.DrawString("0", new Font("", 8), new SolidBrush(Color.Red), 2, 240);
            g.DrawString("128", new Font("", 8), new SolidBrush(Color.Red), 115, 240);
            g.DrawString("255", new Font("", 8), new SolidBrush(Color.Red), 235, 240);
            g.DrawString("Y", new Font("", 8), new SolidBrush(Color.Red), 2, 22);
            g.DrawString("128", new Font("", 8), new SolidBrush(Color.Red), 2, 122);
            g.DrawString("255", new Font("", 8), new SolidBrush(Color.Red), 2, 2);
        }
        public void showCorrImage3(PictureBox box1, PictureBox box2, Label lab1, Label lab2, int N)
        {
            Bitmap bm = new Bitmap(box1.Image);
            Bitmap bo = new Bitmap(N, N);
            int[,] R = new int[N, N];
            int x, y;

            for (int j = 0; j < N; j++)
                for (int i = 0; i < N; i++)
                    R[i, j] = bm.GetPixel(i, j).R;

            Color c = new Color();
            for (int j = 0; j < N - 1; j++)
            {
                for (int i = 0; i < N - 1; i++)
                {
                    x = R[i, j];
                    y = R[i + 1, j+1];
                    c = Color.FromArgb(0, 127, 127);//暂定为x色
                    bo.SetPixel(x, 255 - y, c);
                }
            }
            box2.Refresh();
            Graphics g = box2.CreateGraphics();
            g.Clear(Color.White);
            g.DrawImage(bo, 0, 0);
            lab2.Location = new Point(367, 60);
            lab2.Size = new Size(220, 15);
            lab2.Text = "对角相邻点(x,y)与(x+1,y+1)相关性图示";

            //画刻度线
            Pen pen = new Pen(Color.Red);
            g.DrawLine(pen, 0, 255, 255, 255);  //x轴
            g.DrawLine(pen, 128, 255, 128, 252);
            g.DrawLine(pen, 255, 255, 255, 252);
            g.DrawLine(pen, 0, 0, 0, 255);      //y轴
            g.DrawLine(pen, 0, 127, 3, 127);
            g.DrawLine(pen, 0, 0, 3, 0);
            g.DrawString("X", new Font("", 8), new SolidBrush(Color.Red), 220, 240);
            g.DrawString("0", new Font("", 8), new SolidBrush(Color.Red), 2, 240);
            g.DrawString("128", new Font("", 8), new SolidBrush(Color.Red), 115, 240);
            g.DrawString("255", new Font("", 8), new SolidBrush(Color.Red), 235, 240);
            g.DrawString("Y", new Font("", 8), new SolidBrush(Color.Red), 2, 22);
            g.DrawString("128", new Font("", 8), new SolidBrush(Color.Red), 2, 122);
            g.DrawString("255", new Font("", 8), new SolidBrush(Color.Red), 2, 2);
        }
       
        //显示信息熵
        public void showEntropy(int[,] P, PictureBox box2, Label lab2, int N)
        {
            double entropy = (new TEST()).getEntropy(P, N);
            Graphics g = box2.CreateGraphics();
            g.Clear(Color.White);
            Font font = new Font("", 12, FontStyle.Bold);
            g.DrawString("图像熵:\n H = " + (float)entropy, font,
                         new SolidBrush(Color.Blue), 10, 100);
            lab2.Location = new Point(387, 60);
            lab2.Text = "信息熵";
        }

       

        //显示RGB,no=1:在pictureBox1中显示; no=2:在pictureBox2中显示
        //str--在label.Text中显示的标题; x, y--label.Location = new Point(x, y)
        public void showImage(string str, int[,] R, int[,] G, int[,] B, int x, int y, PictureBox box, Label label, int W)
        {
            Bitmap bo = new Bitmap(W, W);
            int[,] r = new int[W, W],
                   g = new int[W, W],
                   b = new int[W, W];
            //对不在[0,255]内的像素进行调整
            for (int j = 0; j < W; j++)
            {
                for (int i = 0; i < W; i++)
                {
                    if (R[i, j] < 0) r[i, j] = 0;
                    else if (R[i, j] > 255) r[i, j] = 255;
                    else r[i, j] = R[i, j];
                    if (G[i, j] < 0) g[i, j] = 0;
                    else if (G[i, j] > 255) g[i, j] = 255;
                    else g[i, j] = G[i, j];
                    if (B[i, j] < 0) b[i, j] = 0;
                    else if (B[i, j] > 255) b[i, j] = 255;
                    else b[i, j] = B[i, j];
                }
            }
            for (int j = 0; j < W; j++)
                for (int i = 0; i < W; i++)
                    bo.SetPixel(i, j, Color.FromArgb(r[i, j], g[i, j], b[i, j]));

            box.Refresh();
            box.Image = bo;
            label.Location = new Point(x, y);
            label.Text = str;
        }

        //显示RGB,no=1:在pictureBox1中显示; no=2:在pictureBox2中显示
        //str--在label.Text中显示的标题; x, y--label.Location = new Point(x, y)
        //comm.showImage("原始异或密钥", key, key, key, 100, 280, pic1, lab1, N);
        public void showImage(string str, int[] R, int[] G, int[] B, int x, int y, PictureBox box, Label lab, int N)
        {
            int[,] R1 = new int[N, N];
            int[,] G1 = new int[N, N];
            int[,] B1 = new int[N, N];
            for (int j = 0; j < N; j++)
                for (int i = 0; i < N; i++)
                {
                    R1[i, j] = R[j * N + i]; G1[i, j] = G[j * N + i]; B1[i, j] = B[j * N + i];
                }

            showImage(str, R1, G1, B1, x, y, box, lab, N);
        }

        //数据排序,平均值--------------------------------------------------------------------
        //对W[]选择法升序重排, 输出原下标序列
        //L--序列W的长度
        public int[] sort2index(double[] W, int L)
        {
            int[] ind = new int[L];                           //原下标序列
            int i, j, k = 0, ti;
            double t;

            for (i = 0; i < L; i++)                           //初始化下标序列
                ind[i] = i;

            for (i = 0; i < L; i++)
            {
                //外循环开始
                k = i;
                for (j = i + 1; j < L; j++)
                    if (W[j] < W[k])
                        k = j;                                //内循环只用k记录最小值的下标

                if (k > i)
                {
                    t = W[i];
                    W[i] = W[k]; 
                    W[k] = t;          //在外循环实施交换，可减少交换次数
                    ti = ind[i];
                    ind[i] = ind[k]; 
                    ind[k] = ti;//交换下标                    
                }
            }
            return ind;                                       //输出原下标序列
        }

        //计算数组data平均值
        //[]data--输入数组; num--数组data长度
        public double dataAver(int[] data, int num)
        {
            double sum = 0.0;
            for (int i = 0; i < num; i++)
                sum += data[i];
            return (sum / num);
        }

        ////计算方差D(x)
        ////[]data--输入数组; aver--数组data均值;num--数组data长度
        public double meanSqErr(int[] data, double aver, int num)
        {
            double mse = 0.0;
            for (int i = 0; i < num; i++)
                mse += (data[i] - aver) * (data[i] - aver);
            return (mse / num);
        }

       
    
    }
}
