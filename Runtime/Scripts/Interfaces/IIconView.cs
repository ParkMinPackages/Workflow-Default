using UnityEngine;
using UnityEngine.UI;

namespace ParkMinPackages.Workflow.Default.Interfaces
{
	public interface IIconView<TIcon> where TIcon : Object
	{
		public void SetIcon(TIcon icon);
		public TIcon GetIcon();

		protected static class Utility
		{
			public static void SetActiveByIcon(Component component, Object icon) {
				component.gameObject.SetActive(icon != null);
			}
		}
	}

	public interface IImageIconView : IIconView<Sprite>
	{
		public Image ImageIcon { get; }

		public static void SetIcon(IImageIconView view, Sprite icon) {
			view.ImageIcon.sprite = icon;
		}
		public static void SetActiveByIcon(IImageIconView view) {
			Utility.SetActiveByIcon(view.ImageIcon, view.ImageIcon.sprite);
		}
		public static Sprite GetIcon(IImageIconView view) {
			return view.ImageIcon.sprite;
		}
	}

	public interface IRawImageIconView : IIconView<Texture>
	{
		public RawImage RawImageIcon { get; }

		public static void SetIcon(IRawImageIconView view, Texture icon) {
			view.RawImageIcon.texture = icon;
		}
		public static void SetActiveByIcon(IRawImageIconView view) {
			Utility.SetActiveByIcon(view.RawImageIcon, view.RawImageIcon.texture);
		}
		public static Texture GetIcon(IRawImageIconView view) {
			return view.RawImageIcon.texture;
		}
	}

	public static class IIconViewExtensions
	{
		public static TView WithIcon<TView, TIcon>(
			this TView iconView,
			TIcon icon
		) where TView : IIconView<TIcon>
			where TIcon : Object {
			iconView.SetIcon(icon);
			return iconView;
		}
	}
}