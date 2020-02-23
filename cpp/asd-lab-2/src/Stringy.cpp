#include "Stringy.h"
#include <string.h>
#include <ctype.h>


Stringy::Stringy(char* s) {
	symbols = s;
}

Stringy::~Stringy() {
	symbols = nullptr;
	delete[] symbols;
}

int Stringy::getLength() {
	return strlen(symbols);
}

int Stringy::getDigits(){
	int digitsNum = 0;
	for(int i = 0; i < strlen(symbols); i++){
		if(isdigit(symbols[i])) digitsNum++;
	}
	return digitsNum;
}

