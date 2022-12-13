using System.Collections.Generic;
using UnityEngine;

namespace Hibzz.DevMenu
{
	public class Fields
	{
		Dictionary<string, Field> fields = new Dictionary<string, Field>();

		public object this[string key]
		{
			get => fields[key].GetValue();
		}

		protected internal void Add<T>(string key, FieldContainer container)
		{
			// check if the key is already used or not
			if (fields.ContainsKey(key))
			{
				Debug.LogError($"Key '{key}' already exists. Please use a different key.");
				return;
			}

			Field field = null;

			if (typeof(T) == typeof(int))
			{
				var fieldobj = Object.Instantiate(PrefabReferences.Instance.IntFieldPrefab, container.transform);
				field = fieldobj.GetComponent<IntField>();
			}
			else if (typeof(T) == typeof(float))
			{
				var fieldobj = Object.Instantiate(PrefabReferences.Instance.FloatFieldPrefab, container.transform);
				field = fieldobj.GetComponent<FloatField>();
			}
			else if (typeof(T) == typeof(string))
			{
				var fieldobj = Object.Instantiate(PrefabReferences.Instance.TextFieldPrefab, container.transform);
				field = fieldobj.GetComponent<TextField>();
			}
			else if (typeof(T) == typeof(bool))
			{
				var fieldObj = Object.Instantiate(PrefabReferences.Instance.ToggleFieldPrefab, container.transform);
				field = fieldObj.GetComponent<ToggleField>();
			}
			else if (typeof(T).IsEnum)
			{
				var fieldObj = Object.Instantiate(PrefabReferences.Instance.EnumFieldPrefab, container.transform);
				var enum_field = fieldObj.GetComponent<EnumField>();
				enum_field.SetType<T>();
				field = enum_field;
			}

			if (field == null)
			{
				Debug.LogError($"Incompatible Type: Failed to add field '{key}'. Please report error to author.");
				return;
			}

			// add the key to the list of fields
			fields.Add(key, field);

			// adjust the field ordering and rename the added field
			container.ReallignFields();
			field.SetFieldName(key);
		}
	}
}

