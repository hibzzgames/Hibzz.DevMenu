using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace Hibzz.DevMenu 
{
	[AddComponentMenu("Dev Menu/Card")]
	public class Card : MonoBehaviour
	{
		[SerializeField] protected TMP_Text TitleText;
		[SerializeField] protected Transform DropdownArrow;

		protected FieldContainer fieldContainer;

		/// <summary>
		/// A reference to all the fields that were added to this card
		/// </summary>
		public Fields fields;

		/// <summary>
		/// The title of the card
		/// </summary>
		public string Title { get; protected set; }

		/// <summary>
		/// Is the card currently open?
		/// </summary>
		public bool IsOpen { get; protected set; }

		/// <summary>
		/// Action executed when the apply button is pressed
		/// </summary>
		public UnityAction OnApply
		{
			set => fieldContainer.LinkOnClick(value);
		}

		/// <summary>
		/// Set the cards title
		/// </summary>
		/// <param name="title">The cards title</param>
		public void SetTitle(string title)
		{
			Title = title;
			TitleText.text = Title;
		}

		/// <summary>
		/// Delete the command card
		/// </summary>
		public void Delete()
		{
			Destroy(fieldContainer.gameObject);
			Destroy(gameObject);
		}

		/// <summary>
		/// Toggle the card
		/// </summary>
		public void Toggle()
		{
			IsOpen = !IsOpen;

			// rotate the drop down arrow based on the "open" status
			if(IsOpen)
			{
				DropdownArrow.rotation = Quaternion.Euler(0, 0, 0);
				fieldContainer.Open();
			}
			else
			{
				DropdownArrow.rotation = Quaternion.Euler(0, 0, 90);
				fieldContainer.Close();
			}
		}

		/// <summary>
		/// Show or hide a card
		/// </summary>
		/// <param name="show"><c>True</c> to show and <c>false</c> to hide</param>
		public void Show(bool show)
		{
			fieldContainer.gameObject.SetActive(show);
			gameObject.SetActive(show);
		}

		/// <summary>
		/// Add a field of type of type T to this card if it's possible
		/// </summary>
		/// <typeparam name="T">The type of field to add</typeparam>
		/// <param name="fieldname">The name of the field</param>
		public void Add<T>(string fieldname)
		{
			fields.Add<T>(fieldname, fieldContainer);
		}

		// initialize the card
		protected internal void Initialize()
		{
			var fieldObj = Instantiate(PrefabReferences.Instance.FieldContainerPrefab, transform.parent);
			fieldContainer = fieldObj.GetComponent<FieldContainer>();
			fields = new Fields();
		}
	}
}
