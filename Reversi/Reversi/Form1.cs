using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reversi
{
    public partial class Reversi : Form
    {
        string[,] Grid = new string[8, 8];
        int BTokens; //total number of black tokens on board
        int WTokens; //total number of white tokens on board
        bool Skipped; //if the last turn was skipped

        public Reversi()
        {
            InitializeComponent();
            int row, column;
            for (row = 0; row < 8; row = row + 1)
            {
                for (column = 0; column < 8; column = column + 1)
                {
                    Grid[row, column] = "Green";
                }
            }
            BTokens = 2;
            WTokens = 2;
            Skipped = false;
        }

        public bool LegalUp (int row, int column, string color) // checks if legal move upwards
        {
            string Turn;
            if (color == "Black")
            {
                Turn = "White";
            }
            else
            {
                Turn = "Black";
            }

            if (Grid[row - 1, column] == color) //checks space above
            {
                for (row = row - 1; row >= 0; row = row - 1) //checks each row in that column until it reaches the edge
                {
                    if ((Grid[row, column] == "Green") || (Grid[row, column] == "Open")) //detects that the line of opponent's tokens ends with an open space
                    {
                        return false;
                    }
                    else if (Grid[row, column] == Turn) // row ends with other color
                    {
                        return true;
                    }
                }
                    return false;
            }
            else
            {
                return false;
            }
        }

        public void FlipUp (int row, int column, string color) //flips tokens upwards
        {
            string Turn;
            bool valid = false;
            int rowValid, columnValid, toflip = 0, flipped = 0;
            rowValid = row;
            columnValid = column;
            Graphics g = Graphics.FromHwnd(pictureBox1.Handle);
            SolidBrush myBrush = new SolidBrush(Color.Transparent);

            if (color == "Black")
            {
                Turn = "White";
                myBrush = new SolidBrush(Color.White);
            }
            else
            {
                Turn = "Black";
                myBrush = new SolidBrush(Color.Black);
            }

            if (Grid[row - 1, column] == color) //this block is similar to LegalUp
            {
                for (row = row - 1; row >= 0; row = row - 1)
                {
                    if ((Grid[row, column] == "Green") || (Grid[row, column] == "Open"))
                    {
                        valid = false;
                        break;
                    }
                    if (Grid[row, column] == Turn)
                    {
                        valid = true; //at least one token can be flipped
                        break;
                    }
                    toflip++; //counts tokens to be flipped
                }
            }
            else
            {
                valid = false;
            }

            if (valid)
            {
                for (rowValid--; flipped < toflip; rowValid--, flipped++)
                {
                    Grid[rowValid, columnValid] = Turn;
                    int placementX, placementY;
                    placementX = GetPlacementColumn(columnValid);
                    placementY = GetPlacementRow(rowValid);
                    g.FillEllipse(myBrush, placementX, placementY, 40, 40);
                    if (Turn == "White")
                    {
                        WTokens++; //changes current score
                        BTokens--;
                    }
                    else
                    {
                        BTokens++;
                        WTokens--;
                    }
                }
            }
        }

        public bool LegalDown (int row, int column, string color) //checks if legal move downward, this and the following Legal methods are very similar to LegalUp, but with very slight differences. For that reason, they will not be commented
        {
            string Turn;
            if (color == "Black")
            {
                Turn = "White";
            }
            else
            {
                Turn = "Black";
            }
            if (Grid[row + 1, column] == color)
            {
                for (row = row + 1; row < 8; row = row + 1)
                {
                    if ((Grid[row, column] == "Green") || (Grid[row, column] == "Open"))
                    {
                        return false;
                    }
                    else if (Grid[row, column] == Turn)
                    {
                        return true;
                    }
                }
                return false;
            }
            else
            {
                return false;
            }
        }

        public void FlipDown(int row, int column, string color) //flips tokens downwards, similar to FlipUp
        {
            string Turn;
            bool valid = false;
            int rowValid, columnValid, toflip = 0, flipped = 0;
            rowValid = row;
            columnValid = column;
            Graphics g = Graphics.FromHwnd(pictureBox1.Handle);
            SolidBrush myBrush = new SolidBrush(Color.Transparent);

            if (color == "Black")
            {
                Turn = "White";
                myBrush = new SolidBrush(Color.White);
            }
            else
            {
                Turn = "Black";
                myBrush = new SolidBrush(Color.Black);
            }

            if (Grid[row + 1, column] == color)
            {
                for (row = row + 1; row < 8; row = row + 1)
                {
                    if ((Grid[row, column] == "Green") || (Grid[row, column] == "Open"))
                    {
                        valid = false;
                        break;
                    }
                    if (Grid[row, column] == Turn)
                    {
                        valid = true;
                        break;
                    }
                    toflip++;
                }
            }
            else
            {
                valid = false;
            }

            if (valid)
            {
                for (rowValid++; flipped < toflip; rowValid++, flipped++)
                {
                    Grid[rowValid, columnValid] = Turn;
                    int placementX, placementY;
                    placementX = GetPlacementColumn(columnValid);
                    placementY = GetPlacementRow(rowValid);
                    g.FillEllipse(myBrush, placementX, placementY, 40, 40);
                    if (Turn == "White")
                    {
                        WTokens++;
                        BTokens--;
                    }
                    else
                    {
                        BTokens++;
                        WTokens--;
                    }
                }
            }
        }

        public bool LegalLeft(int row, int column, string color) //checks if legal move to the left
        {
            string Turn;
            if (color == "Black")
            {
                Turn = "White";
            }
            else
            {
                Turn = "Black";
            }
            if (Grid[row, column - 1] == color)
            {
                for (column = column - 1; column >= 0; column = column - 1)
                {
                    if ((Grid[row, column] == "Green") || (Grid[row, column] == "Open"))
                    {
                        return false;
                    }
                    else if (Grid[row, column] == Turn)
                    {
                        return true;
                    }
                }
                return false;
            }
            else
            {
                return false;
            }
        }

        public void FlipLeft(int row, int column, string color) //flips tokens to the left
        {
            string Turn;
            bool valid = false;
            int rowValid, columnValid, toflip = 0, flipped = 0;
            rowValid = row;
            columnValid = column;
            Graphics g = Graphics.FromHwnd(pictureBox1.Handle);
            SolidBrush myBrush = new SolidBrush(Color.Transparent);

            if (color == "Black")
            {
                Turn = "White";
                myBrush = new SolidBrush(Color.White);
            }
            else
            {
                Turn = "Black";
                myBrush = new SolidBrush(Color.Black);
            }

            if (Grid[row, column - 1] == color)
            {
                for (column = column - 1; column >= 0; column = column - 1)
                {
                    if ((Grid[row, column] == "Green") || (Grid[row, column] == "Open"))
                    {
                        valid = false;
                        break;
                    }
                    if (Grid[row, column] == Turn)
                    {
                        valid = true;
                        break;
                    }
                    toflip++;
                }
            }
            else
            {
                valid = false;
            }

            if (valid)
            {
                for (columnValid--; flipped < toflip; columnValid--, flipped++)
                {
                    Grid[rowValid, columnValid] = Turn;
                    int placementX, placementY;
                    placementX = GetPlacementColumn(columnValid);
                    placementY = GetPlacementRow(rowValid);
                    g.FillEllipse(myBrush, placementX, placementY, 40, 40);
                    if (Turn == "White")
                    {
                        WTokens++;
                        BTokens--;
                    }
                    else
                    {
                        BTokens++;
                        WTokens--;
                    }
                }
            }
        }

        public bool LegalRight(int row, int column, string color) //checks if legal move to the right
        {
            string Turn;
            if (color == "Black")
            {
                Turn = "White";
            }
            else
            {
                Turn = "Black";
            }
            if (Grid[row, column + 1] == color)
            {
                for (column = column + 1; column < 8; column = column + 1)
                {
                    if ((Grid[row, column] == "Green") || (Grid[row, column] == "Open"))
                    {
                        return false;
                    }
                    else if (Grid[row, column] == Turn)
                    {
                        return true;
                    }
                }
                return false;
            }
            else
            {
                return false;
            }
        }

        public void FlipRight(int row, int column, string color) //flips tokens to the right
        {
            string Turn;
            bool valid = false;
            int rowValid, columnValid, toflip = 0, flipped = 0;
            rowValid = row;
            columnValid = column;
            Graphics g = Graphics.FromHwnd(pictureBox1.Handle);
            SolidBrush myBrush = new SolidBrush(Color.Transparent);

            if (color == "Black")
            {
                Turn = "White";
                myBrush = new SolidBrush(Color.White);
            }
            else
            {
                Turn = "Black";
                myBrush = new SolidBrush(Color.Black);
            }

            if (Grid[row, column + 1] == color)
            {
                for (column = column + 1; column < 8; column = column + 1)
                {
                    if ((Grid[row, column] == "Green") || (Grid[row, column] == "Open"))
                    {
                        valid = false;
                        break;
                    }
                    if (Grid[row, column] == Turn)
                    {
                        valid = true;
                        break;
                    }
                    toflip++;
                }
            }
            else
            {
                valid = false;
            }

            if (valid)
            {
                for (columnValid++; flipped < toflip; columnValid++, flipped++)
                {
                    Grid[rowValid, columnValid] = Turn;
                    int placementX, placementY;
                    placementX = GetPlacementColumn(columnValid);
                    placementY = GetPlacementRow(rowValid);
                    g.FillEllipse(myBrush, placementX, placementY, 40, 40);
                    if (Turn == "White")
                    {
                        WTokens++;
                        BTokens--;
                    }
                    else
                    {
                        BTokens++;
                        WTokens--;
                    }
                }
            }
        }

        public bool LegalUpLeft(int row, int column, string color) //checks if legal move to the upper left
        {
            string Turn;
            if (color == "Black")
            {
                Turn = "White";
            }
            else
            {
                Turn = "Black";
            }
            if (Grid[row - 1, column - 1] == color)
            {
                for (row = row - 1, column = column - 1; (column >= 0) && (row >= 0); column--, row--)
                {
                    if ((Grid[row, column] == "Green") || (Grid[row, column] == "Open"))
                    {
                        return false;
                    }
                    else if (Grid[row, column] == Turn)
                    {
                        return true;
                    }
                }
                return false;
            }
            else
            {
                return false;
            }
        }

        public void FlipUpLeft(int row, int column, string color) //flips tokens to the upper left
        {
            string Turn;
            bool valid = false;
            int rowValid, columnValid, toflip = 0, flipped = 0;
            rowValid = row;
            columnValid = column;
            Graphics g = Graphics.FromHwnd(pictureBox1.Handle);
            SolidBrush myBrush = new SolidBrush(Color.Transparent);

            if (color == "Black")
            {
                Turn = "White";
                myBrush = new SolidBrush(Color.White);
            }
            else
            {
                Turn = "Black";
                myBrush = new SolidBrush(Color.Black);
            }

            if (Grid[row - 1, column - 1] == color)
            {
                for (column = column - 1, row--; (column >= 0) && (row >= 0); column = column - 1, row--)
                {
                    if ((Grid[row, column] == "Green") || (Grid[row, column] == "Open"))
                    {
                        valid = false;
                        break;
                    }
                    if (Grid[row, column] == Turn)
                    {
                        valid = true;
                        break;
                    }
                    toflip++;
                }
            }
            else
            {
                valid = false;
            }

            if (valid)
            {
                for (columnValid--, rowValid--; flipped < toflip; columnValid--, rowValid--, flipped++)
                {
                    Grid[rowValid, columnValid] = Turn;
                    int placementX, placementY;
                    placementX = GetPlacementColumn(columnValid);
                    placementY = GetPlacementRow(rowValid);
                    g.FillEllipse(myBrush, placementX, placementY, 40, 40);
                    if (Turn == "White")
                    {
                        WTokens++;
                        BTokens--;
                    }
                    else
                    {
                        BTokens++;
                        WTokens--;
                    }
                }
            }
        }

        public bool LegalUpRight(int row, int column, string color) //checks if legal move to the upper right
        {
            string Turn;
            if (color == "Black")
            {
                Turn = "White";
            }
            else
            {
                Turn = "Black";
            }
            if (Grid[row - 1, column + 1] == color)
            {
                for (row = row - 1, column = column + 1; (column < 8) && (row >= 0); column++, row--)
                {
                    if ((Grid[row, column] == "Green") || (Grid[row, column] == "Open"))
                    {
                        return false;
                    }
                    else if (Grid[row, column] == Turn)
                    {
                        return true;
                    }
                }
                return false;
            }
            else
            {
                return false;
            }
        }

        public void FlipUpRight(int row, int column, string color) //flips tokens to the upper right
        {
            string Turn;
            bool valid = false;
            int rowValid, columnValid, toflip = 0, flipped = 0;
            rowValid = row;
            columnValid = column;
            Graphics g = Graphics.FromHwnd(pictureBox1.Handle);
            SolidBrush myBrush = new SolidBrush(Color.Transparent);

            if (color == "Black")
            {
                Turn = "White";
                myBrush = new SolidBrush(Color.White);
            }
            else
            {
                Turn = "Black";
                myBrush = new SolidBrush(Color.Black);
            }

            if (Grid[row - 1, column + 1] == color)
            {
                for (column = column + 1, row--; (column < 8) && (row >= 0); column = column + 1, row--)
                {
                    if ((Grid[row, column] == "Green") || (Grid[row, column] == "Open"))
                    {
                        valid = false;
                        break;
                    }
                    if (Grid[row, column] == Turn)
                    {
                        valid = true;
                        break;
                    }
                    toflip++;
                }
            }
            else
            {
                valid = false;
            }

            if (valid)
            {
                for (columnValid++, rowValid--; flipped < toflip; columnValid++, rowValid--, flipped++)
                {
                    Grid[rowValid, columnValid] = Turn;
                    int placementX, placementY;
                    placementX = GetPlacementColumn(columnValid);
                    placementY = GetPlacementRow(rowValid);
                    g.FillEllipse(myBrush, placementX, placementY, 40, 40);
                    if (Turn == "White")
                    {
                        WTokens++;
                        BTokens--;
                    }
                    else
                    {
                        BTokens++;
                        WTokens--;
                    }
                }
            }
        }

        public bool LegalDownLeft(int row, int column, string color) //checks if move is legal to the lower left
        {
            string Turn;
            if (color == "Black")
            {
                Turn = "White";
            }
            else
            {
                Turn = "Black";
            }
            if (Grid[row + 1, column - 1] == color)
            {
                for (row = row + 1, column = column - 1; (column >= 0) && (row < 8); column--, row++)
                {
                    if ((Grid[row, column] == "Green") || (Grid[row, column] == "Open"))
                    {
                        return false;
                    }
                    else if (Grid[row, column] == Turn)
                    {
                        return true;
                    }
                }
                return false;
            }
            else
            {
                return false;
            }
        }

        public void FlipDownLeft(int row, int column, string color) //flips tokens to the lower left
        {
            string Turn;
            bool valid = false;
            int rowValid, columnValid, toflip = 0, flipped = 0;
            rowValid = row;
            columnValid = column;
            Graphics g = Graphics.FromHwnd(pictureBox1.Handle);
            SolidBrush myBrush = new SolidBrush(Color.Transparent);

            if (color == "Black")
            {
                Turn = "White";
                myBrush = new SolidBrush(Color.White);
            }
            else
            {
                Turn = "Black";
                myBrush = new SolidBrush(Color.Black);
            }

            if (Grid[row + 1, column - 1] == color)
            {
                for (column = column - 1, row++; (column >= 0) && (row < 8); column = column - 1, row++)
                {
                    if ((Grid[row, column] == "Green") || (Grid[row, column] == "Open"))
                    {
                        valid = false;
                        break;
                    }
                    if (Grid[row, column] == Turn)
                    {
                        valid = true;
                        break;
                    }
                    toflip++;
                }
            }
            else
            {
                valid = false;
            }

            if (valid)
            {
                for (columnValid--, rowValid++; flipped < toflip; columnValid--, rowValid++, flipped++)
                {
                    Grid[rowValid, columnValid] = Turn;
                    int placementX, placementY;
                    placementX = GetPlacementColumn(columnValid);
                    placementY = GetPlacementRow(rowValid);
                    g.FillEllipse(myBrush, placementX, placementY, 40, 40);
                    if (Turn == "White")
                    {
                        WTokens++;
                        BTokens--;
                    }
                    else
                    {
                        BTokens++;
                        WTokens--;
                    }
                }
            }
        }

        public bool LegalDownRight(int row, int column, string color) //checks if move is legal to the lower right
        {
            string Turn;
            if (color == "Black")
            {
                Turn = "White";
            }
            else
            {
                Turn = "Black";
            }
            if (Grid[row + 1, column + 1] == color)
            {
                for (row = row + 1, column = column + 1; (column < 8) && (row < 8); column++, row++)
                {
                    if ((Grid[row, column] == "Green") || (Grid[row, column] == "Open"))
                    {
                        return false;
                    }
                    else if (Grid[row, column] == Turn)
                    {
                        return true;
                    }
                }
                return false;
            }
            else
            {
                return false;
            }
        }

        public void FlipDownRight(int row, int column, string color) //flips tokens to the lower right
        {
            string Turn;
            bool valid = false;
            int rowValid, columnValid, toflip = 0, flipped = 0;
            rowValid = row;
            columnValid = column;
            Graphics g = Graphics.FromHwnd(pictureBox1.Handle);
            SolidBrush myBrush = new SolidBrush(Color.Transparent);

            if (color == "Black")
            {
                Turn = "White";
                myBrush = new SolidBrush(Color.White);
            }
            else
            {
                Turn = "Black";
                myBrush = new SolidBrush(Color.Black);
            }

            if (Grid[row + 1, column + 1] == color)
            {
                for (column = column + 1, row++; (column < 8) && (row < 8); column = column + 1, row++)
                {
                    if ((Grid[row, column] == "Green") || (Grid[row, column] == "Open"))
                    {
                        valid = false;
                        break;
                    }
                    if (Grid[row, column] == Turn)
                    {
                        valid = true;
                        break;
                    }
                    toflip++;
                }
            }
            else
            {
                valid = false;
            }

            if (valid)
            {
                for (columnValid++, rowValid++; flipped < toflip; columnValid++, rowValid++, flipped++)
                {
                    Grid[rowValid, columnValid] = Turn;
                    int placementX, placementY;
                    placementX = GetPlacementColumn(columnValid);
                    placementY = GetPlacementRow(rowValid);
                    g.FillEllipse(myBrush, placementX, placementY, 40, 40);
                    if (Turn == "White")
                    {
                        WTokens++;
                        BTokens--;
                    }
                    else
                    {
                        BTokens++;
                        WTokens--;
                    }
                }
            }
        }

        public bool DetectNearby(int GridY, int GridX, string color) //detects if the move is legal
        {
            if (Grid[GridY, GridX] == "Green") //spot on grid is not occupied
            {
                //each segment needed to use different methods because if the wrong method was used it would exceed the range of the array
                if ((GridX == 0) && (GridY == 0)) //top left
                {
                    if (LegalRight(GridY, GridX, color) || LegalDownRight(GridY, GridX, color) || LegalDown(GridY, GridX, color)) //checks possible directions for top left corner
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else if ((GridX == 7) && (GridY == 0)) //top right
                {
                    if (LegalLeft(GridY, GridX, color) || LegalDown(GridY, GridX, color) || LegalDownLeft(GridY, GridX, color)) //top right
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else if ((GridX == 0) && (GridY == 7))// bottom left
                {
                    if (LegalUp(GridY, GridX, color) || LegalRight(GridY, GridX, color) || LegalUpRight(GridY, GridX, color))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else if ((GridX == 7) && (GridY == 7))//bottom right
                {
                    if (LegalUpLeft(GridY, GridX, color) || LegalLeft(GridY, GridX, color) || LegalUp(GridY, GridX, color))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else if (GridY == 0) //top
                {
                    if (LegalLeft(GridY, GridX, color) || LegalDownLeft(GridY, GridX, color) || LegalDown(GridY, GridX, color) || LegalDownRight(GridY, GridX, color) || LegalRight(GridY, GridX, color))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else if (GridX == 0) //left
                {
                    if (LegalUpRight(GridY, GridX, color) || LegalUp(GridY, GridX, color) || LegalDown(GridY, GridX, color) || LegalDownRight(GridY, GridX, color) || LegalRight(GridY, GridX, color))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else if (GridY == 7) // bottom
                {
                    if (LegalLeft(GridY, GridX, color) || LegalUpLeft(GridY, GridX, color) || LegalUp(GridY, GridX, color) || LegalUpRight(GridY, GridX, color) || LegalRight(GridY, GridX, color))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else if (GridX == 7) //right
                {
                    if (LegalUpLeft(GridY, GridX, color) || LegalUp(GridY, GridX, color) || LegalDown(GridY, GridX, color) || LegalDownLeft(GridY, GridX, color) || LegalLeft(GridY, GridX, color))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    if (LegalUpRight(GridY, GridX, color) || LegalUp(GridY, GridX, color) || LegalDown(GridY, GridX, color) || LegalDownRight(GridY, GridX, color) || LegalRight(GridY, GridX, color) || LegalLeft(GridY, GridX, color) || LegalDownLeft(GridY, GridX, color) || LegalUpLeft(GridY, GridX, color))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    } 
                }    
            }
            else
            {
                return false;
            }
        }

        public int GetPlacementRow(int row) //gets the y coordinate of the spot on the grid, used when placing tokens
        {
            switch (row)
            {
                case 0:
                    return 0;
                case 1:
                    return 42;
                case 2:
                    return 83;
                case 3:
                    return 124;
                case 4:
                    return 165;
                case 5:
                    return 206;
                case 6:
                    return 247;
                case 7:
                    return 288;
                default:
                    return 404;
            }
        }

        public int GetPlacementColumn(int column) //gets the x coordinate of the spot on the grid, similar to above method
        {
            switch (column)
            {
                case 0:
                    return 0;
                case 1:
                    return 42;
                case 2:
                    return 83;
                case 3:
                    return 124;
                case 4:
                    return 165;
                case 5:
                    return 206;
                case 6:
                    return 247;
                case 7:
                    return 288;
                default:
                    return 404;
            }
        }

        public void ResetOpen() //clears the open spots from last turn, basically just places a green circle on top of a blue one
        {
            int row, column, placementX, placementY;
            Graphics g = Graphics.FromHwnd(pictureBox1.Handle);
            Pen Reset = new Pen(Color.ForestGreen, 1);

            for (row = 0; row < 8; row = row + 1)
            {
                for (column = 0; column < 8; column = column + 1)
                {
                    if (Grid[row, column] == "Open") 
                    {
                        Grid[row, column] = "Green";
                        placementX = GetPlacementColumn(column);
                        placementY = GetPlacementRow(row);
                        g.DrawEllipse(Reset, placementX + 1, placementY + 1, 38, 38);
                    }
                }
            }
        }

        public void PlaceOpen(string color) //places new open spots each turn
        {
            int row, column, placementX, placementY, options = 0;
            string Detecting;
            bool Nearby;
            Graphics g = Graphics.FromHwnd(pictureBox1.Handle);
            Pen Open = new Pen(Color.LightBlue, 1);
            if (color == "Black")
            {
                Detecting = "White";
            }
            else
            {
                Detecting = "Black";
            }

            for (row = 0; row < 8; row++)
            {
                for (column = 0; column < 8; column++)
                {
                    Nearby = DetectNearby(row, column, Detecting); //detects if it is a legal move
                    if (Nearby)
                    {
                        placementX = GetPlacementColumn(column);
                        placementY = GetPlacementRow(row);
                        g.DrawEllipse(Open, placementX + 1, placementY + 1, 38, 38);
                        Grid[row, column] = "Open";
                        options++; //used to check if a turn will be skipped
                    } 
                }
            }
            if (options == 0) //skipped turn
            {
                if (Skipped) //last turn was skipped, neither player can do anything
                {
                    EndGame();
                }
                else if (color == "White")
                {
                    Skipped = true;
                    lblTurn.Text = "Black Turn";
                    lblTurn.ForeColor = Color.White;
                    lblTurn.BackColor = Color.Black;
                    PlaceOpen("Black");
                }
                else
                {
                    Skipped = true;
                    lblTurn.Text = "White Turn";
                    lblTurn.ForeColor = Color.Black;
                    lblTurn.BackColor = Color.White;
                    PlaceOpen("White");
                }
            }
            else
            {
                Skipped = false;
            }
        }

        public void FlipTokens(int GridY, int GridX, string color) //occurs after a click, flips all possible tokens
        {
            if ((GridX == 0) && (GridY == 0)) //top left
            {
                FlipDownRight(GridY, GridX, color);
                FlipDown(GridY, GridX, color);
                FlipRight(GridY, GridX, color);
            }
            else if ((GridX == 7) && (GridY == 0)) //top right
            {
                FlipDownLeft(GridY, GridX, color);
                FlipDown(GridY, GridX, color);
                FlipLeft(GridY, GridX, color);
            }
            else if ((GridX == 0) && (GridY == 7))// bottom left
            {
                FlipUpRight(GridY, GridX, color);
                FlipUp(GridY, GridX, color);
                FlipRight(GridY, GridX, color);
            }
            else if ((GridX == 7) && (GridY == 7))//bottom right
            {
                FlipUpLeft(GridY, GridX, color);
                FlipUp(GridY, GridX, color);
                FlipLeft(GridY, GridX, color);
            }
            else if (GridY == 0) //top
            {
                FlipDown(GridY, GridX, color);
                FlipLeft(GridY, GridX, color);
                FlipRight(GridY, GridX, color);
                FlipDownLeft(GridY, GridX, color);
                FlipDownRight(GridY, GridX, color);
            }
            else if (GridX == 0) //left
            {
                FlipUp(GridY, GridX, color);
                FlipDown(GridY, GridX, color);
                FlipRight(GridY, GridX, color);
                FlipDownRight(GridY, GridX, color);
                FlipUpRight(GridY, GridX, color);
            }
            else if (GridY == 7) // bottom
            {
                FlipUp(GridY, GridX, color);
                FlipLeft(GridY, GridX, color);
                FlipRight(GridY, GridX, color);
                FlipUpLeft(GridY, GridX, color);
                FlipUpRight(GridY, GridX, color);
            }
            else if (GridX == 7) //right
            {
                FlipUp(GridY, GridX, color);
                FlipDown(GridY, GridX, color);
                FlipLeft(GridY, GridX, color);
                FlipDownLeft(GridY, GridX, color);
                FlipUpLeft(GridY, GridX, color);
            }
            else
            {
                FlipUp(GridY, GridX, color);
                FlipDown(GridY, GridX, color);
                FlipLeft(GridY, GridX, color);
                FlipDownLeft(GridY, GridX, color);
                FlipUpLeft(GridY, GridX, color);
                FlipRight(GridY, GridX, color);
                FlipDownRight(GridY, GridX, color);
                FlipUpRight(GridY, GridX, color);
            }
        }

        public void EndGame() //detects winner and displays message
        {
            string Winner;
            if (BTokens > WTokens)
            {
                Winner = "Black";
            }
            else if (WTokens > BTokens)
            {
                Winner = "White";
            }
            else
            {
                Winner = "no one";
            }

            MessageBox.Show(Winner + " is the winner. \r\n\r\n The score is " + BTokens + " Black; " + WTokens + " White \r\n\r\n Press the New Game button to restart.");
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            int x, y;
            Graphics g = e.Graphics;
            Pen myPen = new Pen(Color.Black, 1);
            SolidBrush WBrush = new SolidBrush(Color.White);
            SolidBrush BBrush = new SolidBrush(Color.Black);
            Pen BPen = new Pen(Color.LightBlue, 1);

            for (x = 0; x < 328; x = x + 41) //draws grid lines
            {
                g.DrawLine(myPen, x, 0, x, 327);
            }
            for (y = 0; y < 328; y = y + 41)
            {
                g.DrawLine(myPen, 0, y, 327, y);
            }

            g.FillEllipse(WBrush, 165, 165, 40, 40); //places intial tokens
            g.FillEllipse(WBrush, 124, 124, 40, 40);
            g.FillEllipse(BBrush, 165, 124, 40, 40);
            g.FillEllipse(BBrush, 124, 165, 40, 40);
            Grid[3, 3] = "White";
            Grid[3, 4] = "Black";
            Grid[4, 3] = "Black";
            Grid[4, 4] = "White";

            g.DrawEllipse(BPen, 125, 84, 38, 38); //places intial possible placement options
            Grid[3, 2] = "Open";
            g.DrawEllipse(BPen, 84, 125, 38, 38);
            Grid[2, 3] = "Open";
            g.DrawEllipse(BPen, 166, 207, 38, 38);
            Grid[4, 5] = "Open";
            g.DrawEllipse(BPen, 207, 166, 38, 38);
            Grid[5, 4] = "Open";
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            int MouseX, MouseY, GridX, GridY, PlaceX, PlaceY;
            string strTurn;
            MouseX = e.X;
            MouseY = e.Y;
            strTurn = Convert.ToString(lblTurn.Text);
            Graphics g = Graphics.FromHwnd(pictureBox1.Handle);
            SolidBrush WBrush = new SolidBrush(Color.White);
            SolidBrush BBrush = new SolidBrush(Color.Black);

            //X coordinate on grid
            if ((MouseX >= 0) && (MouseX <= 41))
            {
                GridX = 0;
                PlaceX = 0;
            }
            else if ((MouseX >= 42) && (MouseX <= 82))
            {
                GridX = 1;
                PlaceX = 42;
            }
            else if ((MouseX >= 83) && (MouseX <= 123))
            {
                GridX = 2;
                PlaceX = 83;
            }
            else if ((MouseX >= 124) && (MouseX <= 164))
            {
                GridX = 3;
                PlaceX = 124;
            }
            else if ((MouseX >= 165) && (MouseX <= 205))
            {
                GridX = 4;
                PlaceX = 165;
            }
            else if ((MouseX >= 206) && (MouseX <= 246))
            {
                GridX = 5;
                PlaceX = 206;
            }
            else if ((MouseX >= 247) && (MouseX <= 287))
            {
                GridX = 6;
                PlaceX = 247;
            }
            else
            {
                GridX = 7;
                PlaceX = 288;
            }

            //Y coordinate on grid
            if ((MouseY >= 0) && (MouseY <= 41))
            {
                GridY = 0;
                PlaceY = 0;
            }
            else if ((MouseY >= 42) && (MouseY <= 82))
            {
                GridY = 1;
                PlaceY = 42;
            }
            else if ((MouseY >= 83) && (MouseY <= 123))
            {
                GridY = 2;
                PlaceY = 83;
            }
            else if ((MouseY >= 124) && (MouseY <= 164))
            {
                GridY = 3;
                PlaceY = 124;
            }
            else if ((MouseY >= 165) && (MouseY <= 205))
            {
                GridY = 4;
                PlaceY = 165;
            }
            else if ((MouseY >= 206) && (MouseY <= 246))
            {
                GridY = 5;
                PlaceY = 206;
            }
            else if ((MouseY >= 247) && (MouseY <= 287))
            {
                GridY = 6;
                PlaceY = 247;
            }
            else
            {
                GridY = 7;
                PlaceY = 288;
            }

            if (strTurn == "Black Turn")
            {
                if (Grid[GridY, GridX] == "Open")
                {
                    g.FillEllipse(BBrush, PlaceX, PlaceY, 40, 40);
                    lblTurn.Text = "White Turn";
                    lblTurn.ForeColor = Color.Black;
                    lblTurn.BackColor = Color.White;
                    Grid[GridY, GridX] = "Black"; //changes array
                    BTokens++;
                    FlipTokens(GridY, GridX, "White"); //flips white tokens
                    ResetOpen();
                    PlaceOpen("White"); //place new options for white
                }
            }
            else
            {
                if (Grid[GridY, GridX] == "Open")
                {
                    g.FillEllipse(WBrush, PlaceX, PlaceY, 40, 40);
                    lblTurn.Text = "Black Turn";
                    lblTurn.ForeColor = Color.White;
                    lblTurn.BackColor = Color.Black;
                    Grid[GridY, GridX] = "White";
                    WTokens++;
                    FlipTokens(GridY, GridX, "Black");
                    ResetOpen();
                    PlaceOpen("Black");

                }
            }

            lblBCounter.Text = Convert.ToString(BTokens); //update score
            lblWCounter.Text = Convert.ToString(WTokens);
        }

        private void btnRestart_Click(object sender, EventArgs e) //restarts game
        {
            BTokens = 2;
            WTokens = 2;
            lblBCounter.Text = "2";
            lblWCounter.Text = "2";
            lblTurn.Text = "Black Turn";
            Skipped = false;
            int row, column;

            for (row = 0; row < 8; row = row + 1)
            {
                for (column = 0; column < 8; column = column + 1)
                {
                    Grid[row, column] = "Green";
                }
            }

            pictureBox1.Invalidate();
        }
    }
} 
