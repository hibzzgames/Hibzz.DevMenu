using TMPro;
using UnityEngine;

namespace Hibzz.DevMenu
{
	public abstract class Field : MonoBehaviour
	{
		[SerializeField] TMP_Text FieldNameText;

		public abstract object GetValue();

		protected internal void SetFieldName(string fieldname)
		{
			FieldNameText.text = fieldname;
		}
	}
}
