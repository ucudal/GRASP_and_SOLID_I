//-------------------------------------------------------------------------------
// <copyright file="Step.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
//-------------------------------------------------------------------------------

namespace Full_GRASP_And_SOLID.Library
{
    public class Step
    {
        public Step(Product input, double quantity, Equipment equipment, int time)
        {
            this.Quantity = quantity;
            this.Input = input;
            this.Time = time;
            this.Equipment = equipment;
        }

        public Product Input { get; set; }

        public double Quantity { get; set; }

        public int Time { get; set; }

        public Equipment Equipment { get; set; }

        /// <summary>
        /// Se utilizan el patrón Expert y el principio SRP ya que es la propia clase Step la que cumple con la función de 
        /// saber su costo, lo que hace del código más fácil de extender y más robusto a las modificaciones.
        /// </summary>
        /// <returns></returns>
        public double StepCost()
        {
            double supplyCost = 0;
            double equipmentCost = 0;
            double totalCost = 0;

            supplyCost = Input.UnitCost * Quantity;
            equipmentCost = Equipment.HourlyCost * Time;
            totalCost = supplyCost * equipmentCost;

            return totalCost;
        }
    }
}