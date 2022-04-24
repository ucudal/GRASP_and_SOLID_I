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

        /// <summary>
        /// Nuevamente se cumplen el patrón Expert y el principio SRP, ya que recipe tiene la responsabilidad de llevar a cabo
        /// los steps, de modo que también debe calcular el precio final.
        /// </summary>
        /// <returns></returns>
        public double GetProductionCost()
        {
            double totalCost = 0;
            foreach (Step step in this.steps)
            {
                totalCost += step.StepCost();
            }
            return totalCost;
        }

        public void PrintRecipe()
        {
            Console.WriteLine($"Receta de {this.FinalProduct.Description}:");
            foreach (Step step in this.steps)
            {   
                Console.WriteLine($"{step.Quantity} de '{step.Input.Description}' " +
                    $"usando '{step.Equipment.Description}' durante {step.Time}.");
            }
            Console.WriteLine($"El costo total fue de {this.GetProductionCost()}");
        }
    }
}