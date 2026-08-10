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
			ContentSizeFitter[] contentSizeFitters =
				layoutRebuildable.LayoutRebuildTarget.GetComponentsInChildren<ContentSizeFitter>();

			foreach (ContentSizeFitter contentSizeFitter in contentSizeFitters) {
				LayoutRebuilder.ForceRebuildLayoutImmediate(
					(RectTransform)contentSizeFitter.transform
				);
			}

			LayoutRebuilder.ForceRebuildLayoutImmediate(
				layoutRebuildable.LayoutRebuildTarget
			);
		}
	}
}
