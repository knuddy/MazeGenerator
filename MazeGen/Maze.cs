using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MazeGen
{
    public class Maze
    {
        private Graphics canvas;
        private Random rGen;
        private int nRows;
        private int nCols;
        private int cellWidth;
        private int cellHeight;
        private Dictionary<string, Cell> cells;
        private Stack<Cell> stack;
        private Cell currentCell;
        public bool Complete;

        //Maze Constructor
        public Maze(Graphics canvas, Random rGen, int nRows, int nCols, int cellWidth, int cellHeight)
        {
            this.canvas = canvas;
            this.rGen = rGen;
            this.nRows = nRows;
            this.nCols = nCols;
            this.cellWidth = cellWidth;
            this.cellHeight = cellHeight;

        }//End Constructor


        //Creates a new Dictionary
        //The index is the id of an instance of the Cell class
        //The value is an instance of the Cell class
        private Dictionary<string, Cell> createCells()
        {
            Dictionary<string, Cell> cellList = new Dictionary<string, Cell>();

            for (int r = 0; r < nRows; r++)
            {
                for (int c = 0; c < nCols; c++)
                {
                    Cell cell = new Cell ( 
                                            canvas,
                                            rGen,
                                            new Point(c * cellWidth, r * cellHeight),
                                            new Size(cellWidth, cellHeight),
                                            r,
                                            c,
                                            nRows - 1,
                                            nCols - 1, ref cellList 
                                         );
                }
            }

            return cellList;

        }//End createCells

        public void GenerateMaze()
        {
            //Sets up a new maze
            if (stack == null)
            {
                //Reseting Dictionary and Stack for a fresh maze
                cells = createCells();
                stack = new Stack<Cell>();

                //Obtaining the index of the start cell at random
                int startRow = rGen.Next(nRows - 1);
                int startCol = 0;
                string startCellID = "R" + startRow + "C" + startCol;

                //Adding first cell to the stack and setting Visited to true 
                currentCell = cells[startCellID];
                currentCell.Walls.WestWall = false;
                currentCell.Visited = true;
                //currentCell.brush = new SolidBrush(Color.OrangeRed);
                stack.Push(currentCell);

                //Maze completed set to false
                Complete = false;
            }

            DrawMaze();

            if(currentCell != null)
            {
                currentCell = currentCell.Carve();

                if(currentCell!=null)
                {
                    cells[currentCell.ID].Visited = true;
                    stack.Push(currentCell);
                }
                else if(currentCell==null && stack.Count!=0)
                {
                    currentCell = stack.Pop();
                }

                canvas.FillRectangle(Brushes.DarkMagenta, currentCell.Bounds);
            }

            if (stack.Count == 0)
            {
                Complete = true;
                int endRow = rGen.Next(nRows - 1);
                int endCol = nCols-1;
                string endCellID = "R" + endRow + "C" + endCol;

                cells[endCellID].Walls.EastWall = false;
                //currentCell.brush = new SolidBrush(Color.DarkRed);
                DrawMaze();
            }

        }//End GenerateMaze

        public void DrawMaze()
        {
            for (int r = 0; r < nRows; r++)
            {
                for (int c = 0; c < nCols; c++)
                {
                    cells["R" + r + "C" + c].Draw();
                }
            }
        }//End DrawMaze

    }//End class Maze

}//End namespace

