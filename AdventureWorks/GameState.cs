using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks
{
    class GameState
    {
        public enum State { map, intro};
        State currentState;

        public GameState()
        {
            currentState = State.map;
        }

        public State GetState()
        {
            return currentState;
        }

        public void SetState(State state)
        {
            currentState = state;
        }
    }
}
