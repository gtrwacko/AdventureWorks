using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks
{
	class Actions
	{
		public enum possibleActions {open,close,lockLock,unlockLock}

		public possibleActions setOfActions;
		public int id;
		public string text;

		public Actions()
		{

		}

		public Actions(possibleActions setOfActions, string text)
		{
			this.text = text;
			this.setOfActions = setOfActions;
		}
	}
}
