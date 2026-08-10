using System.Threading;
using Cysharp.Threading.Tasks;
using ParkMinPackages.Workflow.Default.Components.UIs;
using ParkMinPackages.Workflow.Default.Enums;
using ParkMinPackages.Workflow.Default.Interfaces;

namespace ParkMinPackages.Workflow.Default.Extensions.UILogics
{
	public static class YesOrNoUIFlowExtensions
	{
		public static async UniTask<YesOrNo> ShowUntilAnsweredAsync<TView>(
			this TView view,
			CancellationToken cancellationToken
		) where TView : BasicUI, IMessageView, IYesOrNoView {
			if (view is ILayoutRebuildable layoutRebuildable) {
				layoutRebuildable.RebuildLayout();
			}

			await view.UIActivator.ActiveAsync(cancellationToken: cancellationToken);
			try {
				return await view.WaitForAnswerAsync(cancellationToken);
			}
			finally {
				await view.UIActivator.DeActiveAsync(cancellationToken: CancellationToken.None);
			}
		}
	}
}
