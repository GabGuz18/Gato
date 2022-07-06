using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gato
{
	public partial class Form1 : Form
	{
		#region variables

		Gato gato = new Gato();
		public int[,] matriz = new int[3, 3];
		public int ganador = -1;

		#endregion

		public Form1()
		{
			InitializeComponent();
			gato.iniciarPartida();
			matriz = gato.matriz;
		}

		public void Ganador()
		{
			int[] ultMov = gato.ultimoMov;

			if (ultMov[0] == 0 && ultMov[1] == 0)
			{
				button1.Text = "0";
				button1.BackColor = Color.LightPink;
			}

			if (ultMov[0] == 0 && ultMov[1] == 1)
			{

				button2.Text = "0";
				button2.BackColor = Color.LightPink;
			}

			if (ultMov[0] == 0 && ultMov[1] == 2)
			{

				button3.Text = "0";
				button3.BackColor = Color.LightPink;
			}

			if (ultMov[0] == 1 && ultMov[1] == 0)
			{

				button6.Text = "0";
				button6.BackColor = Color.LightPink;
			}

			if (ultMov[0] == 1 && ultMov[1] == 1)
			{

				button5.Text = "0";
				button5.BackColor = Color.LightPink;
			}

			if (ultMov[0] == 1 && ultMov[1] == 2)
			{

				button4.Text = "0";
				button4.BackColor = Color.LightPink;
			}

			if (ultMov[0] == 2 && ultMov[1] == 0)
			{

				button9.Text = "0";
				button9.BackColor = Color.LightPink;
			}

			if (ultMov[0] == 2 && ultMov[1] == 1)
			{

				button8.Text = "0";
				button8.BackColor = Color.LightPink;
			}

			if (ultMov[0] == 2 && ultMov[1] == 2)
			{

				button7.Text = "0";
				button7.BackColor = Color.LightPink;
			}


			if (ganador == 0) MessageBox.Show("Ganaste!");


			if (ganador == 1) MessageBox.Show("Perdiste...");


			if (ganador == -1 && gato.gato())
				MessageBox.Show("Empate!");
		}

		public void Botones(int x, int y, Button btn)
		{
			if (matriz[x, y] == -1)
			{
				gato.posicion(x, y);
				ganador = gato.ganarPartida();
				Ganador();
				btn.Text = "X";
				btn.BackColor = Color.LightCyan;
			}
		}

		private void button1_Click_1(object sender, EventArgs e)
		{
			Botones(0, 2, button1);
		}

		private void button2_Click_1(object sender, EventArgs e)
		{
			Botones(1, 2, button2);
		}

		private void button3_Click_1(object sender, EventArgs e)
		{
			Botones(2, 2, button3);
		}

		private void button4_Click(object sender, EventArgs e)
		{
			Botones(0, 1, button4);
		}

		private void button5_Click(object sender, EventArgs e)
		{
			Botones(1, 1, button5);
		}

		private void button6_Click(object sender, EventArgs e)
		{
			Botones(2, 1, button6);
		}

		private void button7_Click_1(object sender, EventArgs e)
		{
			Botones(0, 0, button7);
		}

		private void button8_Click(object sender, EventArgs e)
		{
			Botones(1, 0, button8);
		}

		private void button9_Click(object sender, EventArgs e)
		{
			Botones(2, 0, button9);
		}

		private void button10_Click_1(object sender, EventArgs e)
		{
			gato = new Gato();
			gato.iniciarPartida();
			matriz = gato.matriz;
			ganador = -1;

			button1.BackColor = Color.Gray;
			button2.BackColor = Color.Gray;

			button3.BackColor = Color.Gray;
			button4.BackColor = Color.Gray;

			button5.BackColor = Color.Gray;
			button6.BackColor = Color.Gray;

			button7.BackColor = Color.Gray;
			button8.BackColor = Color.Gray;
			button9.BackColor = Color.Gray;
		}
	}
}
