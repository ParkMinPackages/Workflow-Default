using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using ParkMinPackages.Workflow.Default.Components.UIs;
using ParkMinPackages.Workflow.Default.Enums;
using ParkMinPackages.Workflow.Default.Interfaces;

namespace ParkMinPackages.Workflow.Default.Extensions.UILogics
{
	public static class UIFlowExtensions
	{
		public static async UniTask ShowForDurationAsync<TView>(
			this TView view,
			TimeSpan duration,
			CancellationToken cancellationToken
		) where TView : BasicUI {
			await view.UIActivator.ActiveAsync(cancellationToken: cancellationToken);
			await UniTask.Delay(duration, cancellationToken: cancellationToken, cancelImmediately: true);
			await view.UIActivator.DeactivateAsync(cancellationToken: cancellationToken);
		}

		public static async UniTask ShowUntilConfirmedAsync<TView>(
			this TView view,
			CancellationToken cancellationToken
		) where TView : BasicUI, IConfirmView {
			await view.UIActivator.ActiveAsync(cancellationToken: cancellationToken);
			try {
				await view.ConfirmAsync(cancellationToken);
			}
			finally {
				await view.UIActivator.DeactivateAsync(cancellationToken: CancellationToken.None);
			}
		}

		public static async UniTask<YesOrNo> ShowUntilAnsweredAsync<TView>(
			this TView view,
			CancellationToken cancellationToken
		) where TView : BasicUI, IYesOrNoView {
			await view.UIActivator.ActiveAsync(cancellationToken: cancellationToken);
			try {
				return await view.YesOrNoAsync(cancellationToken);
			}
			finally {
				await view.UIActivator.DeactivateAsync(cancellationToken: CancellationToken.None);
			}
		}
	}
}