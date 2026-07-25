using System.Threading;
using Cysharp.Threading.Tasks;
using ParkMinPackages.UGUI.Components;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

namespace ParkMinPackages.Workflow.Default.Components.UIs
{
	public class YesOrNoUI : Actor
	{
		public enum YesOrNo
		{
			Yes,
			No
		}

		public async UniTask<YesOrNo> Execute(string title, string message, CancellationToken cancellationToken) {
			_titleText.gameObject.SetActive(!string.IsNullOrEmpty(title));
			_titleText.text = title;

			_messageText.gameObject.SetActive(!string.IsNullOrEmpty(message));
			_messageText.text = message;

			RebuildLayout();

			await _uiActivator.ActiveAsync(cancellationToken: cancellationToken);
			using CancellationTokenSource buttonCts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
			int buttonIndex = await UniTask.WhenAny(
				_yesButton.OnClickAsync(buttonCts.Token),
				_noButton.OnClickAsync(buttonCts.Token)
			);
			buttonCts.Cancel();
			await _uiActivator.DeActiveAsync(cancellationToken: cancellationToken);
			return buttonIndex == 0 ? YesOrNo.Yes : YesOrNo.No;
		}

		public Button YesButton
		{
			get { return _yesButton; }
		}
		public Button NoButton
		{
			get { return _noButton; }
		}

		protected override void Awake() {
			base.Awake();
			_uiActivator = GetComponent<UIActivator>();
		}

		[SerializeField, Required] RectTransform _panel;
		[SerializeField, Required] Text _titleText;
		[SerializeField, Required] Text _messageText;
		[SerializeField, Required] Button _yesButton;
		[SerializeField, Required] Button _noButton;
		UIActivator _uiActivator;

		void RebuildLayout() {
			LayoutRebuilder.ForceRebuildLayoutImmediate(_titleText.rectTransform);
			LayoutRebuilder.ForceRebuildLayoutImmediate(_messageText.rectTransform);
			LayoutRebuilder.ForceRebuildLayoutImmediate(_panel);
		}
	}
}