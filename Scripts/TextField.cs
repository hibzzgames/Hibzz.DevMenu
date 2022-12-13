using TMPro;
using UnityEngine;

namespace Hibzz.DevMenu
{
	public class TextField : Field
	{
		[Tooltip("A reference to a text input field")]
		[SerializeField] TMP_InputField inputField;

		public override object GetValue()
		{
			return inputField.text;
		}
	}
}

