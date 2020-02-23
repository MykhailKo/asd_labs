#include <iostream>
#include "Stringy.h"
#include "Texty.h"


using namespace std;

int main() {
	char* s[] = {"string123", "string2334", "string548d83c4"};

	Stringy s1(s[0]);
	Stringy s2(s[1]);
	Stringy s3(s[2]);

	Stringy strings[] = {s1, s2, s3};

	Texty text(strings, 3);

	char* l = text.getLongestString();
	cout << l << endl << endl;

	for(int i = 0; i < text.size; i++){
		cout << text.strings[i].symbols << endl;
	}
	cout << endl;

	text.deleteString(2);
	for(int i = 0; i < text.size; i++){
		cout << text.strings[i].symbols << endl;
	}

	cout << text.getLength() << endl;
	cout << text.getDigitsPercentage() << endl;
	return 0;
}

