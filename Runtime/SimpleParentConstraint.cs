using UnityEngine;

namespace GameUtils
{
	[ExecuteAlways]
	public class SimpleParentConstraint : MonoBehaviour
	{
		[SerializeField] private Transform _target;

		void OnEnable() {
			if(_target != null) {
				SetTransform();
			}
		}

		private void SetTransform() {
			transform.position = _target.position;
			transform.rotation = _target.rotation;
		}

		public void SetTarget(Transform target) {
			_target = target;
			SetTransform();
		}

		void LateUpdate() {
			if(_target != null) {
				SetTransform();
			}
		}
	}
}