using UnityEngine;
using UnityEngine.UI;

namespace Hibzz.DevMenu
{
	public class ToggleField : Field
	{
		[Tooltip("A reference to the checkbox toggle")]
		[SerializeField] Toggle toggle;

		public override object GetValue()
		{
			return toggle.isOn;
		}
	}
}
