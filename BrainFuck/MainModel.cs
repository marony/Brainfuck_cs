using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.TeamFoundation.Common.Internal;

namespace BrainFuck
{
	class MainModel
	{
		private const int BUFFER_SIZE = 30000;
		private int _pc;
		private int _ptr;
		private int _input;
		private List<char> _buffer;

		public string Execute(string code, string input)
		{
			// 初期化
			_pc = 0;
			_ptr = 0;
			_input = 0;
			_buffer = new List<char>();
			for (int i = 0; i < BUFFER_SIZE; ++i)
				_buffer.Add((char)0);
			var output = new StringBuilder();

			while (_pc < code.Length)
			{
				var inst = code[_pc];
				switch (inst)
				{
				case '>':
					++_ptr;
					break;
				case '<':
					--_ptr;
					break;
				case '+':
					_buffer[_ptr] = ++_buffer[_ptr];
					break;
				case '-':
					_buffer[_ptr] = --_buffer[_ptr];
					break;
				case '.':
					output.Append(_buffer[_ptr]);
					break;
				case ',':
					_buffer[_ptr] = input[_input++];
					break;
				case '[':
					if (_buffer[_ptr] == 0)
					{
						var nest = 0;
						++_pc;
						while (true)
						{
							if (code[_pc] == '[')
								++nest;
							else if (code[_pc] == ']')
							{
								if (nest == 0)
									break;
								--nest;
							}
							++_pc;
						}
					}
					break;
				case ']':
					if (_buffer[_ptr] != 0)
					{
						var nest = 0;
						--_pc;
						while (true)
						{
							if (code[_pc] == ']')
								++nest;
							else if (code[_pc] == '[')
							{
								if (nest == 0)
									break;
								--nest;
							}
							--_pc;
						}
					}
					break;
				}
				++_pc;
			}

			return output.ToString();
		}
	}
}
