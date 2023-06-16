using System;
namespace HackFest
{
	public class Rectangulo
	{
		public Rectangulo(string coordenadas)
		{
			var temp = coordenadas.Split(",");
			if (temp.Length != 4)
			{
				var error = 0;
			}
			x0 = int.Parse(temp[0]);
			y0 = int.Parse(temp[1]);
			x1 = int.Parse(temp[2]);
			y1 = int.Parse(temp[3]);
			domainX = CalcularDominios(x0, x1);
			domainY = CalcularDominios(y0, y1);
			area = (x1-x0) * (y1-y0);
        }

		int x0 = 0;
		int x1 = 0;
		int y0 = 0;
		int y1 = 0;
		public int area = 0;

        List<int> domainX;
		List<int> domainY;

		public List<int> CalcularDominios(int n0, int n1)
		{
			var temp = new List<int>();
			for (int i = n0; i <= n1; i++)
			{
				temp.Add(i);
			}
			return temp;
		}

		public bool validarColision(Rectangulo externo)
		{
			var queryX = queryDominios_X(externo);
			var queryY = queryDominios_Y(externo);

            if (queryX.Count() > 0 && queryY.Count() > 0)
			{
				//hay colisiones
				return true;
			}
           
            return false;
			//return true;
		}

        
        public List<int> queryDominios_X(Rectangulo externo)
		{
			return (from x_this in domainX
					join x_ext in externo.domainX on x_this equals x_ext
					select x_ext).ToList();

        }

        public List<int> queryDominios_Y(Rectangulo externo)
        {
             var query = (from y_this in domainY
                    join y_ext in externo.domainY on y_this equals y_ext
                    select y_ext).ToList();
			return query;
        }


		public int CalcularDisyuncion(Rectangulo externo)
		{
            var queryX = queryDominios_X(externo);
            var queryY = queryDominios_Y(externo);

			return (queryX.Count()-1) * (queryY.Count()-1);
            //var disyuncion = query.Count() * this.
        }
	}
}

