using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using ParkMinPackages.UGUI.Components;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

namespace ParkMinPackages.Workflow.Default.Components.UIs
{
	public class MessageUI : Actor
	{
		public async UniTask Execute(string title, string message, TimeSpan timeSpan, CancellationToken cancellationToken) {
			_titleText.gameObject.SetActive(!string.IsNullOrEmpty(title));
			_titleText.text = title;

			_messageText.gameObject.SetActive(!string.IsNullOrEmpty(message));
			_messageText.text = message;

			_okButton.gameObject.SetActive(false);

			RebuildLayout();

			await _uiActivator.ActiveAsync(cancellationToken: cancellationToken);
			try { await UniTask.Delay(timeSpan, cancellationToken: cancellationToken, cancelImmediately: true); }
			catch (OperationCanceledException e) {
				_uiActivator.DeActiveAsync(cancellationToken: cancellationToken).Forget();
				throw;
			}
			await _uiActivator.DeActiveAsync(cancellationToken: cancellationToken);
		}
		public async UniTask Execute(string title, string message, CancellationToken cancellationToken) {
			_titleText.gameObject.SetActive(!string.IsNullOrEmpty(title));
			_titleText.text = title;

			_messageText.gameObject.SetActive(!string.IsNullOrEmpty(message));
			_messageText.text = message;

			_okButton.gameObject.SetActive(true);

			RebuildLayout();

			await _uiActivator.ActiveAsync(cancellationToken: cancellationToken);
			await _okButton.OnClickAsync(cancellationToken: cancellationToken);
			await _uiActivator.DeActiveAsync(cancellationToken: cancellationToken);
		}

		public Button OKButton
		{
			get { return _okButton; }
		}

		protected override void Awake() {
			base.Awake();
			_uiActivator = GetComponent<UIActivator>();
		}

		[SerializeField, Required] RectTransform _panel;
		[SerializeField, Required] Text _titleText;
		[SerializeField, Required] Text _messageText;
		[SerializeField, Required] Button _okButton;
		UIActivator _uiActivator;

		void RebuildLayout() {
			LayoutRebuilder.ForceRebuildLayoutImmediate(_titleText.rectTransform);
			LayoutRebuilder.ForceRebuildLayoutImmediate(_messageText.rectTransform);
			LayoutRebuilder.ForceRebuildLayoutImmediate(_panel);
		}
	}
}