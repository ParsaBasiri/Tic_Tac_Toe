namespace My_Tic_Tac_toe
{
    public partial class Form1 : Form
    {
        public int turn = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }


        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show("لطفا منتطر لود شدن بازی بمانید.");
        }
        void Reset()
        {
            turn = 0;
            foreach (Button btn in pnlMain.Controls)
            {
                btn.BackColor = SystemColors.Control;
                btn.Text = string.Empty;
                btn.Enabled = true;
            }
        }

        void Action(string btnName)
        {
            foreach (Button btn in pnlMain.Controls)
            {
                if (btn.Name == btnName)
                {
                    if (turn % 2 == 0)
                    {
                        btn.BackColor = System.Drawing.Color.MediumSpringGreen;
                        btn.Text = "X";
                        lblTurn.Text = "بازیکن دوم";
                    }
                    else
                    {
                        btn.BackColor = System.Drawing.Color.Gold;
                        btn.Text = "O";
                        lblTurn.Text = "بازیکن اول";
                    }
                    btn.Enabled = false;
                    pnlMain.Focus();
                    break;
                }
            }
        }
        private void btnRestGame_Click(object sender, EventArgs e)
        {

            DialogResult result = MessageBox.Show("بازی ریست شود؟", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Reset();
                lblTurn.Text = "بازیکن اول";
                lblPlayer1Score.Text = lblPlayer2Score.Text = "0";
            }

        }

        private void btnPlayAgain_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("بازی شروع شود؟", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                lblTurn.Text = "بازیکن اول";
                Reset();
            }
        }
        bool CheckVertical(List<Button> player)
        {
            if ((button1.Text == "X" && button4.Text == "X" && button7.Text == "X") || (button2.Text == "X" && button5.Text == "X" && button8.Text == "X") || (button3.Text == "X" && button6.Text == "X" && button9.Text == "X"))
                return true;
            if ((button1.Text == "O" && button4.Text == "O" && button7.Text == "O") || (button2.Text == "O" && button5.Text == "O" && button8.Text == "O") || (button3.Text == "O" && button6.Text == "O" && button9.Text == "O"))
                return true;
            return false;
        }
        bool CheckHorizantal(List<Button> player)
        {
            if ((button1.Text == "X" && button2.Text == "X" && button3.Text == "X") || (button4.Text == "X" && button5.Text == "X" && button6.Text == "X") || (button7.Text == "X" && button8.Text == "X" && button9.Text == "X"))
                return true;
            if ((button1.Text == "O" && button2.Text == "O" && button3.Text == "O") || (button4.Text == "O" && button5.Text == "O" && button6.Text == "O") || (button7.Text == "O" && button8.Text == "O" && button9.Text == "O"))
                return true;
            return false;
        }
        bool CheckDiagonal(List<Button> player)
        {
            if (button5.Text == "X" && ((button1.Text == "X" && button9.Text == "X") || (button3.Text == "X" && button7.Text == "X")))
                return true;
            if (button5.Text == "O" && ((button1.Text == "O" && button9.Text == "O") || (button3.Text == "O" && button7.Text == "O")))
                return true;
            return false;
        }
        bool isAllButtonsDisable()
        {
            foreach (Button btn in pnlMain.Controls)
            {
                if (btn.Enabled == true) return false;
            }
            return true;
        }
        void Check()
        {
            List<Button> player1 = new List<Button>();
            List<Button> player2 = new List<Button>();
            foreach (Button btn in pnlMain.Controls)
            {
                if (btn.Text == "X") player1.Add(btn);
                else if (btn.Text == "O") player2.Add(btn);
            }
            if (turn % 2 == 0)
            {
                if (CheckVertical(player1) || CheckHorizantal(player1) || CheckDiagonal(player1))
                {
                    MessageBox.Show("بازیکن اول برنده شد", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lblPlayer1Score.Text = (Convert.ToInt16(lblPlayer1Score.Text) + 1).ToString();
                    Reset();
                    return;
                }
            }
            else
            {
                if (CheckVertical(player2) || CheckHorizantal(player2) || CheckDiagonal(player2))
                {
                    MessageBox.Show("بازیکن دوم برنده شد", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lblPlayer2Score.Text = (Convert.ToInt16(lblPlayer2Score.Text) + 1).ToString();
                    Reset();
                    return;
                }
            }
            if (isAllButtonsDisable() == true)
            {
                MessageBox.Show("این دست از بازی برنده نداشت!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Reset();
            }
            turn++;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Action("button1");
            Check();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Action("button2");
            Check();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Action("button3");
            Check();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Action("button4");
            Check();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Action("button5");
            Check();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Action("button6");
            Check();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Action("button7");
            Check();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Action("button8");
            Check();
        }
        private void button9_Click(object sender, EventArgs e)
        {
            Action("button9");
            Check();
        }

        private void pnlMain_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
