using UnityEngine;
using TMPro;

namespace Hibzz.DevMenu
{
	public class IntField : Field
	{
		[Tooltip("The reference to the input field")]
		[SerializeField] TMP_InputField inputField;

		public override object GetValue()
		{
			int result = 0;
			int.TryParse(inputField.text, out result);
			return result;
		}
	}
}
