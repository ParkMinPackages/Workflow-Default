using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine.UI;

namespace ParkMinPackages.Workflow.Default.Interfaces
{
	public interface IConfirmView
	{
		UniTask ConfirmAsync(CancellationToken cancellationToken);
	}

	public interface IButtonConfirmView : IConfirmView
	{
		Button ConfirmButton { get; }
	}

	public static class ButtonConfirmViewExtensions
	{
		public static UniTask ConfirmByButtonAsync(
			this IButtonConfirmView view,
			CancellationToken cancellationToken
		) {
			return view.ConfirmButton.OnClickAsync(cancellationToken);
		}
	}
}
