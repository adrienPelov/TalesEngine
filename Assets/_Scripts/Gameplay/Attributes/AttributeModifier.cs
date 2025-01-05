using UnityEngine;

namespace TalesEngine
{
	public enum EAttributeModifier
	{
		None = 0,
		
	}

	public class AttributeModifier
	{
		[Header("Settings")]
		[SerializeField]
		private bool _bPermanent = false;
		public bool Permanent => _bPermanent;
		[SerializeField]
		private float _durationBase = 1f;

		[SerializeField]
		private bool _bIsValue = true;
		public bool IsValue => _bIsValue;
		[SerializeField]
		[Tooltip("Value added to Attribute [CURRENT] value (CAN be <= 0)")]
		private float _value = 0f;
		public float Value => _value;
		[SerializeField]
		[Tooltip("% added of Attribute [BASE] value (CAN be <= 0)")]
		private float _multiplier = 0f;
		public float Multiplier => _multiplier;

		[Header("Cached Variables")]
		[SerializeField]
		private float _duration;
		public float Duration => _duration;

		#region Attribute Modifier Methods

		///////////////////////////////////
		/// Attribute Modifier Methods
		///////////////////////////////////

		public virtual void InitModifier()
		{
			_duration = _durationBase;
		}

		#endregion
	}
}
