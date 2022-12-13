using System.Collections.Generic;
using UnityEngine;
using Hibzz.Core.Singletons;

namespace Hibzz.DevMenu
{
	[AddComponentMenu("Dev Menu/DevMenu")]
	public class DevMenu : Singleton<DevMenu>
	{
		#region Gameobject References

		[Header("Primary References")]
		[SerializeField] protected GameObject ContentObject;

		#endregion

		// A list of cards added to the dev menu
		protected List<Card> cards = new List<Card>();

		// is the developer menu open?
		protected bool p_isOpen = false;

		// interact with the developer  menu
		protected void p_open(bool open)
		{
			p_isOpen = open;
			gameObject.SetActive(open);
		}

		// add to the developer menu with the given title
		protected Card p_add(string title)
		{
			// instantiate a new title card
			var cardObj = Instantiate(PrefabReferences.Instance.CardPrefab, ContentObject.transform);

			// get the component and set the card's title
			var card = cardObj.GetComponent<Card>();
			card.Initialize();
			card.SetTitle(title);

			// add to the list and return the card so the user may proceed
			// to configure the card more
			cards.Add(card);
			return card;
		}

		// delete the given card
		protected bool p_delete(Card card)
		{
			// when the given card is null, return false
			if(card == null) { return false; }

			// remove the card from the list and return false
			cards.Remove(card);
			card.Delete();

			// notify that the card was deleted
			return true;
		}

		// delete the card with the given name
		protected bool p_delete(string cardTitle)
		{
			var card = cards.Find((card) => { return card.Title == cardTitle; });
			return p_delete(card);
		}

		// filter the cards available
		public void Filter(string value)
		{
			// if the elements are empty then show everything
			if(string.IsNullOrWhiteSpace(value))
			{
				foreach(var card in cards)
				{
					card.Show(true);
				}
				return;
			}

			// if the title has the value, then show it... else hide it
			foreach(var card in cards)
			{
				if (card.Title.Contains(value, System.StringComparison.OrdinalIgnoreCase))
				{
					card.Show(true);
				}
				else
				{
					card.Show(false);
				}
			}
		}

		#region Easy to access public static functions and properties

		/// <summary>
		/// Open the developer menu
		/// </summary>
		public static void Open() => Instance.p_open(true);

		/// <summary>
		/// Close the developer menu
		/// </summary>
		public static void Close() => Instance.p_open(false);

		/// <summary>
		/// Is the developer menu open?
		/// </summary>
		public static bool IsOpen { get { return Instance.p_isOpen; } }

		/// <summary>
		/// Add a command card with the given title
		/// </summary>
		/// <param name="title">The title of the command card</param>
		/// <returns>Returns the command card for further customization</returns>
		public static Card Add(string title) => Instance.p_add(title);

		/// <summary>
		/// Delete the given card
		/// </summary>
		/// <param name="card">The card to delete</param>
		/// <returns>Was the card successfully deleted?</returns>
		public static bool Delete(Card card) => Instance.p_delete(card);

		/// <summary>
		/// Delete the card with the given name
		/// </summary>
		/// <param name="title">The name of the card to delete</param>
		/// <returns>Was the card deleted successfully?</returns>
		public static bool Delete(string title) => Instance.p_delete(title);

		#endregion
	}
}
