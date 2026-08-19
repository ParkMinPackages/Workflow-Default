using ParkMinPackages.Foundation.Objects.Threading;
using ParkMinPackages.Workflow.Default.Interfaces;

namespace ParkMinPackages.Workflow.Default.Components.UIs
{
	public class ShowHideUI : BasicUI, IShowHideUI
	{
		public void Show() {
			IShowHideUI.ShowWithAnimation(this, _showHideCancellationTokenSource);
		}
		public void Hide() {
			IShowHideUI.HideWithAnimation(this, _showHideCancellationTokenSource);
		}

		protected override void OnDestroy() {
			_showHideCancellationTokenSource.Dispose();
			base.OnDestroy();
		}

		readonly AutoRenewCancellationTokenSource _showHideCancellationTokenSource = new AutoRenewCancellationTokenSource();
	}
}
