using UnityEngine;
using System.Collections;

public class Room
   {
        Room top= null;
        Room bot = null;
        Room left = null;
        Room right = null;
        int depth = 0;
        public void addRandomRoom(int maximum)
        {
            if (isHereMustBeRoom(depth + 1, maximum))
                top = new Room(depth + 1,maximum);
            if (isHereMustBeRoom(depth + 1, maximum))
                bot = new Room(depth + 1,maximum);
            if (isHereMustBeRoom(depth + 1, maximum))
                left = new Room(depth + 1,maximum);
            if (isHereMustBeRoom(depth + 1, maximum))
                right = new Room(depth + 1,maximum);
        }

        public Room(int _depth)
        {
            this.depth = _depth;    
        }

        public Room(int _depth, int maximum)
        {
            this.depth = _depth;
            addRandomRoom(maximum);
        }

        public bool isHereMustBeRoom(float depth, float maximum)
        { 
            float k = (maximum - depth)/maximum;
            if (Random.Range(0,1)<k)
                return true;
            return false;
        }

   }
