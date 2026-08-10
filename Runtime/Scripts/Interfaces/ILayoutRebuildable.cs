using UnityEngine;
using UnityEngine.UI;

namespace ParkMinPackages.Workflow.Default.Interfaces
{
	public interface ILayoutRebuildable
	{
		void RebuildLayout();
	}

	public interface IRectTransformLayoutRebuildable : ILayoutRebuildable
	{
		RectTransform LayoutRebuildTarget { get; }
	}

	public static class RectTransformLayoutRebuildableExtensions
	{
		public static void RebuildLayoutByRectTransformTwice(
			this IRectTransformLayoutRebuildable layoutRebuildable
		) {
			LayoutRebuilder.ForceRebuildLayoutImmediate(layoutRebuildable.LayoutRebuildTarget);
			LayoutRebuilder.ForceRebuildLayoutImmediate(layoutRebuildable.LayoutRebuildTarget);
		}
	}
}
