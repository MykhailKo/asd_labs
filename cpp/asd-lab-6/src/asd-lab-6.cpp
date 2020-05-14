#include <iostream>
#include "MyCalc.h"
using namespace std;

int main() {
	MyCalc *c1, *c2, *c3, *c4;
	try {
		c1 = new MyCalc(2, 3, 4);
		//c1->setArgC(-1);
		//c2 = new MyCalc(0, 1, 5);
		//c3 = new MyCalc(1, 1, -2);
		//c2 = new MyCalc(1, 1, 0);
	}catch(int i){
		if(i == 1) cout << "The sum of a and c in denominator must be different from 1 to avoid division by 0!" << endl;
		if(i == 2) cout << "Argument d cannot be 0 to avoid division by 0!" << endl;
	}catch(double i){
		cout << "A number under the square root must be bigger than 0, d must be bigger than 0!" << endl;
	}
	return 0;
}
