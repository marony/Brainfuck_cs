using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.TeamFoundation.MVVM;

namespace BrainFuck
{
	class MainViewModel : MyViewModelBase
	{
		private MainModel _model = new MainModel();

		private string _code = @"+++++++++[>++++++++>+++++++++++>+++++<<<-]>.>++.+++++++..+++.>-.------------.<++++++++.--------.+++.------.--------.>+.";
		public string Code
		{
			get { return _code; }
			set
			{
				_code = value;
				RaisePropertyChanged();
			}
		}
		private string _input = "";
		public string Input
		{
			get { return _input; }
			set
			{
				_input = value;
				RaisePropertyChanged();
			}
		}
		private string _output = "";
		public string Output
		{
			get { return _output; }
			set
			{
				_output = value;
				RaisePropertyChanged();
			}
		}

		private RelayCommand _executeCommand = null;
		public ICommand ExecuteCommand
		{
			get
			{
				if (_executeCommand == null)
				{
					_executeCommand = new RelayCommand(Execute);
				}
				return _executeCommand;
			}
		}
		private void Execute(object o)
		{
			Output = _model.Execute(Code, Input);
		}
	}
}
