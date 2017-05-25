using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace AdventureWorks
{
    class GameObject
    {
        String Name;
        Tile ActiveTile;
        enum Action { Open, Close };
        public bool isPassable { get; set; }

		public GameObject(String Name)
		{
			this.Name = Name;
			isPassable = true;
		}

		public GameObject(String Name, Tile ActiveTile)
        {
            this.Name = Name;
            this.ActiveTile = ActiveTile;
            isPassable = true;
        }

        public GameObject(String Name, Tile ActiveTile, bool isPassable)
        {
            this.Name = Name;
            this.ActiveTile = ActiveTile;
            this.isPassable = isPassable;
        }

        public virtual void Draw(SpriteBatch spriteBatch, Vector2 position){}

		public virtual string TakeAction(Actions.possibleActions actionToPerform) { return ""; }
		public virtual List<Actions> GetPossibleActions() { return new List<Actions>(); }

	}

    class Door : GameObject
    {
        bool isOpen { get; set; }
		bool isLocked;
		Tile openDoorTile;
		Tile closedDoorTile;

		public Door(String Name, Tile openDoorTile, Tile closedDoorTile, bool isOpen) : base(Name)
        {
			this.openDoorTile = openDoorTile;
			this.closedDoorTile = closedDoorTile;
            this.isOpen = isOpen;
			this.isPassable = isOpen;
        }

        public override void Draw(SpriteBatch spriteBatch, Vector2 position)
		{
			if(isOpen)
			{
				openDoorTile.Draw(spriteBatch, position);
			} else
			{
				closedDoorTile.Draw(spriteBatch, position);
			}
		}

		public override string ToString()
		{
			return "This is a door.";
		}

		public override List<Actions> GetPossibleActions()
		{
			List<Actions> thisDoorActions = new List<Actions>();
			if (isOpen)
			{
				thisDoorActions.Add(new Actions(Actions.possibleActions.close, "This is an open door, To Close it press: "));
			}
			else
			{
				thisDoorActions.Add(new Actions(Actions.possibleActions.open, "This is an closed door, To open it press: "));
			}

			if(isLocked)
			{
				thisDoorActions.Add(new Actions(Actions.possibleActions.unlockLock, "To unLock the door press: "));
			} else
			{
				thisDoorActions.Add(new Actions(Actions.possibleActions.lockLock, "To Lock the door press: "));
			}


			return thisDoorActions;
		}

		public override string TakeAction(Actions.possibleActions actionToPerform)
		{
			switch (actionToPerform)
			{
				case Actions.possibleActions.open:
					if (isLocked)
					{
						return "The door is locked and will not open";
					}
					else
					{
						isOpen = true;
						isPassable = true;
						return "You've opened the door";
					}
					break;
				case Actions.possibleActions.close:
					isOpen = false;
					isPassable = false;
					return "You've closed the door";
					break;
				case Actions.possibleActions.lockLock:
					isLocked = true;
					return "You've locked the door";
					break;
				case Actions.possibleActions.unlockLock:
					isLocked = false;
					return "You've unlocked the door";
					break;

			}
			return "";
		}
	}

    class ObjectStack
    {
        ArrayList Stack;

        public ObjectStack()
        {
            Stack = new ArrayList();
        }

        public void AddToStack(GameObject newObject)
        {
            Stack.Add(newObject);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            foreach (GameObject gameObject in Stack)
            {
                gameObject.Draw(spriteBatch, position);
            }
        }
    }
}
