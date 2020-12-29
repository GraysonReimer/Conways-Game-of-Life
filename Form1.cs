using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    
    public partial class Form1 : Form
    {
        public static Cell[,] cells;
        static int size = 8;
        static bool paused = false;
        static bool pressingG = false;
        static bool pressingS = false;
        static bool pressing1 = false;
        static bool pressing2 = false;
        static bool pressing3 = false;
        static bool pressing4 = false;
        static bool pressing5 = false;
        static bool pressing6 = false;
        static bool pressing7 = false;
        static bool pressing8 = false;
        static bool hintsVisible = true;
        List<Label> labels;
        public Form1()
        {
            InitializeComponent();
        }

        public void ReviveCell(int x, int y)
        {
            if (x >= 0 && x < cells.GetLength(0) && y >= 0 && y < cells.GetLength(1))
            {
                if (!cells[x, y].Alive)
                    cells[x, y].Alive = true;
            }
        }

        private void Grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.G)
            {
                pressingG = false;
            }
            if (e.KeyCode == Keys.S)
            {
                pressingS = false;
            }
            if (e.KeyCode == Keys.D1)
            {
                pressing1 = false;
            }
            if (e.KeyCode == Keys.D2)
            {
                pressing2 = false;
            }
            if (e.KeyCode == Keys.D3)
            {
                pressing3 = false;
            }
            if (e.KeyCode == Keys.D4)
            {
                pressing4 = false;
            }
            if (e.KeyCode == Keys.D5)
            {
                pressing5 = false;
            }
            if (e.KeyCode == Keys.D6)
            {
                pressing6 = false;
            }
            if (e.KeyCode == Keys.D7)
            {
                pressing7 = false;
            }
            if (e.KeyCode == Keys.D8)
            {
                pressing8 = false;
            }
            if (e.KeyCode == Keys.H)
            {
                if (hintsVisible)
                {
                    hintsVisible = false;
                    foreach (Label label in labels)
                    {
                        label.Visible = false;
                        label.Refresh();
                    }    
                }
                else
                {
                    hintsVisible = true;
                    foreach (Label label in labels)
                    {
                        label.Visible = true;
                        label.Refresh();
                    }
                }
            }
        }

        void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                if (paused)
                {
                    paused = false;
                    UpdateCells();
                }
                else
                {
                    paused = true;
                }
            }
            if (e.KeyCode == Keys.C)
            {
                Clear();
            }
            if (e.KeyCode == Keys.G)
            {
                pressingG = true;
            }
            if (e.KeyCode == Keys.S)
            {
                pressingS = true;
            }
            if (e.KeyCode == Keys.D1)
            {
                pressing1 = true;
            }
            if (e.KeyCode == Keys.D2)
            {
                pressing2 = true;
            }
            if (e.KeyCode == Keys.D3)
            {
                pressing3 = true;
            }
            if (e.KeyCode == Keys.D4)
            {
                pressing4 = true;
            }
            if (e.KeyCode == Keys.D5)
            {
                pressing5 = true;
            }
            if (e.KeyCode == Keys.D6)
            {
                pressing6 = true;
            }
            if (e.KeyCode == Keys.D7)
            {
                pressing7 = true;
            }
            if (e.KeyCode == Keys.D8)
            {
                pressing8 = true;
            }
        }

        void Spawn(object sender, MouseEventArgs e)
        {
            int x = e.X / size;
            int y = e.Y / size;
            if (pressingG)
            {
                spawnGlider(x, y);
                if (paused)
                    Invalidate();
            }
            if (pressingS)
            {
                spawnSpaceship(x, y);
                if (paused)
                    Invalidate();
            }
            if (pressing1)
            {
                spawnBlock(x, y);
                if (paused)
                    Invalidate();
            }
            if (pressing2)
            {
                spawnBeehive(x, y);
                if (paused)
                    Invalidate();
            }
            if (pressing3)
            {
                spawnLoaf(x, y);
                if (paused)
                    Invalidate();
            }
            if (pressing4)
            {
                spawnBoat(x, y);
                if (paused)
                    Invalidate();
            }
            if (pressing5)
            {
                spawnTub(x, y);
                if (paused)
                    Invalidate();
            }
            if (pressing6)
            {
                spawnCanoe(x, y);
                if (paused)
                    Invalidate();
            }
            if (pressing7)
            {
                spawnBlinker(x, y);
                if (paused)
                    Invalidate();
            }
            if (pressing8)
            {
                spawnBeacon(x, y);
                if (paused)
                    Invalidate();
            }
        }

        void DrawCell(object sender, MouseEventArgs e)
        {
            int x = e.X / size;
            int y = e.Y / size;

            if (e.Button == MouseButtons.Left)
            {


                ReviveCell(x, y);

                if (paused)
                    Invalidate();

                
            }


        }

        void spawnBlock(int x, int y)
        {
            ReviveCell(x, y);
            ReviveCell(x + 1, y);
            ReviveCell(x, y + 1);
            ReviveCell(x + 1, y + 1);
        }

        void spawnBeehive(int x, int y)
        {
            ReviveCell(x, y);
            ReviveCell(x + 1, y);
            ReviveCell(x - 1, y + 1);
            ReviveCell(x + 2, y + 1);
            ReviveCell(x, y + 2);
            ReviveCell(x + 1, y + 2);
        }

        void spawnLoaf(int x, int y)
        {
            ReviveCell(x, y);
            ReviveCell(x + 1, y);
            ReviveCell(x - 1, y + 1);
            ReviveCell(x + 2, y + 1);
            ReviveCell(x + 2, y + 2);
            ReviveCell(x, y + 2);
            ReviveCell(x + 1, y + 3);
        }

        void spawnBoat(int x, int y)
        {
            ReviveCell(x, y);
            ReviveCell(x + 1, y);
            ReviveCell(x, y + 1);
            ReviveCell(x + 2, y + 1);
            ReviveCell(x + 1, y + 2);
        }

        void spawnTub(int x, int y)
        {
            ReviveCell(x, y);
            ReviveCell(x + 1, y + 1);
            ReviveCell(x - 1, y + 1);
            ReviveCell(x, y + 2);
            
        }

        void spawnCanoe(int x, int y)
        {
            ReviveCell(x, y);
            ReviveCell(x, y + 1);
            ReviveCell(x + 1, y + 1);
            ReviveCell(x + 2, y);
            ReviveCell(x + 3, y - 1);
            ReviveCell(x + 4, y - 2);
            ReviveCell(x + 4, y - 3);
            ReviveCell(x + 3, y - 3);
        }

        void spawnBlinker(int x, int y)
        {
            ReviveCell(x, y);
            ReviveCell(x, y + 1);
            ReviveCell(x, y + 2);
        }

        void spawnBeacon(int x, int y)
        {
            ReviveCell(x, y);
            ReviveCell(x + 1, y);
            ReviveCell(x, y + 1);
            ReviveCell(x + 1, y + 1);
            ReviveCell(x + 2, y + 2);
            ReviveCell(x + 3, y + 2);
            ReviveCell(x + 2, y + 3);
            ReviveCell(x + 3, y + 3);
        }

        void spawnSpaceship(int x, int y)
        {
            ReviveCell(x, y);
            ReviveCell(x + 1, y);
            ReviveCell(x + 4, y);
            ReviveCell(x + 5, y);
            ReviveCell(x + 2, y + 1);
            ReviveCell(x + 3, y + 1);
            ReviveCell(x + 2, y + 2);
            ReviveCell(x + 3, y + 2);
            ReviveCell(x + 1, y + 3);
            ReviveCell(x + 4, y + 3);
            ReviveCell(x - 1, y + 3);
            ReviveCell(x - 1, y + 4);
            ReviveCell(x + 6, y + 3);
            ReviveCell(x + 6, y + 4);
            ReviveCell(x - 1, y + 6);
            ReviveCell(x + 6, y + 6);
            ReviveCell(x, y + 7);
            ReviveCell(x + 5, y + 7);
            ReviveCell(x + 1, y + 7);
            ReviveCell(x + 4, y + 7);
            ReviveCell(x + 4, y + 8);
            ReviveCell(x + 1, y + 8);
            ReviveCell(x + 2, y + 8);
            ReviveCell(x + 3, y + 8);
            ReviveCell(x + 3, y + 10);
            ReviveCell(x + 2, y + 10);
            ReviveCell(x + 3, y + 11);
            ReviveCell(x + 2, y + 11);
        }
        void spawnGlider(int x, int y)
        {
            //+X = right +Y = down
            ReviveCell(x, y);
            ReviveCell(x + 1, y + 1);
            ReviveCell(x + 1, y + 2);
            ReviveCell(x, y + 2);
            ReviveCell(x - 1, y + 2);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            for (int i = 0; i < cells.GetLength(0); i++)
                {
                    for (int j = 0; j < cells.GetLength(1); j++)
                    {
                        if (cells[i, j].Alive)
                        {
                            e.Graphics.FillRectangle(Brushes.Green, new Rectangle(i * size, j * size, size, size));
                        }
                        else
                        {
                            e.Graphics.FillRectangle(Brushes.Black, new Rectangle(i * size, j * size, size, size));
                        }
                    }
                }
                List<Cell> cellsToRevive = new List<Cell>();
                List<Cell> cellsToKill = new List<Cell>();
            if (!paused)
            {
                for (int i = 0; i < cells.GetLength(0); i++)
                {
                    for (int j = 0; j < cells.GetLength(1); j++)
                    {
                        if (cells[i, j].Alive)
                        {
                            if (cells[i, j].neighboringCells() < 2 || cells[i, j].neighboringCells() > 3)
                                cellsToKill.Add(cells[i, j]);
                        }

                        if (!cells[i, j].Alive)
                        {
                            if (cells[i, j].neighboringCells() == 3)
                                cellsToRevive.Add(cells[i, j]);
                        }
                    }
                }

            }
                foreach (Cell cell in cellsToKill)
                    cell.Alive = false;
                foreach (Cell cell in cellsToRevive)
                    cell.Alive = true;
                e.Dispose();
                UpdateCells();
            
        }

        void Clear()
        {
            foreach (Cell cell in cells)
                cell.Alive = false;
            if (paused)
                Invalidate();
        }

        void UpdateCells()
        {
            if (!paused)
            {
                Thread.Sleep(1);
            
                Invalidate();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            labels = this.Controls.OfType<Label>().ToList();
            this.Icon = Properties.Resources.Icon;
            this.KeyPreview = true;
            this.MouseMove += new MouseEventHandler(DrawCell);
            this.MouseUp += new MouseEventHandler(Spawn);
            this.MouseDown += new MouseEventHandler(DrawCell);
            this.KeyDown += new KeyEventHandler(Form1_KeyDown);
            this.KeyUp += new KeyEventHandler(Form1_KeyUp);
            this.SetStyle(
  ControlStyles.AllPaintingInWmPaint |
  ControlStyles.UserPaint |
  ControlStyles.DoubleBuffer, true);
            System.Random r = new System.Random();
            this.Width = 1920;
            this.Height = 1080;
            WindowState = FormWindowState.Maximized;
            this.BackColor = Color.White;
            cells = new Cell[this.Width/size, this.Height/size];
            
            for (int i = 0; i < cells.GetLength(0); i++)
            {
                for (int j = 0; j < cells.GetLength(1); j++)
                {
                    cells[i, j] = new Cell(r.Next(0, 3) == 0, i, j);
                }
            }
            foreach (Label label in labels)
            {
                label.BackColor = System.Drawing.Color.Black;
                label.Refresh();
            }
        }
    }

    public class Cell : Form1
    {
        public bool Alive { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public Cell(bool Alive, int X, int Y)
        {
            this.Alive = Alive;
            this.X = X;
            this.Y = Y;
        }
        public int neighboringCells()
        {
            int num = 0;
            getCell(1, 1);
            getCell(0, 1);
            getCell(1, 0);
            getCell(-1, 1);
            getCell(1, -1);
            getCell(0, -1);
            getCell(-1, 0);
            getCell(-1, -1);
            void getCell(int o1, int o2)
            {
                if (X + o1 >= 0 && X + o1 < cells.GetLength(0) && Y + o2 >= 0 && Y + o2 < cells.GetLength(1))
                {
                    if (Form1.cells[X + o1, Y + o2].Alive)
                        num++;
                }
            }
            return num;
        }
        public void drawCell(object sender, PaintEventArgs e)
        {
            OnPaint(e);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // Cell
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(990, 494);
            this.Name = "Cell";
            this.Load += new System.EventHandler(this.Cell_Load);
            this.ResumeLayout(false);

        }

        private void Cell_Load(object sender, EventArgs e)
        {

        }
    }
}
