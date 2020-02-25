using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DataSystem
{
    [System.Serializable]
    public class Data
    {
        public List<Acount> acounts;

        public Data()
        {
            this.acounts = new List<Acount>();
        }

        public Acount GetAcount(string name)
        {
            foreach (var acount in acounts)
            {
                if(acount.name.Equals(name))
                {
                    return acount;
                }
            }
            return null;
        }
    }

    [System.Serializable]
    public class Acount
    {
        public string name;
        public string password;
        public Player player;

        public Acount(string name, string password)
        {
            this.name = name;
            this.password = password;
            this.player = new Player();
        }
    }

    [System.Serializable]
    public class Player
    {
        public List<Slime> slimes;
        public List<Item> items;

        public Player()
        {
            this.slimes = new List<Slime>();
            this.items = new List<Item>();
        }
    }

    [System.Serializable]
    public class Slime
    {
        public string name;
        public int life;
        public int maxLife;
        public float weight;

        public string mainType;
        public string secondType;

        public Slime(string name, int life, int maxLife, float weight, string mainType, string secondType = null)
        {
            this.name = name;
            this.life = life;
            this.maxLife = maxLife;
            this.weight = weight;
            this.mainType = mainType;
            this.secondType = secondType;
        }
    }

    [System.Serializable]
    public class Item
    {
        public string name;
        public int amount;

        public Item(string name, int amount)
        {
            this.name = name;
            this.amount = amount;
        }
    }
}