using System;
using UnityEngine;
using TMPro;
using System.Linq;

namespace Hibzz.DevMenu
{
	public class EnumField : Field
	{
		[Tooltip("A reference to the dropdown UI element")]
		[SerializeField] TMP_Dropdown Dropdown;

		protected Type enumType;

		public override object GetValue()
		{
			var selected_string = Dropdown.options[Dropdown.value].text;
			return Enum.Parse(enumType, selected_string);
		}

		// Assuming that the given type is guaranteed to be an enum
		protected internal void SetType<T>()
		{
			enumType = typeof(T);
			var names = Enum.GetNames(enumType);
			Dropdown.AddOptions(names.ToList());
		}
	}
}
