using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GuessIT
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string word = "";
        List<Label> labels = new List<Label>();
        int ammount = 0;
        enum BodyParts 
        {
            Head,
            Left_Eye,
            Right_Eye,
            Mouth,
            Left_Arm,
            Right_Arm,
            Body,
            Left_Leg,
            Right_Leg

        }

        void DrawHangPost()
        {
            Graphics g = panel1.CreateGraphics();
            Pen p = new Pen(Color.Brown,10);
            g.DrawLine(p, new Point(130,218),  new Point(130,5));
            g.DrawLine(p, new Point(135, 5), new Point(65, 5));
            g.DrawLine(p, new Point(60, 0), new Point(60, 50));
           /* DrawBodyPart(BodyParts.Head);
            DrawBodyPart(BodyParts.Left_Eye);
            DrawBodyPart(BodyParts.Right_Eye);
            DrawBodyPart(BodyParts.Mouth);
            DrawBodyPart(BodyParts.Body);
            DrawBodyPart(BodyParts.Left_Arm);
            DrawBodyPart(BodyParts.Right_Arm);
            DrawBodyPart(BodyParts.Left_Leg);
            DrawBodyPart(BodyParts.Right_Leg);
            /*GetRandomWord();
            MessageBox.Show(GetRandomWord());*/
            Makelabels();
            
        }

        void DrawBodyPart(BodyParts bp)
        {
            Graphics g = panel1.CreateGraphics();
            Pen p = new Pen(Color.Blue);
            if(bp==BodyParts.Head)
            {
                g.DrawEllipse(p,40,50,40,40);
            }
            else if (bp == BodyParts.Left_Eye)
            {
                SolidBrush s = new SolidBrush(Color.Black);
                g.FillEllipse(s, 50, 60, 5, 5);
            }
            else if (bp == BodyParts.Right_Eye)
            {
                SolidBrush s = new SolidBrush(Color.Black);
                g.FillEllipse(s, 63, 60, 5, 5);
            }
            else if (bp == BodyParts.Mouth)
            {
                g.DrawArc(p,50,60,20,20,45,90);
            }
            else if (bp == BodyParts.Body)
            {
                g.DrawLine(p,new Point(60,90),new Point(60,170));
            }
            else if (bp == BodyParts.Left_Arm)
            {
                g.DrawLine(p, new Point(60, 100), new Point(30, 85));
            }
            else if (bp == BodyParts.Right_Arm)
            {
                g.DrawLine(p, new Point(60, 100), new Point(90, 85));
            }
            else if (bp == BodyParts.Left_Leg)
            {
                g.DrawLine(p, new Point(60, 170), new Point(30, 190));
            }
            else if (bp == BodyParts.Right_Leg)
            {
                g.DrawLine(p, new Point(60, 170), new Point(90, 190));
            }

        }

        void Makelabels()
        {
            word = GetRandomWord();
            char[] chars = word.ToCharArray();
            int between = 330 / chars.Length - 1;
            for (int i = 0; i < chars.Length; i++)
            {
                labels.Add(new Label());
                labels[i].Location = new Point((i * between) + 10, 80);
                labels[i].Text= "_";
                labels[i].Parent = groupBox2;
                labels[i].BringToFront();
                labels[i].CreateControl();
             }
            label1.Text = "Word Length " + (chars.Length).ToString();
         }

        string GetRandomWord()
        {
            string[] words = new string[] { "diplomacy", "flexible", "imitation", "gigantic","evangelist", "unique", "debut", "transition", "sense", "activity", "eject", "microsoft", "cabinet", "candor", "cat", "beset", "evolution", "transfer", "amity", "annual", "awaken", "azure", "believe", "birth" };
            Random ran = new Random();
            return words[ran.Next(0,words.Length-1)];
        }

        private void fo(object sender, EventArgs e)
        {
            DrawHangPost();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            char letter = textBox1.Text.ToLower().ToCharArray()[0];
            textBox1.Text = "";
            if (!char.IsLetter(letter))
            {
                MessageBox.Show("You can only submit a letter","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            if (word.Contains(letter))
            {
                char[] letters = word.ToCharArray();
                for (int i = 0; i < letters.Length; i++)
                {
                    if (letters[i] == letter)
                        labels[i].Text = letter.ToString();
                    
                }
                foreach (Label l in labels)
                    if (l.Text == "_") return;
                MessageBox.Show("You Win!!!","Congratulation");
                ResetGame();
            }
            else
            {
                MessageBox.Show("Letter is not correct","Sorry");
                label2.Text += " " + letter.ToString() + ",";
                label3.Text ="Chance: "+(8 - ammount).ToString();
                DrawBodyPart((BodyParts)ammount);
                ammount++;
                if (ammount == 9)
                {
                    MessageBox.Show("Game Over!!");
                }
            }
        }

        void ResetGame()
        {
            Graphics g = panel1.CreateGraphics();
            g.Clear(panel1.BackColor);
            GetRandomWord();
            Makelabels();
            DrawHangPost();
            label2.Text = "Missed: ";
            textBox1.Text = "";
            ammount = 0;
            label3.Text = "Chance: ";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == word)
            {
                MessageBox.Show("You Win!!!", "Congratulation");
                textBox2.Text = "";
                ResetGame();
            }
            else
            {
                MessageBox.Show("The Word is not Correct!");
                textBox2.Text = "";
                DrawBodyPart((BodyParts)ammount);
                ammount++;
                if (ammount == 9)
                {
                    MessageBox.Show("Wrong Guess");
                    ResetGame();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Javedul Ferdous\nEast West University\nBangladesh\nContact:jaf.rakib@live.com","About me");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ResetGame();
        }

    }
}
