using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MazeGen
{
    public partial class Form1 : Form
    { 
        private Graphics canvas;
        private Graphics bufferCanvas;
        private Bitmap backgroundBuffer;
        private Random rGen;
        private Maze maze;
        private double time;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            rowInputTextBox.Text = "10";
            collumnInputTextBox.Text = "10";

            rGen = new Random();

            timer1.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            double startTime= DateTime.Now.Subtract(DateTime.MinValue).TotalSeconds;

            bufferCanvas.FillRectangle(Brushes.Salmon, 0, 0, Width, Height);
            maze.GenerateMaze();
            canvas.DrawImage(backgroundBuffer, 0, 0);

            double endTime = DateTime.Now.Subtract(DateTime.MinValue).TotalSeconds;

            time += endTime - startTime;

            timeLabel.Text = decimal.Round(Convert.ToDecimal(time), 3, MidpointRounding.AwayFromZero).ToString();

            if (maze.Complete)
            {
                timer1.Enabled = false;
            }
        }

        private void newMazeBtn_Click(object sender, EventArgs e)
        {
            Refresh();
      
            try
            {
                int nRows = Convert.ToInt16(rowInputTextBox.Text);
                int nCols = Convert.ToInt16(collumnInputTextBox.Text);
                int cellWidth = (Width / 2) / nCols;
                int cellHeight = (Height / 2) / nRows;
                panelCanvas.Size = new Size((nCols * cellWidth) + 1, (nRows * cellHeight) + 1);
                panelCanvas.Left = (Width / 2) - (panelCanvas.Width / 2);
                panelCanvas.Top = (Height / 3) - (panelCanvas.Height / 3);
                canvas = panelCanvas.CreateGraphics();
                backgroundBuffer = new Bitmap(panelCanvas.Width, panelCanvas.Height);
                bufferCanvas = Graphics.FromImage(backgroundBuffer);
                maze = new Maze(bufferCanvas, rGen, nRows, nCols, cellWidth,cellHeight);
                timer1.Enabled = true;
                time = 0;
            }
            catch
            {
                MessageBox.Show("TextBox must only contain numbers!");
                rowInputTextBox.Text = "10";
                collumnInputTextBox.Text = "10";
            }
        }
    }
}
