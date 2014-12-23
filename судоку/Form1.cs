using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace судоку
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string rez = "",part="",part2="";
        int numbstrok,sqrt;
        bool cv = false;
       

        private void button1_Click(object sender, EventArgs e)
        {
            numbstrok = 0;
            sqrt = 0;
        
            rez = "";
            part = "";
            part2="";
            if (!int.TryParse(textBox1.Text, out numbstrok))
            {
                MessageBox.Show("введено не число");
                return;
            }
    if (cv)
                sqrt = (int) Math.Sqrt(numbstrok);
            int counter = 0;
            for (int i = 1; i < numbstrok + 1; i++)
            {
                for (int j = 1; j < numbstrok + 1; j++)
                {
                    for (int z = 1; z < numbstrok + 1; z++)
                    {
                        for (int v = z + 1; v < numbstrok + 1; v++)
                        {

                            rez += "-" + i + "" + j + "" + z + " " + "-" + i + "" + j + "" + v + " 0\r";//запись f(x,y,z)&f(x,y,v)-> false
                           
                            counter++;
                        }
                        part +=""+ i + "" + j + "" + z +" ";//запись возможных чисел
               
                    }
                    part += "0\r";//окончание записи 
                    counter++;
                }
            }
          


            for (int x1 = 1; x1 < numbstrok + 1; x1++)
                for (int y1 = 1; y1 < numbstrok + 1; y1++)
                    for (int x2 = x1; x2 < numbstrok + 1; x2++)
                        for (int y2 = y1; y2 < numbstrok + 1; y2++)
                            for (int v = 1; v < numbstrok+1; v++)
                            {
                                if ((x1 == x2&&y1!=y2)||(x1!=x2)&&(y1==y2))
                                {
                                    rez += "-" + x1 + "" + y1 + "" + v + " -" + x2 + "" + y2 + "" + v + " 0\r"; // запись f(x,y,z)&f(x,i,z)->false +запись f(j,y,z)&f(x,y,z)->false
 
                                    counter++;
                                    
                                }

                                
  
                            }

            if (cv)
            {

                for (int i = 0; i < sqrt; i++)
                    for (int j = 0; j < sqrt; j++)

                        for (int x1 = 1; x1 < sqrt+1; x1++)
                            for (int y1 = 1; y1 < sqrt + 1; y1++)
                                for (int x2 = 1; x2 < sqrt + 1; x2++)
                                    for (int y2 = 1; y2 < sqrt + 1; y2++)
                                        for (int v = 1; v < numbstrok + 1; v++)
                                            if((x1!=x2||y1!=y2)&&!((x2>x1&&y2==y1)||(y2>y1&&x2==x1)))
                                            {
                                                part2 += "-" + (i*sqrt + x1) + "" + (j* sqrt + y1 ) + "" + v + " -" + (i* sqrt + x2 ) + "" + (j * sqrt + y2) + "" + v + " 0\r";//квадраты 
                                                counter++;
                                            }
            }
                    rez += part2+ part;

                                MessageBox.Show("Файл создан там "+counter+" строк");
            
                TextWriter tw = new StreamWriter("new.txt",false);
                tw.WriteLine(rez);
                tw.Close();
         
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            int num =0;

            if (int.TryParse(textBox1.Text, out num) & num == Math.Pow(Math.Round(Math.Sqrt(num)), 2))
            {
                label1.Text = "обнаружен квадрат " + Math.Sqrt(num);
                cv = true;
            }
            else
            { label1.Text = "квадраты не обнаружены";
            cv = false;
            }

        }



    }
}