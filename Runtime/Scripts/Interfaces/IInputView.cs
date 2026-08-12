using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using ParkMinPackages.Workflow.Default.Enums;
using UnityEngine.UI;

namespace ParkMinPackages.Workflow.Default.Interfaces
{
	public interface IInputView
	{
		public UniTask<(YesOrNo Answer, string Input)> InputAsync(
			CancellationToken cancellationToken
		);
	}

	public interface IInputFieldButtonYesOrNoView : IInputView, IButtonYesOrNoView
	{
		public InputField InputField { get; }

		public static async UniTask<(YesOrNo Answer, string Input)> InputAsync(
			IInputFieldButtonYesOrNoView view,
			CancellationToken cancellationToken
		) {
			if (cancellationToken == CancellationToken.None) {
				throw new ArgumentException("CancellationToken.None is not allowed", nameof(cancellationToken));
			}

			YesOrNo answer = await IButtonYesOrNoView.YesOrNoAsync(view, cancellationToken);
			return (answer, view.InputField.text);
		}
	}
}
