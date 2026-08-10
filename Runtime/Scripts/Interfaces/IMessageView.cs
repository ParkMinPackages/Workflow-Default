using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ParkMinPackages.Workflow.Default.Interfaces
{
	public interface IMessageView
	{
		void SetMessage(string title, string message);
	}

	public interface ITextMessageView : IMessageView
	{
		Text TitleText { get; }
		Text MessageText { get; }
	}

	public interface ITMPTextMessageView : IMessageView
	{
		TMP_Text TitleText { get; }
		TMP_Text MessageText { get; }
	}

	public static class MessageViewExtensions
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

	public static class TextMessageViewExtensions
	{
		public static void SetMessageByText(
			this ITextMessageView textMessageView,
			string title,
			string message
		) {
			textMessageView.TitleText.text = title;
			textMessageView.MessageText.text = message;
		}
		public static void SetMessageActiveByContent(this ITextMessageView textMessageView) {
			MessageViewUtility.SetActiveByContent(textMessageView.TitleText, textMessageView.TitleText.text);
			MessageViewUtility.SetActiveByContent(textMessageView.MessageText, textMessageView.MessageText.text);
		}
	}

	public static class TMPTextMessageViewExtensions
	{
		public static void SetMessageByTMPText(
			this ITMPTextMessageView tmpTextMessageView,
			string title,
			string message
		) {
			tmpTextMessageView.TitleText.text = title;
			tmpTextMessageView.MessageText.text = message;
		}
		public static void SetMessageActiveByContent(this ITMPTextMessageView tmpTextMessageView) {
			MessageViewUtility.SetActiveByContent(tmpTextMessageView.TitleText, tmpTextMessageView.TitleText.text);
			MessageViewUtility.SetActiveByContent(tmpTextMessageView.MessageText, tmpTextMessageView.MessageText.text);
		}
	}

	internal static class MessageViewUtility
	{
		public static void SetActiveByContent(Component component, string content) {
			component.gameObject.SetActive(!string.IsNullOrEmpty(content));
		}
	}
}
