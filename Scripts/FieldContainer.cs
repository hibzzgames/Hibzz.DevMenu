using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Hibzz.DevMenu
{
	public class FieldContainer : MonoBehaviour
	{
		[SerializeField] Button ConfirmButton;

		// A reference to rect transform
		protected RectTransform rect;

		void Start()
		{
			// get the rect transform component
			rect = GetComponent<RectTransform>();

			// initialize by keeping it closed
			Close();

			// add some code to unfocus from GUI on click of the confirm button
			ConfirmButton.onClick.AddListener(() => 
			{
				EventSystem.current.SetSelectedGameObject(null);
			});
		}

		// close the fields
		protected internal void Close()
		{
			var size = rect.sizeDelta;
			size.y = 0;
			rect.sizeDelta = size;
		}

		// open the fields
		protected internal void Open()
		{
			var size = rect.sizeDelta;
			size.y = GetExpectedScale();
			rect.sizeDelta = size;
		}

		// re-allign the fields
		protected internal void ReallignFields()
		{
			ConfirmButton.transform.SetAsLastSibling();
		}

		// link what happens on click
		protected internal void LinkOnClick(UnityAction onClick)
		{
			ConfirmButton.onClick.AddListener(onClick);
		}

		/// <summary>
		/// Based on the current children scale, set the expected scale
		/// </summary>
		protected float GetExpectedScale()
		{
			// reset expected scale
			float expectedScale = 0;

			// get vertical layout group
			var vlg = GetComponent<VerticalLayoutGroup>();
			if (vlg is not null)
			{
				expectedScale += vlg.padding.top;
				expectedScale += (transform.childCount) * vlg.spacing;
			}

			// sum all the children height
			for (int i = 0; i < transform.childCount; i++)
			{
				var rect = transform.GetChild(i).GetComponent<RectTransform>();
				expectedScale += rect.sizeDelta.y;
			}

			return expectedScale;
		}
	}
}
