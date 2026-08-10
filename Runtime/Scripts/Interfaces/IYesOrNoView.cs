using System.Threading;
using Cysharp.Threading.Tasks;
using ParkMinPackages.Workflow.Default.Enums;
using UnityEngine.UI;

namespace ParkMinPackages.Workflow.Default.Interfaces
{
	public interface IYesOrNoView
	{
		UniTask<YesOrNo> WaitForAnswerAsync(
			CancellationToken cancellationToken
		);
	}

	public interface IButtonYesOrNoView : IYesOrNoView
	{
		Button YesButton { get; }
		Button NoButton { get; }
	}

	public static class ButtonYesOrNoViewExtensions
	{
		public static async UniTask<YesOrNo> WaitForAnswerByButtonAsync(
			this IButtonYesOrNoView view,
			CancellationToken cancellationToken
		) {
			using CancellationTokenSource buttonCts =
				CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
			int buttonIndex = await UniTask.WhenAny(
				view.YesButton.OnClickAsync(buttonCts.Token),
				view.NoButton.OnClickAsync(buttonCts.Token)
			);
			buttonCts.Cancel();
			return buttonIndex == 0 ? YesOrNo.Yes : YesOrNo.No;
		}
	}
}
