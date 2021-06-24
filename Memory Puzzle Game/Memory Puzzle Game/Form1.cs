using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Memory_Puzzle_Game
{
    public partial class Form1 : Form
    {
        int[] buttonmap = { 0, 9, 6, 11, 4, 1, 13, 7,
                            5, 2, 12, 3, 14, 8, 10, 15};

        int[] contentMap =new int[16];

        int[] flag = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        Button[] buttons = new Button[16];
        
        Image Question;
        int move = 100;
        
        public Form1()
        {
            InitializeComponent();
            buttonInit();
            this.label2.Text = "";

           
            //this.button1.Image = (Image)(new Bitmap(Question, new Size(80, 80)));
            ImageSetup();
            contentSetup();
        }


        public void Action(int clickedButton,int mappedButton)
        {
            

            if(move !=0)
            {
                if (flag[clickedButton] != 1 && flag[clickedButton] != 2 && flag[mappedButton] == 1)
                {
                    Matched(clickedButton, mappedButton);
                }

                else if (flag[clickedButton] != 2 && flag[clickedButton] != 1)
                {
                    Swap(clickedButton);
                }
            }
            else
            {
                this.label2.Text = "";
                this.label2.ForeColor = Color.Red;
                this.label2.Text = "You Loose ! Try again";
            }
        }

        public void Matched(int clickedButton, int mappedButton)
        {
           
            this.buttons[clickedButton].Image = null;
            this.buttons[mappedButton].Image = null;
            this.buttons[clickedButton].Text = contentMap[clickedButton].ToString();
            this.buttons[mappedButton].Text= contentMap[mappedButton].ToString();

            this.buttons[clickedButton].ForeColor = Color.Green;
            this.buttons[mappedButton].ForeColor = Color.Green;

            flag[clickedButton] = 2;
            flag[mappedButton] = 2;
            //move++;
            label1.Text = move.ToString();
            if(WinCheck())
            {
                this.label2.Text = "You Win ! Try Again";
            }
        }

        public void Swap(int clickedButton)
        {
            this.buttons[clickedButton].ForeColor = Color.Black;
            this.buttons[clickedButton].Image = null;
            buttons[clickedButton].Text = contentMap[clickedButton].ToString();
            flag[clickedButton] = 1;
            move=move-5;
            label1.Text = move.ToString();
            for (int i=0;i<16;i++)
            {
                if(i != clickedButton && flag[i]!=2)
                {
                     buttons[i].Text = "";
                    this.buttons[i].Image = (Image)(new Bitmap(Question, new Size(80, 80)));
                    flag[i] = 0;
                }
            }
        }

        public void buttonInit()
        {
            buttons[0] = button1;
            buttons[1] = button2;
            buttons[2] = button3;
            buttons[3] = button4;
            buttons[4] = button5;
            buttons[5] = button6;
            buttons[6] = button7;
            buttons[7] = button8;
            buttons[8] = button9;
            buttons[9] = button10;
            buttons[10] = button11;
            buttons[11] = button12;
            buttons[12] = button13;
            buttons[13] = button14;
            buttons[14] = button15;
            buttons[15] = button16;

        }
        public bool WinCheck()
        {
            //bool a = true;
            for(int i=0;i<16;i++)
            {
                if(flag[i] !=2)
                {
                    return false;
                }
            }
            return true;
        }

       public void ImageSetup()
        {
            Question = Properties.Resources.QuestionMark;
            for(int i=0;i<16;i++)
            {
                this.buttons[i].Image = (Image)(new Bitmap(Question, new Size(80, 80)));
            }
        }

        //int[] buttonmap = { 0, 9, 6, 11, 4, 1, 13, 7,
                           // 5, 2, 12, 3, 14, 8, 10, 15};

        
           
        public void contentSetup()
        {
            contentMap[0] = 0;
            contentMap[5] = 0;

            contentMap[2] = 1;
            contentMap[9] = 1;

            contentMap[13] = 2;
            contentMap[10] = 2;

            contentMap[3] = 3;
            contentMap[11] = 3;

            contentMap[4] = 7;
            contentMap[14] = 7;

            contentMap[8] = 4;
            contentMap[1] = 4;

            contentMap[6] = 5;
            contentMap[12] = 5;

            contentMap[7] = 6;
            contentMap[15] = 6;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Action(0, 5);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Action(1, 8);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Action(2, 9);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Action(3, 11);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Action(4, 14);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Action(5, 0);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Action(6, 12);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Action(7, 15);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Action(8, 1);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Action(9, 2);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Action(10, 13);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Action(11, 3);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Action(12, 6);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Action(13, 10);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            Action(14, 4);
        }

        private void button16_Click(object sender, EventArgs e)
        {
            Action(15, 7);
        }

        private void button17_Click(object sender, EventArgs e)
        {
            move = 100;
            label1.Text = move.ToString();
            this.label2.Text = "";
            for(int i=0;i<16;i++)
            {
                flag[i] = 0;
                this.buttons[i].Text = "";
                this.buttons[i].Image = (Image)(new Bitmap(Question, new Size(80, 80)));

            }
        }
    }
}
