#include <iostream>
#include "MyString.h"
using namespace std;

int main() {
	MyString ms1("456");
	MyString ms2("457");
	MyString ms3;


	ms2 = ms2 - '5';

	ms3 = ms1 + ms2;

	cout << ms1.getValue() << endl;
	cout << ms2.getValue() << endl;
	cout << ms3.getValue() << endl;
	return 0;
}
