using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using TP01M05.Util;
using BO;
using TP01M05.Models;

namespace TP01M05.Controllers
{
    public class PizzaController : Controller
    {
        // GET: Pizza
        public ActionResult Index()
        {
            return View(Persistance.Instance.Pizzas);
        }

        // GET: Pizza/Create
        public ActionResult Create()
        {
            PizzaCreateViewModel vm = new PizzaCreateViewModel();

            for (int nbIngredient = 0; nbIngredient < Persistance.Instance.Ingredients.Count-1; nbIngredient++) { 
                vm.Ingredients.Add(new SelectListItem { Value = Persistance.Instance.Ingredients[nbIngredient].Id.ToString(), Text = Persistance.Instance.Ingredients[nbIngredient].Nom });
             }

            for (int nbPate = 0; nbPate < Persistance.Instance.Pates.Count - 1; nbPate++) {
                vm.Pates.Add(new SelectListItem { Value = Persistance.Instance.Pates[nbPate].Id.ToString(), Text = Persistance.Instance.Pates[nbPate].Nom });
            }

            return View(vm);
        }

        [HttpPost]
        public ActionResult Create(PizzaCreateViewModel vm)
        {
            try
            {
                //vm.Pizza.Ingredients =  
                //FakeDbCat.Instance.Chats.Add(vm.Chat);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return View();
            }


        }

        // GET: Pizza/Edit/5
        public ActionResult Edit(int id)
        {
            PizzaCreateViewModel vm = new PizzaCreateViewModel();

            for (int nbIngredient = 0; nbIngredient < Persistance.Instance.Ingredients.Count - 1; nbIngredient++)
            {
                vm.Ingredients.Add(new SelectListItem { Value = Persistance.Instance.Ingredients[nbIngredient].Id.ToString(), Text = Persistance.Instance.Ingredients[nbIngredient].Nom });
            }

            for (int nbPate = 0; nbPate < Persistance.Instance.Pates.Count - 1; nbPate++)
            {
                vm.Pates.Add(new SelectListItem { Value = Persistance.Instance.Pates[nbPate].Id.ToString(), Text = Persistance.Instance.Pates[nbPate].Nom });
            }

            return View(vm);
        }

        // POST: Pizza/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Pizza/Delete/5
        public ActionResult Delete(int id)
        {
            Pizza pizza = Persistance.Instance.Pizzas.FirstOrDefault(x => x.Id == id);
            if (pizza != null)
            {
                return View(pizza);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        // POST: Pizza/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                Pizza pizza = Persistance.Instance.Pizzas.FirstOrDefault(x => x.Id == id);
                Persistance.Instance.Pizzas.Remove(pizza);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
