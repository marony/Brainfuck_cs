using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace BrainFuck
{
	/// <summary>
	/// App.xaml の相互作用ロジック
	/// </summary>
	public partial class App : Application
	{
		private void App_OnStartup(object sender, StartupEventArgs e)
		{
			AppDomain.CurrentDomain.UnhandledException += (object s, UnhandledExceptionEventArgs e2) =>
			{
				var inner = e2.ExceptionObject as Exception;
				while (inner != null)
				{
					MessageBox.Show(inner.ToString());
					inner = inner.InnerException;
				}
			};
		}

		private void App_OnDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
		{
			var inner = e.Exception;
			while (inner != null)
			{
				MessageBox.Show(inner.ToString());
				inner = inner.InnerException;
			}
			e.Handled = true;
		}
	}
}
