using Hibzz.Core.Singletons;
using UnityEngine;

namespace Hibzz.DevMenu
{
	[AddComponentMenu("Dev Menu/Prefab References")]
	public class PrefabReferences : Singleton<PrefabReferences>
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

