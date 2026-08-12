using System;
using UnityEngine;
using UnityEngine.UI;

namespace ParkMinPackages.Workflow.Default.Interfaces
{
	public interface ILayoutRebuildable
	{
		public void RebuildLayout();
	}

	public interface IRectTransformLayoutRebuildable : ILayoutRebuildable
	{
		public RectTransform RebuildLayoutTarget { get; }

		public static void RebuildLayout(IRectTransformLayoutRebuildable layoutRebuildable) {
			ContentSizeFitter[] contentSizeFitters = layoutRebuildable.RebuildLayoutTarget.GetComponentsInChildren<ContentSizeFitter>();
			Array.Sort(contentSizeFitters, CompareByHierarchyDepthDescending);

			foreach (ContentSizeFitter contentSizeFitter in contentSizeFitters) {
				LayoutRebuilder.ForceRebuildLayoutImmediate(
					(RectTransform)contentSizeFitter.transform
				);
			}

			LayoutRebuilder.ForceRebuildLayoutImmediate(layoutRebuildable.RebuildLayoutTarget);
		}

		protected static int CompareByHierarchyDepthDescending(
			ContentSizeFitter left,
			ContentSizeFitter right
		) {
			return GetHierarchyDepth(right.transform).CompareTo(GetHierarchyDepth(left.transform));
		}

		protected static int GetHierarchyDepth(Transform transform) {
			int depth = 0;

			while (transform != null) {
				depth++;
				transform = transform.parent;
			}

			return depth;
		}
	}

	public static class ILayoutRebuildableExtensions
	{
		public static T WithRebuildLayout<T>(this T layoutRebuildable) where T : ILayoutRebuildable {
			layoutRebuildable.RebuildLayout();
			return layoutRebuildable;
		}
	}
}
