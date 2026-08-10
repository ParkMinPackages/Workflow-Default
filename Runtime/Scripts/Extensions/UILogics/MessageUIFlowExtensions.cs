using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using ParkMinPackages.Workflow.Default.Components.UIs;
using ParkMinPackages.Workflow.Default.Interfaces;

namespace ParkMinPackages.Workflow.Default.Extensions.UILogics
{
	public static class MessageUIFlowExtensions
	{
		public static async UniTask ShowUntilConfirmedAsync<TView>(
			this TView view,
			CancellationToken cancellationToken
		) where TView : BasicUI, IMessageView, IConfirmView {
			if (view is IButtonConfirmView confirmView) {
				confirmView.ConfirmButton.gameObject.SetActive(true);
			}

			if (view is ILayoutRebuildable layoutRebuildable) {
				layoutRebuildable.RebuildLayout();
			}

			await view.UIActivator.ActiveAsync(cancellationToken: cancellationToken);
			try {
				await view.ConfirmAsync(cancellationToken);
			}
			finally {
				await view.UIActivator.DeActiveAsync(cancellationToken: CancellationToken.None);
			}
		}

		public static async UniTask ShowForDurationAsync<TView>(
			this TView view,
			TimeSpan duration,
			CancellationToken cancellationToken
		) where TView : BasicUI, IMessageView {
			if (view is IButtonConfirmView confirmView) {
				confirmView.ConfirmButton.gameObject.SetActive(false);
			}

			if (view is ILayoutRebuildable layoutRebuildable) {
				layoutRebuildable.RebuildLayout();
			}

			await view.UIActivator.ActiveAsync(cancellationToken: cancellationToken);
			try {
				await UniTask.Delay(
					duration,
					cancellationToken: cancellationToken,
					cancelImmediately: true
				);
			}
			finally {
				await view.UIActivator.DeActiveAsync(cancellationToken: CancellationToken.None);
			}
		}
	}
}
