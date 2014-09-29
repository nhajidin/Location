using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Reactive.Linq;

namespace Location
{
	public class MainViewModel : ReactiveObject
	{
		public MainViewModel()
		{
			Scan = ReactiveCommand.CreateAsyncObservable(
				_ => Observable.Start(() =>
					{
						var list = new List<string>();

						return list;
                    }, RxApp.TaskpoolScheduler));

			Scan.Subscribe(list =>
				{
					CellTowers.Clear();
					CellTowers.AddRange(list);
				});

			CellTowers = new ReactiveList<string>();
		}

		public ReactiveCommand<List<string>> Scan  { get; private set; }

		public ReactiveList<string> CellTowers { get; private set; }
	}
}
