using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.TeamFoundation.MVVM;

namespace BrainFuck
{
	class MyViewModelBase : ViewModelBase
	{
		/// <summary>
		/// プロパティ変更通知
		/// </summary>
		/// <param name="propertyName"></param>
		protected override void RaisePropertyChanged([CallerMemberName] string propertyName = "")
		{
			base.RaisePropertyChanged(propertyName);
		}
	}
}
