using UnityEngine;
using TMPro;

namespace Hibzz.DevMenu
{
	public class FloatField : Field
	{
		[Tooltip("A reference to an input field that accepts a decimal value")]
		[SerializeField] TMP_InputField inputField;

		public override object GetValue()
		{
			float result = 0;
			float.TryParse(inputField.text, out result);
			return result;
		}
	}
}
