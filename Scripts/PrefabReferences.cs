using Hibzz.Singletons;
using UnityEngine;

namespace Hibzz.DevMenu
{
	public class PrefabReferences : ScriptableSingleton<PrefabReferences>
	{
		public GameObject CardPrefab;
		public GameObject FieldContainerPrefab;

		public GameObject TextFieldPrefab;
		public GameObject FloatFieldPrefab;
		public GameObject IntFieldPrefab;
		public GameObject EnumFieldPrefab;
		public GameObject ToggleFieldPrefab;
	}
}

