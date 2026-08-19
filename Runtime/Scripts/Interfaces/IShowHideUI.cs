using Cysharp.Threading.Tasks;
using ParkMinPackages.Foundation.Objects.Threading;
using ParkMinPackages.Workflow.Default.Components.UIs;

namespace ParkMinPackages.Workflow.Default.Interfaces
{
	public interface IShowHideUI
	{
		public void Show();
		public void Hide();

		public static void ShowWithAnimation(
			BasicUI basicUI,
			AutoRenewCancellationTokenSource autoRenewCancellationTokenSource
		) {
			basicUI.UIActivator.ActiveAsync(autoRenewCancellationTokenSource.CancelPreviousAndCreateToken()).Forget();
		}
		public static void HideWithAnimation(
			BasicUI basicUI,
			AutoRenewCancellationTokenSource autoRenewCancellationTokenSource
		) {
			basicUI.UIActivator.DeactivateAsync(autoRenewCancellationTokenSource.CancelPreviousAndCreateToken()).Forget();
		}
	}
}