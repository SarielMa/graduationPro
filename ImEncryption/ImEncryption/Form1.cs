using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace ImEncryption
{
    public partial class Form1 : Form
    {
        static Bitmap curBitmap = null;           //第1幅图像
        static Bitmap resBitmap = null;           //第2幅图像   
        static bool openFlag = false;             //打开图像,加/解密标志
        static bool openFlag2 = false;            //允许打开窗口2图像标志
        string fileName;
        int iw, ih, N;
        Common comm;
        int[,] P = null;
        private void recover()
        {
            openFlag = false;
            openFlag2 = false;
        }
        public Form1()
        {
            InitializeComponent();
            label1.Text = "picture 1";
            label2.Text = "picture 2";
            comm = new Common();
            this.Text = "自可逆矩阵Hill与Haar域置乱混合加密系统";
            N = 256;
        }

        private void 打开ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!openFlag && !openFlag2)
            {
                OpenFileDialog open = new OpenFileDialog();
                open.Filter = "图像文件(*.bmp;*.jpg;*.png)|*.bmp;*jpg;*.png";
                if (open.ShowDialog() == DialogResult.OK)
                {
                    fileName = open.FileName;
                    try
                    {
                        curBitmap = (Bitmap)Image.FromFile(fileName);
                    }
                    catch (Exception exp) { MessageBox.Show(exp.Message); }

                    iw = curBitmap.Width;
                    ih = curBitmap.Height;

                    pictureBox1.Refresh();
                    pictureBox1.Image = curBitmap;
                   // label1.Location = new Point(110, 280);
                    label1.Text = "原图 1";
                    openFlag = true;             //图1已打开                    
                }
            }
            else                                 //允许打开图2
            {
                OpenFileDialog open = new OpenFileDialog();
                open.Filter = "图像文件(*.bmp;*.jpg;*.gif;*.png;*.tif;*.wmf)|" +
                                       "*.bmp;*.jpg;*.gif;*.png;*.tif;*.wmf";

                if (open.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        resBitmap = (Bitmap)Image.FromFile(open.FileName);
                    }
                    catch (Exception exp) { MessageBox.Show(exp.Message); }
                    pictureBox2.Image = resBitmap;
                    //label2.Location = new Point(380, 280);
                    label2.Text = "原图 2";
                    openFlag2 = true;
                }
            }
        }

        private void 加密ToolStripMenuItem_Click(object sender, EventArgs e)//两个加密
        {
            if (curBitmap != null)
            {
                if (iw == N && ih == N)
                {
                   // this.Text = "自可逆矩阵Hill与Haar域置乱混合加密系统";
                    P = comm.getPixel(0, pictureBox1, N);           //从窗口1读入图像 
                    int[,] E = (new HillEncryption()).HillEnc(P, N);//加密
                   // comm.showImage("加密图", E, E, E, 110, 280, pictureBox1, label1, N);
                   //E就是加密后的图像矩阵
                    int[,] E2 = (new HaarBlockScr()).SuperChaosED(E, N, 1);//1是加密，-1是解密
                    comm.showImage("加密图", E2, E2, E2, 87, 60, pictureBox1, label1, N);
                }
                else
                    MessageBox.Show("仅仅适用于256X256图像!", "信息提示");
            }
            else
                MessageBox.Show("请打开一幅图像!", "信息提示");
        }

        private void 解密ToolStripMenuItem_Click(object sender, EventArgs e)//两个解密
        {
            if (curBitmap != null)
            {
                int[,] E = comm.getPixel(0, pictureBox1, N);     //从窗口1读入图像 
                int[,] oP = (new HaarBlockScr()).SuperChaosED(E, N, -1);
                int[,] Po = (new HillEncryption()).HillDec(oP, N);//解密
                comm.showImage("解密图", Po, Po, Po, 387, 60, pictureBox2, label2, N);
                comm.imgDiff("原图", "解密图", P, Po, 256);      //比较原图P与重构图dP像素差异
                recover();
            }
        }

        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string str = fileName.Substring(0, fileName.Length - 4);
            pictureBox1.Image.Save(str + "_.bmp");
            MessageBox.Show("已保存为BMP文件:" + str + "_.bmp");
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void 直方图ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (curBitmap != null)
            {
                int[,] P = comm.getPixel(0, pictureBox1, N);
                TEST test = new TEST();
                //直方图
                int[] hist = test.getHist(P, iw, ih);//取直方图数值
                comm.drawHist("左图的直方图", hist, pictureBox2, label2);

                //计算直方图方差
                float msd = test.getMSD(hist, iw);
                Graphics g = pictureBox2.CreateGraphics();
                Font font = new Font("", 12, FontStyle.Bold);//缺省字体、12号、Bold字型
                g.DrawString("方差: \n S = " + msd, font,
                             new SolidBrush(Color.Blue), 10, 200);
                recover();
            }
        }

        private void 相关性系数ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (curBitmap != null)
            {
                TEST test = new TEST();
                int[,] R = comm.getPixel(0, pictureBox1, N);
                int[,] G = comm.getPixel(1, pictureBox1, N);
                int[,] B = comm.getPixel(2, pictureBox1, N);

                double[,] corr = test.getCorr(R, G, B, N, 3000);//计算相关性
                label2.Text = "相关性的计算";
                comm.showCorr(pictureBox2, corr);               //显示相关性
                recover();
            }
        }

        private void 相关性图示ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (curBitmap != null)
            {
                comm.showCorrImage(pictureBox1, pictureBox2, label1, label2, N);
                recover();
            }
        }
       

        private void 信息熵ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (curBitmap != null)
            {
                int [,] Ph = comm.getPixel(0, pictureBox1, N);
                comm.showEntropy(Ph, pictureBox2, label2, 256);
                recover();
            }
        }

        private void 文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 像素改变率NPCRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (curBitmap != null)
            {
                P = comm.getPixel(0, pictureBox1, N);
                MessageBox.Show("本测试结果由两次加密所生成，为保证结果正确，请之后输入两次相同的分解层数，谢谢！");
                TEST test = new TEST();
                    
                    int[][,] C = encForDiff(P, N);

                   double npcr = test.getNPCR(C[0], C[1], N);
                    MessageBox.Show(  "Hill矩阵与Haar域置乱综合加密系统: NPCR = " + npcr + "%\n");
                    recover();
                
            }
            else
                MessageBox.Show("请打开一幅256X256图像!");
        }

        private void 一致平均改变强度UACIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (curBitmap != null)
            {
                P = comm.getPixel(0, pictureBox1, N);
                MessageBox.Show("本测试结果由两次加密所生成，为保证结果正确，请之后输入两次相同的分解层数，谢谢！");
                
                    TEST test = new TEST();
                  
                    int[][,] C = encForDiff(P, N);
                    double uaci = test.getUACI(C[0], C[1], N);
                    MessageBox.Show("Hill矩阵与Haar域置乱综合加密系统: UACI = " + uaci + "%\n");
                    recover();
                
            }
            else
                MessageBox.Show("请打开一幅256X256图像!");
        }
        private int[][,] encForDiff(int[,] P, int N)
        {
            int[][,] C = new int[2][,];

            C[0] = new int[N, N];
            C[1] = new int[N, N];
            int[,] Q = comm.matrixCopy(P, N);    //将P拷贝给Q
            Q[0, 0] = Q[0, 0] - 5;               //修改Q的一点的灰度值

            
            HillEncryption hill = new HillEncryption();
            HaarBlockScr haar=new HaarBlockScr();
                int[,] E3 = hill.HillEnc(P, N);
                C[0] = haar.SuperChaosED(E3, N, 1);//加密
                int[,] E4 = hill.HillEnc(Q, N);       //加密                
                C[1] = haar.SuperChaosED(E4, N, 1);//加密

            return C;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void 垂直相关性图示ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (curBitmap != null)
            {
                comm.showCorrImage2(pictureBox1, pictureBox2, label1, label2, N);
                recover();
            }
        }

        private void 对角相关性图示ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (curBitmap != null)
            {
                comm.showCorrImage3(pictureBox1, pictureBox2, label1, label2, N);
                recover();
            }
        }
       

        
    }
}
