//-------------------------------------------------------------------------
// <copyright file="Recipe.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
//-------------------------------------------------------------------------

using System;
using System.Collections;

namespace Full_GRASP_And_SOLID.Library
{
    public class Recipe
    {
        private ArrayList steps = new ArrayList();

        public Product FinalProduct { get; set; }

        public void AddStep(Step step)
        {
            this.steps.Add(step);
        }

        public void RemoveStep(Step step)
        {
            this.steps.Remove(step);
        }

        // RESPUESTA 2)
        // Aplico el principio Expert ya que la clase Recipe posee toda la información necesaria
        // utilizar el método GetProductionCost() 
        public double GetProductionCost()
        {
            double costProducts = 0;
            double costEquipment = 0;

            foreach (Step st in steps)
            {
                costProducts += (st.Input.UnitCost * st.Quantity);
                costEquipment += (st.Equipment.HourlyCost * st.Time);
            }
            return (costEquipment + costProducts);
        }

        public void PrintRecipe()
        {
            Console.WriteLine($"Receta de {this.FinalProduct.Description}:");
            foreach (Step step in this.steps)
            {
                Console.WriteLine($"{step.Quantity} de '{step.Input.Description}' " +
                    $"usando '{step.Equipment.Description}' durante {step.Time}");
            }
            Console.WriteLine($"Costo total de producción: ${GetProductionCost()}");
        }
    }
}