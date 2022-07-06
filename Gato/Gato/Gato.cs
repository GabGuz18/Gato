using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gato
{
	class Gato
	{

		#region Variables

		public int[,] matriz = new int[3, 3];
		public int ganador;

		public int[] ultimoMov = new int[3];

		#endregion

		public void iniciarPartida()
		{
			for(int x = 0; x < matriz.GetLength(0); x++)
			{
				for(int y = 0; y < matriz.GetLength(1); y++)
				{
					matriz[x, y] = -1;
				} 
			}
			ganador = -1;
		}

		public void posicion(int x, int y)
		{
			if(x >= 0 && x < 3 && y >= 0 && y < 3 && matriz[x,y] == -1 && ganador == -1)
			{
				matriz[x, y] = 0;
				ganador = ganarPartida();
				mueveIA();
			}
		}

		public int ganarPartida()
		{
			int aux = -1;

			if(matriz[0,0] != -1 && matriz[0,0] == matriz[1,1] && matriz[0,0] == matriz[2, 2])
			{
				aux = matriz[0, 0];
			}

			if (matriz[0, 2] != -1 && matriz[0, 2] == matriz[1, 1] && matriz[0, 0] == matriz[2, 0])
			{
				aux = matriz[0, 2];
			}

			for (int x = 0; x < matriz.GetLength(0); x++){
				if (matriz[x, 0] != -1 && matriz[x, 0] == matriz[x, 1] && matriz[x, 0] == matriz[x, 2])
				{
					aux = matriz[x, 0];
				}
				if (matriz[0, x] != -1 && matriz[0, x] == matriz[1, x] && matriz[0, x] == matriz[2, x])
				{
					aux = matriz[0, x];
				}
			}

			return aux;
		}

		public bool gato()
		{
			bool lleno = true;

			for (int x = 0; x < matriz.GetLength(0); x++)
			{
				for (int y = 0; y < matriz.GetLength(1); y++)
				{
					if (matriz[x, y] == -1)
					{
						lleno = false;
					}
				}
			}

			return lleno;
		}

		public bool Fin()
		{
			bool fin = false;

			if(gato() || ganarPartida() != -1)
			{
				fin = true;
			}

			return fin;
		}

		public void mueveIA()
		{
			if (!Fin())
			{
				int fila = 0;
				int columna = 0;
				int v = Int32.MinValue;
				int aux;

				for(int x = 0; x < matriz.GetLength(0); x++)
				{
					for (int y = 0; y < matriz.GetLength(1); y++)
					{
						if(matriz[x,y] == -1)
						{
							matriz[x, y] = 1;
							aux = Minimo();
							if(aux > v)
							{
								v = aux;
								fila = x;
								columna = y;
							}

							matriz[x, y] = -1;
						}
					}
				}

				matriz[fila, columna] = 1;
				ultimoMov[0] = fila;
				ultimoMov[1] = columna;

			}
		}

		private int Maximo()
		{
			if (Fin())
			{
				if(ganarPartida() != -1)
				{
					return -1;
				}
				else
				{
					return 0;
				}
			}

			int v = Int32.MinValue;
			int aux;

			for (int x = 0; x < matriz.GetLength(0); x++)
			{
				for (int y = 0; y < matriz.GetLength(1); y++)
				{
					if (matriz[x, y] == -1)
					{
						matriz[x, y] = 1;
						aux = Minimo();
						if (aux > v)
						{
							v = aux;
						}

						matriz[x, y] = -1;
					}
				}
			}

			return v;
		}

		private int Minimo()
		{
			if (Fin())
			{
				if (ganarPartida() != -1)
				{
					return 1;
				}
				else
				{
					return 0;
				}
			}

			int v = Int32.MaxValue;
			int aux;

			for (int x = 0; x < matriz.GetLength(0); x++)
			{
				for (int y = 0; y < matriz.GetLength(1); y++)
				{
					if (matriz[x, y] == -1)
					{
						matriz[x, y] = 0;
						aux = Maximo();
						if (aux < v)
						{
							v = aux;
						}

						matriz[x, y] = -1;
					}
				}
			}

			return v;
		}
	}
}
