#include "LetterString.h"
#include <string.h>
#include <ctype.h>
#include <algorithm>


LetterString::LetterString(): MyString::MyString() {}
LetterString::LetterString(char * str): MyString::MyString(str){}

LetterString::~LetterString() {}

int LetterString::getLength(){
	return strlen(_string);
}

string LetterString::getValue(){
	return _string;
}

string LetterString::sortAlphabetical(){
	char tempStr [getLength()];
	for(int i = 0; i < getLength(); i++){
		tempStr[i] = _string[i];
	}
	sort(tempStr, tempStr + getLength());
	return tempStr;
}

