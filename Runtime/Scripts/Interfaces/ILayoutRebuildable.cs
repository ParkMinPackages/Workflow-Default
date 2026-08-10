using System;
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
		public static void RebuildLayoutBottomUp(
			this IRectTransformLayoutRebuildable layoutRebuildable
		) {
			ContentSizeFitter[] contentSizeFitters =
				layoutRebuildable.LayoutRebuildTarget.GetComponentsInChildren<ContentSizeFitter>();
			Array.Sort(contentSizeFitters, CompareByHierarchyDepthDescending);

			foreach (ContentSizeFitter contentSizeFitter in contentSizeFitters) {
				LayoutRebuilder.ForceRebuildLayoutImmediate(
					(RectTransform)contentSizeFitter.transform
				);
			}

			LayoutRebuilder.ForceRebuildLayoutImmediate(
				layoutRebuildable.LayoutRebuildTarget
			);
		}

		static int CompareByHierarchyDepthDescending(
			ContentSizeFitter left,
			ContentSizeFitter right
		) {
			return GetHierarchyDepth(right.transform).CompareTo(GetHierarchyDepth(left.transform));
		}

		static int GetHierarchyDepth(Transform transform) {
			int depth = 0;

			while (transform != null) {
				depth++;
				transform = transform.parent;
			}

			return depth;
		}
	}
}
