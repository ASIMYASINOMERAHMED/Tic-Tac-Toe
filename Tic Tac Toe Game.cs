using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tic_Tac_Toe_Game
{
    public partial class Tic_Tac_Toe_Game : Form
    {
        public Tic_Tac_Toe_Game()
        {
            InitializeComponent();
        }
        private void ResetButton(Button btn)
        {
            btn.Image = Image.FromFile(@"C:\Users\lap2p\Pictures\question-mark-96.png");
            btn.Tag = "?";
            btn.BackColor = Color.Transparent;
        }
        private void RestartGame()
        {
            ResetButton(button1);
            ResetButton(button2);
            ResetButton(button3);
            ResetButton(button4);
            ResetButton(button5);
            ResetButton(button6);
            ResetButton(button7);
            ResetButton(button8);
            ResetButton(button9);
            PlayerTurn = enPlayer.Player1;
            lblTurn.Text = "Player 1";


            lbIWinner.Text = "In Progress";
        }
        enum enPlayer
        {
            Player1,
            Player2
        };
        enPlayer PlayerTurn;
        enum enWinner
        {
            Player1,
            Player2,
            Draw,
            GameInProgress
        };
        stGameStatus GameStatus;
        struct stGameStatus
        {
            public enWinner Winner;
            public bool GameOver;
            public short PlayCount;
        }

        void EndGame()
        {
            lblTurn.Text = "Game Over";
            switch (GameStatus.Winner)
            {
                case enWinner.Player1:
                    lbIWinner.Text = "Player 1";
                    break;
                case enWinner.Player2:
                    lbIWinner.Text = "Player 2";
                    break;
                default:
                    lbIWinner.Text = "Draw";
                    break;
            }
            GameStatus.PlayCount = 0;
        }
        public bool CheckValues(Button btn1, Button btn2, Button btn3)
        {
            if (btn1.Tag.ToString() != "?" && btn1.Tag.ToString() == btn2.Tag.ToString() && btn1.Tag.ToString() == btn3.Tag.ToString())
            {
                btn1.BackColor = Color.GreenYellow;
                btn2.BackColor = Color.GreenYellow;
                btn3.BackColor = Color.GreenYellow;
                if (btn1.Tag.ToString() == "X")
                {
                    GameStatus.Winner = enWinner.Player1;
                    GameStatus.GameOver = true;
                    EndGame();
                    return true;
                }
                else
                {
                    GameStatus.Winner = enWinner.Player2;
                    GameStatus.GameOver = true;
                    EndGame();
                    return true;
                }
            }
            GameStatus.GameOver = false;
            return false;
        }
        public void CheckWinner()
        {
            if (CheckValues(button1, button2, button3))
                return;
            if (CheckValues(button4, button5, button6))
                return;
            if (CheckValues(button7, button8, button9))
                return;
            if (CheckValues(button1, button4, button7))
                return;
            if (CheckValues(button2, button5, button8))
                return;
            if (CheckValues(button3, button6, button9))
                return;
            if (CheckValues(button1, button5, button9))
                return;
            if (CheckValues(button3, button5, button7))
                return;

        }
        public void ChangeImage(Button btn)
        {
            if (btn.Tag.ToString() == "?")
            {
                switch (PlayerTurn)
                {
                    case enPlayer.Player1:
                        btn.Image = Image.FromFile(@"C:\Users\lap2p\Pictures\X.png");
                        PlayerTurn = enPlayer.Player2;
                        lblTurn.Text = "Player 2";
                        GameStatus.PlayCount++;
                        btn.Tag = "X";
                        CheckWinner();
                        break;
                    case enPlayer.Player2:
                        btn.Image = Image.FromFile(@"C:\Users\lap2p\Pictures\O - Copy.png");
                        PlayerTurn = enPlayer.Player1;
                        lblTurn.Text = "Player 1";
                        GameStatus.PlayCount++;
                        btn.Tag = "O";
                        CheckWinner();
                        break;

                }
            }
            else
            {
                MessageBox.Show("Wrong Choice", "Worng", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (GameStatus.PlayCount == 9)
            {
                GameStatus.GameOver = true;
                GameStatus.Winner = enWinner.Draw;
                EndGame();
            }
        }
        private void Tic_Tac_Toe_Game_Paint(object sender, PaintEventArgs e)
        {
            //Color white = Color.FromArgb(255, 255, 255, 255);
            //Pen Pen = new Pen(white);
            //Pen.Width = 10;
            //Pen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            //Pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
            //e.Graphics.DrawLine(Pen, 493, 182, 963, 182);
            //e.Graphics.DrawLine(Pen, 493, 533, 963, 533);
            //e.Graphics.DrawLine(Pen, 496, 182, 496, 533);
            //e.Graphics.DrawLine(Pen, 960, 182, 960, 533);
        }




        private void btnRestart_Click(object sender, EventArgs e)
        {
            RestartGame();
        }

        private void button_Click(object sender, EventArgs e)
        {
            ChangeImage((Button)sender);
        }



    }
}
