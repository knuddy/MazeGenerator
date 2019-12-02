using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MazeGen
{

    //Holds the state of each wall of the cell. 
    public struct Walls
    {
        public bool NorthWall;
        public bool SouthWall;
        public bool EastWall;
        public bool WestWall;
    }

    //Holds the Id of the cells neighbours in each direction
    public struct Neighbors
    {
        public string NorthID;
        public string SouthID;
        public string EastID;
        public string WestID;
    }

    public class Cell
    {
        //Fields that are only accessable inside the class
        private Graphics canvas;
        private Random rGen;
        private Dictionary<string, Cell> cellList;

        //Field that accessable outside the class
        public int Row;
        public int Col;
        public Walls Walls;
        public Neighbors Neighbors;
        public Rectangle Bounds;
        public Pen pen;
        public Brush brush;
        public string ID;
        public bool Visited;


        //Cell Constructor
        public Cell(Graphics canvas, Random rGen, Point location, Size size, int row, int col, int nRows, int nCols, ref Dictionary<string, Cell> cellList)
        {
            this.canvas = canvas;
            this.rGen = rGen;

            this.Row = row;
            this.Col = col;

            Walls = new Walls();
            Walls.NorthWall = true;
            Walls.SouthWall = true;
            Walls.EastWall = true;
            Walls.WestWall = true;

            Bounds = new Rectangle(location, size);

            pen = new Pen(Color.Black);
            brush = new SolidBrush(Color.MediumSeaGreen);

            this.ID = "R" + Row + "C" + Col;

            Neighbors = determineNeighbors(nRows, nCols);

            this.cellList = cellList;
            cellList.Add(this.ID, this);

            Visited = false;
        }//End Constructor


        //Draws each wall of the cell to the canvas
        //If a wall has been broken it will not be drawn
        public void Draw()
        {
            if(Visited)
            {
                canvas.FillRectangle(brush, Bounds);
            }

            if (Walls.NorthWall)
                canvas.DrawLine(pen, new Point(Bounds.Left, Bounds.Top), new Point(Bounds.Right, Bounds.Top));

            if (Walls.SouthWall)
                canvas.DrawLine(pen, new Point(Bounds.Left, Bounds.Bottom), new Point(Bounds.Right, Bounds.Bottom));

            if (Walls.EastWall)
                canvas.DrawLine(pen, new Point(Bounds.Right, Bounds.Top), new Point(Bounds.Right, Bounds.Bottom));

            if (Walls.WestWall)
                canvas.DrawLine(pen, new Point(Bounds.Left, Bounds.Top), new Point(Bounds.Left, Bounds.Bottom));

        }//End Draw


        //Randomly selects a neighbor of the Cell
        //If the cell has no neighbors a null pointer is returned
        public Cell GetNeighbor()
        {
            List<Cell> legalNeighbors = new List<Cell>();

            if (!(Neighbors.NorthID == "none") && !cellList[Neighbors.NorthID].Visited)
                legalNeighbors.Add(cellList[Neighbors.NorthID]);

            if (!(Neighbors.SouthID == "none") && !cellList[Neighbors.SouthID].Visited)
                legalNeighbors.Add(cellList[Neighbors.SouthID]);

            if (!(Neighbors.EastID == "none") && !cellList[Neighbors.EastID].Visited)
                legalNeighbors.Add(cellList[Neighbors.EastID]);

            if (!(Neighbors.WestID == "none") && !cellList[Neighbors.WestID].Visited)
                legalNeighbors.Add(cellList[Neighbors.WestID]);

            Cell currentCell = null;

            if (legalNeighbors.Count > 0)
            {
                int randomCell = rGen.Next(legalNeighbors.Count);
                currentCell = legalNeighbors[randomCell];
            }

            return currentCell;

        }//End GetNeighbor

        public Cell Carve()
        {
            Cell nextCell = GetNeighbor();

            if (nextCell != null)
            {
                if (nextCell.ID == Neighbors.NorthID)
                {
                    this.Walls.NorthWall = false;
                    nextCell.Walls.SouthWall = false;
                }
                else if (nextCell.ID == Neighbors.SouthID)
                {
                    this.Walls.SouthWall = false;
                    nextCell.Walls.NorthWall = false;
                }
                else if (nextCell.ID == Neighbors.EastID)
                {
                    this.Walls.EastWall = false;
                    nextCell.Walls.WestWall = false;
                }
                else if (nextCell.ID == Neighbors.WestID)
                {
                    this.Walls.WestWall = false;
                    nextCell.Walls.EastWall = false;
                }
            }

            return nextCell;

        }


        //Determines the neighbors, of the cell, in each direction (N,S,E,W)
        private Neighbors determineNeighbors(int nRows, int nCols)
        {
            Neighbors newNeighbors = new Neighbors();

            if (Row - 1 < 0)
            {
                newNeighbors.NorthID = "none";
            }
            else
            {
                newNeighbors.NorthID = "R" + (Row - 1) + "C" + Col;
            }

            if (Row + 1 > nRows)
            {
                newNeighbors.SouthID = "none";
            }
            else
            {
                newNeighbors.SouthID = "R" + (Row + 1) + "C" + Col;
            }

            if (Col - 1 < 0)
            {
                newNeighbors.WestID = "none";
            }
            else
            {
                newNeighbors.WestID = "R" + Row + "C" + (Col - 1);
            }

            if (Col + 1 > nCols)
            {
                newNeighbors.EastID = "none";
            }
            else
            {
                newNeighbors.EastID = "R" + Row + "C" + (Col + 1);
            }

            return newNeighbors;

        }//End determineNeighbors

    }//End class Cell

}//End namespace
    

