using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12_10_23
{
	public class Tablets
	{
		private Tablet[] elencoTablets;
		private short tabletsCounter;

		public Tablets(int tot = 5)
		{
			elencoTablets = new Tablet[tot];
			tabletsCounter = 0;
		}

		public Tablet this[int index]
		{
			get
			{
				if(index >= 0 && index < tabletsCounter)
					return elencoTablets[index];
				throw new IndexOutOfRangeException("L'indice specificato non è valido.");
			}
			set
			{
				if(index >= 0 && index < tabletsCounter)
					elencoTablets[index] = value;
				else
					throw new IndexOutOfRangeException("L'indice specificato non è valido.");
			}
		}

		public Tablet[] GetElenco() { return elencoTablets; }

		private static int GetLength(int tot)
		{
			if(tot < 5) return 5;
			return tot/5 * 5 + 5;
		}

		private static void Resize(ref Tablet[] array, int newSize)
		{
			if(array.Length != newSize)
			{
				Tablet[] array2 = new Tablet[newSize];
				if(array.Length < newSize) //se newsize è più grande, copia fino ad array.length e il resto rimane default
					for(int i = 0; i < array.Length; i++)
						array2[i] = array[i];
				else //se newsize è più piccolo copia fino a newsize
					for(int i = 0; i < newSize; i++)
						array2[i] = array[i];
				array = array2;
			}
		}

		public void AggiungiTablet(Tablet tablet)
		{
			if(tabletsCounter < elencoTablets.Length)
			{
				elencoTablets[tabletsCounter] = tablet;
				tabletsCounter++;
			}
			else
			{
				//throw new InvalidOperationException("L'elenco dei voti è pieno.");
				//resize
				Resize(ref elencoTablets, GetLength(tabletsCounter));
				AggiungiTablet(tablet);
			}
		}

		public float PunteggioMedio()
		{
			float sum = 0.0f;
			for(int i = 0; i < tabletsCounter; i++)
				sum += elencoTablets[i].Punteggio();

			return sum / tabletsCounter;
		}

		public string TrovaELeggiDatiMigliorTablet()
		{
			float best = elencoTablets[0].Punteggio();
			int ind = 0;
			for(int i = 1; i < tabletsCounter; i++)
			{
				float punteggio = elencoTablets[i].Punteggio();
				if(punteggio > best)
				{
					best = punteggio;
					ind = i;
				}
			}
			return elencoTablets[ind].LeggiDati();
		}

		public string TrovaELeggiDatiPeggiorTablet()
		{
			float worst = elencoTablets[0].Punteggio();
			int ind = 0;
			for(int i = 1; i < tabletsCounter; i++)
			{
				float punteggio = elencoTablets[i].Punteggio();
				if(punteggio < worst)
				{
					worst = punteggio;
					ind = i;
				}
			}
			return elencoTablets[ind].LeggiDati();
		}

	}
}
