using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameWF
{
    public partial class Form1 : Form
    {

        int points = 0;
        int maxPoint = 25;
        int attemps = 3;
        PictureBox[] boxes;
        bool clicked = false;

        public Form1()
        {
            InitializeComponent();
            boxes = new PictureBox[5] {pictureBox1, pictureBox2, pictureBox3, pictureBox4, pictureBox5};
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label5.Text = points.ToString();
            label3.Text = attemps.ToString();
            label6.Text = maxPoint.ToString();
            label7.Hide();
            label8.Hide();
            ShowNextBox(boxes);
            timer1.Interval = 3000;
            timer1.Enabled = true;
        }
        
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ClickOnBox(points, maxPoint, pictureBox1);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            ClickOnBox(points, maxPoint, pictureBox2);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            ClickOnBox(points, maxPoint, pictureBox3);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            ClickOnBox(points, maxPoint, pictureBox4);
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            ClickOnBox(points, maxPoint, pictureBox5);
        }

        private void ClickOnBox(int points, int maxPoint, PictureBox box)
        {
            clicked = true;
            box.Hide();
            if(points == maxPoint)
            {
                label7.Show();
                HideAll(boxes);
                timer1.Enabled = false;
            }
            else if(attemps <= 0)
            {
                label8.Show();
                HideAll(boxes);
                
            }
            points++;
            UpdateScores();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (clicked)
            {
                points++;
            }
            else
            {
                attemps--;
                if (attemps == 0)
                {
                    timer1.Enabled = false;
                    HideAll(boxes);
                }
            }
            clicked = false;

            Random rand = new Random();
            ShowNextBox(boxes);
            boxes[rand.Next(5)].Show();
            if(timer1.Interval > 900) timer1.Interval -= 250;
            UpdateScores();
        }

        private void ShowNextBox(PictureBox[] boxes)
        {
            for(int i = 0; i < boxes.Length; i++)
            {
                boxes[i].Hide();
            }
            Random r = new Random();
            boxes[r.Next(5)].Show();
        }

        private void HideAll(PictureBox[] boxes)
        {
            for (int i = 0; i < boxes.Length; i++)
            {
                boxes[i].Hide();
            }
        }

        private void UpdateScores()
        {
            label5.Text = points.ToString();
            label3.Text = attemps.ToString();
            label6.Text = maxPoint.ToString();
            Invalidate();
        }
    }
}
