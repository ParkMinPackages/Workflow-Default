using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ParkMinPackages.Workflow.Default.Interfaces
{
	public interface IMessageView
	{
		public void SetMessage(string title, string message);
		public string GetTitle();
		public string GetMessage();

		protected static class Utility
		{
			public static void SetActiveByContent(Component component, string content) {
				component.gameObject.SetActive(!string.IsNullOrEmpty(content));
			}
		}
	}

	public interface ITextMessageView : IMessageView
	{
		public Text TitleText { get; }
		public Text MessageText { get; }

		public static void SetMessage(ITextMessageView view, string title, string message) {
			view.TitleText.text = title;
			view.MessageText.text = message;
		}
		public static void SetActiveByContent(ITextMessageView view) {
			Utility.SetActiveByContent(view.TitleText, view.TitleText.text);
			Utility.SetActiveByContent(view.MessageText, view.MessageText.text);
		}
		public static string GetTitle(ITextMessageView view) {
			return view.TitleText.text;
		}
		public static string GetMessage(ITextMessageView view) {
			return view.MessageText.text;
		}
	}

	public interface ITMPTextMessageView : IMessageView
	{
		public TMP_Text TitleText { get; }
		public TMP_Text MessageText { get; }

		public static void SetMessage(ITMPTextMessageView view, string title, string message) {
			view.TitleText.text = title;
			view.MessageText.text = message;
		}
		public static void SetActiveByContent(ITMPTextMessageView view) {
			Utility.SetActiveByContent(view.TitleText, view.TitleText.text);
			Utility.SetActiveByContent(view.MessageText, view.MessageText.text);
		}
		public static string GetTitle(ITMPTextMessageView view) {
			return view.TitleText.text;
		}
		public static string GetMessage(ITMPTextMessageView view) {
			return view.MessageText.text;
		}
	}

	public static class IMessageViewExtensions
	{
		public static TView WithMessage<TView>(
			this TView messageView,
			string title,
			string message
		) where TView : IMessageView {
			messageView.SetMessage(title, message);
			return messageView;
		}
	}
}
