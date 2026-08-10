using UnityEngine;
using UnityEngine.UI;

namespace ParkMinPackages.Workflow.Default.Interfaces
{
	public interface IIconView
	{
		void SetIcon(Sprite icon);
	}

	public interface IImageIconView : IIconView
	{
		Image IconImage { get; }
	}

	public interface IRawImageIconView : IIconView
	{
		RawImage IconRawImage { get; }
	}

	public static class IconViewExtensions
	{
		public static TView WithIcon<TView>(
			this TView iconView,
			Sprite icon
		) where TView : IIconView {
			iconView.SetIcon(icon);
			return iconView;
		}
	}

	public static class ImageIconViewExtensions
	{
		public static void SetIconByImage(
			this IImageIconView imageIconView,
			Sprite icon
		) {
			imageIconView.IconImage.sprite = icon;
		}
		public static void SetIconImageActiveByContent(
			this IImageIconView imageIconView
		) {
			IconViewUtility.SetActiveByIcon(imageIconView.IconImage, imageIconView.IconImage.sprite);
		}
	}

	public static class RawImageIconViewExtensions
	{
		public static void SetIconByRawImage(
			this IRawImageIconView rawImageIconView,
			Sprite icon
		) {
			rawImageIconView.IconRawImage.texture = icon?.texture;
		}
		public static void SetIconRawImageActiveByContent(
			this IRawImageIconView rawImageIconView
		) {
			IconViewUtility.SetActiveByIcon(rawImageIconView.IconRawImage, rawImageIconView.IconRawImage.texture);
		}
	}

	internal static class IconViewUtility
	{
		public static void SetActiveByIcon(Component component, Object icon) {
			component.gameObject.SetActive(icon != null);
		}
	}
}
