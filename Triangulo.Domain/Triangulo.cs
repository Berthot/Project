using System.Collections.Generic;
using System.Linq;

namespace Triangulo.Domain
{
    public class Triangulo
    {
        private int _index = 0;

        /// <summary>
        ///    6
        ///   3 5
        ///  9 7 1
        /// 4 6 8 4
        /// Um elemento somente pode ser somado com um dos dois elementos da próxima linha.
        /// Como o elemento 5 na Linha 2 pode ser somado com 7 e 1, mas não com o 9.
        /// Neste triangulo o total máximo é 6 + 5 + 7 + 8 = 26
        /// 
        /// Seu código deverá receber uma matriz (multidimensional) como entrada.
        /// O triângulo acima seria: [[6],[3,5],[9,7,1],[4,6,8,4]]
        /// </summary>
        /// <param name="data"></param>
        /// <returns>Retorna o resultado do calculo conforme regra acima</returns>
        public int TriangleResult(string data)
        {
            var list = ConvertStringToArray(data);
            var acc = list[0][0] + list.Skip(1).Sum(Greater);
            _index = 0;
            return acc;
        }

        private int Greater(List<int> value)
        {
            if (value[_index] >= value[_index + 1])
                return value[_index];

            _index++;
            return value[_index];
        }

        private static List<List<int>> ConvertStringToArray(string input)
        {
            var array = input.Replace("]", "").Split("[");
            var list = new List<List<int>>();

            foreach (var s in array.Where(u => !string.IsNullOrEmpty(u)))
            {
                var newList = s.Split(",").Where(s1 => !string.IsNullOrEmpty(s1)).Select(int.Parse).ToList();
                list.Add(newList);
            }

            return list;
        }
    }
}