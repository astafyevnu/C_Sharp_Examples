// парсинг входной строки

// using System.Linq;

// string text = "(1,2) (2,3) (4,5) (5,6)";

// var data = text.Split(" ")
                
//                 .ToArray();

// for (int i = 0 ; i < data.Length; i++)
// {
//     Console.WriteLine(data[i]);
// }

// Технически вместо var мы можем прописать массив строк. Чтобы постоянно типы
// не менять, я оставлю var.

// Дальше моя задача — взять пару и на её основе получить точку с числами, а не со строками.
// Технически скобки для нас ничего не значат, поэтому я могу избавиться от них на первом этапе. Для
// этого я напишу метод Replace, где в качестве первого аргумента мы укажем открывающую скобку, а в
// качестве второго — на что её нужно заменить. В данном случае — на пробел. Затем делаем то же с
// закрывающей строкой. На выходе у нас будет строка без скобок. 

// using System.Linq;

// string text = "(1,2) (2,3) (4,5) (5,6)"
//                 .Replace("(", "")
//                 .Replace(")", "")
//                 ;

// var data = text.Split(" ")
                
//                 .ToArray();

// for (int i = 0 ; i < data.Length; i++)
// {
//     Console.WriteLine(data[i]);
// }

// Я укажу Select(item), и хочу его превратить, используя Split. Только теперь в качестве символаразделителя у меня запятая. 


// using System.Linq;

// string text = "(1,2) (2,3) (4,5) (6,7)"
//                 .Replace("(", "")
//                 .Replace(")", "")
//                 ;
// Console.WriteLine(text);
// var data = text.Split(" ")
//                 .Select(item => item.Split(','))
//                 .ToArray();

// for (int i = 0 ; i < data.Length; i++)
// {
//     Console.WriteLine(data[i]);
// }

// Сейчас мы наблюдаем просто массив data[i]. Проведу ещё раз внутренний цикл.

// using System.Linq;

// string text = "(1,2) (2,3) (4,5) (6,7)"
//                 .Replace("(", "")
//                 .Replace(")", "")
//                 ;
// Console.WriteLine(text);
// var data = text.Split(" ")
//                 .Select(item => item.Split(','))
//                 .ToArray();

// for (int i = 0 ; i < data.Length; i++)
// {
//     for (int k = 0 ; k < data[i].Length; k++)
//     {
//         Console.WriteLine(data[i][k]);
//     }
// }

// После того как мы получили массив координат, может сделать ещё одну выборку. Сказать: «Давайте
// мы текущий массив координат превратим в кортеж чисел». При этом мы будем сами делать разбор
// строки (мы помним, что у нас массив строк). Первый элемент массива нулевой, в качестве второго я
// буду передавать int.Parse(e1). 

// using System.Linq;

// string text = "(1,2) (2,3) (4,5) (6,7)"
//                 .Replace("(", "")
//                 .Replace(")", "")
//                 ;
// Console.WriteLine(text);
// Console.WriteLine();
// var data = text.Split(" ")
//                 .Select(item => item.Split(','))
//                 .Select(e => (int.Parse(e[0]), int.Parse(e[1])))
//                 .ToArray();

// // Теперь результатом уже будет не массив массивов, а массив кортежей. Поэтому внутренний цикл нам
// // не нужен, и мы возвращаем всё как было. 

// for (int i = 0 ; i < data.Length; i++) 
// {
//     Console.WriteLine(data[i]);
//     Console.WriteLine();
// //     for (int k = 0 ; k < data[i].Length; k++)
// //     {
// //         Console.WriteLine(data[i][k]);
// //     }
// }



// Круглые скобки остались, но теперь это уже числа. То есть в момент вывода я могу написать
// Console.WriteLine(data[i].Item1), что даёт нам первую координату, и, соответственно, умножить её,
// например, на 10. 

// using System.Linq;

// string text = "(1,2) (2,3) (4,5) (6,7)"
//                 .Replace("(", "")
//                 .Replace(")", "")
//                 ;
// Console.WriteLine(text);
// Console.WriteLine();
// var data = text.Split(" ")
//                 .Select(item => item.Split(','))
//                 .Select(e => (int.Parse(e[0]), int.Parse(e[1])))
//                 .ToArray();

// for (int i = 0 ; i < data.Length; i++) 
// {
//     Console.WriteLine(data[i].Item1*10);
//     Console.WriteLine();
// }

// Обратите внимание: в коде у нас сейчас какой-то Item1. Что это — непонятно. Поэтому мы можем
// сказать, пусть int.Parse(e[0]) будет координатой X, а int.Parse(e[1]) — координатой Y:

// using System.Linq;

// string text = "(1,2) (2,3) (4,5) (6,7)"
//                 .Replace("(", "")
//                 .Replace(")", "")
//                 ;
// Console.WriteLine(text);
// Console.WriteLine();
// var data = text.Split(" ")
//                 .Select(item => item.Split(','))
//                 .Select(e => (x: int.Parse(e[0]), y: int.Parse(e[1])))
//                 .ToArray();

// for (int i = 0 ; i < data.Length; i++) 
// {
//     Console.WriteLine(data[i].x*10);
//     Console.WriteLine();
// }

// Можно ли как-то сделать по-другому? Технически, если нам нужно один раз и навсегда сделать
// увеличение этих координат, мы снова можем сделать выборку и дальше сказать: «У нас есть точка
// (point), и мы хотим превратить её во что-то новое». В данном случае это будет point.x, которая
// умножается на 10. А в качестве второго элемента кортежа будет point.у. То есть мы превращаем нашу
// точку с учётом этих вновь появившихся дополнений. 


// using System.Linq;

// string text = "(1,2) (2,3) (4,5) (6,7)"
//                 .Replace("(", "")
//                 .Replace(")", "")
//                 ;
// Console.WriteLine(text);
// Console.WriteLine();
// var data = text.Split(" ")
//                 .Select(item => item.Split(','))
//                 .Select(e => (x: int.Parse(e[0]), y: int.Parse(e[1])))
//                 .Select(point => (point.x * 10, point.y))
//                 .ToArray();

// for (int i = 0 ; i < data.Length; i++) 
// {
//     Console.WriteLine(data[i]);
//     Console.WriteLine();
// }

// D:\Lessons\Examples\lesson6\Program.cs(179,31): error CS1061: "(int, int y)" не содержит определения "x", и не удалось найти доступный метод расширения "x", принимающий тип "(int, int y)" в
//  качестве первого аргумента (возможно, пропущена директива using или ссылка на сборку). [D:\Lessons\Examples\lesson6\lesson6.csproj]

// Ошибка сборки. Устраните ошибки сборки и повторите попытку.



// Дальше — больше. Если вам нужно произвести какую-то выборку, прежде чем делать домножение, вы
// можете сказать: «А давайте мы соберём или получим только те точки, для которых первая координата
// делится на 2 (то есть координата чётная). Хочу, чтобы выполнялось такое условие. 

using System.Linq;

string text = "(1,2) (2,3) (4,5) (6,7)"
                .Replace("(", "")
                .Replace(")", "")
                ;
Console.WriteLine(text);
Console.WriteLine();
var data = text.Split(" ")
                .Select(item => item.Split(','))
                .Select(e => (x: int.Parse(e[0]), y: int.Parse(e[1])))
                .Where(e=>e.x % 2 == 0)
                .Select(point => (point.x * 10, point.y))
                .ToArray();

for (int i = 0 ; i < data.Length; i++) 
{
    Console.WriteLine(data[i]);
    Console.WriteLine();
}

