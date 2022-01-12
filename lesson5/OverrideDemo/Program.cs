using OverrideDemo;

RationalNumber number1 = new(3, 4);
RationalNumber number2 = new(11, 8);
Console.WriteLine((number1 + number2).ToString());

float f = number1;
int i = number2;
Console.WriteLine(f);
Console.WriteLine(i);

ComplexNumber? complex1 = null;
ComplexNumber? complex2 = null;
ComplexNumber complex3 = new ComplexNumber(11, 1112);
Console.WriteLine(complex3);
Console.WriteLine(complex1 == complex2);
Console.WriteLine(complex1 == complex3);
complex1 = new ComplexNumber(11, 12);
Console.WriteLine(complex1.Equals(complex2));
Console.WriteLine(complex1.Equals(complex3));
