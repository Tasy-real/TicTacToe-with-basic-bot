using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tic_Tac_Toe
{
    public partial class Form1 : Form
    {
        //checks if computer or not
        bool against_Computer = false;

        bool turn = true; //true = X; false = O;
        int turn_count = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Button(object sender, EventArgs e)
        {
            //Buttons (X/O)
            Button b = (Button)sender;
            if (turn)
                b.Text = "X";
            else
                b.Text = "O";
            turn = !turn;
            b.Enabled = false;

            turn_count++;

            //Checks for Winner
            checkForWinner();

            //check for computer; computer = 0;
            if ((!turn) && (against_Computer))
            {
                computer_makes_move();
            }
            
        }
        private void computer_makes_move()
        {
            //Computer makes Moves
            Button move = null;

            move = look_for_winner_or_block("O");
            if(move == null)
            {
                move = look_for_winner_or_block("X");
                if(move == null)
                {
                    move = look_for_corner();

                    if (move == null)
                    {
                        move = look_for_open_space();
                    }
                }
            }
            if (turn_count != 9)
            {
                move.PerformClick();
            }
        }
        private Button look_for_open_space()
        {
            Button b = null;
            foreach (Control c in Controls)
            {
                b = c as Button;
                if(b != null)
                {
                    if(b.Text == "")
                        return b;
                    
                }
            }
            return null;
        }
        private Button look_for_corner()
        {
           

                if (A3.Text == "O")
                {
                    if (A1.Text == "")
                        return A1;
                    if (C3.Text == "")
                        return C3;
                    if (C1.Text == "")
                        return C1;
                }

                if (C3.Text == "O")
                {
                    if (A1.Text == "")
                        return A1;
                    if (A3.Text == "")
                        return A3;
                    if (C1.Text == "")
                        return C1;
                }

                if (C1.Text == "O")
                {
                    if (A1.Text == "")
                        return A1;
                    if (A3.Text == "")
                        return A3;
                    if (C3.Text == "")
                        return C3;
                }

                if (A1.Text == "O")
                {
                    if (A3.Text == "")
                        return A3;
                    if (C3.Text == "")
                        return C3;
                    if (C1.Text == "")
                        return C1;
                }

            if (A1.Text == "")
                    return A1;
                if (A3.Text == "")
                    return A3;
                if (C1.Text == "")
                    return C1;
                if (C3.Text == "")
                    return C3;
            
            return null;
        }
        private Button look_for_winner_or_block(string mark)
        {
            //Horizontal

            // A
            if ((A1.Text == mark) && (A2.Text == mark) && (A3.Text == ""))
                return A3;
            if ((A3.Text == mark) && (A2.Text == mark) && (A1.Text == ""))
                return A1;
            if ((A3.Text == mark) && (A1.Text == mark) && (A2.Text == ""))
                return A2;

            //B
            if ((B1.Text == mark) && (B2.Text == mark) && (B3.Text == ""))
                return B3;
            if ((B3.Text == mark) && (B2.Text == mark) && (B1.Text == ""))
                return B1;
            if ((B3.Text == mark) && (B1.Text == mark) && (B2.Text == ""))
                return B2;

            //C
            if ((C1.Text == mark) && (C2.Text == mark) && (C3.Text == ""))
                return C3;
            if ((C3.Text == mark) && (C2.Text == mark) && (C1.Text == ""))
                return C1;
            if ((C3.Text == mark) && (C1.Text == mark) && (C2.Text == ""))
                return C2;

            //Vertikal

            //1
            if ((A1.Text == mark) && (B1.Text == mark) && (C1.Text == ""))
                return C1;
            if ((A1.Text == mark) && (C1.Text == mark) && (B1.Text == ""))
                return B1;
            if ((B1.Text == mark) && (C1.Text == mark) && (A1.Text == ""))
                return A1;

            //2
            if ((A2.Text == mark) && (B2.Text == mark) && (C2.Text == ""))
                return C2;
            if ((A2.Text == mark) && (C2.Text == mark) && (B2.Text == ""))
                return B2;
            if ((B2.Text == mark) && (C2.Text == mark) && (A2.Text == ""))
                return A2;

            //3
            if ((A3.Text == mark) && (B3.Text == mark) && (C3.Text == ""))
                return C3;
            if ((A3.Text == mark) && (C3.Text == mark) && (B3.Text == ""))
                return B3;
            if ((B3.Text == mark) && (C3.Text == mark) && (A3.Text == ""))
                return A3;

            //Crosswise

            //left -> right
            if ((A1.Text == mark) && (B2.Text == mark) && (C3.Text == ""))
                return C3;
            if ((A1.Text == mark) && (C3.Text == mark) && (B2.Text == ""))
                return B2;
            if ((C3.Text == mark) && (B3.Text == mark) && (A3.Text == ""))
                return A3;

            // right -> left
            if ((A3.Text == mark) && (B2.Text == mark) && (C1.Text == ""))
                return C1;
            if ((A3.Text == mark) && (C1.Text == mark) && (B2.Text == ""))
                return B2;
            if ((B2.Text == mark) && (C1.Text == mark) && (A3.Text == ""))
                return A3;

            return null;

        }

        private void checkForWinner()
        {
            bool there_is_a_winner = false;
            //horizontal
            if ((A1.Text == A2.Text) && (A2.Text == A3.Text)&&(!A1.Enabled))
                there_is_a_winner = true;
           else if ((B1.Text == B2.Text) && (B2.Text == B3.Text) && (!B1.Enabled))
                there_is_a_winner = true;
          else  if ((C1.Text == C2.Text) && (C2.Text == C3.Text) && (!C1.Enabled))
                there_is_a_winner = true;

            //Vertikal
            else if ((A1.Text == B1.Text) && (B1.Text == C1.Text) && (!C1.Enabled))
                there_is_a_winner = true;
            else if ((A2.Text == B2.Text) && (B2.Text == C2.Text) && (!C2.Enabled))
                there_is_a_winner = true;
            else if ((A3.Text == B3.Text) && (B3.Text == C3.Text) && (!C3.Enabled))
                there_is_a_winner = true;

            //Crosswise
            else if ((A1.Text == B2.Text) && (B2.Text == C3.Text) && (!B2.Enabled))
                there_is_a_winner = true;
            else if ((A3.Text == B2.Text) && (B2.Text == C1.Text) && (!B2.Enabled))
                there_is_a_winner = true;

            //showes winner
            if (there_is_a_winner)
            {
                string winner = " ";
                if (turn)
                    winner = "O";
                else
                    winner = "X";

                MessageBox.Show(winner + " has Won!","Yay!");

                disable_buttons();
            }
            else
            {
                if(turn_count == 9)
                {
                    MessageBox.Show("Draw!", "Oh!");
                }
            }
        }

        private void disable_buttons()
        {
            foreach(Control c in Controls)
            {
                if (c.GetType() == typeof(Button))
                {
                    Button b = (Button)c;
                    b.Enabled = false;
                }
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Information
            MessageBox.Show("If 3 times X or O are in a row,\ncrosswise or in a column, that player wins! \n\n Createt from Tasy-Real " + ":)","About");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Exit
            Application.Exit();
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            turn = true;
            turn_count = 0;
            try
            {


                foreach (Control c in Controls)
                {
                    if (c.GetType() == typeof(Button))
                    {
                        Button b = (Button)c;
                        b.Enabled = true;
                        b.Text = "";
                    }
                }
            }
            catch { }
        }

        private void aktuellerZugToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Current move
            MessageBox.Show("It is the " + turn_count + " move!","Current Move", MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            //If against computer or not
            if (checkBox1.Checked)
            {
                against_Computer = true;
                MessageBox.Show("You are now playing against a computer!", "Computer", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                against_Computer = false;
                MessageBox.Show("You are now playing not more against a computer", "Computer", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
 