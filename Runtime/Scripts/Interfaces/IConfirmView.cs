using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine.UI;

namespace ParkMinPackages.Workflow.Default.Interfaces
{
	public interface IConfirmView
	{
		public UniTask ConfirmAsync(CancellationToken cancellationToken);

		public static UniTask ConfirmAsyncByButton(
			Button confirmButton,
			CancellationToken cancellationToken
		) {
			if (cancellationToken == CancellationToken.None) {
				throw new ArgumentException("CancellationToken.None is not allowed", nameof(cancellationToken));
			}

			return confirmButton.OnClickAsync(cancellationToken);
		}
	}
}