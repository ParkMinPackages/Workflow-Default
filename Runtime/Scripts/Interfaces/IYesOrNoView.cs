using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using ParkMinPackages.Workflow.Default.Enums;
using UnityEngine.UI;

namespace ParkMinPackages.Workflow.Default.Interfaces
{
	public interface IYesOrNoView
	{
		public UniTask<YesOrNo> YesOrNoAsync(CancellationToken cancellationToken);

		public static async UniTask<YesOrNo> YesOrNoAsyncByButtons(
			Button yesButton,
			Button noButton,
			CancellationToken cancellationToken
		) {
			if (cancellationToken == CancellationToken.None) {
				throw new ArgumentException("CancellationToken.None is not allowed", nameof(cancellationToken));
			}

			int buttonIndex = await UniTask.WhenAny(
				yesButton.OnClickAsync(cancellationToken),
				noButton.OnClickAsync(cancellationToken)
			);
			return buttonIndex == 0 ? YesOrNo.Yes : YesOrNo.No;
		}
	}
}