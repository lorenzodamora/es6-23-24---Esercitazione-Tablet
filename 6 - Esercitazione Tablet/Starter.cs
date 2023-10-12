using System;

namespace _12_10_23
{
	internal class Starter
	{
		/*
		 * o Si vogliono confrontare 5 diversi modelli di tablet.
		 * x Le caratteristiche dei tablet utili per la soluzione di questo problema sono:
		 * x la marca, la velocità (espressa in GHz), la dimensione dello schermo (espresso in pollici) e 
		 * x la durata della batteria (espressa in mAh, milliampere-ora).
		 * x Ogni caratteristica viene codificata come un attributo privato della classe.
		 * x I valori di questi attributi vengono letti con il metodo leggiDati e 
		 * x vengono visualizzati con il metodo stampaDati.
		 * x A ogni modello viene assegnato un punteggio nel seguente modo: 
		 * x per la velocità del processore vengono assegnati 10 punti per ogni GHz, 
		 * x per la dimensione dello schermo è assegnato un punto per ogni pollice, 
		 * x per la durata della batteria è assegnato un punto per ogni migliaio di mAh. 
		 * x Dopo aver inserito i dati dei 5 modelli, calcola il punteggio medio assegnato ai tablet 
		 * x e mostra i dati del tablet migliore e di quello peggiore.
		 * x Il punteggio viene calcolato con il metodo punteggio.
		 */

		static Random rnd;

		static void Main()
		{
			//new Tablet("a", 1f, 10f, 10000).StampaDati();

			Console.WriteLine("Schermo intero? (f11)");
			Console.ReadKey();
			Console.Clear();
			Console.WriteLine("ho già riempito randomicamente con 5 nuovi tablet e le loro specifiche\n");

			// Lista di marche(30)
			string[] marche =
			{
				"Acer", "Alcatel", "Apple", "Archos", "Asus", "Blackview", "BQ", "Chuwi",
				"Cubot", "Doogee", "FNF", "Philips", "Google", "Honor", "Sony", "HP",
				"Samsung", "Huawei", "Lenovo", "LG", "Microsoft", "Motorola", "Nokia", "Nubia",
				"Oneplus", "Oppo", "Oukitel", "Realme", "Xiaomi", "Voyo"
			};

			Tablets tablets = new Tablets(5);
			rnd = new Random();

			for(int i = 0; i < 5; i++)
			{
				tablets.AggiungiTablet(new Tablet(marche[rnd.Next(30)], RandomFloat(0.5f,4.0f), RandomFloat(4.5f,22.0f), rnd.Next(1350, 20000+1)));
			}

			Console.WriteLine($"Il punteggio medio dei 5 tablets è: {tablets.PunteggioMedio()}\n");
			Console.WriteLine($"Il migliore dei 5 tablets è:\n{tablets.TrovaELeggiDatiMigliorTablet()}\n");
			Console.WriteLine($"Il peggiore dei 5 tablets è:\n{tablets.TrovaELeggiDatiPeggiorTablet()}\n");

			Console.WriteLine("\n\nFINE\n");
			Console.ReadKey(true);
		}

		// un decimale
		static float RandomFloat(float start, float end)
		{
			int _start = (int)(start * 10);
			int _end = (int)(end * 10);
			int rand = rnd.Next(_start, _end+1);
			return rand / 10f;
		}
	}
}
