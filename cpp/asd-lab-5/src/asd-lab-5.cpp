#include <iostream>
#include "MyString.h"
#include "LetterString.h"
#include "Figure.h"
#include "Circle.h"
#include "Ellipse.h"
using namespace std;

int main() {

	LetterString ms1("ahc1n3");

	cout << ms1.getValue() << endl;
	cout << ms1.sortAlphabetical() << endl;

	Figure *f1, *f2;
	f1 = new Ellipse(2, 3);
	f2 = new Circle(2);

	cout << f1->getArea() << endl;
	cout << f1->getPerimeter() << endl;
	cout << f2 ->getArea() << endl;
	cout << f2->getPerimeter() << endl;
	return 0;
}
