#include "Stringy.h"
#include <string.h>
#include <ctype.h>


Stringy::Stringy(char* s) {
	_symbols = s;
}

Stringy::~Stringy() {
	_symbols = nullptr;
	delete[] _symbols;
}

int Stringy::getLength() {
	return strlen(_symbols);
}

int Stringy::getDigits(){
	int digitsNum = 0;
	for(int i = 0; i < strlen(_symbols); i++){
		if(isdigit(_symbols[i])) digitsNum++;
	}
	return digitsNum;
}

char* Stringy::getSymbols(){
	return _symbols;
}
