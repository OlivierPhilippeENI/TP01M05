using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BO;

namespace TP01M05.Util
{
    public class Persistance
    {
        private static Persistance _instance;
        static readonly object instanceLock = new object();

        public static Persistance Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (instanceLock)
                    {
                        if (_instance == null)
                            _instance = new Persistance();
                    }
                }
                return _instance;
            }
        }

        private List<Pizza> pizzas;
        private List<Ingredient> ingredients;
        private List<Pate> pates;

        public List<Pizza> Pizzas
        {
            get { return pizzas; }
        }

        public List<Ingredient> Ingredients
        {
            get { return ingredients; }
        }

        public List<Pate> Pates
        {
            get { return pates; }
        }

        private Persistance()
        {
            ingredients = BO.Pizza.IngredientsDisponibles;
            pates = BO.Pizza.PatesDisponibles;
            pizzas = getPizza();
        }

        public List<Pizza> getPizza(){
            return new List<Pizza> {
                new Pizza{Id = 1, Nom = "Margaritaaaaa", Pate = pates[2], Ingredients = new List<Ingredient>{ ingredients[0], ingredients[2], ingredients[6]} }
            };
        }
    }
}