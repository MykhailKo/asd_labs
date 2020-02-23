#include "Stringy.h"
#include "Texty.h"
#include <iostream>


Texty::Texty(Stringy* s, int si) {
	size = si;
	strings = s;
	for(int i = 0; i < size; i++){
		length += strings[i].getLength();
		digits += strings[i].getDigits();
	}
}

Texty::~Texty() {
	strings = nullptr;
	delete[] strings;
	size = 0;
}

char* Texty::getLongestString(){
	int longest = 0;
	for(int i = 0; i < size; i++){
		if(strings[i].getLength() > strings[longest].getLength()) longest = i;
	}
	return strings[longest].symbols;
}

bool Texty::deleteString(int index){
	if(index > size - 1){
		return 0;
	}else{
		for(int i = index; i < size; i++){
			strings[i] = strings[i + 1];
		}
		size -= 1;
		return 1;
	}
}

int Texty::getLength(){
	return length;
}
double Texty::getDigitsPercentage(){
	return digits * 100 / length;
}



