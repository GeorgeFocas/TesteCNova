using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;



namespace ProgrammingFellowLocator.Core
{
    public class Fellow
    {
        public string Name { get; set; }
        public Point Position { get; set; }

        public double RelativeDistance { get; set; }

        public void CalculateRelativeDistance(Point anotherFellowPosition)
        {
            //ESSA É A FÓRMULA PARA CALCULAR A DISTÂNCIA ENTRE DOIS PONTOS NUM PLANO CARTESIANO
            double distanceFromAnotherFellow = Math.Sqrt(Math.Pow((anotherFellowPosition.X - Position.X), 2) + Math.Pow((anotherFellowPosition.Y - Position.Y), 2));
            RelativeDistance = distanceFromAnotherFellow;
        }
    }
}
