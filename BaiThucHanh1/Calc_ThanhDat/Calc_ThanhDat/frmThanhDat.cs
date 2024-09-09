using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        Double resultValue = 0;
        String operationPerformed = "";
        bool isOperationPerformed = false;
        
        public Form1()
        {
            InitializeComponent();
            bnt_0.Paint += new PaintEventHandler(button_Paint);
            button1.Paint += new PaintEventHandler(button_Paint);
            button2.Paint += new PaintEventHandler(button_Paint);
            button3.Paint += new PaintEventHandler(button_Paint);
            button4.Paint += new PaintEventHandler(button_Paint);
            button5.Paint += new PaintEventHandler(button_Paint);
            button6.Paint += new PaintEventHandler(button_Paint);
            button7.Paint += new PaintEventHandler(button_Paint);
            button8.Paint += new PaintEventHandler(button_Paint);
            button9.Paint += new PaintEventHandler(button_Paint);
            button10.Paint += new PaintEventHandler(button_Paint);
            button11.Paint += new PaintEventHandler(button_Paint);
            button12.Paint += new PaintEventHandler(button_Paint);
            button13.Paint += new PaintEventHandler(button_Paint);
            button14.Paint += new PaintEventHandler(button_Paint);
            button15.Paint += new PaintEventHandler(button_Paint);
            button16.Paint += new PaintEventHandler(button_Paint);
            button17.Paint += new PaintEventHandler(button_Paint);
        }

        private void button_click(object sender, EventArgs e)
        {
            if ((textBox_Result.Text == "0") || (isOperationPerformed))
                textBox_Result.Clear();

            isOperationPerformed = false;
            Button button = (Button)sender;
            if (button.Text == ".")
            {
                if (!textBox_Result.Text.Contains("."))
                    textBox_Result.Text = textBox_Result.Text + button.Text;

            }
            else
                textBox_Result.Text = textBox_Result.Text + button.Text;


        }

        private void operator_click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if (resultValue != 0)
            {
                button15.PerformClick();
                operationPerformed = button.Text;
                labelCurrentOperation.Text = resultValue + " " + operationPerformed;
                isOperationPerformed = true;
            }
            else
            {

                operationPerformed = button.Text;
                resultValue = Double.Parse(textBox_Result.Text);
                labelCurrentOperation.Text = resultValue + " " + operationPerformed;
                isOperationPerformed = true;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox_Result.Text = "0";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox_Result.Text = "0";
            resultValue = 0;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            switch (operationPerformed)
            {
                case "+":
                    textBox_Result.Text = (resultValue + Double.Parse(textBox_Result.Text)).ToString();
                    break;
                case "-":
                    textBox_Result.Text = (resultValue - Double.Parse(textBox_Result.Text)).ToString();
                    break;
                case "*":
                    textBox_Result.Text = (resultValue * Double.Parse(textBox_Result.Text)).ToString();
                    break;
                case "/":
                    textBox_Result.Text = (resultValue / Double.Parse(textBox_Result.Text)).ToString();
                    break;
                default:
                    break;
            }
            resultValue = Double.Parse(textBox_Result.Text);
            labelCurrentOperation.Text = "";
        }

        private void button_Paint(object sender, PaintEventArgs e)
        { Button btn = (Button)sender;
            if (sender is Button button) // Kiểm tra nếu sender là Button
            {
                // Tạo đường dẫn hình tròn
                GraphicsPath path = new GraphicsPath();
                path.AddEllipse(0, 0, btn.Width, btn.Height);

                // Gán hình dạng mới cho nút
                btn.Region = new Region(path);

                // Vẽ viền cho nút
                Pen pen = new Pen(Color.Black, 2);
                e.Graphics.DrawEllipse(pen, 0, 0, btn.Width - 1, btn.Height - 1);
            }
            else
            {
                MessageBox.Show("Sender is not a button!");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}