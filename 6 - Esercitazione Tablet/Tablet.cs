//using System;

using System;

namespace _12_10_23
{
	public class Tablet
	{
		private string _marca;
		private float _speed;
		private float _schermo;
		private int _batteria;

		/**
		 * <summary>
		 * Ottiene o imposta la marca.
		 * </summary>
		 * <remarks>
		 * Se vuota genera un errore.
		 * </remarks>
		 */
		public string Marca
		{
			get { return _marca; }
			set { _marca = string.IsNullOrEmpty(value) ? "inserimento non valido, [throw]" : value; }
		}

		/**
		 * <summary>
		 * Ottiene o imposta la velocità in GHz
		 * </summary>
		 * <remarks>
		 * I valori vanno da 0.5 a 4.0 compresi.
		 * </remarks>
		 */
		public float Speed
		{
			get { return _speed; }
			set { _speed = IsInRange(value, 0.5f, 4.0f) ? value : 0f; }
		}

		/**
		 * <summary>
		 * Ottiene o imposta la dimensione dello schermo in pollici
		 * </summary>
		 * <remarks>
		 * I valori vanno da 4.5 a 22.0 compresi.
		 * </remarks>
		 */
		public float Schermo
		{
			get { return _schermo; }
			set { _schermo = IsInRange(value, 4.5f, 22.0f) ? value : 0f; }
		}

		/**
		 * <summary>
		 * Ottiene o imposta la durata della batteria in mAh
		 * </summary>
		 * <remarks>
		 * I valori vanno da 1350 a 20˙000 compresi.
		 * </remarks>
		 */
		public int Batteria
		{
			get { return _batteria; }
			set { _batteria = IsInRange(value, 1350, 20000) ? value : 0; }
		}

		/**
		 * <summary>
		 * Inizializza una nuova istanza della classe Tablet usando i valori specificati.
		 * </summary>
		 * <remarks> <list type="bullet">
		 *  <item> Marca : Se vuota genera un errore. </item>
		 *  <item> Speed : I valori vanno da 0.5 a 4.0 compresi. </item>
		 *  <item> Schermo : I valori vanno da 4.5 a 22.0 compresi. </item>
		 *  <item> Batteria : I valori vanno da 1350 a 20˙000 compresi. </item>
		 * </list>
		 * Per i dettagli dei singoli parametri vedere le proprietà dedicate. </remarks>
		 */
		public Tablet(string marca = "marca generica", float speed = 0.5f, float schermo = 4.5f, int batteria = 1350)
		{
			Marca = marca;
			Speed = speed;
			Schermo = schermo;
			Batteria = batteria;

			if(_marca == "inserimento non valido, [throw]" || _speed * _schermo * _batteria == 0f)
			{
				throw new ArgumentException("Almeno un attributo inserito non valido");
			}
		}

		static public bool IsInRange(float value, float min, float max)
		{
			if(value < min) return false;
			if(value > max) return false;
			return true;
		}

		static public bool IsInRange(int value, int min, int max)
		{
			if(value < min) return false;
			if(value > max) return false;
			return true;
		}

		public string LeggiDati()
		{
			return $" - Marca: \"{_marca}\"\n - Velocità: {_speed} GHz\n - Batteria: {_batteria} mAh\n - Schermo: {_schermo}\"\n - Punteggio: {Punteggio()}";
		}

		public void StampaDati(bool endLine = true)
		{
			//if(endLine) Console.WriteLine(LeggiDati()); else Console.Write(LeggiDati());
			Console.Write("Le specifiche del tablet sono le seguenti:\n" + LeggiDati() + (endLine ? Environment.NewLine : ""));
		}

		/**
		 * <summary>
		 * Calcola il punteggio del tablet.
		 * </summary>
		 * <remarks> 
		 * Il punteggio è così calcolato :
		 * <list type="bullet">
		 *  <item> Marca : Non influisce sul punteggio. </item>
		 *  <item> Speed : 10 punti per ogni GHz. </item>
		 *  <item> Schermo : 1 punto per ogni pollice. </item>
		 *  <item> Batteria : 1 punto per ogni migliaio di mAh. </item>
		 * </list> </remarks>
		 */
		public float Punteggio()
		{
			return _speed * 10f + _schermo + _batteria/1000f;
		}
	}
}
