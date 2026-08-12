using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine.UI;

namespace ParkMinPackages.Workflow.Default.Interfaces
{
	public interface IConfirmView
	{
		public UniTask ConfirmAsync(CancellationToken cancellationToken);
	}

	public interface IButtonConfirmView : IConfirmView
	{
		public Button ConfirmButton { get; }

		public static UniTask ConfirmAsync(
			IButtonConfirmView view,
			CancellationToken cancellationToken
		) {
			if (cancellationToken == CancellationToken.None) {
				throw new ArgumentException("CancellationToken.None is not allowed", nameof(cancellationToken));
			}

			return view.ConfirmButton.OnClickAsync(cancellationToken);
		}
	}
}
